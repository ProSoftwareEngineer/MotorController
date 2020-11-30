#include <DualVNH5019MotorShield.h>
#define ENCODEROUTPUT2 24
#define tempPin A1

const int HALLSEN_A = 17; // Hall sensor A connected to pin 17 (external interrupt)
const int HALLSEN_B = 18; // Hall sensor B connected to pin 18

volatile long encoderValue = 0;
volatile long rpmValue = 0;

int interval2 = 10;
long previousMillis2 = 0;
long currentMillis2 = 0;

int spd = 0;
int lastSpd = 0;
double feedback = 0;
double error = 0;
int trackError = 0;

boolean fin;
////////////////////////////////////////

//int posLED = 9; // position light (RED)
//int velLED = 10; // velocity light (GREEN)
//int curLED = 11; // current light (BLUE)
int ledPin = 12; // debug light
const byte numChars = 8; char receivedChars[numChars]; // an array to store the received data
boolean newData, Stopped;

// Command struct
typedef struct {
  int mode;
  double userInput1;
  double userInput2;
  double temperature;
  double loadcurrent;
  double pos;
  double vel;
  double inV;
  double loadV;
} CMD;
CMD cmd;

// Comment out the md object depending on the motor shield
DualVNH5019MotorShield md; // single/dual motor shield

// reset function for arduino mega and uno
void(* resetFunc) (void) = 0;
// the arduino zero uses this function to reset: NVIC_SystemReset()

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  md.init();
  EncoderInit();//Initialize the module
  pinMode(ledPin, OUTPUT);
  pinMode(tempPin, INPUT);
  analogWrite(ledPin, 0);
  newData = false;
  encoderValue = 0;
  Serial.println("<Arduino is ready>\n"); // tell the PC we are ready
  previousMillis2 = millis();
}

void brakeMotor(int num) {
  if (num == -1) {
    md.setM1Brake(400);
    Serial.println("FULL BRAKES");
  }
}

void loop() { // put your main code here, to run repeatedly:
  newData = false;
  cmd = {};
  newData = parseCMD();
  if (newData == true) {
    int mod = cmd.mode;
    if (!(mod == 7 || mod == 11 || mod == 12 || mod == 13 || mod == 14 || mod == 15 || mod == 16 || mod == 29)) {
      printCMD();
    }
  }
  setLED_Brightness(cmd.mode);
  brakeMotor(cmd.mode); // if mode is -1
  encodeStatusMsg(cmd.mode);
  resetArduino(cmd.mode);
  switch (cmd.mode) {
    case -1:
    case 0:
      // do nothing
      break;
    case 1:
      Serial.println("Position Control");
      posCtrl();
      break;
    case 2:
      Serial.println("Velocity Control");
      velCtrl();
      break;
    case 3:
      Serial.println("Current Control");
      currCtrl();
      break;
    case 4:
      Serial.println("Current-based Position Control");
      currPosCtrl();
      break;
    case 5:
      Serial.println("PWM Control");
      pwmCtrl();
      break;
    case 7:
    case 11:
    case 12:
    case 13:
    case 14:
    case 15:
    case 16:
      break;
    default:
      Serial.println("Invalid Mode");
      break;
  }
}

void velCtrl() {
  trackError = 0;
  cmd.userInput1 *= 1.075;
  spd = lastSpd;
  fin = false;
  md.setM1Speed(spd);
  while (fin == false) {
    newData = parseCMD();
    if (newData == true && cmd.mode == -1) {
      brakeMotor(-1);
      break;
    }
    feedback = get_RPM_10_millis(10);
    error = cmd.userInput1 - feedback;

    if ((error < 10) && (error > -10)) {
      if (error > 0) {
        md.setM1Speed(spd++);
      }
      else if (error < 0) {
        md.setM1Speed(spd--);
      }
    } else {
      if (error > 0) {
        spd += 10;
        md.setM1Speed(spd);
      }
      else if (error < 0) {
        spd -= 10;
        md.setM1Speed(spd);
      }
    }
    if ((error >= -0.15) && (error <= 0.15)) {
      trackError++;
    }
    if (trackError == 20 || spd == 400 || spd == -400) {
      md.setM1Speed(spd);
      fin = true;
    }
  }//end of while loop
  lastSpd = spd;
}

