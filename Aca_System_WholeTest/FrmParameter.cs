using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACA_Common.Class;
using System.Configuration;
namespace Aca_System_WholeTest
{
    public partial class FrmParameter : Form
    {
        TextBox[] txtArray = new TextBox[13];
        public FrmParameter()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ToConfig();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            KeyBoard.KeyNum keyNum = new KeyBoard.KeyNum();
            keyNum.TxtString = tbx.Text;
            keyNum.ShowDialog();
            tbx.Text = keyNum.TxtString;
            keyNum.TxtString = "";
        }
        private void FrmParameter_Load(object sender, EventArgs e)
        {
            //配方1
            TxtTimeNoAction_model1.Text = Global.actionTest1Time_model1.ToString();
            TxtCurrentNoAction_model1.Text = Global.actionTest1Current_model1.ToString();
            TxtCurrentActionStart_model1.Text = Global.actionTest2StartCurrent_model1.ToString();
            TxtCurrentActionEnd_model1.Text = Global.actionTest2EndCurrent_model1.ToString();
            TxtActionTimeCurrent_model1.Text = Global.actionTest3Current_model1.ToString();
            TxtActionTime_model1.Text = Global.actionTest3Time_model1.ToString();
            TxtOverVoltage_model1.Text = Global.overVoltageValue_model1.ToString();
            TxtOverVoltageTime_model1.Text = Global.overVoltageTime_model1.ToString();
            TxtUnderVoltage_model1.Text = Global.underVoltageValue_model1.ToString();
            TxtUnderVoltageTime_model1.Text = Global.underVoltageTime_model1.ToString();
            TxtLowVoltage_model1.Text = Global.lowVoltageValue_model1.ToString();
            TxtCloseSwitchTimeUp_model1.Text = Global.closeSwitchTimeUp_model1.ToString();
            TxtVoltageErroRange_model1.Text = Global.VoltageErroRange_model1.ToString();
            //配方2
            TxtTimeNoAction_model2.Text = Global.actionTest1Time_model2.ToString();
            TxtCurrentNoAction_model2.Text = Global.actionTest1Current_model2.ToString();
            TxtCurrentActionStart_model2.Text = Global.actionTest2StartCurrent_model2.ToString();
            TxtCurrentActionEnd_model2.Text = Global.actionTest2EndCurrent_model2.ToString();
            TxtActionTimeCurrent_model2.Text = Global.actionTest3Current_model2.ToString();
            TxtActionTime_model2.Text = Global.actionTest3Time_model2.ToString();
            TxtOverVoltage_model2.Text = Global.overVoltageValue_model2.ToString();
            TxtOverVoltageTime_model2.Text = Global.overVoltageTime_model2.ToString();
            TxtUnderVoltage_model2.Text = Global.underVoltageValue_model2.ToString();
            TxtUnderVoltageTime_model2.Text = Global.underVoltageTime_model2.ToString();
            TxtLowVoltage_model2.Text = Global.lowVoltageValue_model2.ToString();
            TxtCloseSwitchTimeUp_model2.Text = Global.closeSwitchTimeUp_model2.ToString();
            TxtVoltageErroRange_model2.Text = Global.VoltageErroRange_model2.ToString();
            TxtMeachineNum.Text = Global.meachineTestNum.ToString();
            TxtBaudRate.Text = Global.baudRate.ToString();
        }
        /// <summary>
        /// 保存用户配置参数
        /// </summary>
        private void ToConfig()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["BaudRate"].Value = TxtBaudRate.Text;
                config.AppSettings.Settings["actionTest1Current_model1"].Value = TxtCurrentNoAction_model1.Text;
                config.AppSettings.Settings["actionTest1Time_model1"].Value = TxtTimeNoAction_model1.Text;
                config.AppSettings.Settings["actionTest2StartCurrent_model1"].Value = TxtCurrentActionStart_model1.Text;
                config.AppSettings.Settings["actionTest2EndCurrent_model1"].Value = TxtCurrentActionEnd_model1.Text;
                config.AppSettings.Settings["actionTest3Current_model1"].Value = TxtActionTimeCurrent_model1.Text;
                config.AppSettings.Settings["actionTest3Time_model1"].Value = TxtActionTime_model1.Text;
                config.AppSettings.Settings["overVoltageValue_model1"].Value = TxtOverVoltage_model1.Text;
                config.AppSettings.Settings["overVoltageTime_model1"].Value = TxtOverVoltageTime_model1.Text;
                config.AppSettings.Settings["underVoltageValue_model1"].Value = TxtUnderVoltage_model1.Text;
                config.AppSettings.Settings["underVoltageTime_model1"].Value = TxtUnderVoltageTime_model1.Text;
                config.AppSettings.Settings["lowVoltageValue_model1"].Value = TxtLowVoltage_model1.Text;
                config.AppSettings.Settings["closeSwitchTimeUp_model1"].Value = TxtCloseSwitchTimeUp_model1.Text;
                config.AppSettings.Settings["voltageErrorRange_model1"].Value = TxtVoltageErroRange_model1.Text;
                config.AppSettings.Settings["actionTest1Current_model2"].Value = TxtCurrentNoAction_model2.Text;
                config.AppSettings.Settings["actionTest1Time_model2"].Value = TxtTimeNoAction_model2.Text;
                config.AppSettings.Settings["actionTest2StartCurrent_model2"].Value = TxtCurrentActionStart_model2.Text;
                config.AppSettings.Settings["actionTest2EndCurrent_model2"].Value = TxtCurrentActionEnd_model2.Text;
                config.AppSettings.Settings["actionTest3Current_model2"].Value = TxtActionTimeCurrent_model2.Text;
                config.AppSettings.Settings["actionTest3Time_model2"].Value = TxtActionTime_model2.Text;
                config.AppSettings.Settings["overVoltageValue_model2"].Value = TxtOverVoltage_model2.Text;
                config.AppSettings.Settings["overVoltageTime_model2"].Value = TxtOverVoltageTime_model2.Text;
                config.AppSettings.Settings["underVoltageValue_model2"].Value = TxtUnderVoltage_model2.Text;
                config.AppSettings.Settings["underVoltageTime_model2"].Value = TxtUnderVoltageTime_model2.Text;
                config.AppSettings.Settings["lowVoltageValue_model2"].Value = TxtLowVoltage_model2.Text;
                config.AppSettings.Settings["closeSwitchTimeUp_model2"].Value = TxtCloseSwitchTimeUp_model2.Text;
                config.AppSettings.Settings["voltageErrorRange_model2"].Value = TxtVoltageErroRange_model2.Text;
                config.AppSettings.Settings["MeachineNum"].Value = TxtMeachineNum.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }

        private void Txt_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox tbx = (TextBox)sender;
                KeyBoard.KeyNum keyNum = new KeyBoard.KeyNum();
                keyNum.TxtString = tbx.Text;
                keyNum.ShowDialog();
                tbx.Text = keyNum.TxtString;
                if (tbx.Name=="TxtOverVoltage")
                {
                    if (Convert.ToInt32(tbx.Text)>Global.overVoltageMax)
                    {
                        MessageBox.Show("设置过压值大于过压上限");
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
    }
}
