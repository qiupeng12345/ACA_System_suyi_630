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

namespace Aca_System_WholeTest
{
    public partial class FrmManual2 : Form
    {
        private ButtonNew[] btnArray = new ButtonNew[16];
        public FrmManual2()
        {
            InitializeComponent();
        }
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                if (Global.kv.Active)
                {
                    if (!Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 1))
                    {
                        MessageBox.Show("plc通信异常");
                    }
                }
                else MessageBox.Show("plc已断开");
            }
            catch (Exception)
            {

            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                if (Global.kv.Active)
                {
                    if (!Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 0))
                    {
                        MessageBox.Show("plc通信异常");
                    }
                }
                else MessageBox.Show("plc已断开");
            }
            catch (Exception)
            {

            }
        }

        private void TmrState_Tick(object sender, EventArgs e)
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
            }
            catch (Exception)
            {

            }
        }

        private void FrmManual2_Load(object sender, EventArgs e)
        {
            btnArray[0] = buttonNew1;
            btnArray[1] = buttonNew2;
            btnArray[2] = buttonNew3;
            btnArray[3] = buttonNew4;
            btnArray[4] = buttonNew17;
            btnArray[5] = buttonNew18;
            btnArray[6] = buttonNew7;
            btnArray[7] = buttonNew8;
            btnArray[8] = buttonNew9;
            btnArray[9] = buttonNew10;
            btnArray[10] = buttonNew11;
            btnArray[11] = buttonNew12;
            btnArray[12] = buttonNew13;
            btnArray[13] = buttonNew14;
            btnArray[14] = buttonNew15;
            btnArray[15] = buttonNew16;
            TmrState.Enabled = true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmManualSelect frmManualSelect = new FrmManualSelect();
            frmManualSelect.ShowDialog();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual1 frmManual1 = new FrmManual1();
            frmManual1.ShowDialog();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual3 frmManual3 = new FrmManual3();
            frmManual3.ShowDialog();
            
        }

      
    }
}
