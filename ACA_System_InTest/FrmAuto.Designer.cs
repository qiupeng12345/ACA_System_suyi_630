namespace ACA_System_InTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GbxState = new System.Windows.Forms.GroupBox();
            this.LblTestPhase = new ACA_Common.LabelNew();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTimeValue = new ACA_Common.LabelNew();
            this.LblStateValue = new ACA_Common.LabelNew();
            this.label3 = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.LblCurrentValue = new ACA_Common.LabelNew();
            this.LblCurrent = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvAlarm = new System.Windows.Forms.DataGridView();
            this.alarmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarmInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblManualJudge = new System.Windows.Forms.Label();
            this.BtnNo = new ACA_Common.ButtonNew();
            this.BtnOk = new ACA_Common.ButtonNew();
            this.BtnEnd = new ACA_Common.ButtonNew();
            this.BtnJigs = new ACA_Common.ButtonNew();
            this.BtnReady = new ACA_Common.ButtonNew();
            this.BtnAlarm = new ACA_Common.ButtonNew();
            this.BtnStop = new ACA_Common.ButtonNew();
            this.BtnStart = new ACA_Common.ButtonNew();
            this.LblSelectModel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GbxState.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxState
            // 
            this.GbxState.Controls.Add(this.LblTestPhase);
            this.GbxState.Controls.Add(this.label2);
            this.GbxState.Controls.Add(this.label1);
            this.GbxState.Controls.Add(this.LblTimeValue);
            this.GbxState.Controls.Add(this.LblStateValue);
            this.GbxState.Controls.Add(this.label3);
            this.GbxState.Controls.Add(this.LblState);
            this.GbxState.Controls.Add(this.LblCurrentValue);
            this.GbxState.Controls.Add(this.LblCurrent);
            this.GbxState.Controls.Add(this.LblTime);
            this.GbxState.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GbxState.Location = new System.Drawing.Point(4, 65);
            this.GbxState.Name = "GbxState";
            this.GbxState.Size = new System.Drawing.Size(1016, 144);
            this.GbxState.TabIndex = 0;
            this.GbxState.TabStop = false;
            this.GbxState.Text = "工作状态";
            // 
            // LblTestPhase
            // 
            this.LblTestPhase.Address = "15010";
            this.LblTestPhase.AutoSize = true;
            this.LblTestPhase.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTestPhase.Location = new System.Drawing.Point(845, 102);
            this.LblTestPhase.Name = "LblTestPhase";
            this.LblTestPhase.Size = new System.Drawing.Size(124, 28);
            this.LblTestPhase.StateAddress = null;
            this.LblTestPhase.TabIndex = 20;
            this.LblTestPhase.Text = "测试相位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(585, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "高低倍测试相位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(919, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "ms";
            // 
            // LblTimeValue
            // 
            this.LblTimeValue.Address = "4642";
            this.LblTimeValue.AutoSize = true;
            this.LblTimeValue.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTimeValue.Location = new System.Drawing.Point(780, 44);
            this.LblTimeValue.Name = "LblTimeValue";
            this.LblTimeValue.Size = new System.Drawing.Size(68, 28);
            this.LblTimeValue.StateAddress = "4643";
            this.LblTimeValue.TabIndex = 17;
            this.LblTimeValue.Text = "时间";
            // 
            // LblStateValue
            // 
            this.LblStateValue.Address = null;
            this.LblStateValue.AutoSize = true;
            this.LblStateValue.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblStateValue.Location = new System.Drawing.Point(263, 102);
            this.LblStateValue.Name = "LblStateValue";
            this.LblStateValue.Size = new System.Drawing.Size(124, 28);
            this.LblStateValue.StateAddress = null;
            this.LblStateValue.TabIndex = 16;
            this.LblStateValue.Text = "工作状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "A";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblState.Location = new System.Drawing.Point(43, 102);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(180, 28);
            this.LblState.TabIndex = 14;
            this.LblState.Text = "当前工作状态";
            // 
            // LblCurrentValue
            // 
            this.LblCurrentValue.Address = "4640";
            this.LblCurrentValue.AutoSize = true;
            this.LblCurrentValue.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCurrentValue.Location = new System.Drawing.Point(208, 44);
            this.LblCurrentValue.Name = "LblCurrentValue";
            this.LblCurrentValue.Size = new System.Drawing.Size(152, 28);
            this.LblCurrentValue.StateAddress = "4641";
            this.LblCurrentValue.TabIndex = 13;
            this.LblCurrentValue.Text = "当前电流值";
            // 
            // LblCurrent
            // 
            this.LblCurrent.AutoSize = true;
            this.LblCurrent.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCurrent.Location = new System.Drawing.Point(43, 44);
            this.LblCurrent.Name = "LblCurrent";
            this.LblCurrent.Size = new System.Drawing.Size(124, 28);
            this.LblCurrent.TabIndex = 12;
            this.LblCurrent.Text = "当前电流";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(585, 43);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(124, 28);
            this.LblTime.TabIndex = 11;
            this.LblTime.Text = "当前时间";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(429, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 38);
            this.label11.TabIndex = 10;
            this.label11.Text = "瞬时检测单元";
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(870, 506);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(130, 81);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvAlarm);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 272);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报警记录";
            // 
            // DgvAlarm
            // 
            this.DgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alarmTime,
            this.alarmInfo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAlarm.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvAlarm.Location = new System.Drawing.Point(8, 33);
            this.DgvAlarm.Name = "DgvAlarm";
            this.DgvAlarm.RowTemplate.Height = 27;
            this.DgvAlarm.Size = new System.Drawing.Size(1002, 224);
            this.DgvAlarm.TabIndex = 0;
            // 
            // alarmTime
            // 
            this.alarmTime.DataPropertyName = "Time";
            this.alarmTime.HeaderText = "报警时间";
            this.alarmTime.Name = "alarmTime";
            this.alarmTime.Width = 300;
            // 
            // alarmInfo
            // 
            this.alarmInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.alarmInfo.DataPropertyName = "Info";
            this.alarmInfo.HeaderText = "报警信息";
            this.alarmInfo.Name = "alarmInfo";
            // 
            // LblManualJudge
            // 
            this.LblManualJudge.AutoSize = true;
            this.LblManualJudge.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblManualJudge.Location = new System.Drawing.Point(12, 520);
            this.LblManualJudge.Name = "LblManualJudge";
            this.LblManualJudge.Size = new System.Drawing.Size(124, 28);
            this.LblManualJudge.TabIndex = 23;
            this.LblManualJudge.Text = "人工确认";
            // 
            // BtnNo
            // 
            this.BtnNo.Address = "142102";
            this.BtnNo.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnNo.Location = new System.Drawing.Point(163, 609);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.No = 0;
            this.BtnNo.Size = new System.Drawing.Size(130, 81);
            this.BtnNo.StateAddress = "142113";
            this.BtnNo.TabIndex = 25;
            this.BtnNo.Tag = "";
            this.BtnNo.Text = "不合格";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Address = "142101";
            this.BtnOk.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(163, 508);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.No = 0;
            this.BtnOk.Size = new System.Drawing.Size(134, 80);
            this.BtnOk.StateAddress = "142112";
            this.BtnOk.TabIndex = 24;
            this.BtnOk.Text = "合格";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnEnd
            // 
            this.BtnEnd.Address = "142306";
            this.BtnEnd.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnEnd.Location = new System.Drawing.Point(702, 610);
            this.BtnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.No = 0;
            this.BtnEnd.Size = new System.Drawing.Size(130, 80);
            this.BtnEnd.StateAddress = "142309";
            this.BtnEnd.TabIndex = 22;
            this.BtnEnd.Text = "调试完成";
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnJigs
            // 
            this.BtnJigs.Address = "142305";
            this.BtnJigs.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnJigs.Location = new System.Drawing.Point(533, 609);
            this.BtnJigs.Margin = new System.Windows.Forms.Padding(4);
            this.BtnJigs.Name = "BtnJigs";
            this.BtnJigs.No = 0;
            this.BtnJigs.Size = new System.Drawing.Size(128, 80);
            this.BtnJigs.StateAddress = "142308";
            this.BtnJigs.TabIndex = 21;
            this.BtnJigs.Text = "夹具进";
            this.BtnJigs.UseVisualStyleBackColor = true;
            this.BtnJigs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnJigs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnReady
            // 
            this.BtnReady.Address = "142304";
            this.BtnReady.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady.Location = new System.Drawing.Point(353, 607);
            this.BtnReady.Margin = new System.Windows.Forms.Padding(4);
            this.BtnReady.Name = "BtnReady";
            this.BtnReady.No = 0;
            this.BtnReady.Size = new System.Drawing.Size(128, 81);
            this.BtnReady.StateAddress = "142307";
            this.BtnReady.TabIndex = 20;
            this.BtnReady.Text = "准备就绪";
            this.BtnReady.UseVisualStyleBackColor = true;
            this.BtnReady.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnReady.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnAlarm
            // 
            this.BtnAlarm.Address = "142106";
            this.BtnAlarm.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAlarm.Location = new System.Drawing.Point(702, 508);
            this.BtnAlarm.Name = "BtnAlarm";
            this.BtnAlarm.No = 0;
            this.BtnAlarm.Size = new System.Drawing.Size(130, 81);
            this.BtnAlarm.StateAddress = "142106";
            this.BtnAlarm.TabIndex = 19;
            this.BtnAlarm.Text = "报警解除";
            this.BtnAlarm.UseVisualStyleBackColor = true;
            this.BtnAlarm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnAlarm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnStop
            // 
            this.BtnStop.Address = "142102";
            this.BtnStop.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStop.Location = new System.Drawing.Point(531, 508);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.No = 0;
            this.BtnStop.Size = new System.Drawing.Size(130, 81);
            this.BtnStop.StateAddress = "142113";
            this.BtnStop.TabIndex = 2;
            this.BtnStop.Text = "停止";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // BtnStart
            // 
            this.BtnStart.Address = "142101";
            this.BtnStart.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(353, 508);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.No = 0;
            this.BtnStart.Size = new System.Drawing.Size(134, 80);
            this.BtnStart.StateAddress = "142112";
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "启动";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.BtnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // LblSelectModel
            // 
            this.LblSelectModel.AutoSize = true;
            this.LblSelectModel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblSelectModel.Location = new System.Drawing.Point(203, 12);
            this.LblSelectModel.Name = "LblSelectModel";
            this.LblSelectModel.Size = new System.Drawing.Size(154, 24);
            this.LblSelectModel.TabIndex = 33;
            this.LblSelectModel.Text = "当前选择型号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(19, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "当前选择型号：";
            // 
            // FrmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.LblSelectModel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblManualJudge);
            this.Controls.Add(this.BtnEnd);
            this.Controls.Add(this.BtnJigs);
            this.Controls.Add(this.BtnReady);
            this.Controls.Add(this.BtnAlarm);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.GbxState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动瞬时检测";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAuto_Load);
            this.GbxState.ResumeLayout(false);
            this.GbxState.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxState;
        private System.Windows.Forms.Label label11;
        private ACA_Common.ButtonNew BtnStart;
        private ACA_Common.ButtonNew BtnStop;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblCurrent;
        private System.Windows.Forms.Button BtnExit;
        private ACA_Common.LabelNew LblCurrentValue;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private ACA_Common.ButtonNew BtnAlarm;
        private ACA_Common.LabelNew LblTimeValue;
        private ACA_Common.LabelNew LblStateValue;
        private System.Windows.Forms.DataGridView DgvAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn alarmInfo;
        private System.Windows.Forms.Label label1;
        private ACA_Common.LabelNew LblTestPhase;
        private System.Windows.Forms.Label label2;
        private ACA_Common.ButtonNew BtnEnd;
        private ACA_Common.ButtonNew BtnJigs;
        private ACA_Common.ButtonNew BtnReady;
        private System.Windows.Forms.Label LblManualJudge;
        private ACA_Common.ButtonNew BtnNo;
        private ACA_Common.ButtonNew BtnOk;
        private System.Windows.Forms.Label LblSelectModel;
        private System.Windows.Forms.Label label8;
    }
}