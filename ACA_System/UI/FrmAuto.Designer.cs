﻿namespace ACA_System.UI
{
    partial class FrmAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GbxState = new System.Windows.Forms.GroupBox();
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
            this.label1 = new ACA_Common.LabelNew();
            this.GbxControl = new System.Windows.Forms.GroupBox();
            this.BtnEnd = new ACA_Common.ButtonNew();
            this.BtnJigs = new ACA_Common.ButtonNew();
            this.BtnReady = new ACA_Common.ButtonNew();
            this.BtnAlarm = new ACA_Common.ButtonNew();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnStop = new ACA_Common.ButtonNew();
            this.BtnStart = new ACA_Common.ButtonNew();
            this.TmrState = new System.Windows.Forms.Timer(this.components);
            this.GbxAlarm = new System.Windows.Forms.GroupBox();
            this.DgvAlarm = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnNo = new ACA_Common.ButtonNew();
            this.BtnOk = new ACA_Common.ButtonNew();
            this.LblManualJudge = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.label2 = new ACA_Common.LabelNew();
            this.LblSelectModel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GbxState.SuspendLayout();
            this.GbxControl.SuspendLayout();
            this.GbxAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbxState
            // 
            this.GbxState.Controls.Add(this.label4);
            this.GbxState.Controls.Add(this.label21);
            this.GbxState.Controls.Add(this.label20);
            this.GbxState.Controls.Add(this.label19);
            this.GbxState.Controls.Add(this.label18);
            this.GbxState.Controls.Add(this.label17);
            this.GbxState.Controls.Add(this.label16);
            this.GbxState.Controls.Add(this.LblLeakCurrentTime);
            this.GbxState.Controls.Add(this.label11);
            this.GbxState.Controls.Add(this.LblLeakCurrent);
            this.GbxState.Controls.Add(this.label13);
            this.GbxState.Controls.Add(this.LblVoltageC);
            this.GbxState.Controls.Add(this.label15);
            this.GbxState.Controls.Add(this.LblVoltageB);
            this.GbxState.Controls.Add(this.label9);
            this.GbxState.Controls.Add(this.LblVoltageA);
            this.GbxState.Controls.Add(this.label7);
            this.GbxState.Controls.Add(this.LblTime);
            this.GbxState.Controls.Add(this.label5);
            this.GbxState.Controls.Add(this.LblCurrent);
            this.GbxState.Controls.Add(this.label1);
            this.GbxState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GbxState.Location = new System.Drawing.Point(22, 58);
            this.GbxState.Margin = new System.Windows.Forms.Padding(4);
            this.GbxState.Name = "GbxState";
            this.GbxState.Padding = new System.Windows.Forms.Padding(4);
            this.GbxState.Size = new System.Drawing.Size(1012, 225);
            this.GbxState.TabIndex = 2;
            this.GbxState.TabStop = false;
            this.GbxState.Text = "工作状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(892, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "s";
            // 
            // label21
            // 
            this.label21.Address = null;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(892, 137);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 24);
            this.label21.StateAddress = null;
            this.label21.TabIndex = 19;
            this.label21.Text = "ms";
            // 
            // label20
            // 
            this.label20.Address = null;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(892, 85);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 24);
            this.label20.StateAddress = null;
            this.label20.TabIndex = 18;
            this.label20.Text = "mA";
            // 
            // label19
            // 
            this.label19.Address = null;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(418, 189);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 24);
            this.label19.StateAddress = null;
            this.label19.TabIndex = 17;
            this.label19.Text = "V";
            // 
            // label18
            // 
            this.label18.Address = null;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(418, 137);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 24);
            this.label18.StateAddress = null;
            this.label18.TabIndex = 16;
            this.label18.Text = "V";
            // 
            // label17
            // 
            this.label17.Address = null;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(418, 85);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 24);
            this.label17.StateAddress = null;
            this.label17.TabIndex = 15;
            this.label17.Text = "V";
            // 
            // label16
            // 
            this.label16.Address = null;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(418, 27);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 24);
            this.label16.StateAddress = null;
            this.label16.TabIndex = 14;
            this.label16.Text = "A";
            // 
            // LblLeakCurrentTime
            // 
            this.LblLeakCurrentTime.Address = "3652";
            this.LblLeakCurrentTime.AutoSize = true;
            this.LblLeakCurrentTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblLeakCurrentTime.Location = new System.Drawing.Point(715, 137);
            this.LblLeakCurrentTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblLeakCurrentTime.Name = "LblLeakCurrentTime";
            this.LblLeakCurrentTime.Size = new System.Drawing.Size(154, 24);
            this.LblLeakCurrentTime.StateAddress = "3653";
            this.LblLeakCurrentTime.TabIndex = 13;
            this.LblLeakCurrentTime.Text = "当前漏电输出";
            // 
            // label11
            // 
            this.label11.Address = null;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(500, 137);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(226, 24);
            this.label11.StateAddress = null;
            this.label11.TabIndex = 12;
            this.label11.Text = "当前漏电输出时间：";
            // 
            // LblLeakCurrent
            // 
            this.LblLeakCurrent.Address = "3650";
            this.LblLeakCurrent.AutoSize = true;
            this.LblLeakCurrent.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblLeakCurrent.Location = new System.Drawing.Point(714, 85);
            this.LblLeakCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblLeakCurrent.Name = "LblLeakCurrent";
            this.LblLeakCurrent.Size = new System.Drawing.Size(154, 24);
            this.LblLeakCurrent.StateAddress = "3651";
            this.LblLeakCurrent.TabIndex = 11;
            this.LblLeakCurrent.Text = "当前漏电电流";
            // 
            // label13
            // 
            this.label13.Address = null;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(500, 85);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 24);
            this.label13.StateAddress = null;
            this.label13.TabIndex = 10;
            this.label13.Text = "当前漏电电流：";
            // 
            // LblVoltageC
            // 
            this.LblVoltageC.Address = "3648";
            this.LblVoltageC.AutoSize = true;
            this.LblVoltageC.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblVoltageC.Location = new System.Drawing.Point(249, 189);
            this.LblVoltageC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVoltageC.Name = "LblVoltageC";
            this.LblVoltageC.Size = new System.Drawing.Size(142, 24);
            this.LblVoltageC.StateAddress = "3649";
            this.LblVoltageC.TabIndex = 9;
            this.LblVoltageC.Text = "当前C相电压";
            // 
            // label15
            // 
            this.label15.Address = null;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(78, 189);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(166, 24);
            this.label15.StateAddress = null;
            this.label15.TabIndex = 8;
            this.label15.Text = "当前C相电压：";
            // 
            // LblVoltageB
            // 
            this.LblVoltageB.Address = "3646";
            this.LblVoltageB.AutoSize = true;
            this.LblVoltageB.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblVoltageB.Location = new System.Drawing.Point(249, 137);
            this.LblVoltageB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVoltageB.Name = "LblVoltageB";
            this.LblVoltageB.Size = new System.Drawing.Size(142, 24);
            this.LblVoltageB.StateAddress = "3647";
            this.LblVoltageB.TabIndex = 7;
            this.LblVoltageB.Text = "当前B相电压";
            // 
            // label9
            // 
            this.label9.Address = null;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(78, 137);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 24);
            this.label9.StateAddress = null;
            this.label9.TabIndex = 6;
            this.label9.Text = "当前B相电压：";
            // 
            // LblVoltageA
            // 
            this.LblVoltageA.Address = "3644";
            this.LblVoltageA.AutoSize = true;
            this.LblVoltageA.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblVoltageA.Location = new System.Drawing.Point(249, 85);
            this.LblVoltageA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVoltageA.Name = "LblVoltageA";
            this.LblVoltageA.Size = new System.Drawing.Size(142, 24);
            this.LblVoltageA.StateAddress = "3645";
            this.LblVoltageA.TabIndex = 5;
            this.LblVoltageA.Text = "当前A相电压";
            // 
            // label7
            // 
            this.label7.Address = null;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(78, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 24);
            this.label7.StateAddress = null;
            this.label7.TabIndex = 4;
            this.label7.Text = "当前A相电压：";
            // 
            // LblTime
            // 
            this.LblTime.Address = "3642";
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(714, 27);
            this.LblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(106, 24);
            this.LblTime.StateAddress = "3643";
            this.LblTime.TabIndex = 3;
            this.LblTime.Text = "当前时间";
            // 
            // label5
            // 
            this.label5.Address = null;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(500, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.StateAddress = null;
            this.label5.TabIndex = 2;
            this.label5.Text = "当前时间：";
            // 
            // LblCurrent
            // 
            this.LblCurrent.Address = "3640";
            this.LblCurrent.AutoSize = true;
            this.LblCurrent.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCurrent.Location = new System.Drawing.Point(249, 27);
            this.LblCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCurrent.Name = "LblCurrent";
            this.LblCurrent.Size = new System.Drawing.Size(106, 24);
            this.LblCurrent.StateAddress = "3641";
            this.LblCurrent.TabIndex = 1;
            this.LblCurrent.Text = "当前电流";
            // 
            // label1
            // 
            this.label1.Address = null;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(78, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.StateAddress = null;
            this.label1.TabIndex = 0;
            this.label1.Text = "当前电流：";
            // 
            // GbxControl
            // 
            this.GbxControl.Controls.Add(this.BtnEnd);
            this.GbxControl.Controls.Add(this.BtnJigs);
            this.GbxControl.Controls.Add(this.BtnReady);
            this.GbxControl.Controls.Add(this.BtnAlarm);
            this.GbxControl.Controls.Add(this.BtnExit);
            this.GbxControl.Controls.Add(this.BtnStop);
            this.GbxControl.Controls.Add(this.BtnStart);
            this.GbxControl.Location = new System.Drawing.Point(641, 291);
            this.GbxControl.Margin = new System.Windows.Forms.Padding(4);
            this.GbxControl.Name = "GbxControl";
            this.GbxControl.Padding = new System.Windows.Forms.Padding(4);
            this.GbxControl.Size = new System.Drawing.Size(387, 397);
            this.GbxControl.TabIndex = 3;
            this.GbxControl.TabStop = false;
            this.GbxControl.Text = "用户控制";
            // 
            // BtnEnd
            // 
            this.BtnEnd.Address = "122306";
            this.BtnEnd.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnEnd.Location = new System.Drawing.Point(209, 219);
            this.BtnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.No = 0;
            this.BtnEnd.Size = new System.Drawing.Size(146, 61);
            this.BtnEnd.StateAddress = "122309";
            this.BtnEnd.TabIndex = 10;
            this.BtnEnd.Text = "调试完成";
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnJigs
            // 
            this.BtnJigs.Address = "122305";
            this.BtnJigs.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJigs.Location = new System.Drawing.Point(209, 131);
            this.BtnJigs.Margin = new System.Windows.Forms.Padding(4);
            this.BtnJigs.Name = "BtnJigs";
            this.BtnJigs.No = 0;
            this.BtnJigs.Size = new System.Drawing.Size(146, 61);
            this.BtnJigs.StateAddress = "122308";
            this.BtnJigs.TabIndex = 9;
            this.BtnJigs.Text = "夹具进";
            this.BtnJigs.UseVisualStyleBackColor = true;
            this.BtnJigs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnJigs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnReady
            // 
            this.BtnReady.Address = "122304";
            this.BtnReady.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady.Location = new System.Drawing.Point(209, 36);
            this.BtnReady.Margin = new System.Windows.Forms.Padding(4);
            this.BtnReady.Name = "BtnReady";
            this.BtnReady.No = 0;
            this.BtnReady.Size = new System.Drawing.Size(146, 62);
            this.BtnReady.StateAddress = "122307";
            this.BtnReady.TabIndex = 8;
            this.BtnReady.Text = "准备就绪";
            this.BtnReady.UseVisualStyleBackColor = true;
            this.BtnReady.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnReady.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnAlarm
            // 
            this.BtnAlarm.Address = "122106";
            this.BtnAlarm.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAlarm.Location = new System.Drawing.Point(25, 219);
            this.BtnAlarm.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAlarm.Name = "BtnAlarm";
            this.BtnAlarm.No = 0;
            this.BtnAlarm.Size = new System.Drawing.Size(155, 62);
            this.BtnAlarm.StateAddress = "122106";
            this.BtnAlarm.TabIndex = 7;
            this.BtnAlarm.Text = "报警解除";
            this.BtnAlarm.UseVisualStyleBackColor = true;
            this.BtnAlarm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnAlarm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(25, 313);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(155, 56);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Address = "122102";
            this.BtnStop.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStop.Location = new System.Drawing.Point(25, 131);
            this.BtnStop.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.No = 0;
            this.BtnStop.Size = new System.Drawing.Size(155, 61);
            this.BtnStop.StateAddress = "122113";
            this.BtnStop.TabIndex = 1;
            this.BtnStop.Text = "停止";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnStart
            // 
            this.BtnStart.Address = "122101";
            this.BtnStart.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(25, 36);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.No = 0;
            this.BtnStart.Size = new System.Drawing.Size(155, 62);
            this.BtnStart.StateAddress = "122112";
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "启动";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // TmrState
            // 
            this.TmrState.Tick += new System.EventHandler(this.TmrState_Tick);
            // 
            // GbxAlarm
            // 
            this.GbxAlarm.Controls.Add(this.DgvAlarm);
            this.GbxAlarm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GbxAlarm.Location = new System.Drawing.Point(16, 435);
            this.GbxAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.GbxAlarm.Name = "GbxAlarm";
            this.GbxAlarm.Padding = new System.Windows.Forms.Padding(2);
            this.GbxAlarm.Size = new System.Drawing.Size(619, 255);
            this.GbxAlarm.TabIndex = 5;
            this.GbxAlarm.TabStop = false;
            this.GbxAlarm.Text = "报警信息";
            // 
            // DgvAlarm
            // 
            this.DgvAlarm.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAlarm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Info});
            this.DgvAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvAlarm.Location = new System.Drawing.Point(2, 25);
            this.DgvAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.DgvAlarm.Name = "DgvAlarm";
            this.DgvAlarm.ReadOnly = true;
            this.DgvAlarm.RowTemplate.Height = 27;
            this.DgvAlarm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvAlarm.Size = new System.Drawing.Size(615, 228);
            this.DgvAlarm.TabIndex = 0;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "报警时间";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 200;
            // 
            // Info
            // 
            this.Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Info.DataPropertyName = "Info";
            this.Info.HeaderText = "报警信息";
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnNo);
            this.groupBox1.Controls.Add(this.BtnOk);
            this.groupBox1.Controls.Add(this.LblManualJudge);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LblState);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(22, 289);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(611, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工作状态";
            // 
            // BtnNo
            // 
            this.BtnNo.Address = "122101";
            this.BtnNo.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnNo.Location = new System.Drawing.Point(432, 81);
            this.BtnNo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.No = 0;
            this.BtnNo.Size = new System.Drawing.Size(110, 51);
            this.BtnNo.StateAddress = "122112";
            this.BtnNo.TabIndex = 4;
            this.BtnNo.Text = "不合格";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Address = "122101";
            this.BtnOk.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(263, 81);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.No = 0;
            this.BtnOk.Size = new System.Drawing.Size(110, 51);
            this.BtnOk.StateAddress = "122112";
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "合格";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblManualJudge
            // 
            this.LblManualJudge.AutoSize = true;
            this.LblManualJudge.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblManualJudge.Location = new System.Drawing.Point(16, 92);
            this.LblManualJudge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblManualJudge.Name = "LblManualJudge";
            this.LblManualJudge.Size = new System.Drawing.Size(180, 28);
            this.LblManualJudge.TabIndex = 2;
            this.LblManualJudge.Text = "人工判断确认";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "当前工作状态";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblState.Location = new System.Drawing.Point(258, 27);
            this.LblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(124, 28);
            this.LblState.TabIndex = 0;
            this.LblState.Text = "等待开始";
            // 
            // label2
            // 
            this.label2.Address = null;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(418, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 37);
            this.label2.StateAddress = null;
            this.label2.TabIndex = 4;
            this.label2.Text = "自动校对测试工位";
            // 
            // LblSelectModel
            // 
            this.LblSelectModel.AutoSize = true;
            this.LblSelectModel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblSelectModel.Location = new System.Drawing.Point(209, 20);
            this.LblSelectModel.Name = "LblSelectModel";
            this.LblSelectModel.Size = new System.Drawing.Size(154, 24);
            this.LblSelectModel.TabIndex = 31;
            this.LblSelectModel.Text = "当前选择型号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(39, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 24);
            this.label8.TabIndex = 30;
            this.label8.Text = "当前选择型号：";
            // 
            // FrmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.LblSelectModel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GbxAlarm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GbxControl);
            this.Controls.Add(this.GbxState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAuto_Load);
            this.GbxState.ResumeLayout(false);
            this.GbxState.PerformLayout();
            this.GbxControl.ResumeLayout(false);
            this.GbxAlarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GbxState;
        private System.Windows.Forms.GroupBox GbxControl;
        private ACA_Common.LabelNew label2;
        private System.Windows.Forms.Timer TmrState;
        private ACA_Common.ButtonNew BtnStop;
        private ACA_Common.ButtonNew BtnStart;
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
        private ACA_Common.LabelNew label1;
        private System.Windows.Forms.GroupBox GbxAlarm;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblState;
        private ACA_Common.ButtonNew BtnAlarm;
        private System.Windows.Forms.DataGridView DgvAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.Label label4;
        private ACA_Common.ButtonNew BtnEnd;
        private ACA_Common.ButtonNew BtnJigs;
        private ACA_Common.ButtonNew BtnReady;
        private ACA_Common.ButtonNew BtnNo;
        private ACA_Common.ButtonNew BtnOk;
        private System.Windows.Forms.Label LblManualJudge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblSelectModel;
        private System.Windows.Forms.Label label8;
    }
}