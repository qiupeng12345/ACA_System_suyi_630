namespace ACA_System_InTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.ChkTest3 = new ACA_Common.CheckNew();
            this.ChkTest1 = new ACA_Common.CheckNew();
            this.ChkTest2 = new ACA_Common.CheckNew();
            this.ChkLow = new ACA_Common.CheckNew();
            this.ChkHigh = new ACA_Common.CheckNew();
            this.BtnExit = new System.Windows.Forms.Button();
            this.ChkManualCommunication = new ACA_Common.CheckNew();
            this.ChkModel2 = new ACA_Common.CheckNew();
            this.ChkAutoCommunication = new ACA_Common.CheckNew();
            this.ChkModel1 = new ACA_Common.CheckNew();
            this.ChkMeachineAge = new ACA_Common.CheckNew();
            this.ChkManualJudge = new ACA_Common.CheckNew();
            this.ChkBarCode = new ACA_Common.CheckNew();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ChkCloseDoor = new ACA_Common.CheckNew();
            this.ChkAutoLine = new ACA_Common.CheckNew();
            this.ChkManualLine = new ACA_Common.CheckNew();
            this.ChkDefence = new ACA_Common.CheckNew();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(397, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "功能选择";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ChkTest3
            // 
            this.ChkTest3.Address = "4457";
            this.ChkTest3.AutoSize = true;
            this.ChkTest3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkTest3.Location = new System.Drawing.Point(432, 323);
            this.ChkTest3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkTest3.Name = "ChkTest3";
            this.ChkTest3.No = 9;
            this.ChkTest3.Size = new System.Drawing.Size(228, 36);
            this.ChkTest3.TabIndex = 1;
            this.ChkTest3.Text = "B相输出十倍电流";
            this.ChkTest3.UseVisualStyleBackColor = true;
            this.ChkTest3.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkTest1
            // 
            this.ChkTest1.Address = "4458";
            this.ChkTest1.AutoSize = true;
            this.ChkTest1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkTest1.Location = new System.Drawing.Point(741, 323);
            this.ChkTest1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkTest1.Name = "ChkTest1";
            this.ChkTest1.No = 7;
            this.ChkTest1.Size = new System.Drawing.Size(229, 36);
            this.ChkTest1.TabIndex = 2;
            this.ChkTest1.Text = "C相输出十倍电流";
            this.ChkTest1.UseVisualStyleBackColor = true;
            this.ChkTest1.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkTest2
            // 
            this.ChkTest2.Address = "4459";
            this.ChkTest2.AutoSize = true;
            this.ChkTest2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkTest2.Location = new System.Drawing.Point(154, 417);
            this.ChkTest2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkTest2.Name = "ChkTest2";
            this.ChkTest2.No = 8;
            this.ChkTest2.Size = new System.Drawing.Size(230, 36);
            this.ChkTest2.TabIndex = 3;
            this.ChkTest2.Text = "A相输出十倍电流";
            this.ChkTest2.UseVisualStyleBackColor = true;
            this.ChkTest2.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkLow
            // 
            this.ChkLow.Address = "4460";
            this.ChkLow.AutoSize = true;
            this.ChkLow.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkLow.Location = new System.Drawing.Point(432, 417);
            this.ChkLow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkLow.Name = "ChkLow";
            this.ChkLow.No = 10;
            this.ChkLow.Size = new System.Drawing.Size(137, 36);
            this.ChkLow.TabIndex = 4;
            this.ChkLow.Text = "低倍电流";
            this.ChkLow.UseVisualStyleBackColor = true;
            this.ChkLow.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkHigh
            // 
            this.ChkHigh.Address = "4461";
            this.ChkHigh.AutoSize = true;
            this.ChkHigh.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkHigh.Location = new System.Drawing.Point(741, 417);
            this.ChkHigh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkHigh.Name = "ChkHigh";
            this.ChkHigh.No = 11;
            this.ChkHigh.Size = new System.Drawing.Size(137, 36);
            this.ChkHigh.TabIndex = 5;
            this.ChkHigh.Text = "高倍电流";
            this.ChkHigh.UseVisualStyleBackColor = true;
            this.ChkHigh.Click += new System.EventHandler(this.Chk_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.SystemColors.Info;
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(664, 11);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(157, 71);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "退出 <<";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // ChkManualCommunication
            // 
            this.ChkManualCommunication.Address = "4452";
            this.ChkManualCommunication.AutoSize = true;
            this.ChkManualCommunication.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkManualCommunication.Location = new System.Drawing.Point(741, 146);
            this.ChkManualCommunication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkManualCommunication.Name = "ChkManualCommunication";
            this.ChkManualCommunication.No = 2;
            this.ChkManualCommunication.Size = new System.Drawing.Size(137, 36);
            this.ChkManualCommunication.TabIndex = 21;
            this.ChkManualCommunication.Text = "手动通讯";
            this.ChkManualCommunication.UseVisualStyleBackColor = true;
            this.ChkManualCommunication.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkModel2
            // 
            this.ChkModel2.Address = "4451";
            this.ChkModel2.AutoSize = true;
            this.ChkModel2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkModel2.Location = new System.Drawing.Point(159, 234);
            this.ChkModel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkModel2.Name = "ChkModel2";
            this.ChkModel2.No = 3;
            this.ChkModel2.Size = new System.Drawing.Size(132, 36);
            this.ChkModel2.TabIndex = 20;
            this.ChkModel2.Text = "型号630";
            this.ChkModel2.UseVisualStyleBackColor = true;
            this.ChkModel2.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkAutoCommunication
            // 
            this.ChkAutoCommunication.Address = "4453";
            this.ChkAutoCommunication.AutoSize = true;
            this.ChkAutoCommunication.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAutoCommunication.Location = new System.Drawing.Point(741, 234);
            this.ChkAutoCommunication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkAutoCommunication.Name = "ChkAutoCommunication";
            this.ChkAutoCommunication.No = 5;
            this.ChkAutoCommunication.Size = new System.Drawing.Size(137, 36);
            this.ChkAutoCommunication.TabIndex = 22;
            this.ChkAutoCommunication.Text = "自动通讯";
            this.ChkAutoCommunication.UseVisualStyleBackColor = true;
            this.ChkAutoCommunication.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkModel1
            // 
            this.ChkModel1.Address = "4450";
            this.ChkModel1.AutoSize = true;
            this.ChkModel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkModel1.Location = new System.Drawing.Point(159, 146);
            this.ChkModel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkModel1.Name = "ChkModel1";
            this.ChkModel1.No = 0;
            this.ChkModel1.Size = new System.Drawing.Size(132, 36);
            this.ChkModel1.TabIndex = 19;
            this.ChkModel1.Text = "型号400";
            this.ChkModel1.UseVisualStyleBackColor = true;
            this.ChkModel1.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkMeachineAge
            // 
            this.ChkMeachineAge.Address = "4456";
            this.ChkMeachineAge.AutoSize = true;
            this.ChkMeachineAge.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkMeachineAge.Location = new System.Drawing.Point(154, 323);
            this.ChkMeachineAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkMeachineAge.Name = "ChkMeachineAge";
            this.ChkMeachineAge.No = 6;
            this.ChkMeachineAge.Size = new System.Drawing.Size(137, 36);
            this.ChkMeachineAge.TabIndex = 25;
            this.ChkMeachineAge.Text = "机械寿命";
            this.ChkMeachineAge.UseVisualStyleBackColor = true;
            this.ChkMeachineAge.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkManualJudge
            // 
            this.ChkManualJudge.Address = "4455";
            this.ChkManualJudge.AutoSize = true;
            this.ChkManualJudge.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkManualJudge.Location = new System.Drawing.Point(432, 146);
            this.ChkManualJudge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkManualJudge.Name = "ChkManualJudge";
            this.ChkManualJudge.No = 1;
            this.ChkManualJudge.Size = new System.Drawing.Size(137, 36);
            this.ChkManualJudge.TabIndex = 24;
            this.ChkManualJudge.Text = "人工判断";
            this.ChkManualJudge.UseVisualStyleBackColor = true;
            this.ChkManualJudge.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkBarCode
            // 
            this.ChkBarCode.Address = "4454";
            this.ChkBarCode.AutoSize = true;
            this.ChkBarCode.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBarCode.Location = new System.Drawing.Point(432, 234);
            this.ChkBarCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkBarCode.Name = "ChkBarCode";
            this.ChkBarCode.No = 4;
            this.ChkBarCode.Size = new System.Drawing.Size(137, 36);
            this.ChkBarCode.TabIndex = 23;
            this.ChkBarCode.Text = "扫码屏蔽";
            this.ChkBarCode.UseVisualStyleBackColor = true;
            this.ChkBarCode.Click += new System.EventHandler(this.Chk_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.SystemColors.Info;
            this.BtnOk.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(843, 11);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(157, 71);
            this.BtnOk.TabIndex = 26;
            this.BtnOk.Text = "确定 <<";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ChkCloseDoor
            // 
            this.ChkCloseDoor.Address = "4464";
            this.ChkCloseDoor.AutoSize = true;
            this.ChkCloseDoor.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkCloseDoor.Location = new System.Drawing.Point(154, 507);
            this.ChkCloseDoor.Name = "ChkCloseDoor";
            this.ChkCloseDoor.No = 21;
            this.ChkCloseDoor.Size = new System.Drawing.Size(132, 35);
            this.ChkCloseDoor.TabIndex = 27;
            this.ChkCloseDoor.Text = "门禁屏蔽";
            this.ChkCloseDoor.UseVisualStyleBackColor = true;
            // 
            // ChkAutoLine
            // 
            this.ChkAutoLine.Address = "4467";
            this.ChkAutoLine.AutoSize = true;
            this.ChkAutoLine.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkAutoLine.Location = new System.Drawing.Point(432, 507);
            this.ChkAutoLine.Name = "ChkAutoLine";
            this.ChkAutoLine.No = 13;
            this.ChkAutoLine.Size = new System.Drawing.Size(132, 35);
            this.ChkAutoLine.TabIndex = 28;
            this.ChkAutoLine.Text = "自动上料";
            this.ChkAutoLine.UseVisualStyleBackColor = true;
            this.ChkAutoLine.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkManualLine
            // 
            this.ChkManualLine.Address = "4466";
            this.ChkManualLine.AutoSize = true;
            this.ChkManualLine.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkManualLine.Location = new System.Drawing.Point(741, 507);
            this.ChkManualLine.Name = "ChkManualLine";
            this.ChkManualLine.No = 14;
            this.ChkManualLine.Size = new System.Drawing.Size(132, 35);
            this.ChkManualLine.TabIndex = 29;
            this.ChkManualLine.Text = "手动上料";
            this.ChkManualLine.UseVisualStyleBackColor = true;
            this.ChkManualLine.Click += new System.EventHandler(this.Chk_Click);
            // 
            // ChkDefence
            // 
            this.ChkDefence.Address = "4465";
            this.ChkDefence.AutoSize = true;
            this.ChkDefence.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkDefence.Location = new System.Drawing.Point(154, 593);
            this.ChkDefence.Name = "ChkDefence";
            this.ChkDefence.No = 15;
            this.ChkDefence.Size = new System.Drawing.Size(132, 35);
            this.ChkDefence.TabIndex = 30;
            this.ChkDefence.Text = "挡停下降";
            this.ChkDefence.UseVisualStyleBackColor = true;
            this.ChkDefence.Click += new System.EventHandler(this.Chk_Click);
            // 
            // FrmFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.ChkDefence);
            this.Controls.Add(this.ChkManualLine);
            this.Controls.Add(this.ChkAutoLine);
            this.Controls.Add(this.ChkCloseDoor);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.ChkMeachineAge);
            this.Controls.Add(this.ChkManualJudge);
            this.Controls.Add(this.ChkBarCode);
            this.Controls.Add(this.ChkManualCommunication);
            this.Controls.Add(this.ChkModel2);
            this.Controls.Add(this.ChkAutoCommunication);
            this.Controls.Add(this.ChkModel1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.ChkHigh);
            this.Controls.Add(this.ChkLow);
            this.Controls.Add(this.ChkTest2);
            this.Controls.Add(this.ChkTest1);
            this.Controls.Add(this.ChkTest3);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExit;
        private ACA_Common.CheckNew ChkTest3;
        private ACA_Common.CheckNew ChkTest1;
        private ACA_Common.CheckNew ChkTest2;
        private ACA_Common.CheckNew ChkLow;
        private ACA_Common.CheckNew ChkHigh;
        private ACA_Common.CheckNew ChkManualCommunication;
        private ACA_Common.CheckNew ChkModel2;
        private ACA_Common.CheckNew ChkAutoCommunication;
        private ACA_Common.CheckNew ChkModel1;
        private ACA_Common.CheckNew ChkMeachineAge;
        private ACA_Common.CheckNew ChkManualJudge;
        private ACA_Common.CheckNew ChkBarCode;
        private System.Windows.Forms.Button BtnOk;
        private ACA_Common.CheckNew ChkCloseDoor;
        private ACA_Common.CheckNew ChkAutoLine;
        private ACA_Common.CheckNew ChkManualLine;
        private ACA_Common.CheckNew ChkDefence;
    }
}