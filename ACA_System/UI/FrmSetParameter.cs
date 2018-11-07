using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using System.Configuration;
using System.Diagnostics;
using ACA_Common.Class;

namespace ACA_System.UI
{
    public partial class FrmSetParameter : Form
    {
        TextBox[] txtArray = new TextBox[15];
        public FrmSetParameter()
        {
            InitializeComponent();
            try
            {
                ParameterInitialization();
                CmbCurrentProofNum_SelectionChangeCommitted(null, null);
                CmbVoltageProofNum_SelectionChangeCommitted(null, null);
                CmbResidualCurrentProofNum_SelectionChangeCommitted(null, null);
                CmbCurrentProofNummodel2_SelectionChangeCommitted(null, null);
                CmbVoltageProofNummodel2_SelectionChangeCommitted(null, null);
                CmbResidualCurrentProofNummodel2_SelectionChangeCommitted(null, null);
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(ex);
            }
            
        }
        /// <summary>
        /// 初始化界面显示用户上次配置参数
        /// </summary>
        private void ParameterInitialization()
        {
            CmbCurrentProofNum.SelectedItem = Global.currentProofNum_model1.ToString();
            CmbVoltageProofNum.SelectedItem = Global.voltageProofNum_model1.ToString();
            CmbResidualCurrentProofNum.SelectedItem = Global.residualCurrentProofNum_model1.ToString();
            TxtBaudRate.Text = Global.baudRate.ToString();
            TxtCurrent1.Text = Global.presetCurrentValue1_model1.ToString();
            TxtCurrent2.Text = Global.presetCurrentValue2_model1.ToString();
            TxtCurrent3.Text = Global.presetCurrentValue3_model1.ToString();
            TxtCurrent4.Text = Global.presetCurrentValue4_model1.ToString();
            TxtCurrent5.Text = Global.presetCurrentValue5_model1.ToString();
            TxtVoltage1.Text = Global.presetVoltageValue1_model1.ToString();
            TxtVoltage2.Text = Global.presetVoltageValue2_model1.ToString();
            TxtVoltage3.Text = Global.presetVoltageValue3_model1.ToString();
            TxtVoltage4.Text = Global.presetVoltageValue4_model1.ToString();
            TxtVoltage5.Text = Global.presetVoltageValue5_model1.ToString();
            TxtResidualCurrent1.Text = Global.presetResidualCurrentValue1_model1.ToString();
            TxtResidualCurrent2.Text = Global.presetResidualCurrentValue2_model1.ToString();
            TxtResidualCurrent3.Text = Global.presetResidualCurrentValue3_model1.ToString();
            TxtResidualCurrent4.Text = Global.presetResidualCurrentValue4_model1.ToString();
            TxtResidualCurrent5.Text = Global.presetResidualCurrentValue5_model1.ToString();
            TxtCurrentErrorRange.Text = Global.proofCurrentErrorRange_model1.ToString();
            TxtVoltageErrorRange.Text = Global.proofVoltageErrorRange_model1.ToString();
            TxtResidualCurrentErrorRange.Text = Global.proofResidualCurrentErrorRange_model1.ToString();
            TxtCheckValue1.Text = Global.currentCheck_model1.ToString();
            TxtCheckValue2.Text = Global.voltageCheck_model1.ToString();
            TxtCheckValue3.Text = Global.residualCurrentCheck_model1.ToString();
            TxtMeachineNum.Text = Global.meachineTestNum.ToString();
            TxtCheckCurrentErrorRange.Text = Global.checkCurrentErrorRange_model1.ToString();
            TxtCheckVoltageErrorRange.Text = Global.checkVoltageErrorRange_model1.ToString();
            TxtCheckResidualCurrentErrorRange.Text = Global.checkResidualCurrentErrorRange_model1.ToString();
            TxtCurrentZero.Text = Global.currentZero_model1.ToString();
            TxtResidualCurrentZero.Text = Global.residualCurrentZero_model1.ToString();
            CmbCurrentProofNummodel2.SelectedItem = Global.currentProofNum_model2.ToString();
            CmbVoltageProofNummodel2.SelectedItem = Global.voltageProofNum_model2.ToString();
            CmbResidualCurrentProofNummodel2.SelectedItem = Global.residualCurrentProofNum_model2.ToString();
            TxtCurrent1_model2.Text = Global.presetCurrentValue1_model2.ToString();
            TxtCurrent2_model2.Text = Global.presetCurrentValue2_model2.ToString();
            TxtCurrent3_model2.Text = Global.presetCurrentValue3_model2.ToString();
            TxtCurrent4_model2.Text = Global.presetCurrentValue4_model2.ToString();
            TxtCurrent5_model2.Text = Global.presetCurrentValue5_model2.ToString();
            TxtVoltage1_model2.Text = Global.presetVoltageValue1_model2.ToString();
            TxtVoltage2_model2.Text = Global.presetVoltageValue2_model2.ToString();
            TxtVoltage3_model2.Text = Global.presetVoltageValue3_model2.ToString();
            TxtVoltage4_model2.Text = Global.presetVoltageValue4_model2.ToString();
            TxtVoltage5_model2.Text = Global.presetVoltageValue5_model2.ToString();
            TxtResidualCurrent1_model2.Text = Global.presetResidualCurrentValue1_model2.ToString();
            TxtResidualCurrent2_model2.Text = Global.presetResidualCurrentValue2_model2.ToString();
            TxtResidualCurrent3_model2.Text = Global.presetResidualCurrentValue3_model2.ToString();
            TxtResidualCurrent4_model2.Text = Global.presetResidualCurrentValue4_model2.ToString();
            TxtResidualCurrent5_model2.Text = Global.presetResidualCurrentValue5_model2.ToString();
            TxtCurrentErrorRange_model2.Text = Global.proofCurrentErrorRange_model2.ToString();
            TxtVoltageErrorRange_model2.Text = Global.proofVoltageErrorRange_model2.ToString();
            TxtResidualCurrentErrorRange_model2.Text = Global.proofResidualCurrentErrorRange_model2.ToString();
            TxtCheckValue1_model2.Text = Global.currentCheck_model2.ToString();
            TxtCheckValue2_model2.Text = Global.voltageCheck_model2.ToString();
            TxtCheckValue3_model2.Text = Global.residualCurrentCheck_model2.ToString();
            TxtCheckCurrentErrorRange_model2.Text = Global.checkCurrentErrorRange_model2.ToString();
            TxtCheckVoltageErrorRange_model2.Text = Global.checkVoltageErrorRange_model2.ToString();
            TxtCheckResidualCurrentErrorRange_model2.Text = Global.checkResidualCurrentErrorRange_model2.ToString();
            TxtCurrentZero_model2.Text = Global.currentZero_model2.ToString();
            TxtResidualCurrentZero_model2.Text = Global.residualCurrentZero_model2.ToString();
            TxtResidualTime.Text = Global.residualTime.ToString();
            TxtDelayTime.Text = Global.delayTime.ToString();
      
        }

