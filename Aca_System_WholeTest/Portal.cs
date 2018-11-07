using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aca_System_WholeTest
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
                if (!ACA_Common.Class.Global.kv.Connect())
                {
                    MessageBox.Show("plc连接错误，请检查");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ACA_Common.Class.LogHelper.WriteLog(ex);
                MessageBox.Show("plc连接错误，请检查");
                Application.Exit();
            }
            Application.Run(new FrmMain());
        }
    }
}
