namespace GUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rBoxExample = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "(1 XX YY) => Position Control, XX is the angle, YY is the speed",
            "(2 XX) => Velocity Control, XX is the speed",
            "(3 XX) => Current Control, XX is the current",
            "(4 XX YY) => Current-based Position Control, XX is the angle, YY is the current",
            "(5 XX) => PWM Control, XX is the duty cycle",
            "(7 XX) => Set debugging light to XX%, 0% will turn off the light",
            "(11) => Get the Temperature",
            "(12) => Get the Position",
            "(13) => Get the Velocity",
            "(14) => Get the Input Voltage",
            "(15) => Get the Load Voltage",
            "(16) => Get the Load Current",
            "(29) => Reset Arduino",
            "(-1) => Stop the Motor",
            "Reset all input and output windows",
            "Reset individual windows"});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(776, 350);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // rBoxExample
            // 
            this.rBoxExample.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rBoxExample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rBoxExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBoxExample.Location = new System.Drawing.Point(12, 368);
            this.rBoxExample.Name = "rBoxExample";
            this.rBoxExample.ReadOnly = true;
            this.rBoxExample.Size = new System.Drawing.Size(776, 313);
            this.rBoxExample.TabIndex = 1;
            this.rBoxExample.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 693);
            this.Controls.Add(this.rBoxExample);
            this.Controls.Add(this.listBox1);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List of Commands";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox rBoxExample;
    }
}