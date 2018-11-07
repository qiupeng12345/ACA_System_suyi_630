using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using ACA_Common;
using ACA_Common.Class;


namespace ACA_System.UI
{
    public partial class FrmAuto : Form
    {
        ButtonNew[] btnArray = new ButtonNew[6]; //按钮数组
        LabelNew[] lblArray = new LabelNew[7]; //标签数组
        string[] alarmString = new string[28]; //报警信息数组
        string[] stateString = new string[115]; //状态信息数组
        Dictionary<int, string> dicState = new Dictionary<int, string>();
        List<AlarmObject> list;
        string stateAddress = "3601"; //获取状态的地址
        string address1 = "3900"; //报警状态地址1
        string address2 = "3901";//报警状态地址2
        //各报警情况状态位
        bool alarmComuniction1 = false;
        bool alarmCloseSwitch1 = false;
        bool alarmEnterProof1 = false;
        bool alarmProofFail1 = false;
        bool alarmProofCheck1 = false;
        bool alarmSwitchState1 = false;
        bool alarmPLC1 = false;
        bool alarmOpenSwitch1 = false;
        bool alarmSwitchStateCom1 = false;
        bool alarmComuniction2 = false;
        bool alarmCloseSwitch2 = false;
        bool alarmEnterProof2 = false;
        bool alarmProofFail2 = false;
        bool alarmProofCheck2 = false;
        bool alarmSwitchState2 = false;
        bool alarmPLC2 = false;
        bool alarmOpenSwitch2 = false;
        bool alarmSwitchStateCom2 = false;
        bool alarmComuniction3 = false;
        bool alarmCloseSwitch3 = false;
        bool alarmEnterProof3 = false;
        bool alarmProofFail3 = false;
        bool alarmProofCheck3 = false;
        bool alarmSwitchState3 = false;
        bool alarmPLC3 = false;
        bool alarmOpenSwitch3 = false;
        bool alarmSwitchStateCom3 = false;
        bool[] alarm1;
        bool[] alarm2;
        bool[] alarm3;
        //报警信息对象
        AlarmInfo infoCommunication = new AlarmInfo();
        AlarmInfo infoCloseSwitch = new AlarmInfo();
        AlarmInfo infoEnterProof = new AlarmInfo();
        AlarmInfo infoProofFail = new AlarmInfo();
        AlarmInfo infoProofCheck = new AlarmInfo();
        AlarmInfo infoSwitchState = new AlarmInfo();
        AlarmInfo infoPLC = new AlarmInfo();
        AlarmInfo infoOpenSwitch = new AlarmInfo();
        AlarmInfo infoSwitchStateCom = new AlarmInfo();
        //报警信息显示集合（绑定dgv）
        BindingList<AlarmInfo> listAlarm;
        Dictionary<string, AlarmInfo> dicAlarm = new Dictionary<string, AlarmInfo>();//报警信息字典
        bool plcErro = false;


        //BackgroundWorker BGauto =new BackgroundWorker();
        public FrmAuto()
        {
            InitializeComponent();
            GetConfig();
            ListGet();
            //ProofAlarm();
        }

