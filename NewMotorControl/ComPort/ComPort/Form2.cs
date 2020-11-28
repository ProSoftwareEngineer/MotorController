using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            rBoxExample.Text = "Examples for each command, please select one of the commands above to see an example. " + 
                "Please manually reset the Arduino if it seems like the Arduino or the GUI is frozen / not responding.\n\n";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rBoxExample.AppendText(listBox1.SelectedItem.ToString() + "\n");
            rBoxExample.ScrollToCaret();
            string txt;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    txt = "1 180 30 -> Go to angle 180 at 30 rpms";
                    break;
                case 1:
                    txt = "2 30 -> Run at 30 rpms";
                    break;
                case 2:
                    txt = "3 30 -> Run at 30 mA";
                    break;
                case 3:
                    txt = "4 180 30 -> Go to angle 180 at 30 mA";
                    break;
                case 4:
                    txt = "5 30 -> Run at 30% duty cycle";
                    break;
                case 5:
                    txt = "7 50 -> Set the debugging light to 50%";
                    break;
                case 6:
                    txt = "11 -> Get the temperature in Fahrenheit";
                    break;
                case 7:
                    txt = "12 -> Get the current angle of the motor";
                    break;
                case 8:
                    txt = "13 -> Get the current speed of the motor";
                    break;
                case 9:
                    txt = "14 -> Get the current input voltage from the motor";
                    break;
                case 10:
                    txt = "15 -> Get the current load voltage from the motor";
                    break;
                case 11:
                    txt = "15 -> Get the current load current from the motor";
                    break;
                case 12:
                    txt = "29 -> Reset an Arduino Zero";
                    break;
                case 13:
                    txt = "-1 -> Stops the motor with maximum force";
                    break;
                case 14:
                    txt = "Ctrl + Shift + A -> Clears all input and output windows";
                    break;
                case 15:
                    txt = "Right-Click on 'Clear Screen' -> Select one of the options to clear that window only";
                    break;
                default:
                    txt = "";
                    break;
            }
            rBoxExample.AppendText("Example: " + txt + "\n\n");
            rBoxExample.ScrollToCaret();
        }
    }
}
