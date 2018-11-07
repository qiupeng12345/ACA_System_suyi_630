namespace Aca_System_WholeTest
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
            this.components = new System.ComponentModel.Container();
            this.BtnAuto = new System.Windows.Forms.Button();
            this.BtnSemiAuto = new System.Windows.Forms.Button();
            this.BtnParameter = new System.Windows.Forms.Button();
            this.BtnFunction = new System.Windows.Forms.Button();
            this.BtnReady1 = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.LbLTime = new System.Windows.Forms.Label();
            this.LblPlcConnect = new System.Windows.Forms.Label();
            this.TmrState = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BtnReady2 = new System.Windows.Forms.Button();
            this.BtnReady3 = new System.Windows.Forms.Button();
            this.BtnManualSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAuto
            // 
            this.BtnAuto.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAuto.Location = new System.Drawing.Point(315, 152);
            this.BtnAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAuto.Name = "BtnAuto";
            this.BtnAuto.Size = new System.Drawing.Size(153, 101);
            this.BtnAuto.TabIndex = 0;
            this.BtnAuto.Text = "自动整机检测";
            this.BtnAuto.UseVisualStyleBackColor = true;
            this.BtnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // BtnSemiAuto
            // 
            this.BtnSemiAuto.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSemiAuto.Location = new System.Drawing.Point(540, 152);
            this.BtnSemiAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSemiAuto.Name = "BtnSemiAuto";
            this.BtnSemiAuto.Size = new System.Drawing.Size(156, 101);
            this.BtnSemiAuto.TabIndex = 1;
            this.BtnSemiAuto.Text = "半自动整机检测";
            this.BtnSemiAuto.UseVisualStyleBackColor = true;
            this.BtnSemiAuto.Click += new System.EventHandler(this.BtnSemiAuto_Click);
            // 
            // BtnParameter
            // 
            this.BtnParameter.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnParameter.Location = new System.Drawing.Point(85, 304);
            this.BtnParameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnParameter.Name = "BtnParameter";
            this.BtnParameter.Size = new System.Drawing.Size(153, 102);
            this.BtnParameter.TabIndex = 2;
            this.BtnParameter.Text = "整机检测参数配置";
            this.BtnParameter.UseVisualStyleBackColor = true;
            this.BtnParameter.Click += new System.EventHandler(this.BtnParameter_Click);
            // 
            // BtnFunction
            // 
            this.BtnFunction.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnFunction.Location = new System.Drawing.Point(85, 152);
            this.BtnFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnFunction.Name = "BtnFunction";
            this.BtnFunction.Size = new System.Drawing.Size(153, 101);
            this.BtnFunction.TabIndex = 4;
            this.BtnFunction.Text = "自动功能选择";
            this.BtnFunction.UseVisualStyleBackColor = true;
            this.BtnFunction.Click += new System.EventHandler(this.BtnFunction_Click);
            // 
            // BtnReady1
            // 
            this.BtnReady1.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady1.Location = new System.Drawing.Point(89, 476);
            this.BtnReady1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReady1.Name = "BtnReady1";
            this.BtnReady1.Size = new System.Drawing.Size(153, 101);
            this.BtnReady1.TabIndex = 5;
            this.BtnReady1.Text = "就绪界面1";
            this.BtnReady1.UseVisualStyleBackColor = true;
            this.BtnReady1.Click += new System.EventHandler(this.BtnReady_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(772, 152);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(153, 101);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConnect.Location = new System.Drawing.Point(540, 304);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(153, 101);
            this.BtnConnect.TabIndex = 15;
            this.BtnConnect.Text = "连接plc";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // LbLTime
            // 
            this.LbLTime.AutoSize = true;
            this.LbLTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbLTime.Location = new System.Drawing.Point(427, 645);
            this.LbLTime.Name = "LbLTime";
            this.LbLTime.Size = new System.Drawing.Size(82, 24);
            this.LbLTime.TabIndex = 16;
            this.LbLTime.Text = "label1";
            // 
            // LblPlcConnect
            // 
            this.LblPlcConnect.AutoSize = true;
            this.LblPlcConnect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPlcConnect.Location = new System.Drawing.Point(788, 645);
            this.LblPlcConnect.Name = "LblPlcConnect";
            this.LblPlcConnect.Size = new System.Drawing.Size(82, 24);
            this.LblPlcConnect.TabIndex = 17;
            this.LblPlcConnect.Text = "label2";
            // 
            // TmrState
            // 
            this.TmrState.Interval = 1000;
            this.TmrState.Tick += new System.EventHandler(this.TmrState_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(389, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 50);
            this.label1.TabIndex = 20;
            this.label1.Text = "苏益整机测试";
            // 
            // BtnReady2
            // 
            this.BtnReady2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady2.Location = new System.Drawing.Point(311, 476);
            this.BtnReady2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReady2.Name = "BtnReady2";
            this.BtnReady2.Size = new System.Drawing.Size(153, 101);
            this.BtnReady2.TabIndex = 21;
            this.BtnReady2.Text = "就绪界面2";
            this.BtnReady2.UseVisualStyleBackColor = true;
            this.BtnReady2.Click += new System.EventHandler(this.BtnReady2_Click);
            // 
            // BtnReady3
            // 
            this.BtnReady3.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady3.Location = new System.Drawing.Point(540, 476);
            this.BtnReady3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReady3.Name = "BtnReady3";
            this.BtnReady3.Size = new System.Drawing.Size(153, 101);
            this.BtnReady3.TabIndex = 22;
            this.BtnReady3.Text = "就绪界面3";
            this.BtnReady3.UseVisualStyleBackColor = true;
            this.BtnReady3.Click += new System.EventHandler(this.BtnReady3_Click);
            // 
            // BtnManualSelect
            // 
            this.BtnManualSelect.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManualSelect.Location = new System.Drawing.Point(315, 304);
            this.BtnManualSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnManualSelect.Name = "BtnManualSelect";
            this.BtnManualSelect.Size = new System.Drawing.Size(153, 102);
            this.BtnManualSelect.TabIndex = 23;
            this.BtnManualSelect.Text = "手动界面选择";
            this.BtnManualSelect.UseVisualStyleBackColor = true;
            this.BtnManualSelect.Click += new System.EventHandler(this.BtnManualSelect_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.BtnManualSelect);
            this.Controls.Add(this.BtnReady3);
            this.Controls.Add(this.BtnReady2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblPlcConnect);
            this.Controls.Add(this.LbLTime);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnReady1);
            this.Controls.Add(this.BtnFunction);
            this.Controls.Add(this.BtnParameter);
            this.Controls.Add(this.BtnSemiAuto);
            this.Controls.Add(this.BtnAuto);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAuto;
        private System.Windows.Forms.Button BtnSemiAuto;
        private System.Windows.Forms.Button BtnParameter;
        private System.Windows.Forms.Button BtnFunction;
        private System.Windows.Forms.Button BtnReady1;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label LbLTime;
        private System.Windows.Forms.Label LblPlcConnect;
        private System.Windows.Forms.Timer TmrState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnReady2;
        private System.Windows.Forms.Button BtnReady3;
        private System.Windows.Forms.Button BtnManualSelect;
    }
}