void currCtrl() {
  fin = false;
  spd = lastSpd;
  md.setM1Speed(spd);

  while (dir() == 0) {
    if (cmd.userInput1 > 0) {
      md.setM1Speed(spd++);
    } else if (cmd.userInput1 < 0) {
      md.setM1Speed(spd--);
    }
  }
  while (fin == false) {
    feedback = get_average_current(50);
    error = cmd.userInput1 - feedback;

    if (error > 2) {
      md.setM1Speed(spd++);
    } else if (error < -2) {
      md.setM1Speed(spd--);
    } else {
      md.setM1Speed(spd);
    }

    if ((spd == 400) || (spd == -400)) {
      md.setM1Speed(spd);
      if (spd == 400) {
        spd = 399;
      }
      else if (spd == -400) {
        spd = -399;
      }
      lastSpd = spd;
      fin = true;
    }

    newData = parseCMD();

    if (newData == true && cmd.mode == -1) {
      brakeMotor(-1);
      break;
    }
    //    Serial.print("Feedback Current(again): ");
    //    Serial.println(feedback);
    //    Serial.print("Current(again): ");
    //    Serial.println(cmd.userInput1);
    //    Serial.print("Error (again): ");
    //    Serial.println(error);
  }
  if (cmd.userInput1 == 0) {
    md.setM1Brake(100);
  }
}

void posCtrl() {
  long angleCal = 0;
  if (cmd.userInput1 >= 0) {
    angleCal = ((cmd.userInput1 * 6) + ((2 * cmd.userInput1) / 3)) + 28;
  } else {
    angleCal = ((cmd.userInput1 * 6) + ((2 * cmd.userInput1) / 3)) - 28;
  }
  long newAngle = encoderValue + angleCal;
  double angleIs = 0.00;
  fin = false;

  if (angleCal < 0) {
    spd = -cmd.userInput2;
  }
  else {
    spd = cmd.userInput2;
  }
  md.setM1Speed(spd);

  while (fin == false) {
    newData = parseCMD();
    if (newData == true && cmd.mode == -1) {
      brakeMotor(-1);
      break;
    }
    angleIs = ((double)encoderValue / 6.666667);
    Serial.print("SMRPosition ");
    Serial.print(angleIs);
    Serial.println(";");
    if (cmd.userInput1 >= 0) {
      if (encoderValue >= newAngle) {
        md.setM1Brake(400);
        delay(100);
        md.setM1Speed(-100);
        while (encoderValue >= newAngle) {
          if (encoderValue <= newAngle) {
            md.setM1Brake(400);
            fin = true;
          }
        }
      }
    }
    else {
      if (encoderValue <= newAngle) {
        md.setM1Brake(400);
        delay(100);
        md.setM1Speed(100);
        while (encoderValue <= newAngle) {
          if (encoderValue >= newAngle) {
            md.setM1Brake(400);
            fin = true;
          }
        }
      }
    }
  }
}

void currPosCtrl() {
  long angleCal = 0;
  if (cmd.userInput1 >= 0) {
    angleCal = ((cmd.userInput1 * 6) + ((2 * cmd.userInput1) / 3)) + 28;
  } else {
    angleCal = ((cmd.userInput1 * 6) + ((2 * cmd.userInput1) / 3)) - 28;
  }
  long newAngle = encoderValue + angleCal;
  double angleIs = 0.00;
  fin = false;

  while (dir() == 0) {
    if (cmd.userInput2 > 0) {
      md.setM1Speed(spd++);
    } else if (cmd.userInput2 < 0) {
      md.setM1Speed(spd--);
    }
  }
  while (fin == false) {
    newData = parseCMD();
    if (newData == true && cmd.mode == -1) {
      brakeMotor(-1);
      break;
    }
    feedback = get_average_current(50);
    error = cmd.userInput2 - feedback;
    if (error > 2) {
      md.setM1Speed(spd++);
    } else if (error < -2) {
      md.setM1Speed(spd--);
    } else {
      md.setM1Speed(spd);
    }

    if ((spd == 400) || (spd == -400)) {
      md.setM1Speed(spd);
      if (spd == 400) {
        spd = 399;
      }
      else if (spd == -400) {
        spd = -399;
      }
    }
    angleIs = ((double)encoderValue / 6.666667);
    Serial.print("SMRPosition ");
    Serial.print(angleIs);
    Serial.println(";");
    if (cmd.userInput1 >= 0) {
      if (encoderValue >= newAngle) {
        md.setM1Brake(400);
        delay(100);
        md.setM1Speed(-100);
        while (encoderValue >= newAngle) {
          if (encoderValue <= newAngle) {
            md.setM1Brake(400);
            spd = 0;
            fin = true;
          }
        }
      }
    }
    else {
      if (encoderValue <= newAngle) {
        md.setM1Brake(400);
        delay(100);
        md.setM1Speed(100);
        while (encoderValue <= newAngle) {
          if (encoderValue >= newAngle) {
            md.setM1Brake(400);
            spd = 0;
            fin = true;
          }
        }
      }
    }
  }
}

