#include <DualVNH5019MotorShield.h>
#define ENCODEROUTPUT2 24
#define tempPin A1

DualVNH5019MotorShield md;

double userInput1 = 0;
double userInput2 = 0;

const int HALLSEN_A = 17; // Hall sensor A connected to pin 17 (external interrupt)
const int HALLSEN_B = 18; // Hall sensor B connected to pin 18

volatile long encoderValue = 0;
volatile long rpmValue = 0;

int interval = 1000;
long previousMillis = 0;
long currentMillis = 0;

int interval2 = 10;
long previousMillis2 = 0;
long currentMillis2 = 0;

int spd = 0;
int lastSpd = 0;
double feedback = 0;
double error = 0;
int trackError = 0;
int ledPin = 12; // debug light

boolean fin;

// latest version 11/29/2020 9:20pm

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);

  md.init();
  EncoderInit(); // Initialize module for reading encoder

  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(ledPin, OUTPUT);
  pinMode(tempPin, INPUT);
  analogWrite(ledPin, 0);

  Serial.println("<Arduino is ready>\n"); // tell the PC we are ready

  encoderValue = 0;
  previousMillis = millis();
  previousMillis2 = millis();
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  if (Serial.available() > 0) {
    digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
    int mod = Serial.parseInt();
    userInput1 = Serial.parseFloat();
    userInput2 = Serial.parseFloat();
    if ((mod == 2) || (mod == 3) || (mod == 5)) {
      userInput2 = 0;
    }

    setLED_Brightness(mod);
    encodeStatusMsg(mod);
    resetArduino(mod);
    brakeMotor(mod);
    printCMD(mod, userInput1, userInput2);
    modeSel(mod, userInput1, userInput2);
    statusMsg();
  }
}

void brakeMotor(int num) {
  if (num == -1) {
    md.setM1Brake(400);
    Serial.println("FULL BRAKES");
  }
}

