using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;

namespace ComPort
{
    public partial class Form1 : Form
    {
        string dataOUT;
        string dataIN;
        int modeNum;
        bool stillRunning;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]

        public Form1()
        {
            InitializeComponent();
        }

        private void AnimatedLED_Initialization()
        {
            animatedLED1.BackColor = Color.DarkRed;
            animatedLED2.BackColor = Color.DarkGreen;
            animatedLED3.BackColor = Color.DarkBlue;
        }

        private void Button_SendData(Button numberLED, Color LEDcolor)
        {
            try
            {
                numberLED.BackColor = LEDcolor;
            }
            catch (Exception err)
            {
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.Clear();
            for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
            {
                cBoxCOMPORT.Items.Add(ports[i]);
            }
            try
            {
                cBoxCOMPORT.SelectedIndex = 1;
            }
            catch
            {
                cBoxCOMPORT.SelectedIndex = 0;
            }

            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            stillRunning = false;
            rBoxStatus.AppendText("\n");
            rBoxDataIN.AppendText("\n");

            AnimatedLED_Initialization();
            string msg = "Please manually reset the Arduino if it seems like the Arduino or the GUI is frozen / not responding. " +
                "Please do not close the GUI unless it's the last resort.";
            MessageBox.Show(msg, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(CBoxBaudRate.Text);
                serialPort1.DtrEnable = true;

                serialPort1.Open();
                tStripProgressBar.Value = 100;
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                tStripStatusLbl.Text = "Port Status";
            }

            catch (Exception err)
            {
                tStripErrorText.Text = "Open Port";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    if (stillRunning == true)
                    {
                        tStripErrorText.Text = "Still Running";
                        tStripErrorMsg.Text = "Arduino is still giving feedback.";
                    }
                    else
                    {
                        serialPort1.Close();
                        serialPort1.Dispose();
                        tStripProgressBar.Value = 0;
                        btnOpen.Enabled = true;
                        btnClose.Enabled = false;
                        tStripStatusLbl.Text = "Port Status";
                    }
                }
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Close Port";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "29;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }

            catch (Exception err)
            {
                tStripErrorText.Text = "Reset Arduino";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadLine();
            string tempStr = "SMTemperature";
            string posStr = "SMPosition";
            string velStr = "SMVelocity";
            string inVStr = "SMInput Voltage";
            string loadVStr = "SMLoad Voltage";
            string loadCurrStr = "SMLoad Current";
            try
            {
                if (dataIN.StartsWith(tempStr))
                {
                    this.Invoke(new EventHandler(ShowTempData));
                }
                else if (dataIN.StartsWith(posStr))
                {
                    this.Invoke(new EventHandler(ShowPosData));
                }
                else if (dataIN.StartsWith(velStr))
                {
                    this.Invoke(new EventHandler(ShowVelData));
                }
                else if (dataIN.StartsWith(inVStr))
                {
                    this.Invoke(new EventHandler(ShowInputVData));
                }
                else if (dataIN.StartsWith(loadVStr))
                {
                    this.Invoke(new EventHandler(ShowLoadVData));
                }
                else if (dataIN.StartsWith(loadCurrStr))
                {
                    this.Invoke(new EventHandler(ShowLoadCurrData));
                }
                else if (e.ToString() == "")
                {
                    stillRunning = false;
                }
                else
                {
                    this.Invoke(new EventHandler(ShowData));
                }
            }
            catch (Exception err)
            {
                stillRunning = false;
                tStripErrorText.Text = "Data Received";
                tStripErrorMsg.Text = err.Message;
            }
            stillRunning = false;
        }

        private void ShowLoadCurrData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                int first = dataIN.IndexOf("Load Current");
                int last = dataIN.LastIndexOf(";");
                string str2 = dataIN.Substring(first, last - first);
                rBoxStatus.AppendText(str2 + "\n");
                rBoxStatus.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Load Current";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void ShowLoadVData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                int first = dataIN.IndexOf("Load Voltage");
                int last = dataIN.LastIndexOf(";");
                string str2 = dataIN.Substring(first, last - first);
                rBoxStatus.AppendText(str2 + "\n");
                rBoxStatus.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Load Voltage";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void ShowInputVData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                int first = dataIN.IndexOf("Input Voltage");
                int last = dataIN.LastIndexOf(";");
                string str2 = dataIN.Substring(first, last - first);
                rBoxStatus.AppendText(str2 + "\n");
                rBoxStatus.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Input Voltage";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void ShowVelData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                int first = dataIN.IndexOf("Velocity");
                int last = dataIN.LastIndexOf(";");
                string str2 = dataIN.Substring(first, last - first);
                rBoxStatus.AppendText(str2 + "\n");
                rBoxStatus.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Velocity Data";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void ShowPosData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                int first = dataIN.IndexOf("Position");
                int last = dataIN.LastIndexOf(";");
                string str2 = dataIN.Substring(first, last - first);
                rBoxStatus.AppendText(str2 + " \xB0" + "\n");
                rBoxStatus.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Position Data";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void ShowTempData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                int first = dataIN.IndexOf("Temperature");
                int last = dataIN.LastIndexOf(";");
                string str2 = dataIN.Substring(first, last - first);
                rBoxStatus.AppendText(str2 + " \xB0" + "F" + "\n"); 
                rBoxStatus.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Temp Data";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            try
            {
                stillRunning = true;
                rBoxDataIN.AppendText(dataIN);
                rBoxDataIN.ScrollToCaret();
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Show Data";
                tStripErrorMsg.Text = err.Message;
            }
        } 

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            try
            {
                if (rBoxDataIN.Text != "")
                {
                    rBoxDataIN.Text = "----------------- Arduino Messages ----------------";
                    rBoxDataIN.AppendText("\n");
                }
                if (rBoxStatus.Text != "")
                {
                    rBoxStatus.Text = "------------------ Status Messages -----------------";
                    rBoxStatus.AppendText("\n");
                }
                if (tStripErrorText.Text != "")
                {
                    tStripErrorText.Text = "";
                    tStripErrorMsg.Text = "";
                }
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Clear Screen";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void startMotor_Click(object sender, EventArgs e)
        {
            try
            {
                double setpoint, speed;
                if (tBoxSpd.Visible == true) { speed = Convert.ToInt32(tBoxSpd.Text); } else { speed = 0; }
                if (tBoxSet.Visible == true) { setpoint = Convert.ToInt32(tBoxSet.Text); } else { setpoint = 0; }
                if (modeList.SelectedItem.ToString().StartsWith("1"))
                {
                    if (btnCW_CCW.Text != "Clockwise")
                    {
                        setpoint *= -1;
                    }
                }
                else if (modeList.SelectedItem.ToString().StartsWith("2"))
                {
                    if (btnCW_CCW.Text != "Clockwise")
                    {
                        setpoint *= -1;
                    }
                }
                else if (modeList.SelectedItem.ToString().StartsWith("3"))
                {
                    if (btnCW_CCW.Text != "Clockwise")
                    {
                        setpoint *= -1;
                    }
                }
                else if (modeList.SelectedItem.ToString().StartsWith("4"))
                {
                    if (btnCW_CCW.Text != "Clockwise")
                    {
                        setpoint *= -1;
                    }
                }
                else if (modeList.SelectedItem.ToString().StartsWith("5"))
                {
                    if (btnCW_CCW.Text != "Clockwise")
                    {
                        setpoint *= -1;
                    }
                }
                dataOUT = string.Format("{0} {1} {2};", modeNum, setpoint, speed);
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }

            catch (Exception err)
            {
                tStripErrorText.Text = "Start Motor";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void stopMotor_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "-1;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Stop Motor";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void modeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string name = modeList.SelectedItem.ToString();

                switch (name)
                {
                    case "1. Position Control":
                        Button_SendData(animatedLED1, Color.Red);
                        Button_SendData(animatedLED2, Color.DarkGreen);
                        Button_SendData(animatedLED3, Color.DarkBlue);
                        modeNum = 1;
                        DataType2.Text = "rpm";
                        DataType.Text = "\xB0";
                        lblSetpoint.Text = "Angle:";
                        lblSpeed.Text = "Speed:";
                        tBoxSpd.Visible = true;
                        break;
                    case "2. Velocity Control":
                        Button_SendData(animatedLED1, Color.DarkRed);
                        Button_SendData(animatedLED2, Color.LimeGreen);
                        Button_SendData(animatedLED3, Color.DarkBlue);
                        modeNum = 2;
                        DataType2.Text = "";
                        DataType.Text = "rpm";
                        lblSetpoint.Text = "Speed:";
                        lblSpeed.Text = "";
                        tBoxSpd.Visible = false;
                        break;
                    case "3. Current Control":
                        Button_SendData(animatedLED1, Color.DarkRed);
                        Button_SendData(animatedLED2, Color.DarkGreen);
                        Button_SendData(animatedLED3, Color.Blue);
                        modeNum = 3;
                        DataType2.Text = "";
                        DataType.Text = "mA";
                        lblSetpoint.Text = "Current:";
                        lblSpeed.Text = "";
                        tBoxSpd.Visible = false;
                        break;
                    case "4. Current-based Position Control":
                        Button_SendData(animatedLED1, Color.Red);
                        Button_SendData(animatedLED2, Color.DarkGreen);
                        Button_SendData(animatedLED3, Color.Blue);
                        modeNum = 4;
                        DataType2.Text = "mA";
                        DataType.Text = "\xB0";
                        lblSetpoint.Text = "Angle:";
                        lblSpeed.Text = "Current:";
                        tBoxSpd.Visible = true;
                        break;
                    case "5. PWM Control":
                        Button_SendData(animatedLED1, Color.Red);
                        Button_SendData(animatedLED2, Color.LimeGreen);
                        Button_SendData(animatedLED3, Color.Blue);
                        modeNum = 5;
                        DataType2.Text = "";
                        DataType.Text = "%";
                        lblSetpoint.Text = "Duty:";
                        lblSpeed.Text = "";
                        tBoxSpd.Visible = false;
                        break;
                    default:
                        Button_SendData(animatedLED1, Color.DarkRed);
                        Button_SendData(animatedLED2, Color.DarkGreen);
                        Button_SendData(animatedLED3, Color.DarkBlue);
                        DataType2.Text = "";
                        DataType.Text = "";
                        lblSetpoint.Text = "Input 1:";
                        lblSpeed.Text = "Input 2:";
                        tBoxSpd.Visible = true;
                        modeNum = 30;
                        break;
                }
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Mode Select";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void cBoxCOMPORT_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.Clear();
            for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
            {
                cBoxCOMPORT.Items.Add(ports[i]);
            }
        }

        private void btnGetTemp_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "11;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Temperature btn";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnInputVoltage_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "14;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Input Voltage btn";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnLoadVoltage_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "15;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Load Voltage btn";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnVelocity_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "13;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Velocity btn";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "12;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Position btn";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void btnCW_CCW_Click(object sender, EventArgs e)
        {
            if (btnCW_CCW.Text != "Clockwise")
            {
                btnCW_CCW.Text = "Clockwise";
            }
            else
            {
                btnCW_CCW.Text = "Counter Clockwise";
            }
        }

        private void tStripCLI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tStripCLI.Text.EndsWith(";") == false)
                    {
                        dataOUT = tStripCLI.Text + ';';
                    }
                    else
                    {
                        dataOUT = tStripCLI.Text;
                    }
                    serialPort1.Write(dataOUT);
                    tStripCmdSent.Text = dataOUT;
                    tStripCLI.Text = "";
                }

