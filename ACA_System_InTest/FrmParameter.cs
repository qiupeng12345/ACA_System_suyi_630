using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACA_Common.Class;
namespace ACA_System_InTest
{
    public partial class FrmParameter : Form
    {
        TextBox[] txtArray = new TextBox[7];
        
        public FrmParameter()
        {
            InitializeComponent();
            GetParameter();
        }

        private void FrmParameter_Load(object sender, EventArgs e)
        {
            

        }
        /// <summary>
        /// 显示上次用户设置的参数
        /// </summary>
        private void GetParameter()
        {
            TxtBaudRate.Text = Global.baudRate.ToString();
            TxtCurrent_model1.Text = Global.outPutCurrent_model1.ToString();
            TxtTime_model1.Text = Global.outPutTime_model1.ToString();
            TxtLowCurrent_model1.Text = Global.lowTimesCurrent_model1.ToString();
            TxtLowTime_model1.Text = Global.lowTimesTime_model1.ToString();
            TxtHighCurrent_model1.Text = Global.highTimesCurrent_model1.ToString();
            TxtHighTime_model1.Text = Global.highTimesTime_model1.ToString();
            TxtErrorRange_model1.Text = Global.errorRange_model1.ToString();
            TxtCurrent_model2.Text = Global.outPutCurrent_model2.ToString();
            TxtTime_model2.Text = Global.outPutTime_model2.ToString();
            TxtLowCurrent_model2.Text = Global.lowTimesCurrent_model2.ToString();
            TxtLowTime_model2.Text = Global.lowTimesTime_model2.ToString();
            TxtHighCurrent_model2.Text = Global.highTimesCurrent_model2.ToString();
            TxtHighTime_model2.Text = Global.highTimesTime_model2.ToString();
            TxtErrorRange_model2.Text = Global.errorRange_model2.ToString();
            TxtMeachineNum.Text = Global.meachineTestNum.ToString();
        }
        /// <summary>
        /// 调用键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox tbx = (TextBox)sender;
                KeyBoard.KeyNum keyNum = new KeyBoard.KeyNum();
                keyNum.TxtString = tbx.Text;
                keyNum.ShowDialog();
                tbx.Text = keyNum.TxtString;
                if (tbx.Name == "TxtCurrent" || tbx.Name == "TxtLowCurrent" ||tbx.Name=="TxtHighCurrent")
                {
                    if (Convert.ToInt32(tbx.Text)>Global.instaniousMax)
                    {
                        MessageBox.Show("设置输出值大于瞬时上限，请重新设置");
                        tbx.Text = "0";
                    }
                }
                keyNum.TxtString = "";
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(ex);
            }
            
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            ToConfig();
            //ToParameter();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        /// <summary>
        /// 保存用户配置的参数
        /// </summary>
        private void ToConfig()
        {

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["BaudRate"].Value = TxtBaudRate.Text;
                config.AppSettings.Settings["current_model1"].Value = TxtCurrent_model1.Text;
                config.AppSettings.Settings["currentTime_model1"].Value = TxtTime_model1.Text;
                config.AppSettings.Settings["lowCurrent_model1"].Value = TxtLowCurrent_model1.Text;
                config.AppSettings.Settings["lowTime_model1"].Value = TxtLowTime_model1.Text;
                config.AppSettings.Settings["highCurrent_model1"].Value = TxtHighCurrent_model1.Text;
                config.AppSettings.Settings["highTime_model1"].Value = TxtHighTime_model1.Text;
                config.AppSettings.Settings["errorRange_model1"].Value = TxtErrorRange_model1.Text;
                config.AppSettings.Settings["current_model2"].Value = TxtCurrent_model2.Text;
                config.AppSettings.Settings["currentTime_model2"].Value = TxtTime_model2.Text;
                config.AppSettings.Settings["lowCurrent_model2"].Value = TxtLowCurrent_model2.Text;
                config.AppSettings.Settings["lowTime_model2"].Value = TxtLowTime_model2.Text;
                config.AppSettings.Settings["highCurrent_model2"].Value = TxtHighCurrent_model2.Text;
                config.AppSettings.Settings["highTime_model2"].Value = TxtHighTime_model2.Text;
                config.AppSettings.Settings["errorRange_model2"].Value = TxtErrorRange_model2.Text;
                config.AppSettings.Settings["meachineNum"].Value = TxtMeachineNum.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        //private void ToParameter()
        //{
        //    Global.outPutCurrent = Convert.ToInt32(TxtCurrent.Text);
        //    Global.outPutTime = Convert.ToInt32(TxtTime.Text);
        //    Global.lowTimesCurrent = Convert.ToInt32(TxtLowCurrent.Text);
        //    Global.lowTimesTime = Convert.ToInt32(TxtLowTime.Text);
        //    Global.highTimesCurrent = Convert.ToInt32(TxtHighCurrent.Text);
        //    Global.highTimesTime = Convert.ToInt32(TxtHighTime.Text);
        //    Global.errorRange = Convert.ToInt32(TxtErrorRange.Text);

        //}

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
    }
}