void pwmCtrl() {
  spd = ((double)cmd.userInput1 / 100) * 400;
  md.setM1Speed(spd);
}

float GetTemp() {
  // Temperature analysis
  int tempReading = analogRead(tempPin);
  // If using 3.3v input
  float voltage = tempReading * 3.3;
  // Divided by 1024
  voltage /= 1024.0;
  //Converting from 10mv per degree
  float tempC = (voltage - 0.5) * 100;
  float tempF = (tempC * 9.0 / 5.0) + 32.0;
  return tempF;
}

float getAvgTemp(int num) {
  float avg = 0;
  for (int i = 0; i < num; i++) {
    avg += GetTemp();
    delay(4);
  }
  return avg / float(num);
}

int get_average_current(int num) {
  int sum = 0;
  int avg = 0;
  if (dir() >= 0) {                                // check motor direction
    for (int i = 0; i < num; i++) {                // for CW current calculation
      sum += md.getM1CurrentMilliamps();
      delay(1);
    }
  } else {
    for (int i = 0; i < num; i++) {                // for CCW current calculation
      sum += -1 * (md.getM1CurrentMilliamps() - 256);
      delay(1);
    }
  }
  if (dir() == 0) {
    avg = 0;                                       // if the motor is not moving set the feedback current to zero
  } else {
    avg = sum / num;                               // if the motor is moving, calculate current based on feedback
  }
  return avg;                                      // return feedback current
}

void tok() {
  // split the data into its parts
  char * strtokIndx; // this is used by strtok() as an index
  double speedd = 0.00;
  strtokIndx = strtok(receivedChars, " ");     // get the first value
  cmd.mode = atoi(strtokIndx);
  int mod = cmd.mode;

  strtokIndx = strtok(NULL, " ");
  cmd.userInput1 = atof(strtokIndx);     // convert this part to a long or double

  strtokIndx = strtok(NULL, ";");
  speedd = atof(strtokIndx);     // convert this part to a long or double
  if (speedd < 20 && speedd != 0 && (cmd.mode == 1 || cmd.mode == 4)) {
    Serial.print("Speedd = ");
    Serial.println(speedd);
    cmd.userInput2 = (speedd * 10);
    if (cmd.userInput2 < 20) {
      cmd.userInput2 = 20;
    }
  }
  else if (speedd == 0) {
    cmd.userInput2 = spd;
  }
  else {
    cmd.userInput2 = speedd;
  }
  if ((mod == 2) || (mod == 3) || (mod == 5)) {
    cmd.userInput2 = 0;
  }
}

void resetArduino(int mod) {
  if (mod == 29) {
    Serial.println("Arduino is resetting");
    digitalWrite(ledPin, HIGH);
    delay(2000);
    digitalWrite(ledPin, LOW);
    NVIC_SystemReset();
  }
}

void setLED_Brightness(int num) {
  if (num == 7) {
    int light = map(cmd.userInput1, 0, 100, 0, 255);
    analogWrite(ledPin, light);
    if (light > 0) {
      Serial.print("LED ON: ");
      Serial.print(cmd.userInput1);
      Serial.println("%");
    }
    else {
      Serial.print("LED OFF: ");
      Serial.print(cmd.userInput1);
      Serial.println("%");
    }
  }
}

void printCMD() {
  Serial.print("Mode = ");
  Serial.println(cmd.mode);
  Serial.print("User input 1 = ");
  Serial.println(cmd.userInput1);
  Serial.print("User input 2 = ");
  Serial.println(cmd.userInput2);
}

