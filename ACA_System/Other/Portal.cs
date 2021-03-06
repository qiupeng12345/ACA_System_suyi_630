﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACA_BreakCommunication;
using ACA_System.UI;

namespace ACA_System
{

    public class Portal
    {

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!ACA_Common.Class.Global.kv.Connect())
                {
                    MessageBox.Show("plc连接失败，请检查");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ACA_Common.Class.LogHelper.WriteLog(ex);
                MessageBox.Show("plc连接失败，请检查");
                Application.Exit();
            }
            Application.Run(new FrmMain());
        }

        //Login();
        private static void Login()
        {
            FrmLogin login = new FrmLogin();
            login.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult.OK == login.ShowDialog())
            {
                if (login.LoginState == true)
                {
                    FrmMain main = new FrmMain();
                    main.ShowDialog();
                    login.Hide();
                }
            }
        }
    }
}
