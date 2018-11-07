namespace ACA_System_InTest
{
    partial class FrmSemi_Auto
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
            this.BtnStart = new ACA_Common.ButtonNew();
            this.BtnEnd = new ACA_Common.ButtonNew();
            this.BtnJigs = new ACA_Common.ButtonNew();
            this.BtnExit = new ACA_Common.ButtonNew();
            this.BtnHigh = new ACA_Common.ButtonNew();
            this.BtnLow = new ACA_Common.ButtonNew();
            this.BtnOutPutA = new ACA_Common.ButtonNew();
            this.BtnOutPutC = new ACA_Common.ButtonNew();
            this.BtnOutPutB = new ACA_Common.ButtonNew();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblTestPhase = new ACA_Common.LabelNew();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTimeValue = new ACA_Common.LabelNew();
            this.LblStateValue = new ACA_Common.LabelNew();
            this.label4 = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.LblCurrentValue = new ACA_Common.LabelNew();
            this.LblCurrent = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(362, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "瞬时检测半自动";
            // 
            // BtnStart
            // 
            this.BtnStart.Address = "140801";
            this.BtnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(63, 66);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.No = 0;
            this.BtnStart.Size = new System.Drawing.Size(224, 61);
            this.BtnStart.StateAddress = "462601";
            this.BtnStart.TabIndex = 34;
            this.BtnStart.Text = "瞬时手动调试开始";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnEnd
            // 
            this.BtnEnd.Address = "140807";
            this.BtnEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnEnd.Location = new System.Drawing.Point(64, 173);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.No = 0;
            this.BtnEnd.Size = new System.Drawing.Size(224, 65);
            this.BtnEnd.StateAddress = "462607";
            this.BtnEnd.TabIndex = 35;
            this.BtnEnd.Text = "瞬时手动调试结束";
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnJigs
            // 
            this.BtnJigs.Address = "140800";
            this.BtnJigs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJigs.Location = new System.Drawing.Point(63, 289);
            this.BtnJigs.Name = "BtnJigs";
            this.BtnJigs.No = 0;
            this.BtnJigs.Size = new System.Drawing.Size(224, 60);
            this.BtnJigs.StateAddress = "462600";
            this.BtnJigs.TabIndex = 36;
            this.BtnJigs.Text = "夹具进";
            this.BtnJigs.UseVisualStyleBackColor = true;
            this.BtnJigs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnJigs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnExit
            // 
            this.BtnExit.Address = null;
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(666, 289);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.No = 0;
            this.BtnExit.Size = new System.Drawing.Size(285, 60);
            this.BtnExit.StateAddress = null;
            this.BtnExit.TabIndex = 37;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnHigh
            // 
            this.BtnHigh.Address = "140806";
            this.BtnHigh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnHigh.Location = new System.Drawing.Point(337, 289);
            this.BtnHigh.Name = "BtnHigh";
            this.BtnHigh.No = 0;
            this.BtnHigh.Size = new System.Drawing.Size(285, 60);
            this.BtnHigh.StateAddress = "462606";
            this.BtnHigh.TabIndex = 41;
            this.BtnHigh.Text = "任意相输出高倍瞬时电流";
            this.BtnHigh.UseVisualStyleBackColor = true;
            this.BtnHigh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnHigh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnLow
            // 
            this.BtnLow.Address = "140805";
            this.BtnLow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLow.Location = new System.Drawing.Point(666, 177);
            this.BtnLow.Name = "BtnLow";
            this.BtnLow.No = 0;
            this.BtnLow.Size = new System.Drawing.Size(285, 57);
            this.BtnLow.StateAddress = "462605";
            this.BtnLow.TabIndex = 40;
            this.BtnLow.Text = "任意相输出低倍瞬时电流";
            this.BtnLow.UseVisualStyleBackColor = true;
            this.BtnLow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnLow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPutA
            // 
            this.BtnOutPutA.Address = "140804";
            this.BtnOutPutA.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPutA.Location = new System.Drawing.Point(337, 177);
            this.BtnOutPutA.Name = "BtnOutPutA";
            this.BtnOutPutA.No = 0;
            this.BtnOutPutA.Size = new System.Drawing.Size(285, 57);
            this.BtnOutPutA.StateAddress = "462604";
            this.BtnOutPutA.TabIndex = 39;
            this.BtnOutPutA.Text = "A相接通，输出预设瞬时电流";
            this.BtnOutPutA.UseVisualStyleBackColor = true;
            this.BtnOutPutA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPutA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPutC
            // 
            this.BtnOutPutC.Address = "140803";
            this.BtnOutPutC.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPutC.Location = new System.Drawing.Point(666, 69);
            this.BtnOutPutC.Name = "BtnOutPutC";
            this.BtnOutPutC.No = 0;
            this.BtnOutPutC.Size = new System.Drawing.Size(285, 58);
            this.BtnOutPutC.StateAddress = "462603";
            this.BtnOutPutC.TabIndex = 38;
            this.BtnOutPutC.Text = "C相接通，输出预设瞬时电流";
            this.BtnOutPutC.UseVisualStyleBackColor = true;
            this.BtnOutPutC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPutC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnOutPutB
            // 
            this.BtnOutPutB.Address = "140802";
            this.BtnOutPutB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutPutB.Location = new System.Drawing.Point(340, 66);
            this.BtnOutPutB.Name = "BtnOutPutB";
            this.BtnOutPutB.No = 0;
            this.BtnOutPutB.Size = new System.Drawing.Size(285, 61);
            this.BtnOutPutB.StateAddress = "462602";
            this.BtnOutPutB.TabIndex = 42;
            this.BtnOutPutB.Text = "B相接通，输出预设瞬时电流";
            this.BtnOutPutB.UseVisualStyleBackColor = true;
            this.BtnOutPutB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnOutPutB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExit);
            this.groupBox1.Controls.Add(this.BtnOutPutB);
            this.groupBox1.Controls.Add(this.BtnStart);
            this.groupBox1.Controls.Add(this.BtnHigh);
            this.groupBox1.Controls.Add(this.BtnEnd);
            this.groupBox1.Controls.Add(this.BtnLow);
            this.groupBox1.Controls.Add(this.BtnJigs);
            this.groupBox1.Controls.Add(this.BtnOutPutA);
            this.groupBox1.Controls.Add(this.BtnOutPutC);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 403);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "半自动操作区";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblTestPhase);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.LblTimeValue);
            this.groupBox2.Controls.Add(this.LblStateValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LblState);
            this.groupBox2.Controls.Add(this.LblCurrentValue);
            this.groupBox2.Controls.Add(this.LblCurrent);
            this.groupBox2.Controls.Add(this.LblTime);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 218);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "半自动显示区";
            // 
            // LblTestPhase
            // 
            this.LblTestPhase.Address = "15010";
            this.LblTestPhase.AutoSize = true;
            this.LblTestPhase.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTestPhase.Location = new System.Drawing.Point(810, 132);
            this.LblTestPhase.Name = "LblTestPhase";
            this.LblTestPhase.Size = new System.Drawing.Size(124, 28);
            this.LblTestPhase.StateAddress = null;
            this.LblTestPhase.TabIndex = 30;
            this.LblTestPhase.Text = "测试相位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(571, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 28);
            this.label2.TabIndex = 29;
            this.label2.Text = "高低倍测试相位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(884, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "ms";
            // 
            // LblTimeValue
            // 
            this.LblTimeValue.Address = "4642";
            this.LblTimeValue.AutoSize = true;
            this.LblTimeValue.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTimeValue.Location = new System.Drawing.Point(745, 74);
            this.LblTimeValue.Name = "LblTimeValue";
            this.LblTimeValue.Size = new System.Drawing.Size(68, 28);
            this.LblTimeValue.StateAddress = "4643";
            this.LblTimeValue.TabIndex = 27;
            this.LblTimeValue.Text = "时间";
            // 
            // LblStateValue
            // 
            this.LblStateValue.Address = null;
            this.LblStateValue.AutoSize = true;
            this.LblStateValue.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblStateValue.Location = new System.Drawing.Point(278, 132);
            this.LblStateValue.Name = "LblStateValue";
            this.LblStateValue.Size = new System.Drawing.Size(124, 28);
            this.LblStateValue.StateAddress = null;
            this.LblStateValue.TabIndex = 26;
            this.LblStateValue.Text = "工作状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "A";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblState.Location = new System.Drawing.Point(57, 132);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(180, 28);
            this.LblState.TabIndex = 24;
            this.LblState.Text = "当前工作状态";
            // 
            // LblCurrentValue
            // 
            this.LblCurrentValue.Address = "4640";
            this.LblCurrentValue.AutoSize = true;
            this.LblCurrentValue.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCurrentValue.Location = new System.Drawing.Point(278, 70);
            this.LblCurrentValue.Name = "LblCurrentValue";
            this.LblCurrentValue.Size = new System.Drawing.Size(152, 28);
            this.LblCurrentValue.StateAddress = "4641";
            this.LblCurrentValue.TabIndex = 23;
            this.LblCurrentValue.Text = "当前电流值";
            // 
            // LblCurrent
            // 
            this.LblCurrent.AutoSize = true;
            this.LblCurrent.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCurrent.Location = new System.Drawing.Point(57, 73);
            this.LblCurrent.Name = "LblCurrent";
            this.LblCurrent.Size = new System.Drawing.Size(124, 28);
            this.LblCurrent.TabIndex = 22;
            this.LblCurrent.Text = "当前电流";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(571, 73);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(124, 28);
            this.LblTime.TabIndex = 21;
            this.LblTime.Text = "当前时间";
            // 
            // FrmSemi_Auto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmSemi_Auto";
            this.Text = "瞬时检测半自动";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSemi_Auto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ACA_Common.ButtonNew BtnStart;
        private ACA_Common.ButtonNew BtnEnd;
        private ACA_Common.ButtonNew BtnJigs;
        private ACA_Common.ButtonNew BtnExit;
        private ACA_Common.ButtonNew BtnHigh;
        private ACA_Common.ButtonNew BtnLow;
        private ACA_Common.ButtonNew BtnOutPutA;
        private ACA_Common.ButtonNew BtnOutPutC;
        private ACA_Common.ButtonNew BtnOutPutB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ACA_Common.LabelNew LblTestPhase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ACA_Common.LabelNew LblTimeValue;
        private ACA_Common.LabelNew LblStateValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblState;
        private ACA_Common.LabelNew LblCurrentValue;
        private System.Windows.Forms.Label LblCurrent;
        private System.Windows.Forms.Label LblTime;
    }
}