void encodeStatusMsg(int num) {
  //  double temperature = 0, pos = 0, vel = 0, inV = 0, loadV = 0, loadcurrent = 0;
  switch (num) {
    case 11: // Temperature
      // Calculate Temperature
      cmd.temperature = getAvgTemp(50);
      Serial.print("SMTemperature ");
      Serial.print(cmd.temperature);
      Serial.println(";");
      break;
    case 12: // Position
      // Calculate position
      cmd.pos = ((double)encoderValue) / 6.6666667; //calculates angle in Degrees based on the encoderValue
      Serial.print("SMPosition ");
      Serial.print(cmd.pos);
      Serial.println(";");
      break;
    case 13: // Velocity
      // Calculate velocity
      cmd.vel = (double)get_RPM_10_millis(10) * 1.03;
      Serial.print("SMVelocity ");
      Serial.print(cmd.vel);
      Serial.println(" RPM;");
      break;
    case 14: // Input Voltage
      // Calculate input Voltage
      cmd.inV = ((double)spd / 400) * 3.5; //duty cycle multiplied by measured amplitude of duty cycle (3.5 V)
      Serial.print("SMInput Voltage ");
      Serial.print(cmd.inV);
      Serial.println(" V;");
      break;
    case 15: // Load Voltage
      // Calculate load Voltage
      cmd.loadV = ((double)get_average_current(50) / 1000) * 45; //45 represents the resistance, still unknown really, the first input to the function tells the ccw or cw
      Serial.print("SMLoad Voltage ");
      Serial.print(cmd.loadV);
      Serial.println(" V;");
      break;
    case 16: // Load Current
      // Calculate Load Current
      cmd.loadcurrent = get_average_current(50);
      Serial.print("SMLoad Current ");
      Serial.print(cmd.loadcurrent);
      Serial.println(" mA;");
      break;
    default:
      break;
  }
}

boolean parseCMD() {
  static byte ndx = 0;
  char index, rc, endMarker = ';';
  int fc;

  while (Serial.available() > 0 && newData == false) {
    //    delay(100);
    rc = Serial.read();

    if (rc != endMarker) {
      receivedChars[ndx] = rc;
      ndx++;
      if (ndx >= numChars) {
        ndx = numChars - 1;
      }
    } else {
      receivedChars[ndx] = '\0'; // terminate the string
      index = ndx;
      ndx = 0;
      newData = true;
      tok();
    }
  }
  return newData;
}

void EncoderInit() {
  // Attach interrupt at hall sensor A on each rising signal
  attachInterrupt(digitalPinToInterrupt(HALLSEN_A), updateEncoder, RISING);
}

void updateEncoder() {
  // Add or Subtract encoderValue by 1, each time it detects rising signal
  // from hall sensor A
  //Serial.print("HALLSEN_B = ");
  //Serial.println(pinB);
  if (digitalRead(HALLSEN_B) == LOW) { //CW direction
    encoderValue++;
    rpmValue++;
  }
  else { //CCW direction
    //Serial.println("Reading Pin as High");
    encoderValue--;
    rpmValue--;
  }
}

int get_RPM_10_millis(int num) {                            //calc average RPM with 10 millisecond time interval inbetween feedback
  rpmValue = 0;
  int num2 = num;
  double sum = 0;
  double avg = 0;

  while (num >= 0) {
    currentMillis2 = millis();
    if (currentMillis2 - previousMillis2 > interval2) {
      previousMillis2 = currentMillis2;
      sum += (rpmValue * 60 / ENCODEROUTPUT2);
      delay(1);
      rpmValue = 0;
      num--;
    }
  }
  avg = (sum / num2);
  return (int)avg;
}

int dir() {                             // determine the direction the motor is turning
  volatile long value1 = encoderValue;  // save encoderValue to value1
  delay(1);                             // wait
  volatile long value2 = encoderValue;  // save encoderValue to value2

  if (value1 < value2) {                // return 1 for CW direction
    return 1;
  } else if (value1 > value2) {          // return -1 for CCW direction
    return -1;
  } else {                               // return 0 if motor is not turning
    return 0;
  }
}
