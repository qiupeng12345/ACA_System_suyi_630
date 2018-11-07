namespace ACA_System.UI
{
    partial class FrmSemiAuto
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
            this.label1 = new System.Windows.Forms.Label();
            this.TmrState = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnJigs = new ACA_Common.ButtonNew();
            this.BtnStart = new ACA_Common.ButtonNew();
            this.BtnExit = new ACA_Common.ButtonNew();
            this.BtnTestComplete = new ACA_Common.ButtonNew();
            this.BtnOutput5 = new ACA_Common.ButtonNew();
            this.BtnOutput4 = new ACA_Common.ButtonNew();
            this.BtnOutput3 = new ACA_Common.ButtonNew();
            this.BtnOutput2 = new ACA_Common.ButtonNew();
            this.BtnOutput1 = new ACA_Common.ButtonNew();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnJigsVoltage = new ACA_Common.ButtonNew();
            this.BtnExit1 = new ACA_Common.ButtonNew();
            this.BtnEndVoltage = new ACA_Common.ButtonNew();
            this.BtnOutPut5Voltage = new ACA_Common.ButtonNew();
            this.BtnOutPut4Voltage = new ACA_Common.ButtonNew();
            this.BtnOutPut3Voltage = new ACA_Common.ButtonNew();
            this.BtnOutPut2Voltage = new ACA_Common.ButtonNew();
            this.BtnOutPut1Voltage = new ACA_Common.ButtonNew();
            this.BtnStartVoltage = new ACA_Common.ButtonNew();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnJigsResidual = new ACA_Common.ButtonNew();
            this.BtnExit2 = new ACA_Common.ButtonNew();
            this.BtnEndResidual = new ACA_Common.ButtonNew();
            this.BtnOutPut5Residual = new ACA_Common.ButtonNew();
            this.BtnOutPut4Residual = new ACA_Common.ButtonNew();
            this.BtnOutPut3Residual = new ACA_Common.ButtonNew();
            this.BtnOutPut2Residual = new ACA_Common.ButtonNew();
            this.BtnOutPut1Residual = new ACA_Common.ButtonNew();
            this.BtnStartResidual = new ACA_Common.ButtonNew();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new ACA_Common.LabelNew();
            this.label20 = new ACA_Common.LabelNew();
            this.label19 = new ACA_Common.LabelNew();
            this.label18 = new ACA_Common.LabelNew();
            this.label17 = new ACA_Common.LabelNew();
            this.label16 = new ACA_Common.LabelNew();
            this.LblLeakCurrentTime = new ACA_Common.LabelNew();
            this.label11 = new ACA_Common.LabelNew();
            this.LblLeakCurrent = new ACA_Common.LabelNew();
            this.label13 = new ACA_Common.LabelNew();
            this.LblVoltageC = new ACA_Common.LabelNew();
            this.label15 = new ACA_Common.LabelNew();
            this.LblVoltageB = new ACA_Common.LabelNew();
            this.label9 = new ACA_Common.LabelNew();
            this.LblVoltageA = new ACA_Common.LabelNew();
            this.label7 = new ACA_Common.LabelNew();
            this.LblTime = new ACA_Common.LabelNew();
            this.label5 = new ACA_Common.LabelNew();
            this.LblCurrent = new ACA_Common.LabelNew();
            this.labelNew1 = new ACA_Common.LabelNew();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "校对测试半自动";
            // 
            // TmrState
            // 
            this.TmrState.Interval = 40;
            this.TmrState.Tick += new System.EventHandler(this.TmrState_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Location = new System.Drawing.Point(6, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(996, 381);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "半自动操作区";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(3, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 348);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.BtnJigs);
            this.tabPage1.Controls.Add(this.BtnStart);
            this.tabPage1.Controls.Add(this.BtnExit);
            this.tabPage1.Controls.Add(this.BtnTestComplete);
            this.tabPage1.Controls.Add(this.BtnOutput5);
            this.tabPage1.Controls.Add(this.BtnOutput4);
            this.tabPage1.Controls.Add(this.BtnOutput3);
            this.tabPage1.Controls.Add(this.BtnOutput2);
            this.tabPage1.Controls.Add(this.BtnOutput1);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "电流半自动";
            // 
            // BtnJigs
            // 
            this.BtnJigs.Address = "120800";
            this.BtnJigs.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnJigs.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJigs.Location = new System.Drawing.Point(61, 216);
            this.BtnJigs.Name = "BtnJigs";
            this.BtnJigs.No = 7;
            this.BtnJigs.Size = new System.Drawing.Size(189, 64);
            this.BtnJigs.StateAddress = "362600";
            this.BtnJigs.TabIndex = 33;
            this.BtnJigs.Text = "夹具进";
            this.BtnJigs.UseVisualStyleBackColor = false;
            this.BtnJigs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnJigs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnStart
            // 
            this.BtnStart.Address = "120801";
            this.BtnStart.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnStart.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(61, 24);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.No = 0;
            this.BtnStart.Size = new System.Drawing.Size(189, 66);
            this.BtnStart.StateAddress = "362601";
            this.BtnStart.TabIndex = 32;
            this.BtnStart.Text = "电流手动调试开始";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnExit
            // 
            this.BtnExit.Address = "";
            this.BtnExit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnExit.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(668, 217);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.No = 0;
            this.BtnExit.Size = new System.Drawing.Size(222, 64);
            this.BtnExit.StateAddress = "";
            this.BtnExit.TabIndex = 25;
            this.BtnExit.Text = "退出半自动";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnTestComplete
            // 
            this.BtnTestComplete.Address = "120808";
            this.BtnTestComplete.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnTestComplete.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnTestComplete.Location = new System.Drawing.Point(61, 124);
            this.BtnTestComplete.Name = "BtnTestComplete";
            this.BtnTestComplete.No = 6;
            this.BtnTestComplete.Size = new System.Drawing.Size(189, 66);
            this.BtnTestComplete.StateAddress = "362608";
            this.BtnTestComplete.TabIndex = 31;
            this.BtnTestComplete.Text = "手动调试完成";
            this.BtnTestComplete.UseVisualStyleBackColor = false;
            this.BtnTestComplete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnTestComplete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutput5
            // 
            this.BtnOutput5.Address = "120806";
            this.BtnOutput5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutput5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutput5.Location = new System.Drawing.Point(349, 216);
            this.BtnOutput5.Name = "BtnOutput5";
            this.BtnOutput5.No = 5;
            this.BtnOutput5.Size = new System.Drawing.Size(222, 65);
            this.BtnOutput5.StateAddress = "362606";
            this.BtnOutput5.TabIndex = 30;
            this.BtnOutput5.Text = "输出预设电流5";
            this.BtnOutput5.UseVisualStyleBackColor = false;
            this.BtnOutput5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutput5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutput4
            // 
            this.BtnOutput4.Address = "120805";
            this.BtnOutput4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutput4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutput4.Location = new System.Drawing.Point(668, 127);
            this.BtnOutput4.Name = "BtnOutput4";
            this.BtnOutput4.No = 4;
            this.BtnOutput4.Size = new System.Drawing.Size(222, 61);
            this.BtnOutput4.StateAddress = "362605";
            this.BtnOutput4.TabIndex = 29;
            this.BtnOutput4.Text = "输出预设电流4";
            this.BtnOutput4.UseVisualStyleBackColor = false;
            this.BtnOutput4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutput4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutput3
            // 
            this.BtnOutput3.Address = "120804";
            this.BtnOutput3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutput3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutput3.Location = new System.Drawing.Point(349, 126);
            this.BtnOutput3.Name = "BtnOutput3";
            this.BtnOutput3.No = 3;
            this.BtnOutput3.Size = new System.Drawing.Size(222, 64);
            this.BtnOutput3.StateAddress = "362604";
            this.BtnOutput3.TabIndex = 28;
            this.BtnOutput3.Text = "输出预设电流3";
            this.BtnOutput3.UseVisualStyleBackColor = false;
            this.BtnOutput3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutput3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutput2
            // 
            this.BtnOutput2.Address = "120803";
            this.BtnOutput2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutput2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutput2.Location = new System.Drawing.Point(668, 26);
            this.BtnOutput2.Name = "BtnOutput2";
            this.BtnOutput2.No = 2;
            this.BtnOutput2.Size = new System.Drawing.Size(222, 65);
            this.BtnOutput2.StateAddress = "362603";
            this.BtnOutput2.TabIndex = 27;
            this.BtnOutput2.Text = "输出预设电流2";
            this.BtnOutput2.UseVisualStyleBackColor = false;
            this.BtnOutput2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutput2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutput1
            // 
            this.BtnOutput1.Address = "120802";
            this.BtnOutput1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutput1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutput1.Location = new System.Drawing.Point(349, 24);
            this.BtnOutput1.Name = "BtnOutput1";
            this.BtnOutput1.No = 1;
            this.BtnOutput1.Size = new System.Drawing.Size(222, 66);
            this.BtnOutput1.StateAddress = "362602";
            this.BtnOutput1.TabIndex = 26;
            this.BtnOutput1.Text = "输出预设电流1";
            this.BtnOutput1.UseVisualStyleBackColor = false;
            this.BtnOutput1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutput1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Controls.Add(this.BtnJigsVoltage);
            this.tabPage2.Controls.Add(this.BtnExit1);
            this.tabPage2.Controls.Add(this.BtnEndVoltage);
            this.tabPage2.Controls.Add(this.BtnOutPut5Voltage);
            this.tabPage2.Controls.Add(this.BtnOutPut4Voltage);
            this.tabPage2.Controls.Add(this.BtnOutPut3Voltage);
            this.tabPage2.Controls.Add(this.BtnOutPut2Voltage);
            this.tabPage2.Controls.Add(this.BtnOutPut1Voltage);
            this.tabPage2.Controls.Add(this.BtnStartVoltage);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "电压半自动";
            // 
            // BtnJigsVoltage
            // 
            this.BtnJigsVoltage.Address = "120800";
            this.BtnJigsVoltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnJigsVoltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJigsVoltage.Location = new System.Drawing.Point(62, 217);
            this.BtnJigsVoltage.Name = "BtnJigsVoltage";
            this.BtnJigsVoltage.No = 0;
            this.BtnJigsVoltage.Size = new System.Drawing.Size(257, 63);
            this.BtnJigsVoltage.StateAddress = "362600";
            this.BtnJigsVoltage.TabIndex = 19;
            this.BtnJigsVoltage.Text = "夹具进";
            this.BtnJigsVoltage.UseVisualStyleBackColor = false;
            this.BtnJigsVoltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnJigsVoltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnExit1
            // 
            this.BtnExit1.Address = null;
            this.BtnExit1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnExit1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit1.Location = new System.Drawing.Point(658, 217);
            this.BtnExit1.Name = "BtnExit1";
            this.BtnExit1.No = 0;
            this.BtnExit1.Size = new System.Drawing.Size(203, 59);
            this.BtnExit1.StateAddress = null;
            this.BtnExit1.TabIndex = 18;
            this.BtnExit1.Text = "退出半自动";
            this.BtnExit1.UseVisualStyleBackColor = false;
            this.BtnExit1.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnEndVoltage
            // 
            this.BtnEndVoltage.Address = "120808";
            this.BtnEndVoltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnEndVoltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnEndVoltage.Location = new System.Drawing.Point(62, 122);
            this.BtnEndVoltage.Name = "BtnEndVoltage";
            this.BtnEndVoltage.No = 0;
            this.BtnEndVoltage.Size = new System.Drawing.Size(257, 61);
            this.BtnEndVoltage.StateAddress = "362608";
            this.BtnEndVoltage.TabIndex = 17;
            this.BtnEndVoltage.Text = "手动调试完成";
            this.BtnEndVoltage.UseVisualStyleBackColor = false;
            this.BtnEndVoltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnEndVoltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut5Voltage
            // 
            this.BtnOutPut5Voltage.Address = "121005";
            this.BtnOutPut5Voltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut5Voltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut5Voltage.Location = new System.Drawing.Point(376, 219);
            this.BtnOutPut5Voltage.Name = "BtnOutPut5Voltage";
            this.BtnOutPut5Voltage.No = 0;
            this.BtnOutPut5Voltage.Size = new System.Drawing.Size(206, 59);
            this.BtnOutPut5Voltage.StateAddress = "362805";
            this.BtnOutPut5Voltage.TabIndex = 16;
            this.BtnOutPut5Voltage.Text = "输出预设电压5";
            this.BtnOutPut5Voltage.UseVisualStyleBackColor = false;
            this.BtnOutPut5Voltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut5Voltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut4Voltage
            // 
            this.BtnOutPut4Voltage.Address = "121004";
            this.BtnOutPut4Voltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut4Voltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut4Voltage.Location = new System.Drawing.Point(658, 120);
            this.BtnOutPut4Voltage.Name = "BtnOutPut4Voltage";
            this.BtnOutPut4Voltage.No = 0;
            this.BtnOutPut4Voltage.Size = new System.Drawing.Size(203, 63);
            this.BtnOutPut4Voltage.StateAddress = "362804";
            this.BtnOutPut4Voltage.TabIndex = 15;
            this.BtnOutPut4Voltage.Text = "输出预设电压4";
            this.BtnOutPut4Voltage.UseVisualStyleBackColor = false;
            this.BtnOutPut4Voltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut4Voltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut3Voltage
            // 
            this.BtnOutPut3Voltage.Address = "121003";
            this.BtnOutPut3Voltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut3Voltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut3Voltage.Location = new System.Drawing.Point(376, 122);
            this.BtnOutPut3Voltage.Name = "BtnOutPut3Voltage";
            this.BtnOutPut3Voltage.No = 0;
            this.BtnOutPut3Voltage.Size = new System.Drawing.Size(206, 61);
            this.BtnOutPut3Voltage.StateAddress = "362803";
            this.BtnOutPut3Voltage.TabIndex = 14;
            this.BtnOutPut3Voltage.Text = "输出预设电压3";
            this.BtnOutPut3Voltage.UseVisualStyleBackColor = false;
            this.BtnOutPut3Voltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut3Voltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut2Voltage
            // 
            this.BtnOutPut2Voltage.Address = "121002";
            this.BtnOutPut2Voltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut2Voltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut2Voltage.Location = new System.Drawing.Point(658, 21);
            this.BtnOutPut2Voltage.Name = "BtnOutPut2Voltage";
            this.BtnOutPut2Voltage.No = 0;
            this.BtnOutPut2Voltage.Size = new System.Drawing.Size(203, 61);
            this.BtnOutPut2Voltage.StateAddress = "362802";
            this.BtnOutPut2Voltage.TabIndex = 13;
            this.BtnOutPut2Voltage.Text = "输出预设电压2";
            this.BtnOutPut2Voltage.UseVisualStyleBackColor = false;
            this.BtnOutPut2Voltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut2Voltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut1Voltage
            // 
            this.BtnOutPut1Voltage.Address = "121001";
            this.BtnOutPut1Voltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut1Voltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut1Voltage.Location = new System.Drawing.Point(376, 23);
            this.BtnOutPut1Voltage.Name = "BtnOutPut1Voltage";
            this.BtnOutPut1Voltage.No = 0;
            this.BtnOutPut1Voltage.Size = new System.Drawing.Size(206, 63);
            this.BtnOutPut1Voltage.StateAddress = "362801";
            this.BtnOutPut1Voltage.TabIndex = 12;
            this.BtnOutPut1Voltage.Text = "输出预设电压1";
            this.BtnOutPut1Voltage.UseVisualStyleBackColor = false;
            this.BtnOutPut1Voltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut1Voltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnStartVoltage
            // 
            this.BtnStartVoltage.Address = "121000";
            this.BtnStartVoltage.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnStartVoltage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStartVoltage.Location = new System.Drawing.Point(62, 23);
            this.BtnStartVoltage.Name = "BtnStartVoltage";
            this.BtnStartVoltage.No = 0;
            this.BtnStartVoltage.Size = new System.Drawing.Size(257, 61);
            this.BtnStartVoltage.StateAddress = "362800";
            this.BtnStartVoltage.TabIndex = 11;
            this.BtnStartVoltage.Text = "电压手动调试开始";
            this.BtnStartVoltage.UseVisualStyleBackColor = false;
            this.BtnStartVoltage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStartVoltage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage3.Controls.Add(this.BtnJigsResidual);
            this.tabPage3.Controls.Add(this.BtnExit2);
            this.tabPage3.Controls.Add(this.BtnEndResidual);
            this.tabPage3.Controls.Add(this.BtnOutPut5Residual);
            this.tabPage3.Controls.Add(this.BtnOutPut4Residual);
            this.tabPage3.Controls.Add(this.BtnOutPut3Residual);
            this.tabPage3.Controls.Add(this.BtnOutPut2Residual);
            this.tabPage3.Controls.Add(this.BtnOutPut1Residual);
            this.tabPage3.Controls.Add(this.BtnStartResidual);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(976, 304);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "漏电流半自动";
            // 
            // BtnJigsResidual
            // 
            this.BtnJigsResidual.Address = "120800";
            this.BtnJigsResidual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnJigsResidual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJigsResidual.Location = new System.Drawing.Point(55, 221);
            this.BtnJigsResidual.Name = "BtnJigsResidual";
            this.BtnJigsResidual.No = 0;
            this.BtnJigsResidual.Size = new System.Drawing.Size(306, 62);
            this.BtnJigsResidual.StateAddress = "362600";
            this.BtnJigsResidual.TabIndex = 34;
            this.BtnJigsResidual.Text = "夹具进";
            this.BtnJigsResidual.UseVisualStyleBackColor = false;
            this.BtnJigsResidual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnJigsResidual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnExit2
            // 
            this.BtnExit2.Address = null;
            this.BtnExit2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnExit2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit2.Location = new System.Drawing.Point(701, 221);
            this.BtnExit2.Name = "BtnExit2";
            this.BtnExit2.No = 0;
            this.BtnExit2.Size = new System.Drawing.Size(225, 62);
            this.BtnExit2.StateAddress = null;
            this.BtnExit2.TabIndex = 33;
            this.BtnExit2.Text = "退出半自动";
            this.BtnExit2.UseVisualStyleBackColor = false;
            this.BtnExit2.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnEndResidual
            // 
            this.BtnEndResidual.Address = "120808";
            this.BtnEndResidual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnEndResidual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnEndResidual.Location = new System.Drawing.Point(55, 125);
            this.BtnEndResidual.Name = "BtnEndResidual";
            this.BtnEndResidual.No = 0;
            this.BtnEndResidual.Size = new System.Drawing.Size(306, 62);
            this.BtnEndResidual.StateAddress = "362608";
            this.BtnEndResidual.TabIndex = 32;
            this.BtnEndResidual.Text = "手动调试完成";
            this.BtnEndResidual.UseVisualStyleBackColor = false;
            this.BtnEndResidual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnEndResidual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut5Residual
            // 
            this.BtnOutPut5Residual.Address = "121205";
            this.BtnOutPut5Residual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut5Residual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut5Residual.Location = new System.Drawing.Point(414, 221);
            this.BtnOutPut5Residual.Name = "BtnOutPut5Residual";
            this.BtnOutPut5Residual.No = 0;
            this.BtnOutPut5Residual.Size = new System.Drawing.Size(225, 62);
            this.BtnOutPut5Residual.StateAddress = "363005";
            this.BtnOutPut5Residual.TabIndex = 31;
            this.BtnOutPut5Residual.Text = "输出预设漏电电流5";
            this.BtnOutPut5Residual.UseVisualStyleBackColor = false;
            this.BtnOutPut5Residual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut5Residual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut4Residual
            // 
            this.BtnOutPut4Residual.Address = "121204";
            this.BtnOutPut4Residual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut4Residual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut4Residual.Location = new System.Drawing.Point(701, 125);
            this.BtnOutPut4Residual.Name = "BtnOutPut4Residual";
            this.BtnOutPut4Residual.No = 0;
            this.BtnOutPut4Residual.Size = new System.Drawing.Size(225, 62);
            this.BtnOutPut4Residual.StateAddress = "363004";
            this.BtnOutPut4Residual.TabIndex = 30;
            this.BtnOutPut4Residual.Text = "输出预设漏电电流4";
            this.BtnOutPut4Residual.UseVisualStyleBackColor = false;
            this.BtnOutPut4Residual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut4Residual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut3Residual
            // 
            this.BtnOutPut3Residual.Address = "121203";
            this.BtnOutPut3Residual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut3Residual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut3Residual.Location = new System.Drawing.Point(414, 125);
            this.BtnOutPut3Residual.Name = "BtnOutPut3Residual";
            this.BtnOutPut3Residual.No = 0;
            this.BtnOutPut3Residual.Size = new System.Drawing.Size(225, 62);
            this.BtnOutPut3Residual.StateAddress = "363003";
            this.BtnOutPut3Residual.TabIndex = 29;
            this.BtnOutPut3Residual.Text = "输出预设漏电电流3";
            this.BtnOutPut3Residual.UseVisualStyleBackColor = false;
            this.BtnOutPut3Residual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut3Residual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut2Residual
            // 
            this.BtnOutPut2Residual.Address = "121202";
            this.BtnOutPut2Residual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut2Residual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut2Residual.Location = new System.Drawing.Point(701, 31);
            this.BtnOutPut2Residual.Name = "BtnOutPut2Residual";
            this.BtnOutPut2Residual.No = 0;
            this.BtnOutPut2Residual.Size = new System.Drawing.Size(225, 62);
            this.BtnOutPut2Residual.StateAddress = "363002";
            this.BtnOutPut2Residual.TabIndex = 28;
            this.BtnOutPut2Residual.Text = "输出预设漏电电流2";
            this.BtnOutPut2Residual.UseVisualStyleBackColor = false;
            this.BtnOutPut2Residual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut2Residual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPut1Residual
            // 
            this.BtnOutPut1Residual.Address = "121201";
            this.BtnOutPut1Residual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnOutPut1Residual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPut1Residual.Location = new System.Drawing.Point(414, 31);
            this.BtnOutPut1Residual.Name = "BtnOutPut1Residual";
            this.BtnOutPut1Residual.No = 0;
            this.BtnOutPut1Residual.Size = new System.Drawing.Size(225, 62);
            this.BtnOutPut1Residual.StateAddress = "363001";
            this.BtnOutPut1Residual.TabIndex = 27;
            this.BtnOutPut1Residual.Text = "输出预设漏电电流1";
            this.BtnOutPut1Residual.UseVisualStyleBackColor = false;
            this.BtnOutPut1Residual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPut1Residual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnStartResidual
            // 
            this.BtnStartResidual.Address = "121200";
            this.BtnStartResidual.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BtnStartResidual.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStartResidual.Location = new System.Drawing.Point(55, 31);
            this.BtnStartResidual.Name = "BtnStartResidual";
            this.BtnStartResidual.No = 0;
            this.BtnStartResidual.Size = new System.Drawing.Size(306, 62);
            this.BtnStartResidual.StateAddress = "363000";
            this.BtnStartResidual.TabIndex = 26;
            this.BtnStartResidual.Text = "漏电流手动调试开始";
            this.BtnStartResidual.UseVisualStyleBackColor = false;
            this.BtnStartResidual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStartResidual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.LblLeakCurrentTime);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.LblLeakCurrent);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.LblVoltageC);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.LblVoltageB);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LblVoltageA);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LblTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LblCurrent);
            this.groupBox1.Controls.Add(this.labelNew1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 639);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "半自动显示";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(897, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "s";
            // 
            // label21
            // 
            this.label21.Address = null;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(897, 153);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 24);
            this.label21.StateAddress = null;
            this.label21.TabIndex = 40;
            this.label21.Text = "ms";
            // 
            // label20
            // 
            this.label20.Address = null;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(897, 101);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 24);
            this.label20.StateAddress = null;
            this.label20.TabIndex = 39;
            this.label20.Text = "mA";
            // 
            // label19
            // 
            this.label19.Address = null;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(423, 101);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 24);
            this.label19.StateAddress = null;
            this.label19.TabIndex = 38;
            this.label19.Text = "V";
            // 
            // label18
            // 
            this.label18.Address = null;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(423, 205);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 24);
            this.label18.StateAddress = null;
            this.label18.TabIndex = 37;
            this.label18.Text = "V";
            // 
            // label17
            // 
            this.label17.Address = null;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(423, 153);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 24);
            this.label17.StateAddress = null;
            this.label17.TabIndex = 36;
            this.label17.Text = "V";
            // 
            // label16
            // 
            this.label16.Address = null;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(423, 43);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 24);
            this.label16.StateAddress = null;
            this.label16.TabIndex = 35;
            this.label16.Text = "A";
            // 
            // LblLeakCurrentTime
            // 
            this.LblLeakCurrentTime.Address = "3652";
            this.LblLeakCurrentTime.AutoSize = true;
            this.LblLeakCurrentTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblLeakCurrentTime.Location = new System.Drawing.Point(720, 153);
            this.LblLeakCurrentTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblLeakCurrentTime.Name = "LblLeakCurrentTime";
            this.LblLeakCurrentTime.Size = new System.Drawing.Size(154, 24);
            this.LblLeakCurrentTime.StateAddress = "3653";
            this.LblLeakCurrentTime.TabIndex = 34;
            this.LblLeakCurrentTime.Text = "当前漏电输出";
            // 
            // label11
            // 
            this.label11.Address = null;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(505, 153);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(226, 24);
            this.label11.StateAddress = null;
            this.label11.TabIndex = 33;
            this.label11.Text = "当前漏电输出时间：";
            // 
            // LblLeakCurrent
            // 
            this.LblLeakCurrent.Address = "3650";
            this.LblLeakCurrent.AutoSize = true;
            this.LblLeakCurrent.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblLeakCurrent.Location = new System.Drawing.Point(719, 101);
            this.LblLeakCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblLeakCurrent.Name = "LblLeakCurrent";
            this.LblLeakCurrent.Size = new System.Drawing.Size(154, 24);
            this.LblLeakCurrent.StateAddress = "3651";
            this.LblLeakCurrent.TabIndex = 32;
            this.LblLeakCurrent.Text = "当前漏电电流";
            // 
            // label13
            // 
            this.label13.Address = null;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(505, 101);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 24);
            this.label13.StateAddress = null;
            this.label13.TabIndex = 31;
            this.label13.Text = "当前漏电电流：";
            // 
            // LblVoltageC
            // 
            this.LblVoltageC.Address = "3648";
            this.LblVoltageC.AutoSize = true;
            this.LblVoltageC.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblVoltageC.Location = new System.Drawing.Point(254, 101);
            this.LblVoltageC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVoltageC.Name = "LblVoltageC";
            this.LblVoltageC.Size = new System.Drawing.Size(142, 24);
            this.LblVoltageC.StateAddress = "3649";
            this.LblVoltageC.TabIndex = 30;
            this.LblVoltageC.Text = "当前C相电压";
            // 
            // label15
            // 
            this.label15.Address = null;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(83, 101);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(166, 24);
            this.label15.StateAddress = null;
            this.label15.TabIndex = 29;
            this.label15.Text = "当前C相电压：";
            // 
            // LblVoltageB
            // 
            this.LblVoltageB.Address = "3646";
            this.LblVoltageB.AutoSize = true;
            this.LblVoltageB.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblVoltageB.Location = new System.Drawing.Point(254, 205);
            this.LblVoltageB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVoltageB.Name = "LblVoltageB";
            this.LblVoltageB.Size = new System.Drawing.Size(142, 24);
            this.LblVoltageB.StateAddress = "3647";
            this.LblVoltageB.TabIndex = 28;
            this.LblVoltageB.Text = "当前B相电压";
            // 
            // label9
            // 
            this.label9.Address = null;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(83, 205);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 24);
            this.label9.StateAddress = null;
            this.label9.TabIndex = 27;
            this.label9.Text = "当前B相电压：";
            // 
            // LblVoltageA
            // 
            this.LblVoltageA.Address = "3644";
            this.LblVoltageA.AutoSize = true;
            this.LblVoltageA.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblVoltageA.Location = new System.Drawing.Point(254, 153);
            this.LblVoltageA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVoltageA.Name = "LblVoltageA";
            this.LblVoltageA.Size = new System.Drawing.Size(142, 24);
            this.LblVoltageA.StateAddress = "3645";
            this.LblVoltageA.TabIndex = 26;
            this.LblVoltageA.Text = "当前A相电压";
            // 
            // label7
            // 
            this.label7.Address = null;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(83, 153);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 24);
            this.label7.StateAddress = null;
            this.label7.TabIndex = 25;
            this.label7.Text = "当前A相电压：";
            // 
            // LblTime
            // 
            this.LblTime.Address = "3642";
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(720, 43);
            this.LblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(106, 24);
            this.LblTime.StateAddress = "3643";
            this.LblTime.TabIndex = 24;
            this.LblTime.Text = "当前时间";
            // 
            // label5
            // 
            this.label5.Address = null;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(505, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.StateAddress = null;
            this.label5.TabIndex = 23;
            this.label5.Text = "当前时间：";
            // 
            // LblCurrent
            // 
            this.LblCurrent.Address = "3640";
            this.LblCurrent.AutoSize = true;
            this.LblCurrent.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCurrent.Location = new System.Drawing.Point(254, 43);
            this.LblCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCurrent.Name = "LblCurrent";
            this.LblCurrent.Size = new System.Drawing.Size(106, 24);
            this.LblCurrent.StateAddress = "3641";
            this.LblCurrent.TabIndex = 22;
            this.LblCurrent.Text = "当前电流";
            // 
            // labelNew1
            // 
            this.labelNew1.Address = null;
            this.labelNew1.AutoSize = true;
            this.labelNew1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNew1.ForeColor = System.Drawing.Color.Red;
            this.labelNew1.Location = new System.Drawing.Point(83, 43);
            this.labelNew1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNew1.Name = "labelNew1";
            this.labelNew1.Size = new System.Drawing.Size(130, 24);
            this.labelNew1.StateAddress = null;
            this.labelNew1.TabIndex = 21;
            this.labelNew1.Text = "当前电流：";
            // 
            // FrmSemiAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmSemiAuto";
            this.Text = "电流测试半自动";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCurrent_Load);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TmrState;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ACA_Common.ButtonNew BtnJigs;
        private ACA_Common.ButtonNew BtnStart;
        private ACA_Common.ButtonNew BtnExit;
        private ACA_Common.ButtonNew BtnTestComplete;
        private ACA_Common.ButtonNew BtnOutput5;
        private ACA_Common.ButtonNew BtnOutput4;
        private ACA_Common.ButtonNew BtnOutput3;
        private ACA_Common.ButtonNew BtnOutput2;
        private ACA_Common.ButtonNew BtnOutput1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private ACA_Common.LabelNew label21;
        private ACA_Common.LabelNew label20;
        private ACA_Common.LabelNew label19;
        private ACA_Common.LabelNew label18;
        private ACA_Common.LabelNew label17;
        private ACA_Common.LabelNew label16;
        private ACA_Common.LabelNew LblLeakCurrentTime;
        private ACA_Common.LabelNew label11;
        private ACA_Common.LabelNew LblLeakCurrent;
        private ACA_Common.LabelNew label13;
        private ACA_Common.LabelNew LblVoltageC;
        private ACA_Common.LabelNew label15;
        private ACA_Common.LabelNew LblVoltageB;
        private ACA_Common.LabelNew label9;
        private ACA_Common.LabelNew LblVoltageA;
        private ACA_Common.LabelNew label7;
        private ACA_Common.LabelNew LblTime;
        private ACA_Common.LabelNew label5;
        private ACA_Common.LabelNew LblCurrent;
        private ACA_Common.LabelNew labelNew1;
        private ACA_Common.ButtonNew BtnJigsVoltage;
        private ACA_Common.ButtonNew BtnExit1;
        private ACA_Common.ButtonNew BtnEndVoltage;
        private ACA_Common.ButtonNew BtnOutPut5Voltage;
        private ACA_Common.ButtonNew BtnOutPut4Voltage;
        private ACA_Common.ButtonNew BtnOutPut3Voltage;
        private ACA_Common.ButtonNew BtnOutPut2Voltage;
        private ACA_Common.ButtonNew BtnOutPut1Voltage;
        private ACA_Common.ButtonNew BtnStartVoltage;
        private ACA_Common.ButtonNew BtnJigsResidual;
        private ACA_Common.ButtonNew BtnExit2;
        private ACA_Common.ButtonNew BtnEndResidual;
        private ACA_Common.ButtonNew BtnOutPut5Residual;
        private ACA_Common.ButtonNew BtnOutPut4Residual;
        private ACA_Common.ButtonNew BtnOutPut3Residual;
        private ACA_Common.ButtonNew BtnOutPut2Residual;
        private ACA_Common.ButtonNew BtnOutPut1Residual;
        private ACA_Common.ButtonNew BtnStartResidual;
    }
}