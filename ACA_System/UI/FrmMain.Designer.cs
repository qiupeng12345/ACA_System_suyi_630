namespace ACA_System.UI
{
    partial class FrmMain
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
            this.BtnAuto = new System.Windows.Forms.Button();
            this.BtnSetParameter = new System.Windows.Forms.Button();
            this.BtnCurrentTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnManual1 = new System.Windows.Forms.Button();
            this.BtnReady = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnManual2 = new System.Windows.Forms.Button();
            this.BtnAutoSelect = new System.Windows.Forms.Button();
            this.BtnManual3 = new System.Windows.Forms.Button();
            this.LblPlcState = new System.Windows.Forms.Label();
            this.TmrState = new System.Windows.Forms.Timer();
            this.LblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAuto
            // 
            this.BtnAuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAuto.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAuto.Location = new System.Drawing.Point(434, 122);
            this.BtnAuto.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAuto.Name = "BtnAuto";
            this.BtnAuto.Size = new System.Drawing.Size(145, 117);
            this.BtnAuto.TabIndex = 0;
            this.BtnAuto.Text = "全自动 >>>";
            this.BtnAuto.UseVisualStyleBackColor = true;
            this.BtnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // BtnSetParameter
            // 
            this.BtnSetParameter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSetParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetParameter.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSetParameter.Location = new System.Drawing.Point(167, 290);
            this.BtnSetParameter.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSetParameter.Name = "BtnSetParameter";
            this.BtnSetParameter.Size = new System.Drawing.Size(145, 117);
            this.BtnSetParameter.TabIndex = 1;
            this.BtnSetParameter.Text = "参数设置  >>>";
            this.BtnSetParameter.UseVisualStyleBackColor = true;
            this.BtnSetParameter.Click += new System.EventHandler(this.BtnSetParameter_Click);
            // 
            // BtnCurrentTest
            // 
            this.BtnCurrentTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCurrentTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCurrentTest.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCurrentTest.Location = new System.Drawing.Point(692, 122);
            this.BtnCurrentTest.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCurrentTest.Name = "BtnCurrentTest";
            this.BtnCurrentTest.Size = new System.Drawing.Size(145, 117);
            this.BtnCurrentTest.TabIndex = 2;
            this.BtnCurrentTest.Text = "校对测试半自动  >>>";
            this.BtnCurrentTest.UseVisualStyleBackColor = true;
            this.BtnCurrentTest.Click += new System.EventHandler(this.BtnCurrentTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(411, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "江苏苏益";
            // 
            // BtnManual1
            // 
            this.BtnManual1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnManual1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnManual1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManual1.Location = new System.Drawing.Point(167, 460);
            this.BtnManual1.Margin = new System.Windows.Forms.Padding(4);
            this.BtnManual1.Name = "BtnManual1";
            this.BtnManual1.Size = new System.Drawing.Size(145, 117);
            this.BtnManual1.TabIndex = 7;
            this.BtnManual1.Text = "手动界面1  >>>";
            this.BtnManual1.UseVisualStyleBackColor = true;
            this.BtnManual1.Click += new System.EventHandler(this.BtnManual_Click);
            // 
            // BtnReady
            // 
            this.BtnReady.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReady.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady.Location = new System.Drawing.Point(434, 290);
            this.BtnReady.Margin = new System.Windows.Forms.Padding(4);
            this.BtnReady.Name = "BtnReady";
            this.BtnReady.Size = new System.Drawing.Size(145, 117);
            this.BtnReady.TabIndex = 8;
            this.BtnReady.Text = "就绪界面 >>>";
            this.BtnReady.UseVisualStyleBackColor = true;
            this.BtnReady.Click += new System.EventHandler(this.BtnReady_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExit.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(692, 290);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(145, 117);
            this.BtnExit.TabIndex = 9;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnManual2
            // 
            this.BtnManual2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnManual2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnManual2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManual2.Location = new System.Drawing.Point(436, 460);
            this.BtnManual2.Margin = new System.Windows.Forms.Padding(4);
            this.BtnManual2.Name = "BtnManual2";
            this.BtnManual2.Size = new System.Drawing.Size(145, 117);
            this.BtnManual2.TabIndex = 13;
            this.BtnManual2.Text = "手动界面2  >>>";
            this.BtnManual2.UseVisualStyleBackColor = true;
            this.BtnManual2.Click += new System.EventHandler(this.BtnManual2_Click);
            // 
            // BtnAutoSelect
            // 
            this.BtnAutoSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAutoSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAutoSelect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAutoSelect.Location = new System.Drawing.Point(167, 122);
            this.BtnAutoSelect.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAutoSelect.Name = "BtnAutoSelect";
            this.BtnAutoSelect.Size = new System.Drawing.Size(145, 117);
            this.BtnAutoSelect.TabIndex = 12;
            this.BtnAutoSelect.Text = "自动功能选择 >>>";
            this.BtnAutoSelect.UseVisualStyleBackColor = true;
            this.BtnAutoSelect.Click += new System.EventHandler(this.BtnAutoSelect_Click);
            // 
            // BtnManual3
            // 
            this.BtnManual3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnManual3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnManual3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManual3.Location = new System.Drawing.Point(692, 460);
            this.BtnManual3.Margin = new System.Windows.Forms.Padding(4);
            this.BtnManual3.Name = "BtnManual3";
            this.BtnManual3.Size = new System.Drawing.Size(145, 117);
            this.BtnManual3.TabIndex = 10;
            this.BtnManual3.Text = "手动界面3  >>>";
            this.BtnManual3.UseVisualStyleBackColor = true;
            this.BtnManual3.Click += new System.EventHandler(this.BtnManual3_Click);
            // 
            // LblPlcState
            // 
            this.LblPlcState.AutoSize = true;
            this.LblPlcState.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPlcState.Location = new System.Drawing.Point(821, 646);
            this.LblPlcState.Name = "LblPlcState";
            this.LblPlcState.Size = new System.Drawing.Size(142, 24);
            this.LblPlcState.TabIndex = 14;
            this.LblPlcState.Text = "PLC通信状态";
            // 
            // TmrState
            // 
            this.TmrState.Interval = 300;
            this.TmrState.Tick += new System.EventHandler(this.TmrState_Tick);
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(401, 651);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(106, 24);
            this.LblTime.TabIndex = 16;
            this.LblTime.Text = "当前时间";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.LblPlcState);
            this.Controls.Add(this.BtnManual2);
            this.Controls.Add(this.BtnAutoSelect);
            this.Controls.Add(this.BtnManual3);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnReady);
            this.Controls.Add(this.BtnManual1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCurrentTest);
            this.Controls.Add(this.BtnSetParameter);
            this.Controls.Add(this.BtnAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button BtnAuto;
        protected System.Windows.Forms.Button BtnSetParameter;
        protected System.Windows.Forms.Button BtnCurrentTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnManual1;
        protected System.Windows.Forms.Button BtnReady;
        protected System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnManual2;
        protected System.Windows.Forms.Button BtnAutoSelect;
        protected System.Windows.Forms.Button BtnManual3;
        private System.Windows.Forms.Label LblPlcState;
        private System.Windows.Forms.Timer TmrState;
        private System.Windows.Forms.Label LblTime;
    }
}