        private void CmbCurrentProofNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbCurrentProofNum.SelectedItem.ToString() == "3")
            {

                TxtCurrent4.Enabled = false;
                TxtCurrent5.Enabled = false;
            }
            else if (CmbCurrentProofNum.SelectedItem.ToString() == "4")
            {
                TxtCurrent4.Enabled = true;
                TxtCurrent5.Enabled = false;
            }
            else
            {
                TxtCurrent4.Enabled = true;
                TxtCurrent5.Enabled = true;
            }
        }



        private void CmbVoltageProofNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbVoltageProofNum.SelectedItem.ToString() == "3")
            {
                TxtVoltage4.Enabled = false;
                TxtVoltage5.Enabled = false;
            }
            else if (CmbVoltageProofNum.SelectedItem.ToString() == "4")
            {
                TxtVoltage4.Enabled = true;
                TxtVoltage5.Enabled = false;
            }
            else
            {
                TxtVoltage4.Enabled = true;
                TxtVoltage5.Enabled = true;
            }
        }

        private void CmbResidualCurrentProofNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbResidualCurrentProofNum.SelectedItem.ToString() == "3")
            {
                TxtResidualCurrent4.Enabled = false;
                TxtResidualCurrent5.Enabled = false;
            }
            else if (CmbResidualCurrentProofNum.SelectedItem.ToString() == "4")
            {
                TxtResidualCurrent4.Enabled = true;
                TxtResidualCurrent5.Enabled = false;
            }
            else
            {
                TxtResidualCurrent4.Enabled = true;
                TxtResidualCurrent5.Enabled = true;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (TextCheck())
            {
                //ToParameter();
                ToConfig();
                Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.ShowDialog();
            }
            else
            {
                MessageUtil.ShowError("请确认参数是否全部正确设置");
            }
        }
        /// <summary>
        /// 保存用户参数设定值到配置文件中，便于下一次使用
        /// </summary>
        private void ToConfig() //
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["CurrentProofNum"].Value = CmbCurrentProofNum.SelectedItem.ToString();
                config.AppSettings.Settings["VoltageProofNum"].Value = CmbVoltageProofNum.SelectedItem.ToString();
                config.AppSettings.Settings["ResidualCurrentProofNum"].Value = CmbCurrentProofNum.SelectedItem.ToString();
                config.AppSettings.Settings["BaudRate"].Value = TxtBaudRate.Text;
                config.AppSettings.Settings["PresetCurrent1"].Value = TxtCurrent1.Text;
                config.AppSettings.Settings["PresetCurrent2"].Value = TxtCurrent2.Text;
                config.AppSettings.Settings["PresetCurrent3"].Value = TxtCurrent3.Text;
                config.AppSettings.Settings["PresetCurrent4"].Value = TxtCurrent4.Text;
                config.AppSettings.Settings["PresetCurrent5"].Value = TxtCurrent5.Text;
                config.AppSettings.Settings["PresetVoltage1"].Value = TxtVoltage1.Text;
                config.AppSettings.Settings["PresetVoltage2"].Value = TxtVoltage2.Text;
                config.AppSettings.Settings["PresetVoltage3"].Value = TxtVoltage3.Text;
                config.AppSettings.Settings["PresetVoltage4"].Value = TxtVoltage4.Text;
                config.AppSettings.Settings["PresetVoltage5"].Value = TxtVoltage5.Text;
                config.AppSettings.Settings["PresetResidualCurrent1"].Value = TxtResidualCurrent1.Text;
                config.AppSettings.Settings["PresetResidualCurrent2"].Value = TxtResidualCurrent2.Text;
                config.AppSettings.Settings["PresetResidualCurrent3"].Value = TxtResidualCurrent3.Text;
                config.AppSettings.Settings["PresetResidualCurrent4"].Value = TxtResidualCurrent4.Text;
                config.AppSettings.Settings["PresetResidualCurrent5"].Value = TxtResidualCurrent5.Text;
                config.AppSettings.Settings["CurrentErrorRange"].Value = TxtCurrentErrorRange.Text;
                config.AppSettings.Settings["CurrentCheckErrorRange"].Value = TxtCheckCurrentErrorRange.Text;
                config.AppSettings.Settings["VoltageErrorRange"].Value = TxtVoltageErrorRange.Text;
                config.AppSettings.Settings["VoltageCheckErrorRange"].Value = TxtCheckVoltageErrorRange.Text;
                config.AppSettings.Settings["ResidualCurrentErrorRange"].Value = TxtResidualCurrentErrorRange.Text;
                config.AppSettings.Settings["ResidualCurrentCheckErrorRange"].Value = TxtCheckResidualCurrentErrorRange.Text;
                config.AppSettings.Settings["CheckValue1"].Value = TxtCheckValue1.Text;
                config.AppSettings.Settings["CheckValue2"].Value = TxtCheckValue2.Text;
                config.AppSettings.Settings["CheckValue3"].Value = TxtCheckValue3.Text;
                config.AppSettings.Settings["CurrentZero"].Value = TxtCurrentZero.Text;
                config.AppSettings.Settings["ResidualCurrentZero"].Value = TxtResidualCurrentZero.Text;
                config.AppSettings.Settings["CurrentProofNum_model2"].Value = CmbCurrentProofNummodel2.SelectedItem.ToString();
                config.AppSettings.Settings["VoltageProofNum_model2"].Value = CmbVoltageProofNummodel2.SelectedItem.ToString();
                config.AppSettings.Settings["ResidualCurrentProofNum_model2"].Value = CmbCurrentProofNummodel2.SelectedItem.ToString();
                config.AppSettings.Settings["PresetCurrent1_model2"].Value = TxtCurrent1_model2.Text;
                config.AppSettings.Settings["PresetCurrent2_model2"].Value = TxtCurrent2_model2.Text;
                config.AppSettings.Settings["PresetCurrent3_model2"].Value = TxtCurrent3_model2.Text;
                config.AppSettings.Settings["PresetCurrent4_model2"].Value = TxtCurrent4_model2.Text;
                config.AppSettings.Settings["PresetCurrent5_model2"].Value = TxtCurrent5_model2.Text;
                config.AppSettings.Settings["PresetVoltage1_model2"].Value = TxtVoltage1_model2.Text;
                config.AppSettings.Settings["PresetVoltage2_model2"].Value = TxtVoltage2_model2.Text;
                config.AppSettings.Settings["PresetVoltage3_model2"].Value = TxtVoltage3_model2.Text;
                config.AppSettings.Settings["PresetVoltage4_model2"].Value = TxtVoltage4_model2.Text;
                config.AppSettings.Settings["PresetVoltage5_model2"].Value = TxtVoltage5_model2.Text;
                config.AppSettings.Settings["PresetResidualCurrent1_model2"].Value = TxtResidualCurrent1_model2.Text;
                config.AppSettings.Settings["PresetResidualCurrent2_model2"].Value = TxtResidualCurrent2_model2.Text;
                config.AppSettings.Settings["PresetResidualCurrent3_model2"].Value = TxtResidualCurrent3_model2.Text;
                config.AppSettings.Settings["PresetResidualCurrent4_model2"].Value = TxtResidualCurrent4_model2.Text;
                config.AppSettings.Settings["PresetResidualCurrent5_model2"].Value = TxtResidualCurrent5_model2.Text;
                config.AppSettings.Settings["CurrentErrorRange_model2"].Value = TxtCurrentErrorRange_model2.Text;
                config.AppSettings.Settings["CurrentCheckErrorRange_model2"].Value = TxtCheckCurrentErrorRange_model2.Text;
                config.AppSettings.Settings["VoltageErrorRange_model2"].Value = TxtVoltageErrorRange_model2.Text;
                config.AppSettings.Settings["VoltageCheckErrorRange_model2"].Value = TxtCheckVoltageErrorRange_model2.Text;
                config.AppSettings.Settings["ResidualCurrentErrorRange_model2"].Value = TxtResidualCurrentErrorRange_model2.Text;
                config.AppSettings.Settings["ResidualCurrentCheckErrorRange_model2"].Value = TxtCheckResidualCurrentErrorRange_model2.Text;
                config.AppSettings.Settings["CheckValue1_model2"].Value = TxtCheckValue1_model2.Text;
                config.AppSettings.Settings["CheckValue2_model2"].Value = TxtCheckValue2_model2.Text;
                config.AppSettings.Settings["CheckValue3_model2"].Value = TxtCheckValue3_model2.Text;
                config.AppSettings.Settings["CurrentZero_model2"].Value = TxtCurrentZero_model2.Text;
                config.AppSettings.Settings["ResidualCurrentZero_model2"].Value = TxtResidualCurrentZero_model2.Text;
                config.AppSettings.Settings["MeachineNum"].Value = TxtMeachineNum.Text;
                config.AppSettings.Settings["ResidualTime"].Value = TxtResidualTime.Text;
                config.AppSettings.Settings["DelayTime"].Value = TxtDelayTime.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                LogHelper.WriteLog(ex);
            }

        }
        /*
        private void ToParameter()
        {
            try
            {
                Global.presetCurrentValue1 = Convert.ToInt32(TxtCurrent1.Text);
                Global.presetCurrentValue2 = Convert.ToInt32(TxtCurrent2.Text);
                Global.presetCurrentValue3 = Convert.ToInt32(TxtCurrent3.Text);
                Global.presetCurrentValue4 = Convert.ToInt32(TxtCurrent4.Text);
                Global.presetCurrentValue5 = Convert.ToInt32(TxtCurrent5.Text);
                Global.presetVoltageValue1 = Convert.ToInt32(TxtVoltage1.Text);
                Global.presetVoltageValue2 = Convert.ToInt32(TxtVoltage2.Text);
                Global.presetVoltageValue3 = Convert.ToInt32(TxtVoltage3.Text);
                Global.presetVoltageValue4 = Convert.ToInt32(TxtVoltage4.Text);
                Global.presetVoltageValue5 = Convert.ToInt32(TxtVoltage5.Text);
                Global.closeSwitchVoltage = Convert.ToInt32(TxtCloseSwitchVoltage.Text);
                Global.presetResidualCurrentValue1 = Convert.ToInt32(TxtResidualCurrent1.Text);
                Global.presetResidualCurrentValue2 = Convert.ToInt32(TxtResidualCurrent2.Text);
                Global.presetResidualCurrentValue3 = Convert.ToInt32(TxtResidualCurrent3.Text);
                Global.presetResidualCurrentValue4 = Convert.ToInt32(TxtResidualCurrent4.Text);
                Global.presetResidualCurrentValue5 = Convert.ToInt32(TxtResidualCurrent5.Text);
                // ****************一些必要参数
                Global.currentCheck = Convert.ToInt32(TxtCheckValue1.Text);
                Global.voltageCheck = Convert.ToInt32(TxtCheckValue2.Text);
                Global.residualCurrentCheck = Convert.ToInt32(lable16.Text);
                Global.currentProofNum_model1 = Convert.ToInt32(CmbCurrentProofNum.SelectedItem);
                Global.voltageProofNum_model1 = Convert.ToInt32(CmbVoltageProofNum.SelectedItem);
                Global.resdualCurrentProofNum_model1 = Convert.ToInt32(CmbResidualCurrentProofNum.SelectedItem);
                Global.proofCurrentErrorRange = Convert.ToInt32(TxtCurrentErrorRange.Text);
                Global.proofVoltageErrorRange = Convert.ToInt32(TxtVoltageErrorRange.Text);
                Global.proofResidualCurrentErrorRange = Convert.ToInt32(TxtResidualCurrentErrorRange.Text);
            }
            catch (Exception)
            {

            }
            //预设值
        */
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        /// <summary>
        /// 检查参数是否全部设置
        /// </summary>
        /// <returns></returns>
        private bool TextCheck() //
        {
            if (CmbCurrentProofNum.SelectedItem.ToString() != "")
            {
                if (CmbCurrentProofNum.SelectedItem.ToString() == "4")
                {
                    if (TxtCurrent4.Text == "")
                    {
                        return false;
                    }
                }
                else if (CmbCurrentProofNum.SelectedItem.ToString() == "5")
                {
                    if (TxtCurrent4.Text == "" || TxtCurrent5.Text == "")
                    {
                        return false;
                    }
                }
            }
            else return false;
            if (CmbResidualCurrentProofNum.SelectedItem.ToString() != "")
            {
                if (CmbResidualCurrentProofNum.SelectedItem.ToString() == "4")
                {
                    if (TxtResidualCurrent4.Text == "")
                    {
                        return false;
                    }
                }
                else if (CmbResidualCurrentProofNum.SelectedItem.ToString() == "5")
                {
                    if (TxtResidualCurrent4.Text == "" || TxtResidualCurrent5.Text == "")
                    {
                        return false;
                    }
                }
            }
            else return false;
            if (CmbVoltageProofNum.SelectedItem.ToString() != "")
            {
                if (CmbVoltageProofNum.SelectedItem.ToString() == "4")
                {
                    if (TxtVoltage4.Text == "")
                    {
                        return false;
                    }
                }
                else if (CmbVoltageProofNum.SelectedItem.ToString() == "5")
                {
                    if (TxtVoltage4.Text == "" || TxtVoltage5.Text == "")
                    {
                        return false;
                    }
                }
            }
            else return false;
            for (int i = 0; i < txtArray.Length; i++)
            {
                if (txtArray[i].Text == "")
                {
                    return false;
                }
            }
            return true;
        }


        private void Txt_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox tbx = (TextBox)sender;
                KeyBoard.KeyNum keyNum = new KeyBoard.KeyNum();
                keyNum.TxtString = tbx.Text;
                keyNum.ShowDialog();
                tbx.Text = keyNum.TxtString;
                if (tbx.Name=="TxtCurrent1" || tbx.Name == "TxtCurrent2" || tbx.Name == "TxtCurrent3" || tbx.Name == "TxtCurrent4" || tbx.Name == "TxtCurrent5"||tbx.Name=="TxtCheckValue1" )
                {
                    if (Convert.ToInt32(tbx.Text)>Global.currentMax)
                    {
                        MessageBox.Show("设置值大于电流上限，请重新设置");
                        tbx.Text = "0";
                    }
                }
                else if (tbx.Name=="TxtVoltage1" || tbx.Name == "TxtVoltage2" || tbx.Name == "TxtVoltage3" || tbx.Name == "TxtVoltage4" || tbx.Name == "TxtVoltage5"||tbx.Name=="TxtCheckValue2")
                {
                    if (Convert.ToInt32(tbx.Text) > Global.voltageMax)
                    {
                        MessageBox.Show("设置值大于电压上限，请重新设置");
                        tbx.Text = "0";
                    }
                }
                else if (tbx.Name=="TxtResidualCurrent1"|| tbx.Name == "TxtResidualCurrent2" || tbx.Name == "TxtResidualCurrent3" || tbx.Name == "TxtResidualCurrent4" || tbx.Name == "TxtResidualCurrent5" || tbx.Name == "TxtCheckValue3")
                {
                    if (Convert.ToInt32(tbx.Text) > Global.residualCurrentMax)
                    {
                        MessageBox.Show("设置值大于剩余电流上限，请重新设置");
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

        private void FrmSetParameter_Load(object sender, EventArgs e)
        {
            txtArray[0] = TxtCurrent1;
            txtArray[1] = TxtCurrent2;
            txtArray[2] = TxtCurrent3;
            txtArray[3] = TxtVoltage1;
            txtArray[4] = TxtVoltage2;
            txtArray[5] = TxtVoltage3;
            txtArray[6] = TxtResidualCurrent1;
            txtArray[7] = TxtResidualCurrent2;
            txtArray[8] = TxtResidualCurrent3;
            txtArray[9] = TxtCurrentErrorRange;
            txtArray[10] = TxtVoltageErrorRange;
            txtArray[11] = TxtResidualCurrentErrorRange;
            txtArray[12] = TxtCheckValue1;
            txtArray[13] = TxtCheckValue2;
            txtArray[14] = TxtCheckValue3;
        }

        private void CmbCurrentProofNummodel2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbCurrentProofNummodel2.SelectedItem.ToString() == "3")
            {

                TxtCurrent4_model2.Enabled = false;
                TxtCurrent5_model2.Enabled = false;
            }
            else if (CmbCurrentProofNummodel2.SelectedItem.ToString() == "4")
            {
                TxtCurrent4_model2.Enabled = true;
                TxtCurrent5_model2.Enabled = false;
            }
            else
            {
                TxtCurrent4_model2.Enabled = true;
                TxtCurrent5_model2.Enabled = true;
            }
        }

        private void CmbVoltageProofNummodel2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbVoltageProofNummodel2.SelectedItem.ToString() == "3")
            {
                TxtVoltage4_model2.Enabled = false;
                TxtVoltage5_model2.Enabled = false;
            }
            else if (CmbVoltageProofNummodel2.SelectedItem.ToString() == "4")
            {
                TxtVoltage4_model2.Enabled = true;
                TxtVoltage5_model2.Enabled = false;
            }
            else
            {
                TxtVoltage4_model2.Enabled = true;
                TxtVoltage5_model2.Enabled = true;
            }
        }

        private void CmbResidualCurrentProofNummodel2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbResidualCurrentProofNummodel2.SelectedItem.ToString() == "3")
            {
                TxtResidualCurrent4_model2.Enabled = false;
                TxtResidualCurrent5_model2.Enabled = false;
            }
            else if (CmbResidualCurrentProofNummodel2.SelectedItem.ToString() == "4")
            {
                TxtResidualCurrent4_model2.Enabled = true;
                TxtResidualCurrent5_model2.Enabled = false;
            }
            else
            {
                TxtResidualCurrent4_model2.Enabled = true;
                TxtResidualCurrent5_model2.Enabled = true;
            }
        }
    }
}
