namespace Aca_System_WholeTest
{
    partial class FrmManual2
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
            this.BtnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNew4 = new ACA_Common.ButtonNew();
            this.buttonNew3 = new ACA_Common.ButtonNew();
            this.buttonNew2 = new ACA_Common.ButtonNew();
            this.buttonNew1 = new ACA_Common.ButtonNew();
            this.TmrState = new System.Windows.Forms.Timer(this.components);
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.buttonNew13 = new ACA_Common.ButtonNew();
            this.buttonNew14 = new ACA_Common.ButtonNew();
            this.buttonNew15 = new ACA_Common.ButtonNew();
            this.buttonNew16 = new ACA_Common.ButtonNew();
            this.buttonNew17 = new ACA_Common.ButtonNew();
            this.buttonNew18 = new ACA_Common.ButtonNew();
            this.buttonNew7 = new ACA_Common.ButtonNew();
            this.buttonNew8 = new ACA_Common.ButtonNew();
            this.buttonNew9 = new ACA_Common.ButtonNew();
            this.buttonNew10 = new ACA_Common.ButtonNew();
            this.buttonNew11 = new ACA_Common.ButtonNew();
            this.buttonNew12 = new ACA_Common.ButtonNew();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnBack.Location = new System.Drawing.Point(841, 5);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(163, 69);
            this.BtnBack.TabIndex = 39;
            this.BtnBack.Text = "退出  <<";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(468, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 50);
            this.label1.TabIndex = 38;
            this.label1.Text = "工位1/2手动";
            // 
            // buttonNew4
            // 
            this.buttonNew4.Address = "160307";
            this.buttonNew4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew4.Location = new System.Drawing.Point(714, 602);
            this.buttonNew4.Name = "buttonNew4";
            this.buttonNew4.No = 0;
            this.buttonNew4.Size = new System.Drawing.Size(264, 66);
            this.buttonNew4.StateAddress = "562107";
            this.buttonNew4.TabIndex = 23;
            this.buttonNew4.Text = "C5-3-4工位2电极升降气缸上升";
            this.buttonNew4.UseVisualStyleBackColor = true;
            this.buttonNew4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew3
            // 
            this.buttonNew3.Address = "160306";
            this.buttonNew3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew3.Location = new System.Drawing.Point(714, 507);
            this.buttonNew3.Name = "buttonNew3";
            this.buttonNew3.No = 0;
            this.buttonNew3.Size = new System.Drawing.Size(264, 66);
            this.buttonNew3.StateAddress = "562106";
            this.buttonNew3.TabIndex = 22;
            this.buttonNew3.Text = "C5-3-4工位2电极升降气缸下降";
            this.buttonNew3.UseVisualStyleBackColor = true;
            this.buttonNew3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew2
            // 
            this.buttonNew2.Address = "160305";
            this.buttonNew2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew2.Location = new System.Drawing.Point(714, 413);
            this.buttonNew2.Name = "buttonNew2";
            this.buttonNew2.No = 0;
            this.buttonNew2.Size = new System.Drawing.Size(264, 66);
            this.buttonNew2.StateAddress = "562105";
            this.buttonNew2.TabIndex = 21;
            this.buttonNew2.Text = "C5-3-3工位2电极加电气缸后退";
            this.buttonNew2.UseVisualStyleBackColor = true;
            this.buttonNew2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew1
            // 
            this.buttonNew1.Address = "160304";
            this.buttonNew1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew1.Location = new System.Drawing.Point(714, 314);
            this.buttonNew1.Name = "buttonNew1";
            this.buttonNew1.No = 0;
            this.buttonNew1.Size = new System.Drawing.Size(264, 66);
            this.buttonNew1.StateAddress = "562104";
            this.buttonNew1.TabIndex = 20;
            this.buttonNew1.Text = "C5-3-3工位2电极加电气缸前进";
            this.buttonNew1.UseVisualStyleBackColor = true;
            this.buttonNew1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // TmrState
            // 
            this.TmrState.Interval = 40;
            this.TmrState.Tick += new System.EventHandler(this.TmrState_Tick);
            // 
            // BtnDown
            // 
            this.BtnDown.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDown.Location = new System.Drawing.Point(237, 12);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(157, 69);
            this.BtnDown.TabIndex = 134;
            this.BtnDown.Text = "下一页";
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnUp
            // 
            this.BtnUp.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnUp.Location = new System.Drawing.Point(48, 12);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(157, 69);
            this.BtnUp.TabIndex = 133;
            this.BtnUp.Text = "上一页";
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // buttonNew13
            // 
            this.buttonNew13.Address = "160303";
            this.buttonNew13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew13.Location = new System.Drawing.Point(714, 215);
            this.buttonNew13.Name = "buttonNew13";
            this.buttonNew13.No = 0;
            this.buttonNew13.Size = new System.Drawing.Size(264, 70);
            this.buttonNew13.StateAddress = "562103";
            this.buttonNew13.TabIndex = 140;
            this.buttonNew13.Text = "C5-3-2工位2通讯气缸缩回";
            this.buttonNew13.UseVisualStyleBackColor = true;
            this.buttonNew13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew14
            // 
            this.buttonNew14.Address = "160302";
            this.buttonNew14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew14.Location = new System.Drawing.Point(714, 108);
            this.buttonNew14.Name = "buttonNew14";
            this.buttonNew14.No = 0;
            this.buttonNew14.Size = new System.Drawing.Size(264, 70);
            this.buttonNew14.StateAddress = "562102";
            this.buttonNew14.TabIndex = 139;
            this.buttonNew14.Text = "C5-3-2工位2通讯气缸伸出";
            this.buttonNew14.UseVisualStyleBackColor = true;
            this.buttonNew14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew15
            // 
            this.buttonNew15.Address = "160301";
            this.buttonNew15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew15.Location = new System.Drawing.Point(375, 570);
            this.buttonNew15.Name = "buttonNew15";
            this.buttonNew15.No = 0;
            this.buttonNew15.Size = new System.Drawing.Size(264, 70);
            this.buttonNew15.StateAddress = "562101";
            this.buttonNew15.TabIndex = 138;
            this.buttonNew15.Text = "C5-3-1工位2产品定位气缸缩回";
            this.buttonNew15.UseVisualStyleBackColor = true;
            this.buttonNew15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew16
            // 
            this.buttonNew16.Address = "160300";
            this.buttonNew16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew16.Location = new System.Drawing.Point(375, 458);
            this.buttonNew16.Name = "buttonNew16";
            this.buttonNew16.No = 0;
            this.buttonNew16.Size = new System.Drawing.Size(264, 70);
            this.buttonNew16.StateAddress = "562100";
            this.buttonNew16.TabIndex = 137;
            this.buttonNew16.Text = "C5-3-1工位2产品定位气缸伸出";
            this.buttonNew16.UseVisualStyleBackColor = true;
            this.buttonNew16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew17
            // 
            this.buttonNew17.Address = "160215";
            this.buttonNew17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew17.Location = new System.Drawing.Point(375, 342);
            this.buttonNew17.Name = "buttonNew17";
            this.buttonNew17.No = 0;
            this.buttonNew17.Size = new System.Drawing.Size(264, 70);
            this.buttonNew17.StateAddress = "562015";
            this.buttonNew17.TabIndex = 136;
            this.buttonNew17.Text = "C5-2-4工位1电极升降气缸上升";
            this.buttonNew17.UseVisualStyleBackColor = true;
            this.buttonNew17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew17.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew18
            // 
            this.buttonNew18.Address = "160214";
            this.buttonNew18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew18.Location = new System.Drawing.Point(375, 226);
            this.buttonNew18.Name = "buttonNew18";
            this.buttonNew18.No = 0;
            this.buttonNew18.Size = new System.Drawing.Size(264, 70);
            this.buttonNew18.StateAddress = "562014";
            this.buttonNew18.TabIndex = 135;
            this.buttonNew18.Text = "C5-2-4工位1电极升降气缸下降";
            this.buttonNew18.UseVisualStyleBackColor = true;
            this.buttonNew18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew18.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew7
            // 
            this.buttonNew7.Address = "160213";
            this.buttonNew7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew7.Location = new System.Drawing.Point(375, 108);
            this.buttonNew7.Name = "buttonNew7";
            this.buttonNew7.No = 0;
            this.buttonNew7.Size = new System.Drawing.Size(264, 70);
            this.buttonNew7.StateAddress = "562013";
            this.buttonNew7.TabIndex = 146;
            this.buttonNew7.Text = "C5-2-3工位1电极加电气缸后退";
            this.buttonNew7.UseVisualStyleBackColor = true;
            this.buttonNew7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew8
            // 
            this.buttonNew8.Address = "160212";
            this.buttonNew8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew8.Location = new System.Drawing.Point(64, 570);
            this.buttonNew8.Name = "buttonNew8";
            this.buttonNew8.No = 0;
            this.buttonNew8.Size = new System.Drawing.Size(264, 70);
            this.buttonNew8.StateAddress = "562012";
            this.buttonNew8.TabIndex = 145;
            this.buttonNew8.Text = "C5-2-3工位1电极加电气缸前进";
            this.buttonNew8.UseVisualStyleBackColor = true;
            this.buttonNew8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew9
            // 
            this.buttonNew9.Address = "160211";
            this.buttonNew9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew9.Location = new System.Drawing.Point(64, 458);
            this.buttonNew9.Name = "buttonNew9";
            this.buttonNew9.No = 0;
            this.buttonNew9.Size = new System.Drawing.Size(264, 70);
            this.buttonNew9.StateAddress = "562011";
            this.buttonNew9.TabIndex = 144;
            this.buttonNew9.Text = "C5-2-2工位1通讯气缸缩回";
            this.buttonNew9.UseVisualStyleBackColor = true;
            this.buttonNew9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew10
            // 
            this.buttonNew10.Address = "160210";
            this.buttonNew10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew10.Location = new System.Drawing.Point(64, 342);
            this.buttonNew10.Name = "buttonNew10";
            this.buttonNew10.No = 0;
            this.buttonNew10.Size = new System.Drawing.Size(264, 70);
            this.buttonNew10.StateAddress = "562010";
            this.buttonNew10.TabIndex = 143;
            this.buttonNew10.Text = "C5-2-2工位1通讯气缸伸出";
            this.buttonNew10.UseVisualStyleBackColor = true;
            this.buttonNew10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew11
            // 
            this.buttonNew11.Address = "160209";
            this.buttonNew11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew11.Location = new System.Drawing.Point(64, 226);
            this.buttonNew11.Name = "buttonNew11";
            this.buttonNew11.No = 0;
            this.buttonNew11.Size = new System.Drawing.Size(264, 70);
            this.buttonNew11.StateAddress = "562009";
            this.buttonNew11.TabIndex = 142;
            this.buttonNew11.Text = "C5-2-1工位1产品定位气缸缩回";
            this.buttonNew11.UseVisualStyleBackColor = true;
            this.buttonNew11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // buttonNew12
            // 
            this.buttonNew12.Address = "160208";
            this.buttonNew12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew12.Location = new System.Drawing.Point(64, 108);
            this.buttonNew12.Name = "buttonNew12";
            this.buttonNew12.No = 0;
            this.buttonNew12.Size = new System.Drawing.Size(264, 70);
            this.buttonNew12.StateAddress = "562008";
            this.buttonNew12.TabIndex = 141;
            this.buttonNew12.Text = "C5-2-1工位1产品定位气缸伸出";
            this.buttonNew12.UseVisualStyleBackColor = true;
            this.buttonNew12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseDown);
            this.buttonNew12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_MouseUp);
            // 
            // FrmManual2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 701);
            this.Controls.Add(this.buttonNew7);
            this.Controls.Add(this.buttonNew8);
            this.Controls.Add(this.buttonNew9);
            this.Controls.Add(this.buttonNew10);
            this.Controls.Add(this.buttonNew11);
            this.Controls.Add(this.buttonNew12);
            this.Controls.Add(this.buttonNew13);
            this.Controls.Add(this.buttonNew14);
            this.Controls.Add(this.buttonNew15);
            this.Controls.Add(this.buttonNew16);
            this.Controls.Add(this.buttonNew17);
            this.Controls.Add(this.buttonNew18);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnUp);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNew4);
            this.Controls.Add(this.buttonNew3);
            this.Controls.Add(this.buttonNew2);
            this.Controls.Add(this.buttonNew1);
            this.Name = "FrmManual2";
            this.Text = "手动界面2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmManual2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label1;
        private ACA_Common.ButtonNew buttonNew4;
        private ACA_Common.ButtonNew buttonNew3;
        private ACA_Common.ButtonNew buttonNew2;
        private ACA_Common.ButtonNew buttonNew1;
        private System.Windows.Forms.Timer TmrState;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.Button BtnUp;
        private ACA_Common.ButtonNew buttonNew13;
        private ACA_Common.ButtonNew buttonNew14;
        private ACA_Common.ButtonNew buttonNew15;
        private ACA_Common.ButtonNew buttonNew16;
        private ACA_Common.ButtonNew buttonNew17;
        private ACA_Common.ButtonNew buttonNew18;
        private ACA_Common.ButtonNew buttonNew7;
        private ACA_Common.ButtonNew buttonNew8;
        private ACA_Common.ButtonNew buttonNew9;
        private ACA_Common.ButtonNew buttonNew10;
        private ACA_Common.ButtonNew buttonNew11;
        private ACA_Common.ButtonNew buttonNew12;
    }
}