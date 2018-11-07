using ACA_Common.Class;
using System;
using System.Windows.Forms;
using ACA_Common;
using System.Drawing;

namespace ACA_System.UI
{
    public partial class FrmManual1 : Form
    {
        private ButtonNew[] BtnArray = new ButtonNew[18];
        public FrmManual1()
        {
            InitializeComponent();
            
        }
        private void FrmManual1_Load(object sender, EventArgs e)
        {
            BtnArray[0] = buttonNew1;
            BtnArray[1] = buttonNew2;
            BtnArray[2] = buttonNew3;
            BtnArray[3] = buttonNew4;
            BtnArray[4] = buttonNew5;
            BtnArray[5] = buttonNew6;
            BtnArray[6] = buttonNew7;
            BtnArray[7] = buttonNew8;
            BtnArray[8] = buttonNew9;
            BtnArray[9] = buttonNew10;
            BtnArray[10] = buttonNew11;
            BtnArray[11] = buttonNew12;
            BtnArray[12] = buttonNew13;
            BtnArray[13] = buttonNew14;
            BtnArray[14] = buttonNew15;
            BtnArray[15] = buttonNew16;
            BtnArray[16] = buttonNew17;
            BtnArray[17] = buttonNew18;
            TmrState.Enabled = true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        /// <summary>
        /// 按下按钮的操作，置1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseDown(object sender,MouseEventArgs e)
        {
            ButtonNew BtnNew = (ButtonNew)sender;
            try
            {
                if (Global.kv.Active)
                {
                    Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, BtnNew.Address, 1);
                }
                else MessageBox.Show("plc已断开");
            }
            catch (Exception)
            {
                MessageBox.Show("plc通信发生异常");
            }
        }
        /// <summary>
        /// 松开按钮的操作，复位0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseUp(object sender,MouseEventArgs e)
        {
            ButtonNew BtnNew = (ButtonNew)sender;
            try
            {
                if (Global.kv.Active)
                {
                    Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, BtnNew.Address, 0);

                   
                }
                else MessageBox.Show("plc已断开");

            }
            catch (Exception)
            {
                MessageBox.Show("plc通信发生异常");
            }

        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < BtnArray.Length; i++)
                {
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, BtnArray[i].StateAddress) == 1)
                    {
                        BtnArray[i].BackColor = Color.GreenYellow;
                    }
                    else BtnArray[i].BackColor = Color.FromArgb(212, 208, 200);
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual2 frmManual2 = new FrmManual2();
            frmManual2.ShowDialog();
            
        }
    }
}
