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

namespace Aca_System_WholeTest
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitializeParameter();
            ToPlc();

        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitializeParameter()
        {
            try
            {
                Global.actionTest1Current_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest1Current_model1"]);
                Global.actionTest1Time_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest1Time_model1"]);
                Global.actionTest2StartCurrent_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest2StartCurrent_model1"]);
                Global.actionTest2EndCurrent_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest2EndCurrent_model1"]);
                //Global.actionTest2Time = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest2EndCurrent"]);
                Global.actionTest3Current_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest3Current_model1"]);
                Global.actionTest3Time_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest3Time_model1"]);
                Global.overVoltageValue_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["overVoltageValue_model1"]);
                Global.overVoltageTime_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["overVoltageTime_model1"]);
                Global.underVoltageValue_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["underVoltageValue_model1"]);
                Global.underVoltageTime_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["underVoltageTime_model1"]);
                Global.lowVoltageValue_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["lowVoltageValue_model1"]);
                Global.closeSwitchTimeUp_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["closeSwitchTimeUp_model1"]);
                Global.VoltageErroRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["voltageErrorRange_model1"]);
                Global.actionTest1Current_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest1Current_model2"]);
                Global.actionTest1Time_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest1Time_model2"]);
                Global.actionTest2StartCurrent_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest2StartCurrent_model2"]);
                Global.actionTest2EndCurrent_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest2EndCurrent_model2"]);
                //Global.actionTest2Time = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest2EndCurrent"]);
                Global.actionTest3Current_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest3Current_model2"]);
                Global.actionTest3Time_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["actionTest3Time_model2"]);
                Global.overVoltageValue_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["overVoltageValue_model2"]);
                Global.overVoltageTime_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["overVoltageTime_model2"]);
                Global.underVoltageValue_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["underVoltageValue_model2"]);
                Global.underVoltageTime_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["underVoltageTime_model2"]);
                Global.lowVoltageValue_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["lowVoltageValue_model2"]);
                Global.closeSwitchTimeUp_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["closeSwitchTimeUp_model2"]);
                Global.VoltageErroRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["voltageErrorRange_model2"]);
                Global.meachineTestNum = Convert.ToInt32(ConfigurationManager.AppSettings["MeachineNum"]);
                Global.doActionTest1 = GetBool(ConfigurationManager.AppSettings["doAction1"]);
                Global.doActionTest2 = GetBool(ConfigurationManager.AppSettings["doAction2"]);
                Global.doActionTest3 = GetBool(ConfigurationManager.AppSettings["doAction3"]);
                Global.doOverVoltage = GetBool(ConfigurationManager.AppSettings["doOverVoltage"]);
                Global.dounderVoltage = GetBool(ConfigurationManager.AppSettings["doUnderVoltage"]);
                Global.doLowVoltage = GetBool(ConfigurationManager.AppSettings["doLowVoltage"]);
                Global.doLosePhase = GetBool(ConfigurationManager.AppSettings["doLosePhase"]);
                Global.doZeroPhase = GetBool(ConfigurationManager.AppSettings["doZeroPhase"]);
                Global.model1Select = GetBool(ConfigurationManager.AppSettings["Model1"]);
                Global.model2Select = GetBool(ConfigurationManager.AppSettings["Model2"]);
                Global.manualCommunication = GetBool(ConfigurationManager.AppSettings["ManualCom"]);
                Global.autoCommunication = GetBool(ConfigurationManager.AppSettings["AutoCom"]);
                Global.scan = GetBool(ConfigurationManager.AppSettings["Scan"]);
                Global.manualJudge = GetBool(ConfigurationManager.AppSettings["ManualJudge"]);
                Global.meachineAge = GetBool(ConfigurationManager.AppSettings["MeachineAge"]);
                Global.useStation1 = GetBool(ConfigurationManager.AppSettings["UseStation1"]);
                Global.useStation2 = GetBool(ConfigurationManager.AppSettings["UseStation2"]);
                Global.useStation3 = GetBool(ConfigurationManager.AppSettings["UseStation3"]);
                Global.useStation4 = GetBool(ConfigurationManager.AppSettings["UseStation4"]);
                Global.useStation5 = GetBool(ConfigurationManager.AppSettings["UseStation5"]);
                Global.useStation6 = GetBool(ConfigurationManager.AppSettings["UseStation6"]);
                Global.closeDoor = GetBool(ConfigurationManager.AppSettings["CloseDoor"]);
                Global.manualLine = GetBool(ConfigurationManager.AppSettings["ManualLine"]);
                Global.autoLine = GetBool(ConfigurationManager.AppSettings["AutoLine"]);
                Global.finallyJudge = GetBool(ConfigurationManager.AppSettings["FinallyJudge"]);
                Global.baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
                if (Global.model1Select)
                {
                    Global.actionTest1Current = Global.actionTest1Current_model1;
                    Global.actionTest1Time = Global.actionTest1Time_model1;
                    Global.actionTest2StartCurrent = Global.actionTest2StartCurrent_model1;
                    Global.actionTest2EndCurrent = Global.actionTest2EndCurrent_model1;
                    Global.actionTest3Current = Global.actionTest3Current_model1;
                    Global.actionTest3Time = Global.actionTest3Time_model1;
                    Global.overVoltageValue = Global.overVoltageValue_model1;
                    Global.overVoltageTime = Global.overVoltageTime_model1;
                    Global.underVoltageValue = Global.underVoltageValue_model1;
                    Global.underVoltageTime = Global.underVoltageTime_model1;
                    Global.lowVoltageValue = Global.lowVoltageValue_model1;
                    Global.closeSwitchTimeUp = Global.closeSwitchTimeUp_model1;
                    Global.VoltageErroRange = Global.VoltageErroRange_model1;
                }
                else if (Global.model2Select)
                {
                    Global.actionTest1Current = Global.actionTest1Current_model2;
                    Global.actionTest1Time = Global.actionTest1Time_model2;
                    Global.actionTest2StartCurrent = Global.actionTest2StartCurrent_model2;
                    Global.actionTest2EndCurrent = Global.actionTest2EndCurrent_model2;
                    Global.actionTest3Current = Global.actionTest3Current_model2;
                    Global.actionTest3Time = Global.actionTest3Time_model2;
                    Global.overVoltageValue = Global.overVoltageValue_model2;
                    Global.overVoltageTime = Global.overVoltageTime_model2;
                    Global.underVoltageValue = Global.underVoltageValue_model2;
                    Global.underVoltageTime = Global.underVoltageTime_model2;
                    Global.lowVoltageValue = Global.lowVoltageValue_model2;
                    Global.closeSwitchTimeUp = Global.closeSwitchTimeUp_model2;
                    Global.VoltageErroRange = Global.VoltageErroRange_model2;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private bool GetBool(string value)
        {
            if (value == "1")
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 将参数写入plc中
        /// </summary>
        private void ToPlc()
        {
            try
            {
                WriteMemory(MemoryAddress.actionTest1Current, Global.actionTest1Current);
                WriteMemory(MemoryAddress.actionTest1Time, Global.actionTest1Time);
                WriteMemory(MemoryAddress.actionTest2EndCurrent, Global.actionTest2EndCurrent);
                WriteMemory(MemoryAddress.actionTest2StartCurrent, Global.actionTest2StartCurrent);
                //WriteMemory(MemoryAddress.actionTest2Time, Global.actionTest2Time);
                WriteMemory(MemoryAddress.actionTest3Current, Global.actionTest3Current);
                WriteMemory(MemoryAddress.actionTest3Time, Global.actionTest3Time);
                WriteMemory(MemoryAddress.closeSwitchTimeUp, Global.closeSwitchTimeUp);
                WriteMemory(MemoryAddress.lowVoltageValue, Global.lowVoltageValue);
                WriteMemory(MemoryAddress.overVoltageTime, Global.overVoltageTime);
                WriteMemory(MemoryAddress.overVoltageValue, Global.overVoltageValue);
                WriteMemory(MemoryAddress.underVoltageTime, Global.underVoltageTime);
                WriteMemory(MemoryAddress.underVoltageValue, Global.underVoltageValue);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                //    MessageBox.Show(ex.ToString());
            }

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TmrState.Enabled = true;
        }

        private void BtnFunction_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmFunction frmFunction = new FrmFunction();
            frmFunction.ShowDialog();
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmAuto frmAuto = new FrmAuto();
            frmAuto.ShowDialog();
        }

        private void BtnSemiAuto_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmSemiAuto1 frmSemiAuto = new FrmSemiAuto1();
            frmSemiAuto.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReady_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmReady1 frmReady1 = new FrmReady1();
            frmReady1.ShowDialog();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.kv.Connect())
                {
                    MessageBox.Show("plc连接成功");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }


        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            try
            {
                LbLTime.Text = DateTime.Now.ToString();
                if (Global.kv.Active)
                {
                    LblPlcConnect.Text = "plc通信正常";
                }
                else LblPlcConnect.Text = "plc通信异常";
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(ex);
            }

        }

        private void BtnParameter_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmParameter frmParameter = new FrmParameter();
            frmParameter.ShowDialog();
        }

        private void BtnReady2_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmReady2 frmReady2 = new FrmReady2();
            frmReady2.ShowDialog();
        }

        private void BtnReady3_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmReady3 frmReady3 = new FrmReady3();
            frmReady3.ShowDialog();
        }

        private void BtnManualSelect_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmManualSelect frmManualSelect = new FrmManualSelect();
            frmManualSelect.ShowDialog();

        }
        private void WriteMemory(MemoryAddress address, int data)
        {
            uint[] dataReturn = DoubleConvert.Real_to_2Int(data);
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, ((int)address).ToString(), (int)dataReturn[1]);
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, ((int)(address) + 1).ToString(), (int)dataReturn[0]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                //MessageBox.Show(ex.ToString());
            }
        }
        private enum MemoryAddress : int
        {
            actionTest1Current = 5400,
            actionTest1Time = 5402,
            actionTest2StartCurrent = 5404,
            actionTest2EndCurrent = 5406,
            actionTest2Time = 5408,
            actionTest3Current = 5410,
            actionTest3Time = 5412,
            overVoltageValue = 5414,
            overVoltageTime = 5416,
            underVoltageValue = 5418,
            underVoltageTime = 5420,
            lowVoltageValue = 5422,
            closeSwitchTimeUp = 5424,
        }
    }
}
