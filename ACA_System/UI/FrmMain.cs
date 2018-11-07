using ACA_Common.Class;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ACA_System.UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();    
            GetParameter();
            ToPlc();
        }
        /// <summary>
        /// 获取用户参数
        /// </summary>
        private void GetParameter()
        {
            try
            {
                Global.currentProofNum_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentProofNum"]);
                Global.voltageProofNum_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["VoltageProofNum"]);
                Global.residualCurrentProofNum_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentProofNum"]);
                Global.presetCurrentValue1_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent1"]);
                Global.presetCurrentValue2_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent2"]);
                Global.presetCurrentValue3_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent3"]);
                Global.presetCurrentValue4_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent4"]);
                Global.presetCurrentValue5_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent5"]);
                Global.presetVoltageValue1_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage1"]);
                Global.presetVoltageValue2_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage2"]);
                Global.presetVoltageValue3_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage3"]);
                Global.presetVoltageValue4_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage4"]);
                Global.presetVoltageValue5_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage5"]);
                Global.closeSwitchVoltage = Convert.ToInt32(ConfigurationManager.AppSettings["CloseSwitchVoltage"]);
                Global.presetResidualCurrentValue1_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent1"]);
                Global.presetResidualCurrentValue2_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent2"]);
                Global.presetResidualCurrentValue3_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent3"]);
                Global.presetResidualCurrentValue4_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent4"]);
                Global.presetResidualCurrentValue5_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent5"]);
                Global.proofCurrentErrorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentErrorRange"]);
                Global.proofVoltageErrorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["VoltageErrorRange"]);
                Global.proofResidualCurrentErrorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentErrorRange"]);
                Global.checkCurrentErrorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentCheckErrorRange"]);
                Global.checkVoltageErrorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["VoltageCheckErrorRange"]);
                Global.checkResidualCurrentErrorRange_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentCheckErrorRange"]);
                Global.currentZero_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentZero"]);
                Global.residualCurrentZero_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentZero"]);
                Global.currentCheck_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CheckValue1"]);
                Global.voltageCheck_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CheckValue2"]);
                Global.residualCurrentCheck_model1 = Convert.ToInt32(ConfigurationManager.AppSettings["CheckValue3"]);
                Global.currentProofNum_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentProofNum_model2"]);
                Global.voltageProofNum_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["VoltageProofNum"]);
                Global.residualCurrentProofNum_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentProofNum_model2"]);
                Global.presetCurrentValue1_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent1_model2"]);
                Global.presetCurrentValue2_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent2_model2"]);
                Global.presetCurrentValue3_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent3_model2"]);
                Global.presetCurrentValue4_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent4_model2"]);
                Global.presetCurrentValue5_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetCurrent5_model2"]);
                Global.presetVoltageValue1_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage1_model2"]);
                Global.presetVoltageValue2_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage2_model2"]);
                Global.presetVoltageValue3_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage3_model2"]);
                Global.presetVoltageValue4_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage4_model2"]);
                Global.presetVoltageValue5_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetVoltage5_model2"]);
                Global.presetResidualCurrentValue1_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent1_model2"]);
                Global.presetResidualCurrentValue2_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent2_model2"]);
                Global.presetResidualCurrentValue3_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent3_model2"]);
                Global.presetResidualCurrentValue4_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent4_model2"]);
                Global.presetResidualCurrentValue5_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["PresetResidualCurrent5_model2"]);
                Global.proofCurrentErrorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentErrorRange_model2"]);
                Global.proofVoltageErrorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["VoltageErrorRange_model2"]);
                Global.proofResidualCurrentErrorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentErrorRange_model2"]);
                Global.checkCurrentErrorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentCheckErrorRange_model2"]);
                Global.checkVoltageErrorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["VoltageCheckErrorRange_model2"]);
                Global.checkResidualCurrentErrorRange_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentCheckErrorRange_model2"]);
                Global.currentZero_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentZero_model2"]);
                Global.residualCurrentZero_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualCurrentZero_model2"]);
                Global.currentCheck_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CheckValue1_model2"]);
                Global.voltageCheck_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CheckValue2_model2"]);
                Global.residualCurrentCheck_model2 = Convert.ToInt32(ConfigurationManager.AppSettings["CheckValue3_model2"]);
                Global.meachineTestNum = Convert.ToInt32(ConfigurationManager.AppSettings["MeachineNum"]);
                Global.doCurrent1 = GetBool(ConfigurationManager.AppSettings["DoCurrent1"]);
                Global.doCurrent2 = GetBool(ConfigurationManager.AppSettings["DoCurrent2"]);
                Global.doCurrent3 = GetBool(ConfigurationManager.AppSettings["DoCurrent3"]);
                Global.doCurrent4 = GetBool(ConfigurationManager.AppSettings["DoCurrent4"]);
                Global.doCurrent5 = GetBool(ConfigurationManager.AppSettings["DoCurrent5"]);
                Global.doVoltage1 = GetBool(ConfigurationManager.AppSettings["DoVoltage1"]);
                Global.doVoltage2 = GetBool(ConfigurationManager.AppSettings["DoVoltage2"]);
                Global.doVoltage3 = GetBool(ConfigurationManager.AppSettings["DoVoltage3"]);
                Global.doVoltage4 = GetBool(ConfigurationManager.AppSettings["DoVoltage4"]);
                Global.doVoltage5 = GetBool(ConfigurationManager.AppSettings["DoVoltage5"]);
                Global.doResidualCurrent1 = GetBool(ConfigurationManager.AppSettings["DoResidualCurrent1"]);
                Global.doResidualCurrent2 = GetBool(ConfigurationManager.AppSettings["DoResidualCurrent2"]);
                Global.doResidualCurrent3 = GetBool(ConfigurationManager.AppSettings["DoResidualCurrent3"]);
                Global.doResidualCurrent4 = GetBool(ConfigurationManager.AppSettings["DoResidualCurrent4"]);
                Global.doResidualCurrent5 = GetBool(ConfigurationManager.AppSettings["DoResidualCurrent5"]);
                Global.model1Select = GetBool(ConfigurationManager.AppSettings["Model1"]);
                Global.model2Select = GetBool(ConfigurationManager.AppSettings["Model2"]);
                Global.manualCommunication = GetBool(ConfigurationManager.AppSettings["ManualCom"]);
                Global.autoCommunication = GetBool(ConfigurationManager.AppSettings["AutoCom"]);
                Global.scan = GetBool(ConfigurationManager.AppSettings["Scan"]);
                Global.manualJudge = GetBool(ConfigurationManager.AppSettings["ManualJudge"]);
                Global.meachineAge = GetBool(ConfigurationManager.AppSettings["MeachineAge"]);
                Global.meachineTestNum = Convert.ToInt32(ConfigurationManager.AppSettings["MeachineNum"]);
                Global.closeDoor = GetBool(ConfigurationManager.AppSettings["CloseDoor"]);
                Global.autoLine = GetBool(ConfigurationManager.AppSettings["AutoLine"]);
                Global.manualLine = GetBool(ConfigurationManager.AppSettings["ManualLine"]);
                Global.defence= GetBool(ConfigurationManager.AppSettings["Defence"]);
                Global.openLine = GetBool(ConfigurationManager.AppSettings["OpenLine"]);
                Global.closeLine = GetBool(ConfigurationManager.AppSettings["CloseLine"]);
                Global.baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
                Global.residualTime = Convert.ToInt32(ConfigurationManager.AppSettings["ResidualTime"]);
                Global.delayTime= Convert.ToInt32(ConfigurationManager.AppSettings["DelayTime"]);
                if (Global.model1Select)
                {
                    Global.currentProofNum = Global.currentProofNum_model1;
                    Global.currentProofNum = Global.currentProofNum_model1;
                    Global.residualCurrentProofNum = Global.residualCurrentProofNum_model1;
                    Global.presetCurrentValue1 = Global.presetCurrentValue1_model1;
                    Global.presetCurrentValue2 = Global.presetCurrentValue2_model1;
                    Global.presetCurrentValue3 = Global.presetCurrentValue3_model1;
                    Global.presetCurrentValue4 = Global.presetCurrentValue4_model1;
                    Global.presetCurrentValue5 = Global.presetCurrentValue5_model1;
                    Global.presetVoltageValue1 = Global.presetVoltageValue1_model1;
                    Global.presetVoltageValue2 = Global.presetVoltageValue2_model1;
                    Global.presetVoltageValue3 = Global.presetVoltageValue3_model1;
                    Global.presetVoltageValue4 = Global.presetVoltageValue4_model1;
                    Global.presetVoltageValue5 = Global.presetVoltageValue5_model1;
                    Global.presetResidualCurrentValue1 = Global.presetResidualCurrentValue1_model1;
                    Global.presetResidualCurrentValue2 = Global.presetResidualCurrentValue2_model1;
                    Global.presetResidualCurrentValue3 = Global.presetResidualCurrentValue3_model1;
                    Global.presetResidualCurrentValue4 = Global.presetResidualCurrentValue4_model1;
                    Global.presetResidualCurrentValue5 = Global.presetResidualCurrentValue5_model1;
                    Global.proofCurrentErrorRange = Global.proofCurrentErrorRange_model1;
                    Global.proofVoltageErrorRange = Global.proofVoltageErrorRange_model1;
                    Global.proofResidualCurrentErrorRange = Global.proofResidualCurrentErrorRange_model1;
                    Global.checkCurrentErrorRange = Global.checkCurrentErrorRange_model1;
                    Global.checkVoltageErrorRange = Global.checkVoltageErrorRange_model1;
                    Global.checkResidualCurrentErrorRange = Global.checkResidualCurrentErrorRange_model1;
                    Global.currentZero = Global.currentZero_model1;
                    Global.residualCurrentZero = Global.residualCurrentZero_model1;
                    Global.currentCheck = Global.currentCheck_model1;
                    Global.voltageCheck = Global.voltageCheck_model1;
                    Global.residualCurrentCheck = Global.residualCurrentCheck_model1;
                }
                else if (Global.model2Select)
                {
                    Global.currentProofNum = Global.currentProofNum_model2;
                    Global.currentProofNum = Global.currentProofNum_model2;
                    Global.residualCurrentProofNum = Global.residualCurrentProofNum_model2;
                    Global.presetCurrentValue1 = Global.presetCurrentValue1_model2;
                    Global.presetCurrentValue2 = Global.presetCurrentValue2_model2;
                    Global.presetCurrentValue3 = Global.presetCurrentValue3_model2;
                    Global.presetCurrentValue4 = Global.presetCurrentValue4_model2;
                    Global.presetCurrentValue5 = Global.presetCurrentValue5_model2;
                    Global.presetVoltageValue1 = Global.presetVoltageValue1_model2;
                    Global.presetVoltageValue2 = Global.presetVoltageValue2_model2;
                    Global.presetVoltageValue3 = Global.presetVoltageValue3_model2;
                    Global.presetVoltageValue4 = Global.presetVoltageValue4_model2;
                    Global.presetVoltageValue5 = Global.presetVoltageValue5_model2;
                    Global.presetResidualCurrentValue1 = Global.presetResidualCurrentValue1_model2;
                    Global.presetResidualCurrentValue2 = Global.presetResidualCurrentValue2_model2;
                    Global.presetResidualCurrentValue3 = Global.presetResidualCurrentValue3_model2;
                    Global.presetResidualCurrentValue4 = Global.presetResidualCurrentValue4_model2;
                    Global.presetResidualCurrentValue5 = Global.presetResidualCurrentValue5_model2;
                    Global.proofCurrentErrorRange = Global.proofCurrentErrorRange_model2;
                    Global.proofVoltageErrorRange = Global.proofVoltageErrorRange_model2;
                    Global.proofResidualCurrentErrorRange = Global.proofResidualCurrentErrorRange_model2;
                    Global.checkCurrentErrorRange = Global.checkCurrentErrorRange_model2;
                    Global.checkVoltageErrorRange = Global.checkVoltageErrorRange_model2;
                    Global.checkResidualCurrentErrorRange = Global.checkResidualCurrentErrorRange_model2;
                    Global.currentZero = Global.currentZero_model2;
                    Global.residualCurrentZero = Global.residualCurrentZero_model2;
                    Global.currentCheck = Global.currentCheck_model2;
                    Global.voltageCheck = Global.voltageCheck_model2;
                    Global.residualCurrentCheck = Global.residualCurrentCheck_model2;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }
            
            //Global.setMeachineAge = GetBool(ConfigurationManager.AppSettings["SetMeachineAge"]);
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
        /// 将Plc所需参数写到Plc中
        /// </summary>
        private void ToPlc()
        {
            try
            {
                WriteMemory(MemoryAddress.CurrentProofNum, Global.currentProofNum);
                WriteMemory(MemoryAddress.Preset1CurrentValue, Global.presetCurrentValue1);
                WriteMemory(MemoryAddress.Preset2CurrentValue, Global.presetCurrentValue2);
                WriteMemory(MemoryAddress.Preset3CurrentValue, Global.presetCurrentValue3);
                WriteMemory(MemoryAddress.Preset4CurrentValue, Global.presetCurrentValue4);
                WriteMemory(MemoryAddress.Preset5CurrentValue, Global.presetCurrentValue5);
                WriteMemory(MemoryAddress.CurrentCheckValue, Global.currentCheck);
                WriteMemory(MemoryAddress.CurrentProofRange, Global.proofCurrentErrorRange);
                WriteMemory(MemoryAddress.VoltageProofNum, Global.voltageProofNum);
                WriteMemory(MemoryAddress.Preset1VoltageValue, Global.presetVoltageValue1);
                WriteMemory(MemoryAddress.Preset2VoltageValue, Global.presetVoltageValue2);
                WriteMemory(MemoryAddress.Preset3VoltageValue, Global.presetVoltageValue3);
                WriteMemory(MemoryAddress.Preset4VoltageValue, Global.presetVoltageValue4);
                WriteMemory(MemoryAddress.Preset5VoltageValue, Global.presetVoltageValue5);
                WriteMemory(MemoryAddress.VoltageCheckValue, Global.voltageCheck);
                WriteMemory(MemoryAddress.VoltageProofRange, Global.proofVoltageErrorRange);
                WriteMemory(MemoryAddress.ResidualCurrentProofNum, Global.currentProofNum);
                WriteMemory(MemoryAddress.Preset1ResidualCurrentValue, Global.presetResidualCurrentValue1);
                WriteMemory(MemoryAddress.Preset2ResidualCurrentValue, Global.presetResidualCurrentValue2);
                WriteMemory(MemoryAddress.Preset3ResidualCurrentValue, Global.presetResidualCurrentValue3);
                WriteMemory(MemoryAddress.Preset4ResidualCurrentValue, Global.presetResidualCurrentValue4);
                WriteMemory(MemoryAddress.Preset5ResidualCurrentValue, Global.presetResidualCurrentValue5);
                WriteMemory(MemoryAddress.ResidualCurrentCheckValue, Global.residualCurrentCheck);
                WriteMemory(MemoryAddress.ResidualCurrentProofRange, Global.proofResidualCurrentErrorRange);
                WriteMemory(MemoryAddress.CloseSwitchVoltage, Global.closeSwitchVoltage);
                WriteMemory(MemoryAddress.ResidualTime, Global.residualTime);
              
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                //MessageBox.Show(ex.ToString());
            }
           

        }
        private void BtnSetParameter_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmSetParameter frmSet = new FrmSetParameter();
            frmSet.ShowDialog();
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmAuto frmAuto = new FrmAuto();
            frmAuto.ShowDialog();
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmManual1 frmManual1 = new FrmManual1();
            frmManual1.ShowDialog();
        }

        private void BtnCurrentTest_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmSemiAuto frmCurrent = new FrmSemiAuto();
            frmCurrent.ShowDialog();
        }

        /// <summary>
        /// 获取保存的用户设置参数
        /// </summary>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReady_Click(object sender, EventArgs e)
        {
           
            TmrState.Enabled = false;
            Hide();
            FrmReady frmReady = new FrmReady();
            frmReady.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TmrState.Enabled = true;
        }


        private void BtnAutoSelect_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmFunction frmFunction = new FrmFunction();
            frmFunction.ShowDialog();
        }

        private void BtnManual2_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmManual2 frmManual2 = new FrmManual2();
            frmManual2.ShowDialog();
        }

        private void BtnManual3_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmManual3 frmManual3 = new FrmManual3();
            frmManual3.ShowDialog();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                    if (Global.kv.Connect())
                    {
                        //MessageBox.Show("plc连接成功");
                    }
                    else
                    {
                        MessageBox.Show("plc连接失败");
                    }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            try
            {
                LblTime.Text = DateTime.Now.ToString();
                if (!Global.kv.Active)
                {
                    //MessageBox.Show("PLC通信错误，请检查通信");
                    LblPlcState.Text = "PLC通信异常";
                }
                else LblPlcState.Text = "PLC通信正常";
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        /// <summary>
        /// 将对应参数值写到对应地址寄存器中
        /// </summary>
        /// <param name="address"></param>
        /// <param name="data"></param>
        private void WriteMemory(MemoryAddress address, int data)
        {
           uint[] dataReturn= DoubleConvert.Real_to_2Int(data);
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM,  ((int)address).ToString(), (int)dataReturn[1]);
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, ((int)(address)+1).ToString(), (int)dataReturn[0]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                //MessageBox.Show(ex.ToString());
            }
        }
        public enum MemoryAddress : int
        {
            CurrentProofNum=3400,
            Preset1CurrentValue=3402,
            Preset2CurrentValue=3404,
            Preset3CurrentValue=3406,
            Preset4CurrentValue=3408,
            Preset5CurrentValue=3410,
            CurrentCheckValue=3412,
            CurrentProofRange=3414,
            /// <summary>
            /// 电压
            /// </summary>
            VoltageProofNum=3416,
            Preset1VoltageValue=3418,
            Preset2VoltageValue=3420,
            Preset3VoltageValue=3422,
            Preset4VoltageValue=3424,
            Preset5VoltageValue=3426,
            VoltageCheckValue=3428,
            VoltageProofRange=3430,
            /// <summary>
            /// 剩余电流
            /// </summary>
            ResidualCurrentProofNum=3432,
            Preset1ResidualCurrentValue=3434,
            Preset2ResidualCurrentValue=3436,
            Preset3ResidualCurrentValue=3438,
            Preset4ResidualCurrentValue=3440,
            Preset5ResidualCurrentValue=3442,
            ResidualCurrentCheckValue=3444,
            ResidualCurrentProofRange=3446,
            /// <summary>
            /// 其他参数
            /// </summary>
            CloseSwitchVoltage=3448, 
            MeachineNum=3450,
            ResidualTime=3452,
        }
    }
}