void modeSel(int mod, int userInput1, int userInput2) {
  long angleCal = 0, newAngle = 0, angleIs = 0;
  switch (mod) {
    case 1: // 1. Position Mode
      angleCal = 0;
      if (userInput1 >= 0) {
        angleCal = ((userInput1 * 6) + ((2 * userInput1) / 3)) + 28;
      } else {
        angleCal = ((userInput1 * 6) + ((2 * userInput1) / 3)) - 28;
      }
      newAngle = encoderValue + angleCal;
      angleIs = 0.00;
      fin = false;

      if (angleCal < 0) {
        spd = -userInput2;
      }
      else {
        spd = userInput2;
      }

      md.setM1Speed(spd);

      while (fin == false) {

        if (Serial.available()) {
          int num = Serial.parseInt();
          brakeMotor(num);
          fin = true;
        }
        angleIs = ((double)encoderValue / 6.666667);
        Serial.print("SMRPosition ");
        Serial.print(angleIs);
        Serial.println(";");
        if (userInput1 >= 0) {
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
      break;
    case 2: // 2. Velocity Mode
      trackError = 0;
      userInput1 = userInput1 * 1.075;
      spd = lastSpd;
      fin = false;

      md.setM1Speed(spd);

      while (fin == false) {
        if (Serial.available()) {
          int num = Serial.parseInt();
          brakeMotor(num);
          fin = true;
        }

        feedback = get_RPM_10_millis(10);
        error = userInput1 - feedback;

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
        if (trackError == 5 || spd == 400 || spd == -400) {
          md.setM1Speed(spd);
          fin = true;
        }
      }//end of while loop
      lastSpd = spd;
      break;
    case 3: // 3. Current Mode
      fin = false;
      spd = lastSpd;
      md.setM1Speed(spd);

      while (dir() == 0) {
        if (userInput1 > 0) {
          md.setM1Speed(spd++);
        } else if (userInput1 < 0) {
          md.setM1Speed(spd--);
        }
      }

      while (fin == false) {
        feedback = get_average_current(50);
        error = userInput1 - feedback;

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

        if (Serial.available()) {
          int num = Serial.parseInt();
          brakeMotor(num);
          fin = true;
        }
        //          Serial.print("Feedback Current(again): ");
        //          Serial.println(feedback);
        //          Serial.print("Current(again): ");
        //          Serial.println(userInput1);
        //          Serial.print("Error (again): ");
        //          Serial.println(error);
      }
      if (userInput1 == 0) {
        md.setM1Brake(100);
      }
      break;
    case 4: // 4. Current-based Position Mode
      angleCal = 0;
      if (userInput1 >= 0) {
        angleCal = ((userInput1 * 6) + ((2 * userInput1) / 3)) + 28;
      } else {
        angleCal = ((userInput1 * 6) + ((2 * userInput1) / 3)) - 28;
      }
      newAngle = encoderValue + angleCal;
      angleIs = 0.00;
      fin = false;

      while (dir() == 0) {
        if (userInput2 > 0) {
          md.setM1Speed(spd++);
        } else if (userInput2 < 0) {
          md.setM1Speed(spd--);
        }
      }

      while (fin == false) {

        if (Serial.available()) {
          int num = Serial.parseInt();
          brakeMotor(num);
          fin = true;
        }

        feedback = get_average_current(50);
        error = userInput2 - feedback;

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
        if (userInput1 >= 0) {
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
      break;
    case 5: // 5. PWM Mode
      spd = ((double)userInput1 / 100) * 400;
      md.setM1Speed(spd);
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
  digitalWrite(LED_BUILTIN, LOW);   // turn the LED off (HIGH is the voltage level)
}

void encodeStatusMsg(int num) {
  double temperature = 0, pos = 0, vel = 0, inV = 0, loadV = 0, loadcurrent = 0;
  switch (num) {
    case 11: // Temperature
      // Calculate Temperature
      temperature = getAvgTemp(50);
      Serial.print("SMTemperature ");
      Serial.print(temperature);
      Serial.println(";");
      break;
    case 12: // Position
      // Calculate position
      pos = ((double)encoderValue) / 6.6666667; //calculates angle in Degrees based on the encoderValue
      Serial.print("SMPosition ");
      Serial.print(pos);
      Serial.println(";");
      break;
    case 13: // Velocity
      // Calculate velocity
      vel = (double)get_RPM_10_millis(10) * 1.03;
      Serial.print("SMVelocity ");
      Serial.print(vel);
      Serial.println(" RPM;");
      break;
    case 14: // Input Voltage
      // Calculate input Voltage
      inV = ((double)spd / 400) * 3.5; //duty cycle multiplied by measured amplitude of duty cycle (3.5 V)
      Serial.print("SMInput Voltage ");
      Serial.print(inV);
      Serial.println(" V;");
      break;
    case 15: // Load Voltage
      // Calculate load Voltage
      loadV = ((double)get_average_current(50) / 1000) * 45; //45 represents the resistance, still unknown really, the first input to the function tells the ccw or cw
      Serial.print("SMLoad Voltage ");
      Serial.print(loadV);
      Serial.println(" V;");
      break;
    case 16: // Load Voltage
      // Calculate Load Current
      loadcurrent = get_average_current(50);
      Serial.print("SMLoad Current ");
      Serial.print(loadcurrent);
      Serial.println(" mA;");
      break;
    default:
      break;
  }
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

void statusMsg() {
  double temperature = 0;
  double loadVoltage = 0;
  double inputVoltage = 0;
  double loadCurrent = 0;
  double motorPosition = 0;
  double motorVelocity = 0;

  // Calculate Temperature (F)
  temperature = getAvgTemp(50);

  //Calculate loadCurrent
  loadCurrent = get_average_current(50);

  //Calculate loadVoltage
  loadVoltage = ((double)get_average_current(50) / 1000) * 45; // 45 represents the resistance, still unknown really, the first input to the function tells the ccw or cw

  //Calculate inputVoltage
  inputVoltage = ((double)spd / 400) * 3.5;         // duty cycle multiplied by measured amplitude of duty cycle (3.5 V)

  //Calculate motorPosition
  motorPosition = ((double)encoderValue) / 6.6666667; // calculates angle in Degrees based on the encoderValue

  //Calculate and print motorVelocity

  motorVelocity = get_RPM_10_millis(10) * 1.03;
  if (motorVelocity < 0) {
    motorVelocity = -1 * motorVelocity;
  }

  //print temperature
  Serial.print("SMTemperature ");
  Serial.print(temperature);
  Serial.println(";");

  //print loadVoltage
  Serial.print("SMLoad Voltage ");
  Serial.print(loadVoltage);
  Serial.println(" V;");

  //print inputVoltage
  Serial.print("SMInput Voltage ");
  Serial.print(inputVoltage);
  Serial.println(" V;");

  //print loadCurrent
  Serial.print("SMLoad Current ");
  Serial.print(loadCurrent);
  Serial.println(" mA;");

  //print motorPosition
  Serial.print("SMPosition ");
  Serial.print(motorPosition);
  Serial.println(";");

  //print motorVelocity
  Serial.print("SMVelocity ");
  Serial.print(motorVelocity);
  Serial.println(" RPM;");
}

void resetArduino(int num) {
  if (num == 29) {
    Serial.println("Arduino is resetting");
    digitalWrite(ledPin, HIGH);
    delay(2000);
    digitalWrite(ledPin, LOW);
    NVIC_SystemReset();
  }
}

void setLED_Brightness(int num) {
  if (num == 7) {
    int light = map(userInput1, 0, 100, 0, 255);
    analogWrite(ledPin, light);
    if (light > 0) {
      Serial.print("LED ON: ");
      Serial.print(userInput1);
      Serial.println("%");
    }
    else {
      Serial.print("LED OFF: ");
      Serial.print(userInput1);
      Serial.println("%");
    }
  }
}

void printCMD(int num, double ui1, double ui2) {
  Serial.print("Mode = ");
  Serial.println(num);
  Serial.print("User input 1 = ");
  Serial.println(ui1);
  Serial.print("User input 2 = ");
  Serial.println(ui2);
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

double get_RPM_10_millis(int num) {                            //calc average RPM with 10 millisecond time interval inbetween feedback
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
  return avg;
}

void EncoderInit()
{
  // Attach interrupt at hall sensor A on each rising signal
  attachInterrupt(digitalPinToInterrupt(HALLSEN_A), updateEncoder, RISING);
}

void updateEncoder()
{
  // Add or Subtract encoderValue by 1, each time it detects rising signal
  // from hall sensor A
  if (digitalRead(HALLSEN_B) == LOW) {  //CW direction
    encoderValue++;
    rpmValue++;
  }
  else {                                //CCW direction
    encoderValue--;
    rpmValue--;
  }
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
