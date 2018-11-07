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
using ACA_Common;
using ACA_Common.Class;
using log4net;
namespace ACA_System_InTest
{
    public partial class FrmFunction : Form
    {
        private bool[] functionDo = new bool[16];
        private CheckNew[] checks = new CheckNew[16];
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
            functionDo[7] = Global.doOutPut2;
            functionDo[8] = Global.doOutPut3;
            functionDo[9] = Global.doOutPut1;
            functionDo[10] = Global.doLow;
            functionDo[11] = Global.doHigh;
            functionDo[12] = Global.closeDoor;
            functionDo[13] = Global.autoLine;
            functionDo[14] = Global.manualLine;
            functionDo[15] = Global.defence;
            checks[0] = ChkModel1;
            checks[1] = ChkManualJudge;
            checks[2] = ChkManualCommunication;
            checks[3] = ChkModel2;
            checks[4] = ChkBarCode;
            checks[5] = ChkAutoCommunication;
            checks[6] = ChkMeachineAge;
            checks[7] = ChkTest2;
            checks[8] = ChkTest3;
            checks[9] = ChkTest1;
            checks[10] = ChkLow;
            checks[11] = ChkHigh;
            checks[12] = ChkCloseDoor;
            checks[13] = ChkAutoLine;
            checks[14] = ChkManualLine;
            checks[15] = ChkDefence;
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].Checked = functionDo[i];
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
            try
            {
                for (int i = 0; i < checks.Length; i++)
                {
                    if (checks[i].Checked)
                    {
                        Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, checks[i].Address, 1);
                    }
                    else Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, checks[i].Address, 0);

                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);

            }
            
        }
        private void ToConfig()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["doOutput1"].Value = GetCheck(ChkTest1);
                config.AppSettings.Settings["doOutput2"].Value = GetCheck(ChkTest2);
                config.AppSettings.Settings["doOutput3"].Value = GetCheck(ChkTest3);
                config.AppSettings.Settings["doLow"].Value = GetCheck(ChkLow);
                config.AppSettings.Settings["doHigh"].Value = GetCheck(ChkHigh);
                config.AppSettings.Settings["Model1"].Value = GetCheck(ChkModel1);
                config.AppSettings.Settings["Model2"].Value = GetCheck(ChkModel2);
                config.AppSettings.Settings["ManualCom"].Value = GetCheck(ChkManualCommunication);
                config.AppSettings.Settings["AutoCom"].Value = GetCheck(ChkAutoCommunication);
                config.AppSettings.Settings["Scan"].Value = GetCheck(ChkBarCode);
                config.AppSettings.Settings["ManualJudge"].Value = GetCheck(ChkManualJudge);
                config.AppSettings.Settings["MeachineAge"].Value = GetCheck(ChkMeachineAge);
                config.AppSettings.Settings["CloseDoor"].Value = GetCheck(ChkCloseDoor);
                config.AppSettings.Settings["AutoLine"].Value = GetCheck(ChkAutoLine);
                config.AppSettings.Settings["ManualLine"].Value = GetCheck(ChkManualLine);
                config.AppSettings.Settings["Defence"].Value = GetCheck(ChkDefence);
                //config.AppSettings.Settings["SetMeachineAge"].Value = GetCheck(ChkSetMeachineAge);
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
            if (chkFunction.Checked)
            {
                functionDo[chkFunction.No] = true;
            }
            else functionDo[chkFunction.No] = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ToPlc();
            ToConfig();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
    }
}
