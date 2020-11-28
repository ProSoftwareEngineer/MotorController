namespace ComPort
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearScreen = new System.Windows.Forms.Button();
            this.contextMenu_clear = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tStripClearInputs = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripClearArduino = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripClearStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripClearError = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.animatedLED2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.animatedLED1 = new System.Windows.Forms.Button();
            this.animatedLED3 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rBoxDataIN = new System.Windows.Forms.RichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCW_CCW = new System.Windows.Forms.Button();
            this.startMotor = new System.Windows.Forms.Button();
            this.stopMotor = new System.Windows.Forms.Button();
            this.DataType = new System.Windows.Forms.Label();
            this.DataType2 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tBoxSpd = new System.Windows.Forms.TextBox();
            this.lblSetpoint = new System.Windows.Forms.Label();
            this.tBoxSet = new System.Windows.Forms.TextBox();
            this.modeSelLabel = new System.Windows.Forms.Label();
            this.modeList = new System.Windows.Forms.ListBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadCurr = new System.Windows.Forms.Button();
            this.btnTemp = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnInputVoltage = new System.Windows.Forms.Button();
            this.btnVelocity = new System.Windows.Forms.Button();
            this.btnLoadVoltage = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tStripCmd = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStripCmdSent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStripErrorText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStripErrorMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rBoxStatus = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tStripCLI_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripCLI = new System.Windows.Forms.ToolStripTextBox();
            this.tStripListCMD = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenu_clear.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBoxBaudRate);
            this.groupBox1.Controls.Add(this.cBoxCOMPORT);
            this.groupBox1.Location = new System.Drawing.Point(13, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(327, 248);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com Port Control";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnClearScreen, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOpen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnReset, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 88);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(299, 148);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(4, 78);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 66);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.AutoSize = true;
            this.btnClearScreen.ContextMenuStrip = this.contextMenu_clear;
            this.btnClearScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearScreen.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClearScreen.Location = new System.Drawing.Point(153, 4);
            this.btnClearScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.Size = new System.Drawing.Size(142, 66);
            this.btnClearScreen.TabIndex = 4;
            this.btnClearScreen.Text = "Clear Screen";
            this.btnClearScreen.UseVisualStyleBackColor = true;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // contextMenu_clear
            // 
            this.contextMenu_clear.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu_clear.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripClearInputs,
            this.tStripClearArduino,
            this.tStripClearStatus,
            this.tStripClearError});
            this.contextMenu_clear.Name = "contextMenuStrip1";
            this.contextMenu_clear.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenu_clear.Size = new System.Drawing.Size(238, 100);
            this.contextMenu_clear.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_clear_ItemClicked);
            // 
            // tStripClearInputs
            // 
            this.tStripClearInputs.Name = "tStripClearInputs";
            this.tStripClearInputs.Size = new System.Drawing.Size(237, 24);
            this.tStripClearInputs.Text = "Clear Inputs";
            // 
            // tStripClearArduino
            // 
            this.tStripClearArduino.Name = "tStripClearArduino";
            this.tStripClearArduino.Size = new System.Drawing.Size(237, 24);
            this.tStripClearArduino.Text = "Clear Arduino Messages";
            // 
            // tStripClearStatus
            // 
            this.tStripClearStatus.Name = "tStripClearStatus";
            this.tStripClearStatus.Size = new System.Drawing.Size(237, 24);
            this.tStripClearStatus.Text = "Clear Status Messages";
            // 
            // tStripClearError
            // 
            this.tStripClearError.Name = "tStripClearError";
            this.tStripClearError.Size = new System.Drawing.Size(237, 24);
            this.tStripClearError.Text = "Clear Error Messages";
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = true;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(4, 4);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(141, 66);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(152, 77);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(144, 68);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset Arduino";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAUD RATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM PORT";
            // 
            // CBoxBaudRate
            // 
            this.CBoxBaudRate.DisplayMember = "7";
            this.CBoxBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBoxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400"});
            this.CBoxBaudRate.Location = new System.Drawing.Point(135, 57);
            this.CBoxBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.CBoxBaudRate.Name = "CBoxBaudRate";
            this.CBoxBaudRate.Size = new System.Drawing.Size(172, 24);
            this.CBoxBaudRate.TabIndex = 1;
            this.CBoxBaudRate.Text = "115200";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(135, 23);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(4);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(172, 24);
            this.cBoxCOMPORT.Sorted = true;
            this.cBoxCOMPORT.TabIndex = 0;
            this.cBoxCOMPORT.Text = "COM5";
            this.cBoxCOMPORT.DropDown += new System.EventHandler(this.cBoxCOMPORT_DropDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.animatedLED2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.animatedLED1);
            this.groupBox2.Controls.Add(this.animatedLED3);
            this.groupBox2.Location = new System.Drawing.Point(13, 284);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(327, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LED Control";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(16, 22);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(295, 56);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(255, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "Current";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(133, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 29;
            this.label11.Text = "Velocity";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // animatedLED2
            // 
            this.animatedLED2.BackColor = System.Drawing.Color.DarkGreen;
            this.animatedLED2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.animatedLED2.Location = new System.Drawing.Point(135, 86);
            this.animatedLED2.Name = "animatedLED2";
            this.animatedLED2.Size = new System.Drawing.Size(60, 60);
            this.animatedLED2.TabIndex = 26;
            this.animatedLED2.TabStop = false;
            this.animatedLED2.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "Position";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // animatedLED1
            // 
            this.animatedLED1.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.animatedLED1.Location = new System.Drawing.Point(12, 86);
            this.animatedLED1.Name = "animatedLED1";
            this.animatedLED1.Size = new System.Drawing.Size(60, 60);
            this.animatedLED1.TabIndex = 25;
            this.animatedLED1.TabStop = false;
            this.animatedLED1.UseVisualStyleBackColor = false;
            // 
            // animatedLED3
            // 
            this.animatedLED3.BackColor = System.Drawing.Color.DarkBlue;
            this.animatedLED3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.animatedLED3.Location = new System.Drawing.Point(256, 86);
            this.animatedLED3.Name = "animatedLED3";
            this.animatedLED3.Size = new System.Drawing.Size(60, 60);
            this.animatedLED3.TabIndex = 27;
            this.animatedLED3.TabStop = false;
            this.animatedLED3.UseVisualStyleBackColor = false;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rBoxDataIN);
            this.groupBox9.Location = new System.Drawing.Point(348, 37);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(446, 209);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Arduino Messages";
            // 
            // rBoxDataIN
            // 
            this.rBoxDataIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rBoxDataIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBoxDataIN.Location = new System.Drawing.Point(8, 20);
            this.rBoxDataIN.Name = "rBoxDataIN";
            this.rBoxDataIN.ReadOnly = true;
            this.rBoxDataIN.Size = new System.Drawing.Size(427, 180);
            this.rBoxDataIN.TabIndex = 25;
            this.rBoxDataIN.TabStop = false;
            this.rBoxDataIN.Text = "----------------- Arduino Messages ----------------";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.flowLayoutPanel1);
            this.groupBox8.Controls.Add(this.DataType);
            this.groupBox8.Controls.Add(this.DataType2);
            this.groupBox8.Controls.Add(this.lblSpeed);
            this.groupBox8.Controls.Add(this.tBoxSpd);
            this.groupBox8.Controls.Add(this.lblSetpoint);
            this.groupBox8.Controls.Add(this.tBoxSet);
            this.groupBox8.Controls.Add(this.modeSelLabel);
            this.groupBox8.Controls.Add(this.modeList);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(13, 466);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(485, 220);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Motor Control Settings";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCW_CCW);
            this.flowLayoutPanel1.Controls.Add(this.startMotor);
            this.flowLayoutPanel1.Controls.Add(this.stopMotor);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(280, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(191, 158);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // btnCW_CCW
            // 
            this.btnCW_CCW.AutoSize = true;
            this.btnCW_CCW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCW_CCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCW_CCW.Location = new System.Drawing.Point(3, 3);
            this.btnCW_CCW.Name = "btnCW_CCW";
            this.btnCW_CCW.Size = new System.Drawing.Size(184, 32);
            this.btnCW_CCW.TabIndex = 9;
            this.btnCW_CCW.Text = "Clockwise";
            this.btnCW_CCW.UseVisualStyleBackColor = true;
            this.btnCW_CCW.Click += new System.EventHandler(this.btnCW_CCW_Click);
            // 
            // startMotor
            // 
            this.startMotor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startMotor.Location = new System.Drawing.Point(3, 41);
            this.startMotor.Name = "startMotor";
            this.startMotor.Size = new System.Drawing.Size(184, 53);
            this.startMotor.TabIndex = 10;
            this.startMotor.Text = "Start Motor";
            this.startMotor.UseVisualStyleBackColor = true;
            this.startMotor.Click += new System.EventHandler(this.startMotor_Click);
            // 
            // stopMotor
            // 
            this.stopMotor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopMotor.Location = new System.Drawing.Point(3, 100);
            this.stopMotor.Name = "stopMotor";
            this.stopMotor.Size = new System.Drawing.Size(184, 53);
            this.stopMotor.TabIndex = 11;
            this.stopMotor.Text = "Stop Motor";
            this.stopMotor.UseVisualStyleBackColor = true;
            this.stopMotor.Click += new System.EventHandler(this.stopMotor_Click);
            // 
            // DataType
            // 
            this.DataType.AutoSize = true;
            this.DataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataType.Location = new System.Drawing.Point(208, 190);
            this.DataType.Name = "DataType";
            this.DataType.Size = new System.Drawing.Size(27, 20);
            this.DataType.TabIndex = 21;
            this.DataType.Text = "---";
            // 
            // DataType2
            // 
            this.DataType2.AutoSize = true;
            this.DataType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataType2.Location = new System.Drawing.Point(444, 190);
            this.DataType2.Name = "DataType2";
            this.DataType2.Size = new System.Drawing.Size(27, 20);
            this.DataType2.TabIndex = 19;
            this.DataType2.Text = "---";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(258, 190);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(64, 20);
            this.lblSpeed.TabIndex = 10;
            this.lblSpeed.Text = "Input 2:";
            // 
            // tBoxSpd
            // 
            this.tBoxSpd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxSpd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxSpd.Location = new System.Drawing.Point(335, 189);
            this.tBoxSpd.Name = "tBoxSpd";
            this.tBoxSpd.Size = new System.Drawing.Size(93, 19);
            this.tBoxSpd.TabIndex = 8;
            this.tBoxSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBoxSpd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tBoxSpd_KeyUp);
            this.tBoxSpd.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tBoxSpd_MouseDoubleClick);
            // 
            // lblSetpoint
            // 
            this.lblSetpoint.AutoSize = true;
            this.lblSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetpoint.Location = new System.Drawing.Point(8, 190);
            this.lblSetpoint.Name = "lblSetpoint";
            this.lblSetpoint.Size = new System.Drawing.Size(64, 20);
            this.lblSetpoint.TabIndex = 8;
            this.lblSetpoint.Text = "Input 1:";
            // 
            // tBoxSet
            // 
            this.tBoxSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxSet.Location = new System.Drawing.Point(99, 189);
            this.tBoxSet.Name = "tBoxSet";
            this.tBoxSet.Size = new System.Drawing.Size(93, 19);
            this.tBoxSet.TabIndex = 7;
            this.tBoxSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBoxSet.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tBoxSet_KeyUp);
            this.tBoxSet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tBoxSet_MouseDoubleClick);
            // 
            // modeSelLabel
            // 
            this.modeSelLabel.AutoSize = true;
            this.modeSelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeSelLabel.Location = new System.Drawing.Point(1, 20);
            this.modeSelLabel.Name = "modeSelLabel";
            this.modeSelLabel.Size = new System.Drawing.Size(128, 25);
            this.modeSelLabel.TabIndex = 6;
            this.modeSelLabel.Text = "Select Mode:";
            // 
            // modeList
            // 
            this.modeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeList.FormattingEnabled = true;
            this.modeList.ItemHeight = 20;
            this.modeList.Items.AddRange(new object[] {
            "1. Position Control",
            "2. Velocity Control",
            "3. Current Control",
            "4. Current-based Position Control",
            "5. PWM Control"});
            this.modeList.Location = new System.Drawing.Point(6, 48);
            this.modeList.Name = "modeList";
            this.modeList.Size = new System.Drawing.Size(268, 100);
            this.modeList.Sorted = true;
            this.modeList.TabIndex = 3;
            this.modeList.SelectedIndexChanged += new System.EventHandler(this.modeList_SelectedIndexChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tableLayoutPanel1);
            this.groupBox12.Location = new System.Drawing.Point(504, 466);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(290, 220);
            this.groupBox12.TabIndex = 18;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Status Commands";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadCurr, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnTemp, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnPosition, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInputVoltage, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnVelocity, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadVoltage, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 188);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btnLoadCurr
            // 
            this.btnLoadCurr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCurr.Location = new System.Drawing.Point(3, 158);
            this.btnLoadCurr.Name = "btnLoadCurr";
            this.btnLoadCurr.Size = new System.Drawing.Size(265, 27);
            this.btnLoadCurr.TabIndex = 17;
            this.btnLoadCurr.Text = "Load Current";
            this.btnLoadCurr.UseVisualStyleBackColor = true;
            this.btnLoadCurr.Click += new System.EventHandler(this.btnLoadCurr_Click);
            // 
            // btnTemp
            // 
            this.btnTemp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemp.Location = new System.Drawing.Point(3, 127);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(265, 25);
            this.btnTemp.TabIndex = 16;
            this.btnTemp.Text = "Temperature";
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.btnGetTemp_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosition.Location = new System.Drawing.Point(3, 3);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(265, 25);
            this.btnPosition.TabIndex = 12;
            this.btnPosition.Text = "Position";
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnInputVoltage
            // 
            this.btnInputVoltage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInputVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInputVoltage.Location = new System.Drawing.Point(3, 96);
            this.btnInputVoltage.Name = "btnInputVoltage";
            this.btnInputVoltage.Size = new System.Drawing.Size(265, 25);
            this.btnInputVoltage.TabIndex = 15;
            this.btnInputVoltage.Text = "Input Voltage";
            this.btnInputVoltage.UseVisualStyleBackColor = true;
            this.btnInputVoltage.Click += new System.EventHandler(this.btnInputVoltage_Click);
            // 
            // btnVelocity
            // 
            this.btnVelocity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVelocity.Location = new System.Drawing.Point(3, 34);
            this.btnVelocity.Name = "btnVelocity";
            this.btnVelocity.Size = new System.Drawing.Size(265, 25);
            this.btnVelocity.TabIndex = 13;
            this.btnVelocity.Text = "Velocity";
            this.btnVelocity.UseVisualStyleBackColor = true;
            this.btnVelocity.Click += new System.EventHandler(this.btnVelocity_Click);
            // 
            // btnLoadVoltage
            // 
            this.btnLoadVoltage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadVoltage.Location = new System.Drawing.Point(3, 65);
            this.btnLoadVoltage.Name = "btnLoadVoltage";
            this.btnLoadVoltage.Size = new System.Drawing.Size(265, 25);
            this.btnLoadVoltage.TabIndex = 14;
            this.btnLoadVoltage.Text = "Load Voltage";
            this.btnLoadVoltage.UseVisualStyleBackColor = true;
            this.btnLoadVoltage.Click += new System.EventHandler(this.btnLoadVoltage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripStatusLbl,
            this.tStripProgressBar,
            this.tStripCmd,
            this.tStripCmdSent,
            this.tStripErrorText,
            this.tStripErrorMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(805, 26);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tStripStatusLbl
            // 
            this.tStripStatusLbl.Name = "tStripStatusLbl";
            this.tStripStatusLbl.Size = new System.Drawing.Size(79, 20);
            this.tStripStatusLbl.Text = "Port Status";
            // 
            // tStripProgressBar
            // 
            this.tStripProgressBar.Name = "tStripProgressBar";
            this.tStripProgressBar.Size = new System.Drawing.Size(100, 18);
            this.tStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tStripCmd
            // 
            this.tStripCmd.Name = "tStripCmd";
            this.tStripCmd.Size = new System.Drawing.Size(111, 20);
            this.tStripCmd.Text = "Command Sent";
            // 
            // tStripCmdSent
            // 
            this.tStripCmdSent.Name = "tStripCmdSent";
            this.tStripCmdSent.Size = new System.Drawing.Size(27, 20);
            this.tStripCmdSent.Text = "---";
            // 
            // tStripErrorText
            // 
            this.tStripErrorText.Name = "tStripErrorText";
            this.tStripErrorText.Size = new System.Drawing.Size(103, 20);
            this.tStripErrorText.Text = "Error Message";
            // 
            // tStripErrorMsg
            // 
            this.tStripErrorMsg.Name = "tStripErrorMsg";
            this.tStripErrorMsg.Size = new System.Drawing.Size(27, 20);
            this.tStripErrorMsg.Text = "---";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rBoxStatus);
            this.groupBox3.Location = new System.Drawing.Point(348, 246);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(446, 213);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status Messages";
            // 
            // rBoxStatus
            // 
            this.rBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBoxStatus.Location = new System.Drawing.Point(8, 22);
            this.rBoxStatus.Name = "rBoxStatus";
            this.rBoxStatus.ReadOnly = true;
            this.rBoxStatus.Size = new System.Drawing.Size(427, 180);
            this.rBoxStatus.TabIndex = 26;
            this.rBoxStatus.TabStop = false;
            this.rBoxStatus.Text = "------------------ Status Messages -----------------";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripCLI_Menu,
            this.tStripMClearAll,
            this.tStripListCMD,
            this.tStripHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 28);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tStripCLI_Menu
            // 
            this.tStripCLI_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripCLI});
            this.tStripCLI_Menu.Name = "tStripCLI_Menu";
            this.tStripCLI_Menu.Size = new System.Drawing.Size(185, 24);
            this.tStripCLI_Menu.Text = "Command Line Interface";
            this.tStripCLI_Menu.DropDownClosed += new System.EventHandler(this.tStripCLI_Menu_DropDownClosed);
            // 
            // tStripCLI
            // 
            this.tStripCLI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tStripCLI.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tStripCLI.MaxLength = 20;
            this.tStripCLI.Name = "tStripCLI";
            this.tStripCLI.Size = new System.Drawing.Size(100, 23);
            this.tStripCLI.Text = "---";
            this.tStripCLI.ToolTipText = "Type command followed by a \';\'\r\nThen press enter.";
            this.tStripCLI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tStripCLI_KeyDown);
            this.tStripCLI.Click += new System.EventHandler(this.tStripCLI_Click);
            // 
            // tStripListCMD
            // 
            this.tStripListCMD.Name = "tStripListCMD";
            this.tStripListCMD.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.tStripListCMD.Size = new System.Drawing.Size(140, 24);
            this.tStripListCMD.Text = "List of commands";
            this.tStripListCMD.ToolTipText = "Explained Instructions";
            this.tStripListCMD.Click += new System.EventHandler(this.tStripListCMD_Click);
            // 
            // tStripMClearAll
            // 
            this.tStripMClearAll.Name = "tStripMClearAll";
            this.tStripMClearAll.ShortcutKeyDisplayString = "Ctrl + Shift + A";
            this.tStripMClearAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.tStripMClearAll.Size = new System.Drawing.Size(79, 24);
            this.tStripMClearAll.Text = "Clear All";
            this.tStripMClearAll.ToolTipText = "Clears all input and output windows";
            this.tStripMClearAll.Click += new System.EventHandler(this.tStripMClearAll_Click);
            // 
            // tStripHelp
            // 
            this.tStripHelp.Name = "tStripHelp";
            this.tStripHelp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
            this.tStripHelp.Size = new System.Drawing.Size(55, 24);
            this.tStripHelp.Text = "Help";
            this.tStripHelp.ToolTipText = "Instructions";
            this.tStripHelp.Click += new System.EventHandler(this.tStripHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 725);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motor Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.contextMenu_clear.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBoxBaudRate;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnClearScreen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button animatedLED2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button animatedLED1;
        private System.Windows.Forms.Button animatedLED3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button stopMotor;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TextBox tBoxSpd;
        private System.Windows.Forms.Label lblSetpoint;
        private System.Windows.Forms.Button startMotor;
        private System.Windows.Forms.TextBox tBoxSet;
        private System.Windows.Forms.Label modeSelLabel;
        private System.Windows.Forms.ListBox modeList;
        private System.Windows.Forms.Label DataType2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label DataType;
        private System.Windows.Forms.Button btnVelocity;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLoadVoltage;
        private System.Windows.Forms.Button btnInputVoltage;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tStripStatusLbl;
        private System.Windows.Forms.ToolStripProgressBar tStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tStripCmd;
        private System.Windows.Forms.ToolStripStatusLabel tStripCmdSent;
        private System.Windows.Forms.ToolStripStatusLabel tStripErrorText;
        private System.Windows.Forms.ToolStripStatusLabel tStripErrorMsg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rBoxDataIN;
        private System.Windows.Forms.RichTextBox rBoxStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnCW_CCW;
        private System.Windows.Forms.ToolStripMenuItem tStripCLI_Menu;
        private System.Windows.Forms.ToolStripTextBox tStripCLI;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem tStripListCMD;
        private System.Windows.Forms.Button btnLoadCurr;
        private System.Windows.Forms.ContextMenuStrip contextMenu_clear;
        private System.Windows.Forms.ToolStripMenuItem tStripClearInputs;
        private System.Windows.Forms.ToolStripMenuItem tStripClearArduino;
        private System.Windows.Forms.ToolStripMenuItem tStripClearStatus;
        private System.Windows.Forms.ToolStripMenuItem tStripClearError;
        private System.Windows.Forms.ToolStripMenuItem tStripMClearAll;
        private System.Windows.Forms.ToolStripMenuItem tStripHelp;
    }
}

