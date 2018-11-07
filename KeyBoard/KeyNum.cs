﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyBoard
{
    public partial class KeyNum : Form
    {
        private string txtString;

        public string TxtString { get { return txtString; } set { txtString = value; } }

        public KeyNum()
        {
            InitializeComponent();
        }

        private void BtnNum1_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "1";
        }

        private void BtnNum2_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "2";
        }

        private void BtnNum3_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "3";
        }

        private void BtnNum4_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "4";
        }

        private void BtnNum5_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "5";
        }

        private void BtnNum6_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "6";
        }

        private void BtnNum7_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "7";
        }

        private void BtnNum8_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "8";
        }

        private void BtnNum9_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "9";
        }

        private void BtnNum0_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + "0";
        }

        private void BtnKeyPoint_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text + ".";
        }

        private void BtnEsc_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtResult.Text.Substring(0, TxtResult.TextLength - 1);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();
        }

        private void  BtnOk_Click(object sender, EventArgs e)
        {
            txtString = TxtResult.Text;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeyNum_Load(object sender, EventArgs e)
        {
            TxtResult.Text = "";
        }
    }
}
