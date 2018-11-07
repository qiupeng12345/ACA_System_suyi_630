namespace ACA_System_InTest
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnAuto = new System.Windows.Forms.Button();
            this.BtnSemiAuto = new System.Windows.Forms.Button();
            this.BtnParameterSet = new System.Windows.Forms.Button();
            this.BtnManual1 = new System.Windows.Forms.Button();
            this.BtnReady = new System.Windows.Forms.Button();
            this.BtnFunction = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnManual2 = new System.Windows.Forms.Button();
            this.BtnManual3 = new System.Windows.Forms.Button();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.TmrState = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BtnAuto
            // 
            this.BtnAuto.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAuto.Location = new System.Drawing.Point(445, 80);
            this.BtnAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAuto.Name = "BtnAuto";
            this.BtnAuto.Size = new System.Drawing.Size(158, 115);
            this.BtnAuto.TabIndex = 0;
            this.BtnAuto.Text = "自动瞬时检测  >>";
            this.BtnAuto.UseVisualStyleBackColor = true;
            this.BtnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // BtnSemiAuto
            // 
            this.BtnSemiAuto.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSemiAuto.Location = new System.Drawing.Point(755, 80);
            this.BtnSemiAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSemiAuto.Name = "BtnSemiAuto";
            this.BtnSemiAuto.Size = new System.Drawing.Size(158, 115);
            this.BtnSemiAuto.TabIndex = 1;
            this.BtnSemiAuto.Text = "半自动瞬时检测  >>";
            this.BtnSemiAuto.UseVisualStyleBackColor = true;
            this.BtnSemiAuto.Click += new System.EventHandler(this.BtnSemiAuto_Click);
            // 
            // BtnParameterSet
            // 
            this.BtnParameterSet.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnParameterSet.Location = new System.Drawing.Point(131, 262);
            this.BtnParameterSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnParameterSet.Name = "BtnParameterSet";
            this.BtnParameterSet.Size = new System.Drawing.Size(158, 115);
            this.BtnParameterSet.TabIndex = 2;
            this.BtnParameterSet.Text = "瞬时检测参数设置  >>";
            this.BtnParameterSet.UseVisualStyleBackColor = true;
            this.BtnParameterSet.Click += new System.EventHandler(this.BtnParameterSet_Click);
            // 
            // BtnManual1
            // 
            this.BtnManual1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManual1.Location = new System.Drawing.Point(131, 448);
            this.BtnManual1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnManual1.Name = "BtnManual1";
            this.BtnManual1.Size = new System.Drawing.Size(158, 106);
            this.BtnManual1.TabIndex = 3;
            this.BtnManual1.Text = "手动界面1  >>";
            this.BtnManual1.UseVisualStyleBackColor = true;
            this.BtnManual1.Click += new System.EventHandler(this.BtnManual1_Click);
            // 
            // BtnReady
            // 
            this.BtnReady.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReady.Location = new System.Drawing.Point(445, 262);
            this.BtnReady.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReady.Name = "BtnReady";
            this.BtnReady.Size = new System.Drawing.Size(158, 115);
            this.BtnReady.TabIndex = 4;
            this.BtnReady.Text = "就绪界面  >>";
            this.BtnReady.UseVisualStyleBackColor = true;
            this.BtnReady.Click += new System.EventHandler(this.BtnReady_Click);
            // 
            // BtnFunction
            // 
            this.BtnFunction.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnFunction.Location = new System.Drawing.Point(131, 80);
            this.BtnFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnFunction.Name = "BtnFunction";
            this.BtnFunction.Size = new System.Drawing.Size(158, 115);
            this.BtnFunction.TabIndex = 5;
            this.BtnFunction.Text = "自动功能选择  >>";
            this.BtnFunction.UseVisualStyleBackColor = true;
            this.BtnFunction.Click += new System.EventHandler(this.BtnFunction_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Location = new System.Drawing.Point(755, 262);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(158, 115);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnManual2
            // 
            this.BtnManual2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManual2.Location = new System.Drawing.Point(445, 448);
            this.BtnManual2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnManual2.Name = "BtnManual2";
            this.BtnManual2.Size = new System.Drawing.Size(158, 106);
            this.BtnManual2.TabIndex = 7;
            this.BtnManual2.Text = "手动界面2  >>";
            this.BtnManual2.UseVisualStyleBackColor = true;
            this.BtnManual2.Click += new System.EventHandler(this.BtnManual2_Click);
            // 
            // BtnManual3
            // 
            this.BtnManual3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnManual3.Location = new System.Drawing.Point(755, 448);
            this.BtnManual3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnManual3.Name = "BtnManual3";
            this.BtnManual3.Size = new System.Drawing.Size(158, 106);
            this.BtnManual3.TabIndex = 8;
            this.BtnManual3.Text = "手动界面3  >>";
            this.BtnManual3.UseVisualStyleBackColor = true;
            this.BtnManual3.Click += new System.EventHandler(this.BtnManual3_Click);
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(429, 632);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(106, 24);
            this.LblTime.TabIndex = 10;
            this.LblTime.Text = "当前时间";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblState.Location = new System.Drawing.Point(807, 632);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(106, 24);
            this.LblState.TabIndex = 11;
            this.LblState.Text = "当前时间";
            // 
            // TmrState
            // 
            this.TmrState.Tick += new System.EventHandler(this.TmrState_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.BtnManual3);
            this.Controls.Add(this.BtnManual2);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnFunction);
            this.Controls.Add(this.BtnReady);
            this.Controls.Add(this.BtnManual1);
            this.Controls.Add(this.BtnParameterSet);
            this.Controls.Add(this.BtnSemiAuto);
            this.Controls.Add(this.BtnAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "瞬时检测主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAuto;
        private System.Windows.Forms.Button BtnSemiAuto;
        private System.Windows.Forms.Button BtnParameterSet;
        private System.Windows.Forms.Button BtnManual1;
        private System.Windows.Forms.Button BtnReady;
        private System.Windows.Forms.Button BtnFunction;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnManual2;
        private System.Windows.Forms.Button BtnManual3;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Timer TmrState;
    }
}

