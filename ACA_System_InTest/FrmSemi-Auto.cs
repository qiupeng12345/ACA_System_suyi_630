using ACA_Common.Class;
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
using log4net;
namespace ACA_System_InTest
{
    public partial class FrmSemi_Auto : Form
    {
        System.Threading.Timer tmrState;
        ButtonNew[] btnArray = new ButtonNew[8];
        LabelNew[] lblArray = new LabelNew[2];
        public FrmSemi_Auto()
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
                for (int i = 0; i < lblArray.Length; i++)
                {
                    lblArray[i].Text = DoubleConvert.Dint_to_Real((uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].StateAddress)
                     , (uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].Address)).ToString("0.00");

                }

                for (int i = 0; i < btnArray.Length; i++)
                {
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, btnArray[i].StateAddress) == 1)
                    {
                        btnArray[i].BackColor = Color.GreenYellow;
                    }
                    else btnArray[i].BackColor = Color.FromArgb(212, 208, 200);
                }
                switch (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, LblTestPhase.Address))
                {
                    case 1:
                        LblTestPhase.Text = "A相";
                        break;
                    case 2:
                        LblTestPhase.Text = "B相";
                        break;
                    case 3:
                        LblTestPhase.Text = "C相";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
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
        private void FrmSemi_Auto_Load(object sender, EventArgs e)
        {
            btnArray[0] = BtnStart;
            btnArray[1] = BtnEnd;
            btnArray[2] = BtnJigs;
            btnArray[3] = BtnOutPutA;
            btnArray[4] = BtnOutPutB;
            btnArray[5] = BtnOutPutC;
            btnArray[6] = BtnLow;
            btnArray[7] = BtnHigh;
            lblArray[0] = LblCurrentValue;
            lblArray[1] = LblTimeValue;
            tmrState = new System.Threading.Timer(StateRefresh, this, 0, 1000);
        }
    }
}
