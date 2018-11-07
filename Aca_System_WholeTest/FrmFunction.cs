using ACA_Common;
using ACA_Common.Class;
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

namespace Aca_System_WholeTest
{
    public partial class FrmFunction : Form
    {
        private bool[] functionDo = new bool[25];
        private CheckNew[] checks = new CheckNew[25];
        public FrmFunction()
        {
            InitializeComponent();
        }
        private void FrmFunction_Load(object sender, EventArgs e)
        {
            Ready();
        }
        /// <summary>
        /// 界面勾选项保存显示
        /// </summary>
        private void Ready()
        {
            functionDo[0] = Global.model1Select;
            functionDo[1] = Global.manualJudge;
            functionDo[2] = Global.manualCommunication;
            functionDo[3] = Global.model2Select;
            functionDo[4] = Global.scan;
            functionDo[5] = Global.autoCommunication;
            functionDo[6] = Global.meachineAge;
            functionDo[7] = Global.doActionTest1;
            functionDo[8] = Global.doActionTest2;
            functionDo[9] = Global.doActionTest3;
            functionDo[10] = Global.doOverVoltage;
            functionDo[11] = Global.dounderVoltage;
            functionDo[12] = Global.doLowVoltage;
            functionDo[13] = Global.doLosePhase;
            functionDo[14] = Global.doZeroPhase;
            functionDo[15] = Global.useStation1;
            functionDo[16] = Global.useStation2;
            functionDo[17] = Global.useStation3;
            functionDo[18] = Global.useStation4;
            functionDo[19] = Global.useStation5;
            functionDo[20] = Global.useStation6;
            functionDo[21] = Global.closeDoor;
            functionDo[22] = Global.autoLine;
            functionDo[23] = Global.manualLine;
            functionDo[24] = Global.finallyJudge;
            checks[0] = ChkModel1;
            checks[1] = ChkManualJudge;
            checks[2] = ChkManualCommunication;
            checks[3] = ChkModel2;
            checks[4] = ChkBarCode;
            checks[5] = ChkAutoCommunication;
            checks[6] = ChkMeachineAge;
            checks[7] = ChkAction1;
            checks[8] = ChkAction2;
            checks[9] = ChkAction3;
            checks[10] = ChkOverVoltage;
            checks[11] = ChkUnderVoltage;
            checks[12] = ChkLowVoltage;
            checks[13] = ChkLosePhase;
            checks[14] = ChkZero;
            checks[15] = ChkStation1;
            checks[16] = ChkStation2;
            checks[17] = ChkStation3;
            checks[18] = ChkStation4;
            checks[19] = ChkStation5;
            checks[20] = ChkStation6;
            checks[21] = ChkCloseDoor;
            checks[22] = ChkAutoLine;
            checks[23] = ChkManualLine;
            checks[24] = ChkFinallyJudge;
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].Checked = functionDo[i];
            }
        }
        private void Chk_Click(object sender, EventArgs e)
        {
            CheckNew chkFunction = (CheckNew)sender;
            if (chkFunction == ChkModel1)
            {
                if (!ChkModel2.Checked)
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
                if (!ChkModel1.Checked)
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
            else if (chkFunction == ChkAutoLine)
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
            else if (chkFunction == ChkManualLine)
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
            else
            {
                if (chkFunction.Checked)
                {
                    functionDo[chkFunction.No] = true;
                }
                else functionDo[chkFunction.No] = false;
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();

        }
        private void ToPlc()
        {
            for (int i = 0; i < checks.Length; i++)
            {
                try
                {
                    if (checks[i].Checked)
                    {
                        Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, checks[i].Address, 1);
                    }
                    else
                    {
                        Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, checks[i].Address, 0);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex);
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void ToConfig()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["doAction1"].Value = GetCheck(ChkAction1);
                config.AppSettings.Settings["doAction2"].Value = GetCheck(ChkAction2);
                config.AppSettings.Settings["doAction3"].Value = GetCheck(ChkAction3);
                config.AppSettings.Settings["doOverVoltage"].Value = GetCheck(ChkOverVoltage);
                config.AppSettings.Settings["doUnderVoltage"].Value = GetCheck(ChkUnderVoltage);
                config.AppSettings.Settings["doLowVoltage"].Value = GetCheck(ChkLowVoltage);
                config.AppSettings.Settings["doLosePhase"].Value = GetCheck(ChkLosePhase);
                config.AppSettings.Settings["doZeroPhase"].Value = GetCheck(ChkZero);
                config.AppSettings.Settings["Model1"].Value = GetCheck(ChkModel1);
                config.AppSettings.Settings["Model2"].Value = GetCheck(ChkModel2);
                config.AppSettings.Settings["ManualCom"].Value = GetCheck(ChkManualCommunication);
                config.AppSettings.Settings["AutoCom"].Value = GetCheck(ChkAutoCommunication);
                config.AppSettings.Settings["Scan"].Value = GetCheck(ChkBarCode);
                config.AppSettings.Settings["ManualJudge"].Value = GetCheck(ChkManualJudge);
                config.AppSettings.Settings["MeachineAge"].Value = GetCheck(ChkMeachineAge);
                config.AppSettings.Settings["UseStation1"].Value = GetCheck(ChkStation1);
                config.AppSettings.Settings["UseStation2"].Value = GetCheck(ChkStation2);
                config.AppSettings.Settings["UseStation3"].Value = GetCheck(ChkStation3);
                config.AppSettings.Settings["UseStation4"].Value = GetCheck(ChkStation4);
                config.AppSettings.Settings["UseStation5"].Value = GetCheck(ChkStation5);
                config.AppSettings.Settings["UseStation6"].Value = GetCheck(ChkStation6);
                config.AppSettings.Settings["CloseDoor"].Value = GetCheck(ChkCloseDoor);
                config.AppSettings.Settings["AutoLine"].Value = GetCheck(ChkAutoLine);
                config.AppSettings.Settings["ManualLine"].Value = GetCheck(ChkManualLine);
                config.AppSettings.Settings["FinallyJudge"].Value = GetCheck(ChkFinallyJudge);

                //config.AppSettings.Settings["SetMeachineAge"].Value = GetCheck(ChkSetMeachineAge);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
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
    }
}