                catch (Exception err)
                {
                    tStripErrorText.Text = "CLI error";
                    tStripErrorMsg.Text = err.Message;
                }
            }
        }

        private void tStripCLI_Menu_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                tStripCLI.Text = "---";
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "CLI DropDown error";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                tStripStatusLbl.Text = "Led Brightness";
                tStripProgressBar.Value = trackBar1.Value;
                dataOUT = string.Format("7 {0};", tStripProgressBar.Value);
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Track Bar";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    serialPort1.Dispose();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Request to close GUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tStripCLI_Click(object sender, EventArgs e)
        {
            tStripCLI.Text = "";
        }

        private void tStripGetCMDs_Click(object sender, EventArgs e)
        {
            GUI.Form2 f2 = new GUI.Form2();
            f2.Show();
        }

        private void btnLoadCurr_Click(object sender, EventArgs e)
        {
            try
            {
                dataOUT = "16;";
                serialPort1.Write(dataOUT);
                tStripCmdSent.Text = dataOUT;
            }
            catch (Exception err)
            {
                tStripErrorText.Text = "Load Current btn";
                tStripErrorMsg.Text = err.Message;
            }
        }

        private void tBoxSet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tBoxSet.Text != "")
            {
                tBoxSet.Text = "";
            }
        }

        private void tBoxSpd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tBoxSpd.Text != "")
            {
                tBoxSpd.Text = "";
            }
        }

        private void tBoxSpd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tBoxSet.Text != "")
                {
                    startMotor_Click(sender, e);
                }
            }
        }

        private void tBoxSet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((modeList.SelectedIndex == 1) || (modeList.SelectedIndex == 4))
                {
                    if (tBoxSpd.Text != "")
                    {
                        startMotor_Click(sender, e);
                    }
                }
                else
                {
                    startMotor_Click(sender, e);
                }
            }
        }

        private void contextMenu_clear_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem.Text;
            switch (item)
            {
                case "Clear Arduino Messages":
                    rBoxDataIN.Text = "----------------- Arduino Messages ----------------";
                    rBoxDataIN.AppendText("\n");
                    break;
                case "Clear Status Messages":
                    rBoxStatus.Text = "------------------ Status Messages -----------------";
                    rBoxStatus.AppendText("\n");
                    break;
                case "Clear Error Messages":
                    tStripErrorMsg.Text = "---";
                    tStripErrorText.Text = "Error Message";
                    break;
                case "Clear Inputs":
                    tBoxSet.Text = "";
                    tBoxSpd.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void tStripMClearAll_Click(object sender, EventArgs e)
        {
            if (rBoxDataIN.Text != "" || tBoxSet.Text != "")
            {
                rBoxDataIN.Text = "----------------- Arduino Messages ----------------";
                rBoxDataIN.AppendText("\n");
                rBoxStatus.Text = "------------------ Status Messages -----------------";
                rBoxStatus.AppendText("\n");
                tStripErrorMsg.Text = "---";
                tStripErrorText.Text = "Error Message";
                tBoxSet.Text = "";
                tBoxSpd.Text = "";
            }
        }

        private void tStripListCMD_Click(object sender, EventArgs e)
        {
            GUI.Form2 f2 = new GUI.Form2();
            f2.Show();

            // Fix tab control to control GUI from keyboard only
        }

        private void tStripHelp_Click(object sender, EventArgs e)
        {
            GUI.Form3 f3 = new GUI.Form3();
            f3.Show();
        }
    }
}
