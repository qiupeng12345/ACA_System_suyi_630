using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACA_Common;
using ACA_Common.Class;
using System.Threading;

namespace Aca_System_WholeTest
{
    
    public partial class FrmSemiAuto1 : Form
    {
        System.Threading.Timer tmrState;
        ButtonNew[] btnArray = new ButtonNew[33];
        LabelNew[] lblArray = new LabelNew[15];
        WholeTest wholeTest = new WholeTest();
        public FrmSemiAuto1()
        {
            InitializeComponent();
        }
        private void StateRefresh(object state)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                    State()));
            }
        }
        private void State()
        {
            try
            {
                for (int i = 0; i < btnArray.Length; i++)
                {
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, btnArray[i].StateAddress) == 1)
                    {
                        btnArray[i].BackColor = Color.GreenYellow;
                    }
                    else btnArray[i].BackColor = Color.FromArgb(212, 208, 200);
                }
                for (int i = 0; i < lblArray.Length; i++)
                {
                    lblArray[i].Text = DoubleConvert.Dint_to_Real((uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].StateAddress)
                     , (uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].Address)).ToString("0.00");
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                //MessageBox.Show(ex.ToString());
            }

        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            tmrState.Dispose();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ButtonNew btn = (ButtonNew)sender;
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 1);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }

        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ButtonNew btn = (ButtonNew)sender;
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 0);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }

        }
        private void FrmSemiAuto_Load(object sender, EventArgs e)
        {
            lblArray[0] = LblVoltageA1;
            lblArray[1] = LblVoltageB1;
            lblArray[2] = LblVoltageC1;
            lblArray[3] = LblCurrent1;
            lblArray[4] = LblTime1;
            lblArray[5] = LblVoltageA2;
            lblArray[6] = LblVoltageB2;
            lblArray[7] = LblVoltageC2;
            lblArray[8] = LblCurrent2;
            lblArray[9] = LblTime2;
            lblArray[10] = LblVoltageA3;
            lblArray[11] = LblVoltageB3;
            lblArray[12] = LblVoltageC3;
            lblArray[13] = LblCurrent3;
            lblArray[14] = LblTime3;
            btnArray[0] = BtnStart;
            btnArray[1] = BtnTestComplete;
            btnArray[2] = BtnJigs;
            btnArray[3] = BtnAction1;
            btnArray[4] = BtnAction2;
            btnArray[5] = BtnAction3;
            btnArray[6] = BtnOverVoltage;
            btnArray[7] = BtnUnderVoltage;
            btnArray[8] = BtnLowVoltage;
            btnArray[9] = BtnLosePhase;
            btnArray[10] = BtnZeroPhase;
            btnArray[11] = BtnStart1;
            btnArray[12] = BtnEnd1;
            btnArray[13] = BtnJigs1;
            btnArray[14] = BtnActionTest1;
            btnArray[15] = BtnActionTest2;
            btnArray[16] = BtnActionTest3;
            btnArray[17] = BtnOverVoltage1;
            btnArray[18] = BtnUnderVoltage1;
            btnArray[19] = BtnLowVoltage1;
            btnArray[20] = BtnLosePhase1;
            btnArray[21] = BtnZero1;
            btnArray[22] = BtnStart2;
            btnArray[23] = BtnEnd2;
            btnArray[24] = BtnJigs2;
            btnArray[25] = BtnTest1;
            btnArray[26] = BtnTest2;
            btnArray[27] = BtnTest3;
            btnArray[28] = BtnOverVoltage2;
            btnArray[29] = BtnUnderVoltage2;
            btnArray[30] = BtnLowVoltage2;
            btnArray[31] = BtnLosePhase2;
            btnArray[32] = BtnZero2;
            tmrState = new System.Threading.Timer(StateRefresh, this, 0, 1000);
        }
    }
}
