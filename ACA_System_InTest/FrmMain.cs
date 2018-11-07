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
using System.Threading;
using log4net;
namespace ACA_System_InTest
{
    public partial class FrmMain : Form
    {
        private delegate void uishow();
        public FrmMain()
        {
            InitializeComponent();
            GetParameter();
            //ToPlc();
        }
        /// <summary>
        /// 获取保存的用户设置参数
        /// </summary>
        private void GetParameter()
        {
            try
            {
                Global.outPutCurrent_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["current_model1"]);
                Global.outPutTime_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["currentTime_model1"]);
                Global.lowTimesCurrent_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["lowCurrent_model1"]);
                Global.lowTimesTime_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["lowTime_model1"]);
                Global.highTimesCurrent_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["highCurrent_model1"]);
                Global.highTimesTime_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["highTime_model1"]);
                Global.errorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["errorRange_model1"]);
                Global.outPutCurrent_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["current_model2"]);
                Global.outPutTime_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["currentTime_model2"]);
                Global.lowTimesCurrent_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["lowCurrent_model2"]);
                Global.lowTimesTime_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["lowTime_model2"]);
                Global.highTimesCurrent_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["highCurrent_model2"]);
                Global.highTimesTime_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["highTime_model2"]);
                Global.errorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["errorRange_model2"]);
                Global.meachineTestNum = Convert.ToInt32(ConfigurationManager.AppSettings["meachineNum"]);
                Global.doOutPut1 = GetBool(ConfigurationManager.AppSettings["doOutput1"]);
                Global.doOutPut2 = GetBool(ConfigurationManager.AppSettings["doOutput2"]);
                Global.doOutPut3 = GetBool(ConfigurationManager.AppSettings["doOutput3"]);
                Global.doLow = GetBool(ConfigurationManager.AppSettings["doLow"]);
                Global.doHigh = GetBool(ConfigurationManager.AppSettings["doHigh"]);
                Global.model1Select = GetBool(ConfigurationManager.AppSettings["Model1"]);
                Global.model2Select = GetBool(ConfigurationManager.AppSettings["Model2"]);
                Global.manualCommunication = GetBool(ConfigurationManager.AppSettings["ManualCom"]);
                Global.autoCommunication = GetBool(ConfigurationManager.AppSettings["AutoCom"]);
                Global.scan = GetBool(ConfigurationManager.AppSettings["Scan"]);
                Global.manualJudge = GetBool(ConfigurationManager.AppSettings["ManualJudge"]);
                Global.meachineAge = GetBool(ConfigurationManager.AppSettings["MeachineAge"]);
                Global.autoLine = GetBool(ConfigurationManager.AppSettings["AutoLine"]);
                Global.manualLine = GetBool(ConfigurationManager.AppSettings["ManualLine"]);
                Global.defence = GetBool(ConfigurationManager.AppSettings["Defence"]);
                Global.baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
                Global.closeDoor = GetBool(ConfigurationManager.AppSettings["CloseDoor"]);
                if (Global.model1Select)
                {
                    Global.outPutCurrent = Global.outPutCurrent_model1;
                    Global.outPutTime= Global.outPutTime_model1;
                    Global.lowTimesCurrent= Global.lowTimesCurrent_model1;
                    Global.lowTimesTime= Global.lowTimesTime_model1;
                    Global.highTimesCurrent=Global.highTimesCurrent_model1;
                    Global.highTimesTime=Global.highTimesTime_model1;
                    Global.errorRange= Global.errorRange_model1;
                }
                else if (Global.model2Select)
                {
                    Global.outPutCurrent = Global.outPutCurrent_model2;
                    Global.outPutTime = Global.outPutTime_model2;
                    Global.lowTimesCurrent = Global.lowTimesCurrent_model2;
                    Global.lowTimesTime = Global.lowTimesTime_model2;
                    Global.highTimesCurrent = Global.highTimesCurrent_model2;
                    Global.highTimesTime = Global.highTimesTime_model2;
                    Global.errorRange = Global.errorRange_model2;
                }
                //Global.setMeachineAge = GetBool(ConfigurationManager.AppSettings["SetMeachineAge"]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }
            
        }
        /// <summary>
        /// 将用户设置参数写入plc
        /// </summary>
        private void ToPlc()
        {
            try
            {
                WriteMemory(MemoryAddress.outPutCurrent, Global.outPutCurrent);
                WriteMemory(MemoryAddress.outPutTime, Global.outPutTime);
                WriteMemory(MemoryAddress.lowTimesCurrent, Global.lowTimesCurrent);
                WriteMemory(MemoryAddress.lowTimesTime, Global.lowTimesTime);
                WriteMemory(MemoryAddress.highTimesCurrent, Global.highTimesCurrent);
                WriteMemory(MemoryAddress.highTimesTime, Global.highTimesTime);
                WriteMemory(MemoryAddress.errorRange, Global.errorRange);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
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
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ToPlc();
            TmrState.Enabled = true;
        }
        /// <summary>
        /// 状态显示
        /// </summary>
        private void Display()
        {
            try
            {
                LblTime.Text = DateTime.Now.ToString();
                LblState.Text = Global.kv.Active ? "plc连接正常" : "plc连接异常";
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            
        }
        /// <summary>
        /// 将整型数据转换成浮点数写入plc中（两个寄存器）
        /// </summary>
        /// <param name="address"></param>
        /// <param name="data"></param>
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
        /// <summary>
        /// 寄存器地址枚举
        /// </summary>
        private enum MemoryAddress : int
        {
            outPutCurrent = 4400,
            outPutTime = 4402,
            lowTimesCurrent = 4404,
            lowTimesTime = 4406,
            highTimesCurrent = 4408,
            highTimesTime = 4410,
            errorRange = 4412,
        }
        private void BtnManual1_Click(object sender, EventArgs e)
        {

            Hide();
            FrmManual1 frmManual1 = new FrmManual1();
            frmManual1.ShowDialog();
        }

        private void BtnManual2_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual2 frmManual2 = new FrmManual2();
            frmManual2.ShowDialog();
        }

        private void BtnManual3_Click(object sender, EventArgs e)
        {
            Hide();
            FrmManual3 frmManual3 = new FrmManual3();
            frmManual3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.kv.Connect())
                {
                    //MessageBox.Show("plc" +
                    //    "连接成功");
                }
                else MessageBox.Show("plc连接失败");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show("plc无法连接，请检查");
            }
            
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
            FrmSemi_Auto frmSemi_Auto = new FrmSemi_Auto();
            frmSemi_Auto.ShowDialog();
        }

        private void BtnParameterSet_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmParameter frmParameter = new FrmParameter();
            frmParameter.ShowDialog();
        }

        private void BtnReady_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmReady frmReady = new FrmReady();
            frmReady.ShowDialog();
        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            Display();
        }
    }
}
