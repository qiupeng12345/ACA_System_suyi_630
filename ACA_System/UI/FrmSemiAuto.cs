using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ACA_Common.Class;
using ACA_Common;

namespace ACA_System.UI
{
    public partial class FrmSemiAuto : Form
    {
        ButtonNew[] btnArray = new ButtonNew[24];
        LabelNew[] lblArray = new LabelNew[7];
        public FrmSemiAuto()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        private void FrmCurrent_Load(object sender, EventArgs e)
        {
            btnArray[0] = BtnStart;
            btnArray[1] = BtnJigs;
            btnArray[2] = BtnTestComplete;
            btnArray[3] = BtnOutput1;
            btnArray[4] = BtnOutput2;
            btnArray[5] = BtnOutput3;
            btnArray[6] = BtnOutput4;
            btnArray[7] = BtnOutput5;
            btnArray[8] = BtnStartVoltage;
            btnArray[9] = BtnJigsVoltage;
            btnArray[10] = BtnEndVoltage;
            btnArray[11] = BtnOutPut1Voltage;
            btnArray[12] = BtnOutPut2Voltage;
            btnArray[13] = BtnOutPut3Voltage;
            btnArray[14] = BtnOutPut4Voltage;
            btnArray[15] = BtnOutPut5Voltage;
            btnArray[16] = BtnStartResidual;
            btnArray[17] = BtnJigsResidual;
            btnArray[18] = BtnEndResidual;
            btnArray[19] = BtnOutPut1Residual;
            btnArray[20] = BtnOutPut2Residual;
            btnArray[21] = BtnOutPut3Residual;
            btnArray[22] = BtnOutPut4Residual;
            btnArray[23] = BtnOutPut5Residual;
            lblArray[0] = LblCurrent;
            lblArray[1] = LblTime;
            lblArray[2] = LblVoltageA;
            lblArray[3] = LblVoltageB;
            lblArray[4] = LblVoltageC;
            lblArray[5] = LblLeakCurrent;
            lblArray[6] = LblLeakCurrentTime;
            TmrState.Enabled = true;
        }
        /// <summary>
        /// 点击输出按钮操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 1);
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 0);
        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            try
            {
                DisPlay();
                InfoDisplay();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            
        }
        private void DisPlay()
        {
            for (int i = 0; i < btnArray.Length; i++)
            {
                if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, btnArray[i].StateAddress) == 1)
                {
                    btnArray[i].BackColor = Color.GreenYellow;
                }
                else btnArray[i].BackColor = Color.FromArgb(212, 208, 200);
            }
        }
        private void InfoDisplay()
        {
            for (int i = 0; i < lblArray.Length; i++)
            {
                lblArray[i].Text = DoubleConvert.Dint_to_Real((uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].StateAddress)
                 , (uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].Address)).ToString("0.00");
                Thread.Sleep(10);
            }
        }
    }
}
