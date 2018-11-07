using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACA_Common.Class;
using log4net;
namespace ACA_System_InTest
{
    static class Portal
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!Global.kv.Connect())
                {
                    MessageBox.Show("plc连接异常，请检查");
                    Application.Exit();
                }
            }
            catch (Exception ex )
            {
                LogHelper.WriteLog(ex); //记录报错日志
                MessageBox.Show("plc连接异常，请检查");
                Application.Exit();
            }
            Application.Run(new FrmMain());

        }
    }
}
