using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aca_System_WholeTest
{
    public partial class FrmManualSelect : Form
    {
        public FrmManualSelect()
        {
            InitializeComponent();
        }

        private void BtnManual2_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual2 frmManual2 = new FrmManual2();
            frmManual2.ShowDialog();
        }

        private void BtnManual3_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual3 frmManual3 = new FrmManual3();
            frmManual3.ShowDialog();
        }

        private void BtnManual4_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual4 frmManual4 = new FrmManual4();
            frmManual4.ShowDialog();
        }

        private void BtnManual1_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual1 frmManual1 = new FrmManual1();
            frmManual1.ShowDialog();
        }

        private void BtnManual5_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual5 frmManual5 = new FrmManual5();
            frmManual5.ShowDialog();
        }

        private void BtnManual6_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual6 frmManual6 = new FrmManual6();
            frmManual6.ShowDialog();
        }

        private void BtnManual7_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual7 frmManual7 = new FrmManual7();
            frmManual7.ShowDialog();
        }

        private void BtnManual8_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual8 frmManual8 = new FrmManual8();
            frmManual8.ShowDialog();
        }

        private void BtnManual9_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual9 frmManual9 = new FrmManual9();
            frmManual9.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
    }
}