        private void FrmAuto_Load(object sender, EventArgs e)
        {
            alarm1 = new bool[]
            {
                alarmComuniction1,
                alarmCloseSwitch1,
                alarmEnterProof1 ,
                alarmProofFail1 ,
                alarmProofCheck1,
                alarmSwitchState1,
                alarmPLC1 ,
                alarmOpenSwitch1,
                alarmSwitchStateCom1,
            };
            alarm2 = new bool[]
             {
                alarmComuniction2,
                alarmCloseSwitch2,
                alarmEnterProof2 ,
                alarmProofFail2 ,
                alarmProofCheck2,
                alarmSwitchState2,
                alarmPLC2 ,
                alarmOpenSwitch2,
                alarmSwitchStateCom2,
             };
            alarm3 = new bool[]
            {
                alarmComuniction3,
                alarmCloseSwitch3,
                alarmEnterProof3 ,
                alarmProofFail3 ,
                alarmProofCheck3,
                alarmSwitchState3,
                alarmPLC3 ,
                alarmOpenSwitch3,
                alarmSwitchStateCom3,
            };
            lblArray[0] = LblCurrent;
            lblArray[1] = LblTime;
            lblArray[2] = LblVoltageA;
            lblArray[3] = LblVoltageB;
            lblArray[4] = LblVoltageC;
            lblArray[5] = LblLeakCurrent;
            lblArray[6] = LblLeakCurrentTime;
            btnArray[0] = BtnStart;
            btnArray[1] = BtnStop;
            btnArray[2] = BtnAlarm;
            btnArray[3] = BtnReady;
            btnArray[4] = BtnJigs;
            btnArray[5] = BtnEnd;
            listAlarm = new BindingList<AlarmInfo>();
            DgvAlarm.DataSource = listAlarm;
            if (!Global.manualJudge)
            {
                LblManualJudge.Visible = false;
                BtnOk.Visible = false;
                BtnNo.Visible = false;
            }
            if (Global.autoLine)
            {
                BtnReady.Visible = false;
                BtnJigs.Visible = false;
                BtnEnd.Visible = false;
            }
            TmrState.Enabled = true;
        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            Display();
            StateDisplay();
            Alarm();
            ProofAlarm("3602", alarm1);
            ProofAlarm("3603", alarm2);
            ProofAlarm("3604", alarm3);

        }
        /// <summary>
        /// 定义报警集合
        /// </summary>
        private void ListGet()
        {
            list = new List<AlarmObject>()
            {
                new AlarmObject("390000", alarmString[0],false),new AlarmObject("390001", alarmString[1], false),
                new AlarmObject("390002", alarmString[2], false),new AlarmObject("390003", alarmString[3], false),
                new AlarmObject("390004", alarmString[4], false),new AlarmObject("390005", alarmString[5], false),
                new AlarmObject("390006", alarmString[6], false),new AlarmObject("390007", alarmString[7], false),
                new AlarmObject("390008", alarmString[8], false),new AlarmObject("390009", alarmString[9], false),
                new AlarmObject("390010", alarmString[10], false),new AlarmObject("390011", alarmString[11], false),
                new AlarmObject("390012", alarmString[12], false),new AlarmObject("390013", alarmString[13], false),
                new AlarmObject("390014", alarmString[14], false),new AlarmObject("390015", alarmString[15], false),
                new AlarmObject("390100", alarmString[16], false),new AlarmObject("390101", alarmString[17], false),
                new AlarmObject("390102", alarmString[18], false),new AlarmObject("390103", alarmString[19], false),
                new AlarmObject("390104", alarmString[20], false),new AlarmObject("390105", alarmString[21], false),
                new AlarmObject("390106", alarmString[22], false),new AlarmObject("390107", alarmString[23], false),
                new AlarmObject("390108", alarmString[24], false),new AlarmObject("390109", alarmString[25], false),
                new AlarmObject("390110", alarmString[26], false),new AlarmObject("390111",alarmString[27],false),
            };
        }
        /// <summary>
        /// 从appconfig 中获取配置好的报警信息和状态信息
        /// </summary>
        private void GetConfig()
        {


            try
            {
                for (int i = 0; i < alarmString.Length; i++)
                {
                    alarmString[i] = ConfigurationManager.AppSettings["alarm" + i.ToString()];
                }
                for (int i = 0; i < stateString.Length; i++)
                {
                    stateString[i] = ConfigurationManager.AppSettings["state" + i.ToString()];
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        /// <summary>
        /// 获取当前工作状态
        /// </summary>
        private void StateDisplay()
        {
            try
            {
                LblState.Text = stateString[(Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, stateAddress))];
                if (Global.model1Select)
                {
                    LblSelectModel.Text = "400A";
                }
                else if (Global.model2Select)
                {
                    LblSelectModel.Text = "630A";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                LblState.Text = "erro";
            }

        }
        /// <summary>
        /// 界面显示
        /// </summary>
        private void Display()
        {
            try
            {
                for (int i = 0; i < lblArray.Length; i++)
                {
                    lblArray[i].Text = DoubleConvert.Dint_to_Real((uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].StateAddress)
                     , (uint)Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, lblArray[i].Address)).ToString("0.00");
                    Thread.Sleep(10);
                }
                for (int i = 0; i < btnArray.Length; i++)
                {
                    if ((Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btnArray[i].StateAddress) == 1))
                    {
                        if (btnArray[i].StateAddress=="122112")
                        {
                            if (Global.workState)
                            {
                                btnArray[i].BackColor = Color.Green;
                            }
                            else btnArray[i].BackColor = Color.Red;
                        }
                        else btnArray[i].BackColor = Color.Green;
                    }
                    else btnArray[i].BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                for (int i = 0; i < lblArray.Length; i++)
                {
                    lblArray[i].Text = "erro";
                }

            }

        }
        /// <summary>
        /// 显示报警信息
        /// </summary>
        private void Alarm()
        {
            try
            {
                if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address1) != 0 || Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address2) != 0 || Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address1) != 0)
                {
                    foreach (var item in list)
                    {
                        if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, item.AlarmAddress) == 1) //读取该位为1（报警）
                        {
                            if (!item.IsAlarming) //没有标记为报警
                            {
                                AlarmInfo info = new AlarmInfo(DateTime.Now, item.AlarmTip);
                                listAlarm.Add(info);
                                dicAlarm.Add(item.AlarmAddress, info);
                                item.IsAlarming = true;
                            }
                        }
                        else if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM_B, item.AlarmAddress) == 0)
                        {
                            if (item.IsAlarming) //标记为正在报警
                            {
                                listAlarm.Remove(dicAlarm[item.AlarmAddress]);
                                dicAlarm.Remove(item.AlarmAddress);
                                item.IsAlarming = false;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (item.IsAlarming) //标记为正在报警
                        {
                            listAlarm.Remove(dicAlarm[item.AlarmAddress]);
                            dicAlarm.Remove(item.AlarmAddress);
                            item.IsAlarming = false;
                        }
                    }
                }
                ///校对过程报警

                if (plcErro)
                {
                    if (dicAlarm["plc报错"] != null)
                    {
                        listAlarm.Remove(dicAlarm["plc报错"]);
                        dicAlarm.Remove("plc报错");
                        plcErro = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                if (!plcErro)
                {
                    foreach (var item in list)
                    {
                        if (item.IsAlarming) //标记为正在报警
                        {
                            listAlarm.Remove(dicAlarm[item.AlarmAddress]);
                            dicAlarm.Remove(item.AlarmAddress);
                            item.IsAlarming = false;
                        }
                    }
                    AlarmInfo alarmPlc = new AlarmInfo(DateTime.Now, "plc通信发生异常");
                    listAlarm.Add(alarmPlc);
                    dicAlarm.Add("plc报错", alarmPlc);
                    plcErro = true;
                    Global.kv.DisConnect();
                }
            }

        }
        /// <summary>
        /// 校对过程报警
        /// </summary>
        /// <param name="address"></param>
        /// <param name="alarm"></param>
        private void ProofAlarm(string address, bool[] alarm)
        {
            try
            {
                ///电流校对环节
                int ngnum = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address);
                if (ngnum != 0)
                {

                    switch (ngnum)
                    {
                        case ProofTest.ngCommunication:
                            if (!alarm[0])
                            {
                                infoCommunication = new AlarmInfo(DateTime.Now, "通讯异常");
                                listAlarm.Add(infoCommunication);
                                alarm[0] = true;
                            }
                            break;
                        case ProofTest.ngCloseSwitch:
                            if (!alarm[1])
                            {
                                infoCloseSwitch = new AlarmInfo(DateTime.Now, "产品合闸失败");
                                listAlarm.Add(infoCloseSwitch);
                                alarm[1] = true;
                            }
                            break;
                        case ProofTest.ngEnterProof:
                            if (!alarm[2])
                            {
                                switch (address)
                                {
                                    case "3602":
                                        infoEnterProof = new AlarmInfo(DateTime.Now, "无法进入电流校对模式");
                                        break;
                                    case "3603":
                                        infoEnterProof = new AlarmInfo(DateTime.Now, "无法进入电压校对模式");
                                        break;
                                    case "3604":
                                        infoEnterProof = new AlarmInfo(DateTime.Now, "无法进入剩余电流校对模式");
                                        break;
                                }
                                listAlarm.Add(infoEnterProof);
                                alarm[2] = true;
                            }

                            break;
                        case ProofTest.ngProofFail:
                            if (!alarm[3])
                            {
                                switch (address)
                                {
                                    case "3602":
                                        infoProofFail = new AlarmInfo(DateTime.Now, "电流校对失败");
                                        break;
                                    case "3603":
                                        infoProofFail = new AlarmInfo(DateTime.Now, "电压校对失败");
                                        break;
                                    case "3604":
                                        infoProofFail = new AlarmInfo(DateTime.Now, "剩余电流校对失败");
                                        break;
                                }
                                listAlarm.Add(infoProofFail);
                                alarm[3] = true;
                            }

                            break;
                        case ProofTest.ngCheckFail:
                            if (!alarm[4])
                            {
                                switch (address)
                                {
                                    case "3602":
                                        infoProofCheck = new AlarmInfo(DateTime.Now, "检测电流校对不合格");
                                        break;
                                    case "3603":
                                        infoProofCheck = new AlarmInfo(DateTime.Now, "检测电压校对不合格");
                                        break;
                                    case "3604":
                                        infoProofCheck = new AlarmInfo(DateTime.Now, "检测剩余电流校对不合格");
                                        break;
                                }
                                listAlarm.Add(infoProofCheck);
                                alarm[4] = true;
                            }

                            break;
                        case ProofTest.ngSwitchState1:
                            if (!alarm[5])
                            {
                                infoSwitchState = new AlarmInfo(DateTime.Now, "物理判断分合闸状态错误");
                                listAlarm.Add(infoSwitchState);
                                alarm[5] = true;
                            }

                            break;
                        case ProofTest.ngPlc:
                            if (!alarm[6])
                            {
                                switch (address)
                                {
                                    case "3602":
                                        infoPLC = new AlarmInfo(DateTime.Now, "电流不能正常输出");
                                        break;
                                    case "3603":
                                        infoPLC = new AlarmInfo(DateTime.Now, "电压调节失败");
                                        break;
                                    case "3604":
                                        infoPLC = new AlarmInfo(DateTime.Now, "剩余电流没有输出");
                                        break;
                                }
                                listAlarm.Add(infoPLC);
                                alarm[6] = true;
                            }

                            break;
                        case ProofTest.ngOpenSwitch:
                            if (!alarm[7])
                            {
                                infoOpenSwitch = new AlarmInfo(DateTime.Now, "产品分闸错误");
                                listAlarm.Add(infoOpenSwitch);
                                alarm[7] = true;
                            }
                            break;
                        case ProofTest.ngSwitchState2:
                            if (!alarm[8])
                            {
                                infoSwitchStateCom= new AlarmInfo(DateTime.Now, "通信判断分合闸状态错误");
                                listAlarm.Add(infoSwitchStateCom);
                                alarm[8] = true;
                            }
                            break;
                        default:
                            break;

                    }
                }
                else
                {
                    if (alarm[0])
                    {
                        listAlarm.Remove(infoCommunication);
                        alarm[0] = false;
                    }
                    if (alarm[1])
                    {
                        listAlarm.Remove(infoCloseSwitch);
                        alarm[1] = false;
                    }
                    if (alarm[2])
                    {
                        listAlarm.Remove(infoEnterProof);
                        alarm[2] = false;
                    }
                    if (alarm[4])
                    {
                        listAlarm.Remove(infoProofCheck);
                        alarm[4] = false;
                    }
                    if (alarm[3])
                    {
                        listAlarm.Remove(infoProofFail);
                        alarm[3] = false;
                    }
                    if (alarm[5])
                    {
                        listAlarm.Remove(infoSwitchState);
                        alarm[5] = false;
                    }
                    if (alarm[6])
                    {
                        listAlarm.Remove(infoPLC);
                        alarm[6] = false;
                    }
                    if (alarm[7])
                    {
                        listAlarm.Remove(infoOpenSwitch);
                        alarm[7] = false;
                    }
                    if (alarm[8])
                    {
                        listAlarm.Remove(infoSwitchStateCom);
                        alarm[8] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
           
        }
        /// <summary>
        /// 按下启动/停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                if (Global.kv.Active)
                {
                    if (!Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, btn.Address, 1))
                    {
                        MessageBox.Show("plc通信异常");
                    }
                }
                else MessageBox.Show("plc断开连接");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        /// <summary>
        /// 松开启动按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                if (Global.kv.Active)
                {
                    if (!Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, btn.Address, 0))
                    {
                        MessageBox.Show("plc通信异常");
                    }

                }
                else MessageBox.Show("plc断开连接");
                if (btn.Text == "启动")
                {
                    if (!Global.workState)
                    {
                        Global.proof.AutoWork = true; ///自动校对状态位  
                        Global.proof.Suyi.ComPort.BaudRate = Global.baudRate;
                        if (!Global.proof.Suyi.ComPort.IsOpen)
                        {
                            Global.proof.Suyi.ComPort.Open();
                        }
                        //Global.thProof.IsBackground = true;
                            Thread thProof = new Thread(Global.proof.AutoTest);
                            thProof.IsBackground = true;
                            thProof.Start();
                        Global.workState = true;
                    }

                    //BGauto.DoWork += Global.proof.AutoTest;
                    //BGauto.RunWorkerAsync();
                }
                else if (btn.Text == "停止")
                {
                    Global.workState = false;
                    Global.proof.AutoWork = false;
                    Global.proof.Suyi.ComPort.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Global.proof.Suyi.ComPort.Close();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Global.proofJudge = 1;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            Global.proofJudge = 2;
        }
    }

}

