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
    public partial class FrmManual5 : Form
    {
        private ButtonNew[] btnArray = new ButtonNew[19];
        public FrmManual5()
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmManualSelect frmManualSelect = new FrmManualSelect();
            frmManualSelect.ShowDialog();
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

        private void FrmManual5_Load(object sender, EventArgs e)
        {
            btnArray[0] = buttonNew1;
            btnArray[1] = buttonNew2;
            btnArray[2] = buttonNew3;
            btnArray[3] = buttonNew4;
            btnArray[4] = buttonNew5;
            btnArray[5] = buttonNew6;
            btnArray[6] = buttonNew7;
            btnArray[7] = buttonNew19;
            btnArray[8] = buttonNew9;
            btnArray[9] = buttonNew10;
            btnArray[10] = buttonNew11;
            btnArray[11] = buttonNew12;
            btnArray[12] = buttonNew20;
            btnArray[13] = buttonNew21;
            btnArray[14] = buttonNew22;
            btnArray[15] = buttonNew23;
            btnArray[16] = buttonNew24;
            btnArray[17] = buttonNew25;
            btnArray[18] = buttonNew26;
            TmrState.Enabled = true;
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual4 frmManual4 = new FrmManual4();
            frmManual4.ShowDialog();
            
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual6 frmManual6 = new FrmManual6();
            frmManual6.ShowDialog();
            
        }
    }
}
