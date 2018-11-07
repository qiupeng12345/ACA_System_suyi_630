namespace Aca_System_WholeTest
{
    partial class FrmFunction
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ChkAutoLine = new ACA_Common.CheckNew();
            this.ChkManualLine = new ACA_Common.CheckNew();
            this.ChkCloseDoor = new ACA_Common.CheckNew();
            this.ChkStation6 = new ACA_Common.CheckNew();
            this.ChkStation5 = new ACA_Common.CheckNew();
            this.ChkStation4 = new ACA_Common.CheckNew();
            this.ChkStation3 = new ACA_Common.CheckNew();
            this.ChkStation2 = new ACA_Common.CheckNew();
            this.ChkStation1 = new ACA_Common.CheckNew();
            this.ChkZero = new ACA_Common.CheckNew();
            this.ChkLosePhase = new ACA_Common.CheckNew();
            this.ChkLowVoltage = new ACA_Common.CheckNew();
            this.ChkMeachineAge = new ACA_Common.CheckNew();
            this.ChkManualJudge = new ACA_Common.CheckNew();
            this.ChkBarCode = new ACA_Common.CheckNew();
            this.ChkManualCommunication = new ACA_Common.CheckNew();
            this.ChkModel2 = new ACA_Common.CheckNew();
            this.ChkAutoCommunication = new ACA_Common.CheckNew();
            this.ChkModel1 = new ACA_Common.CheckNew();
            this.ChkUnderVoltage = new ACA_Common.CheckNew();
            this.ChkOverVoltage = new ACA_Common.CheckNew();
            this.ChkAction3 = new ACA_Common.CheckNew();
            this.ChkAction2 = new ACA_Common.CheckNew();
            this.ChkAction1 = new ACA_Common.CheckNew();
            this.ChkFinallyJudge = new ACA_Common.CheckNew();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.SystemColors.Info;
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(637, 2);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(165, 81);
            this.BtnExit.TabIndex = 32;
            this.BtnExit.Text = "退出 <<";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(100, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 50);
            this.label1.TabIndex = 26;
            this.label1.Text = "功能选择";
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.SystemColors.Info;
            this.BtnOk.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(840, 2);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(165, 81);
            this.BtnOk.TabIndex = 43;
            this.BtnOk.Text = "确认<<";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ChkAutoLine
            // 
            this.ChkAutoLine.Address = "5441";
            this.ChkAutoLine.AutoSize = true;
            this.ChkAutoLine.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAutoLine.Location = new System.Drawing.Point(783, 204);
            this.ChkAutoLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkAutoLine.Name = "ChkAutoLine";
            this.ChkAutoLine.No = 22;
            this.ChkAutoLine.Size = new System.Drawing.Size(137, 36);
            this.ChkAutoLine.TabIndex = 52;
            this.ChkAutoLine.Text = "自动上料";
            this.ChkAutoLine.UseVisualStyleBackColor = true;
            this.ChkAutoLine.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkManualLine
            // 
            this.ChkManualLine.Address = "5440";
            this.ChkManualLine.AutoSize = true;
            this.ChkManualLine.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkManualLine.Location = new System.Drawing.Point(783, 282);
            this.ChkManualLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkManualLine.Name = "ChkManualLine";
            this.ChkManualLine.No = 23;
            this.ChkManualLine.Size = new System.Drawing.Size(137, 36);
            this.ChkManualLine.TabIndex = 53;
            this.ChkManualLine.Text = "手动上料";
            this.ChkManualLine.UseVisualStyleBackColor = true;
            this.ChkManualLine.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkCloseDoor
            // 
            this.ChkCloseDoor.Address = "5451";
            this.ChkCloseDoor.AutoSize = true;
            this.ChkCloseDoor.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkCloseDoor.Location = new System.Drawing.Point(788, 126);
            this.ChkCloseDoor.Name = "ChkCloseDoor";
            this.ChkCloseDoor.No = 21;
            this.ChkCloseDoor.Size = new System.Drawing.Size(132, 35);
            this.ChkCloseDoor.TabIndex = 50;
            this.ChkCloseDoor.Text = "门禁屏蔽";
            this.ChkCloseDoor.UseVisualStyleBackColor = true;
            this.ChkCloseDoor.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkStation6
            // 
            this.ChkStation6.Address = "5450";
            this.ChkStation6.AutoSize = true;
            this.ChkStation6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkStation6.Location = new System.Drawing.Point(538, 616);
            this.ChkStation6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkStation6.Name = "ChkStation6";
            this.ChkStation6.No = 20;
            this.ChkStation6.Size = new System.Drawing.Size(147, 36);
            this.ChkStation6.TabIndex = 49;
            this.ChkStation6.Text = "630工位3";
            this.ChkStation6.UseVisualStyleBackColor = true;
            this.ChkStation6.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkStation5
            // 
            this.ChkStation5.Address = "5449";
            this.ChkStation5.AutoSize = true;
            this.ChkStation5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkStation5.Location = new System.Drawing.Point(290, 616);
            this.ChkStation5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkStation5.Name = "ChkStation5";
            this.ChkStation5.No = 19;
            this.ChkStation5.Size = new System.Drawing.Size(147, 36);
            this.ChkStation5.TabIndex = 48;
            this.ChkStation5.Text = "630工位2";
            this.ChkStation5.UseVisualStyleBackColor = true;
            this.ChkStation5.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkStation4
            // 
            this.ChkStation4.Address = "5448";
            this.ChkStation4.AutoSize = true;
            this.ChkStation4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkStation4.Location = new System.Drawing.Point(48, 616);
            this.ChkStation4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkStation4.Name = "ChkStation4";
            this.ChkStation4.No = 18;
            this.ChkStation4.Size = new System.Drawing.Size(147, 36);
            this.ChkStation4.TabIndex = 47;
            this.ChkStation4.Text = "630工位1";
            this.ChkStation4.UseVisualStyleBackColor = true;
            this.ChkStation4.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkStation3
            // 
            this.ChkStation3.Address = "5447";
            this.ChkStation3.AutoSize = true;
            this.ChkStation3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkStation3.Location = new System.Drawing.Point(538, 537);
            this.ChkStation3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkStation3.Name = "ChkStation3";
            this.ChkStation3.No = 17;
            this.ChkStation3.Size = new System.Drawing.Size(147, 36);
            this.ChkStation3.TabIndex = 46;
            this.ChkStation3.Text = "400工位3";
            this.ChkStation3.UseVisualStyleBackColor = true;
            this.ChkStation3.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkStation2
            // 
            this.ChkStation2.Address = "5446";
            this.ChkStation2.AutoSize = true;
            this.ChkStation2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkStation2.Location = new System.Drawing.Point(290, 537);
            this.ChkStation2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkStation2.Name = "ChkStation2";
            this.ChkStation2.No = 16;
            this.ChkStation2.Size = new System.Drawing.Size(147, 36);
            this.ChkStation2.TabIndex = 45;
            this.ChkStation2.Text = "400工位2";
            this.ChkStation2.UseVisualStyleBackColor = true;
            this.ChkStation2.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkStation1
            // 
            this.ChkStation1.Address = "5445";
            this.ChkStation1.AutoSize = true;
            this.ChkStation1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkStation1.Location = new System.Drawing.Point(48, 537);
            this.ChkStation1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkStation1.Name = "ChkStation1";
            this.ChkStation1.No = 15;
            this.ChkStation1.Size = new System.Drawing.Size(147, 36);
            this.ChkStation1.TabIndex = 44;
            this.ChkStation1.Text = "400工位1";
            this.ChkStation1.UseVisualStyleBackColor = true;
            this.ChkStation1.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkZero
            // 
            this.ChkZero.Address = "5435";
            this.ChkZero.AutoSize = true;
            this.ChkZero.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkZero.Location = new System.Drawing.Point(538, 459);
            this.ChkZero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkZero.Name = "ChkZero";
            this.ChkZero.No = 14;
            this.ChkZero.Size = new System.Drawing.Size(87, 36);
            this.ChkZero.TabIndex = 42;
            this.ChkZero.Text = "缺零";
            this.ChkZero.UseVisualStyleBackColor = true;
            this.ChkZero.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkLosePhase
            // 
            this.ChkLosePhase.Address = "5434";
            this.ChkLosePhase.AutoSize = true;
            this.ChkLosePhase.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkLosePhase.Location = new System.Drawing.Point(290, 459);
            this.ChkLosePhase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkLosePhase.Name = "ChkLosePhase";
            this.ChkLosePhase.No = 13;
            this.ChkLosePhase.Size = new System.Drawing.Size(87, 36);
            this.ChkLosePhase.TabIndex = 41;
            this.ChkLosePhase.Text = "缺相";
            this.ChkLosePhase.UseVisualStyleBackColor = true;
            this.ChkLosePhase.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkLowVoltage
            // 
            this.ChkLowVoltage.Address = "5433";
            this.ChkLowVoltage.AutoSize = true;
            this.ChkLowVoltage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkLowVoltage.Location = new System.Drawing.Point(48, 459);
            this.ChkLowVoltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkLowVoltage.Name = "ChkLowVoltage";
            this.ChkLowVoltage.No = 12;
            this.ChkLowVoltage.Size = new System.Drawing.Size(87, 36);
            this.ChkLowVoltage.TabIndex = 40;
            this.ChkLowVoltage.Text = "低压";
            this.ChkLowVoltage.UseVisualStyleBackColor = true;
            this.ChkLowVoltage.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkMeachineAge
            // 
            this.ChkMeachineAge.Address = "5444";
            this.ChkMeachineAge.AutoSize = true;
            this.ChkMeachineAge.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkMeachineAge.Location = new System.Drawing.Point(48, 282);
            this.ChkMeachineAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkMeachineAge.Name = "ChkMeachineAge";
            this.ChkMeachineAge.No = 6;
            this.ChkMeachineAge.Size = new System.Drawing.Size(137, 36);
            this.ChkMeachineAge.TabIndex = 39;
            this.ChkMeachineAge.Text = "机械寿命";
            this.ChkMeachineAge.UseVisualStyleBackColor = true;
            this.ChkMeachineAge.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkManualJudge
            // 
            this.ChkManualJudge.Address = "5443";
            this.ChkManualJudge.AutoSize = true;
            this.ChkManualJudge.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkManualJudge.Location = new System.Drawing.Point(290, 124);
            this.ChkManualJudge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkManualJudge.Name = "ChkManualJudge";
            this.ChkManualJudge.No = 1;
            this.ChkManualJudge.Size = new System.Drawing.Size(137, 36);
            this.ChkManualJudge.TabIndex = 38;
            this.ChkManualJudge.Text = "人工判断";
            this.ChkManualJudge.UseVisualStyleBackColor = true;
            this.ChkManualJudge.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkBarCode
            // 
            this.ChkBarCode.Address = "5442";
            this.ChkBarCode.AutoSize = true;
            this.ChkBarCode.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBarCode.Location = new System.Drawing.Point(290, 202);
            this.ChkBarCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBarCode.Name = "ChkBarCode";
            this.ChkBarCode.No = 4;
            this.ChkBarCode.Size = new System.Drawing.Size(137, 36);
            this.ChkBarCode.TabIndex = 37;
            this.ChkBarCode.Text = "扫码屏蔽";
            this.ChkBarCode.UseVisualStyleBackColor = true;
            this.ChkBarCode.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkManualCommunication
            // 
            this.ChkManualCommunication.Address = "5438";
            this.ChkManualCommunication.AutoSize = true;
            this.ChkManualCommunication.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkManualCommunication.Location = new System.Drawing.Point(538, 124);
            this.ChkManualCommunication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkManualCommunication.Name = "ChkManualCommunication";
            this.ChkManualCommunication.No = 2;
            this.ChkManualCommunication.Size = new System.Drawing.Size(137, 36);
            this.ChkManualCommunication.TabIndex = 35;
            this.ChkManualCommunication.Text = "手动通讯";
            this.ChkManualCommunication.UseVisualStyleBackColor = true;
            this.ChkManualCommunication.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkModel2
            // 
            this.ChkModel2.Address = "5437";
            this.ChkModel2.AutoSize = true;
            this.ChkModel2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkModel2.Location = new System.Drawing.Point(48, 202);
            this.ChkModel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkModel2.Name = "ChkModel2";
            this.ChkModel2.No = 3;
            this.ChkModel2.Size = new System.Drawing.Size(132, 36);
            this.ChkModel2.TabIndex = 34;
            this.ChkModel2.Text = "型号630";
            this.ChkModel2.UseVisualStyleBackColor = true;
            this.ChkModel2.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkAutoCommunication
            // 
            this.ChkAutoCommunication.Address = "5439";
            this.ChkAutoCommunication.AutoSize = true;
            this.ChkAutoCommunication.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAutoCommunication.Location = new System.Drawing.Point(538, 202);
            this.ChkAutoCommunication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkAutoCommunication.Name = "ChkAutoCommunication";
            this.ChkAutoCommunication.No = 5;
            this.ChkAutoCommunication.Size = new System.Drawing.Size(137, 36);
            this.ChkAutoCommunication.TabIndex = 36;
            this.ChkAutoCommunication.Text = "自动通讯";
            this.ChkAutoCommunication.UseVisualStyleBackColor = true;
            this.ChkAutoCommunication.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkModel1
            // 
            this.ChkModel1.Address = "5436";
            this.ChkModel1.AutoSize = true;
            this.ChkModel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkModel1.Location = new System.Drawing.Point(48, 124);
            this.ChkModel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkModel1.Name = "ChkModel1";
            this.ChkModel1.No = 0;
            this.ChkModel1.Size = new System.Drawing.Size(132, 36);
            this.ChkModel1.TabIndex = 33;
            this.ChkModel1.Text = "型号400";
            this.ChkModel1.UseVisualStyleBackColor = true;
            this.ChkModel1.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkUnderVoltage
            // 
            this.ChkUnderVoltage.Address = "5432";
            this.ChkUnderVoltage.AutoSize = true;
            this.ChkUnderVoltage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkUnderVoltage.Location = new System.Drawing.Point(538, 374);
            this.ChkUnderVoltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkUnderVoltage.Name = "ChkUnderVoltage";
            this.ChkUnderVoltage.No = 11;
            this.ChkUnderVoltage.Size = new System.Drawing.Size(87, 36);
            this.ChkUnderVoltage.TabIndex = 31;
            this.ChkUnderVoltage.Text = "欠压";
            this.ChkUnderVoltage.UseVisualStyleBackColor = true;
            this.ChkUnderVoltage.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkOverVoltage
            // 
            this.ChkOverVoltage.Address = "5431";
            this.ChkOverVoltage.AutoSize = true;
            this.ChkOverVoltage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkOverVoltage.Location = new System.Drawing.Point(290, 374);
            this.ChkOverVoltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkOverVoltage.Name = "ChkOverVoltage";
            this.ChkOverVoltage.No = 10;
            this.ChkOverVoltage.Size = new System.Drawing.Size(87, 36);
            this.ChkOverVoltage.TabIndex = 30;
            this.ChkOverVoltage.Text = "过压";
            this.ChkOverVoltage.UseVisualStyleBackColor = true;
            this.ChkOverVoltage.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkAction3
            // 
            this.ChkAction3.Address = "5430";
            this.ChkAction3.AutoSize = true;
            this.ChkAction3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAction3.Location = new System.Drawing.Point(48, 374);
            this.ChkAction3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkAction3.Name = "ChkAction3";
            this.ChkAction3.No = 9;
            this.ChkAction3.Size = new System.Drawing.Size(137, 36);
            this.ChkAction3.TabIndex = 29;
            this.ChkAction3.Text = "动作时间";
            this.ChkAction3.UseVisualStyleBackColor = true;
            this.ChkAction3.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkAction2
            // 
            this.ChkAction2.Address = "5429";
            this.ChkAction2.AutoSize = true;
            this.ChkAction2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAction2.Location = new System.Drawing.Point(538, 282);
            this.ChkAction2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkAction2.Name = "ChkAction2";
            this.ChkAction2.No = 8;
            this.ChkAction2.Size = new System.Drawing.Size(162, 36);
            this.ChkAction2.TabIndex = 28;
            this.ChkAction2.Text = "动作值判断";
            this.ChkAction2.UseVisualStyleBackColor = true;
            this.ChkAction2.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkAction1
            // 
            this.ChkAction1.Address = "5428";
            this.ChkAction1.AutoSize = true;
            this.ChkAction1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAction1.Location = new System.Drawing.Point(290, 282);
            this.ChkAction1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkAction1.Name = "ChkAction1";
            this.ChkAction1.No = 7;
            this.ChkAction1.Size = new System.Drawing.Size(162, 36);
            this.ChkAction1.TabIndex = 27;
            this.ChkAction1.Text = "极限不驱动";
            this.ChkAction1.UseVisualStyleBackColor = true;
            this.ChkAction1.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkFinallyJudge
            // 
            this.ChkFinallyJudge.Address = "5440";
            this.ChkFinallyJudge.AutoSize = true;
            this.ChkFinallyJudge.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkFinallyJudge.Location = new System.Drawing.Point(783, 374);
            this.ChkFinallyJudge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkFinallyJudge.Name = "ChkFinallyJudge";
            this.ChkFinallyJudge.No = 23;
            this.ChkFinallyJudge.Size = new System.Drawing.Size(187, 36);
            this.ChkFinallyJudge.TabIndex = 54;
            this.ChkFinallyJudge.Text = "最终人工判断";
            this.ChkFinallyJudge.UseVisualStyleBackColor = true;
            this.ChkFinallyJudge.Click += new System.EventHandler(this.Chk_Click);
            // 
            // FrmFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.ChkFinallyJudge);
            this.Controls.Add(this.ChkAutoLine);
            this.Controls.Add(this.ChkManualLine);
            this.Controls.Add(this.ChkCloseDoor);
            this.Controls.Add(this.ChkStation6);
            this.Controls.Add(this.ChkStation5);
            this.Controls.Add(this.ChkStation4);
            this.Controls.Add(this.ChkStation3);
            this.Controls.Add(this.ChkStation2);
            this.Controls.Add(this.ChkStation1);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.ChkZero);
            this.Controls.Add(this.ChkLosePhase);
            this.Controls.Add(this.ChkLowVoltage);
            this.Controls.Add(this.ChkMeachineAge);
            this.Controls.Add(this.ChkManualJudge);
            this.Controls.Add(this.ChkBarCode);
            this.Controls.Add(this.ChkManualCommunication);
            this.Controls.Add(this.ChkModel2);
            this.Controls.Add(this.ChkAutoCommunication);
            this.Controls.Add(this.ChkModel1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.ChkUnderVoltage);
            this.Controls.Add(this.ChkOverVoltage);
            this.Controls.Add(this.ChkAction3);
            this.Controls.Add(this.ChkAction2);
            this.Controls.Add(this.ChkAction1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmFunction";
            this.Text = "功能选择";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFunction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ACA_Common.CheckNew ChkMeachineAge;
        private ACA_Common.CheckNew ChkManualJudge;
        private ACA_Common.CheckNew ChkBarCode;
        private ACA_Common.CheckNew ChkManualCommunication;
        private ACA_Common.CheckNew ChkModel2;
        private ACA_Common.CheckNew ChkAutoCommunication;
        private ACA_Common.CheckNew ChkModel1;
        private System.Windows.Forms.Button BtnExit;
        private ACA_Common.CheckNew ChkUnderVoltage;
        private ACA_Common.CheckNew ChkOverVoltage;
        private ACA_Common.CheckNew ChkAction3;
        private ACA_Common.CheckNew ChkAction2;
        private ACA_Common.CheckNew ChkAction1;
        private System.Windows.Forms.Label label1;
        private ACA_Common.CheckNew ChkZero;
        private ACA_Common.CheckNew ChkLosePhase;
        private ACA_Common.CheckNew ChkLowVoltage;
        private System.Windows.Forms.Button BtnOk;
        private ACA_Common.CheckNew ChkStation3;
        private ACA_Common.CheckNew ChkStation2;
        private ACA_Common.CheckNew ChkStation1;
        private ACA_Common.CheckNew ChkStation6;
        private ACA_Common.CheckNew ChkStation5;
        private ACA_Common.CheckNew ChkStation4;
        private ACA_Common.CheckNew ChkCloseDoor;
        private ACA_Common.CheckNew ChkAutoLine;
        private ACA_Common.CheckNew ChkManualLine;
        private ACA_Common.CheckNew ChkFinallyJudge;
    }
}