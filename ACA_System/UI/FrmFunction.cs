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
using ACA_Common;

namespace ACA_System.UI
{
    public partial class FrmFunction : Form
    {
        private List<bool> functionDo;
        private List<CheckNew> checkBoxes;
        private string[] appString = new string[28];
        public FrmFunction()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            functionDo = new List<bool>()
            {
              Global.doCurrent1,Global.doCurrent2,Global.doCurrent3,Global.doCurrent4,Global.doCurrent5,
              Global.doVoltage1,Global.doVoltage2,Global.doVoltage3,Global.doVoltage4,Global.doVoltage5,
              Global.doResidualCurrent1,Global.doResidualCurrent2,Global.doResidualCurrent3,Global.doResidualCurrent4,Global.doResidualCurrent5,
              Global.model1Select,Global.model2Select,Global.manualCommunication,Global.autoCommunication,Global.scan,
              Global.manualJudge,Global.meachineAge,Global.closeDoor,Global.autoLine,Global.manualLine,Global.defence,
              Global.openLine,Global.closeLine,
            };
            checkBoxes = new List<CheckNew>()
            {
              ChkCurrent1,ChkCurrent2,ChkCurrent3,ChkCurrent4,ChkCurrent5,
              ChkVoltage1,ChkVoltage2,ChkVoltage3,ChkVoltage4,ChkVoltage5,
              ChkResidualCurrent1,ChkResidualCurrent2,ChkResidualCurrent3,ChkResidualCurrent4,ChkResidualCurrent5,
              ChkModel1,ChkModel2,ChkManualCommunication,ChkAutoCommunication,ChkBarCode,ChkManualJudge,ChkMeachineAge,
              ChkCloseDoor,ChkAutoLine,ChkManualLine,ChkDefence,ChkOpen,ChkClose,
            };
            appString[0] = "DoCurrent1";
            appString[1] = "DoCurrent2";
            appString[2] = "DoCurrent3";
            appString[3] = "DoCurrent4";
            appString[4] = "DoCurrent5";
            appString[5] = "DoVoltage1";
            appString[6] = "DoVoltage2";
            appString[7] = "DoVoltage3";
            appString[8] = "DoVoltage4";
            appString[9] = "DoVoltage5";
            appString[10] = "DoResidualCurrent1";
            appString[11] = "DoResidualCurrent2";
            appString[12] = "DoResidualCurrent3";
            appString[13] = "DoResidualCurrent4";
            appString[14] = "DoResidualCurrent5";
            appString[15] = "Model1";
            appString[16] = "Model2";
            appString[17] = "ManualCom";
            appString[18] = "AutoCom";
            appString[19] = "Scan";
            appString[20] = "ManualJudge";
            appString[21] = "MeachineAge";
            appString[22] = "CloseDoor";
            appString[23] = "AutoLine";
            appString[24] = "ManualLine";
            appString[25] = "Defence";
            appString[26] = "OpenLine";
            appString[27] = "CloseLine";
        }
        private void FrmFunction_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < checkBoxes.Count; i++)
            {
                checkBoxes[i].Checked = functionDo[i];
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        //private void UpdateGlobal()
        //{
        //    for (int i = 0; i < Funcitondo.Count; i++)
        //    {
        //        Funcitondo[i] = checkBoxes[i].Checked;
        //    }
        //}
        private void ToPlc()
        {
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, checkBoxes[i].Address, 1);
                }
                else Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, checkBoxes[i].Address, 0);
            }
        }
        /// <summary>
        /// 记录用户配置的参数
        /// </summary>
        private void ToConfig()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                for (int i = 0; i < appString.Length; i++)
                {
                    config.AppSettings.Settings[appString[i]].Value = GetCheck(checkBoxes[i]);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private string GetCheck(CheckBox check)
        {
            if (check.Checked)
            {
                return "1";
            }
            else return "0";
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ToConfig();
            ToPlc();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }

        private void Chk_Click(object sender, EventArgs e)
        {
            CheckNew chkFunction = (CheckNew)sender;
            if (chkFunction == ChkModel1)
            {
                if (!ChkModel2.Checked )
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;
                }
            }
            else if (chkFunction == ChkModel2)
            {
                if (!ChkModel1.Checked )
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else if (chkFunction == ChkAutoCommunication)
            {
                if (!ChkManualCommunication.Checked)
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else if (chkFunction == ChkManualCommunication)
            {
                if (!ChkAutoCommunication.Checked)
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else if (chkFunction== ChkAutoLine)
            {
                if (!ChkManualLine.Checked)
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else if (chkFunction==ChkManualLine)
            {
                if (!ChkAutoLine.Checked)
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else if(chkFunction==ChkOpen)
            {
                if (!ChkClose.Checked)
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else if (chkFunction == ChkClose)
            {
                if (!ChkOpen.Checked)
                {
                    if (chkFunction.Checked)
                    {
                        functionDo[chkFunction.No] = true;
                    }
                    else functionDo[chkFunction.No] = false;
                }
                else
                {
                    MessageBox.Show("功能选择冲突");
                    chkFunction.Checked = false;

                }
            }
            else
            {
                if (chkFunction.Checked)
                {
                    functionDo[chkFunction.No] = true;
                }
                else functionDo[chkFunction.No] = false;
            }
        }
    }
}
