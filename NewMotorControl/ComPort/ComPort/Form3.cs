using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form3 : Form
    {
        string msg, msg2;
        public string url;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            msg = "Home\n\n";
            msg2 = "";
            richTextBox1.Text = msg;
            richTextBox1.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            msg = "Shortcuts\n\n";
            msg2 = "";
            richTextBox1.Text = msg;
            richTextBox1.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            msg = "Tips\n\n";
            msg2 = "";
            richTextBox1.Text = msg;
            richTextBox1.ScrollToCaret();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            msg = "Frequently Asked Questions\n\n";
            msg2 = "";
            richTextBox1.Text = msg;
            richTextBox1.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            msg = "Github Repository\n\n";
            msg2 = "";
            var prs = new ProcessStartInfo("msedge.exe");
            prs.Arguments = msg2;
            Process.Start(prs);
            richTextBox1.Text = msg + msg2;
            richTextBox1.ScrollToCaret();
        }
    }
}
