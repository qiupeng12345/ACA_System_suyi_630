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

namespace ACA_System_InTest
{
    public partial class FrmReady : Form
    {
        private System.Threading.Timer tmrState;
        private ButtonNew[] btnArray= new ButtonNew[16];
        public FrmReady()
        {
            InitializeComponent();
        }

        private void FrmReady_Load(object sender, EventArgs e)
        {
            btnArray[0] = buttonNew1;
            btnArray[1] = buttonNew2;
            btnArray[2] = buttonNew3;
            btnArray[3] = buttonNew4;
            btnArray[4] = buttonNew5;
            btnArray[5] = buttonNew6;
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
            tmrState = new System.Threading.Timer(UiDisplay, this, 0, 1000);
        }

       private void UiDisplay(object state)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Display();
                }));
            }
        }

        private void Display()
        {
            try
            {
                for (int i = 0; i < btnArray.Length; i++)
                {
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, btnArray[i].Address) == 1)
                    {
                        btnArray[i].BackColor = Color.GreenYellow;
                    }
                    else btnArray[i].BackColor = Color.FromArgb(212, 208, 200);
                }
            }
            catch (Exception)
            {
                //for (int i = 0; i < btnArray.Length; i++)
                //{
                //    btnArray[i].BackColor = Color.FromArgb(212, 208, 200);
                //}
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            tmrState.Dispose();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
    }
}
