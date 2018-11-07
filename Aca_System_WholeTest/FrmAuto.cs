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
using ACA_Common;
using System.Configuration;
using System.Threading;

namespace Aca_System_WholeTest
{
    public partial class FrmAuto : Form
    {
        LabelNew[] lblArray = new LabelNew[15]; //标签数组
        string[] alarmString = new string[73];  //报警信息数组
        string[] stateString = new string[55];  //状态信息数组
        ButtonNew[] btnArray = new ButtonNew[7]; //按钮数组
        Dictionary<int, string> dicState = new Dictionary<int, string>(); //状态字典
        List<AlarmObject> list1; //报警信息集合1
        List<AlarmObject> list2;
        List<AlarmObject> list3;
        List<AlarmObject> list4;
        List<AlarmObject> list5;
        string address1 = "5900"; //设备报警信息地址1
        string address2 = "5901";
        string address3 = "5902";
        string address4 = "5903";
        string address5 = "5904";
        string workAlarmAddress1 = "5602"; //整机测试工作报警地址1
        string workAlarmAddress2 = "5604";
        string workAlarmAddress3 = "5606";
        BindingList<AlarmInfo> listAlarm;
        Dictionary<string, AlarmInfo> dicAlarm = new Dictionary<string, AlarmInfo>();//报警字典
        private bool plcErro = false; //plc故障状态位
        private int workAlarmd1 = 0; //用于判断哪一种工作状态报警了
        private int workAlarmd2 = 0; //用于判断哪一种工作状态报警了
        private int workAlarmd3 = 0; //用于判断哪一种工作状态报警了
        AlarmInfo infoAlarm1 = new AlarmInfo(DateTime.Now, "");
        AlarmInfo infoAlarm2 = new AlarmInfo(DateTime.Now, "");
        AlarmInfo infoAlarm3 = new AlarmInfo(DateTime.Now, "");
        public FrmAuto()
        {
            InitializeComponent();
            GetConfig();
            ListGet();
        }

        private void FrmAuto_Load(object sender, EventArgs e)
        {
            lblArray[0] = LblVoltageA1;
            lblArray[1] = LblVoltageB1;
            lblArray[2] = LblVoltageC1;
            lblArray[3] = LblCurrent1;
            lblArray[4] = LblTime1;
            lblArray[5] = LblVoltageA2;
            lblArray[6] = LblVoltageB2;
            lblArray[7] = LblVoltageC2;
            lblArray[8] = LblCurrent2;
            lblArray[9] = LblTime2;
            lblArray[10] = LblVoltageA3;
            lblArray[11] = LblVoltageB3;
            lblArray[12] = LblVoltageC3;
            lblArray[13] = LblCurrent3;
            lblArray[14] = LblTime3;
            btnArray[0] = BtnStart;
            btnArray[1] = BtnStop;
            btnArray[2] = BtnAlarm;
            btnArray[3] = BtnReady;
            btnArray[4] = BtnJigs;
            btnArray[5] = BtnEnd;
            btnArray[6] = BtnMeachineHand;
            LblChecking1.Visible = false;
            LblChecking2.Visible = false;
            LblChecking3.Visible = false;
            BtnOk1.Visible = false;
            BtnNo1.Visible = false;
            BtnOk2.Visible = false;
            BtnNo2.Visible = false;
            BtnOk3.Visible = false;
            BtnNo3.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label9.Visible = false;
            label7.Visible = false;
            label15.Visible = false;
            label13.Visible = false;
            if (Global.autoLine)
            {
                BtnReady.Visible = false;
                BtnJigs.Visible = false;
                BtnEnd.Visible = false;
                BtnMeachineHand.Visible = false;
            }
            listAlarm = new BindingList<AlarmInfo>();
            DgvAlarm.DataSource = listAlarm;
            TmrState.Enabled = true;
        }
        /// <summary>
        /// 按下按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                if (!Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 1))
                {
                    MessageBox.Show("plc通信异常");
                }
                if (btn.Text == "启动")
                {
                    ///只有不是运行状态
                    if (!Global.workState)
                    {
                        Global.wh1.StationAddress = 1; //工位地址
                        Global.wh1.AutoWork = true;
                        Global.wh2.StationAddress = 2;
                        Global.wh2.AutoWork = true;
                        Global.wh3.StationAddress = 3;
                        Global.wh3.AutoWork = true;
                        Global.wh1.SuyiStation1.ComPort.BaudRate = Global.baudRate;
                        Global.wh2.SuyiStation2.ComPort.BaudRate = Global.baudRate;
                        Global.wh3.SuyiStation3.ComPort.BaudRate = Global.baudRate;
                        if (!Global.wh1.SuyiStation1.ComPort.IsOpen) //打开工位1串口
                        {
                            Global.wh1.SuyiStation1.ComPort.Open();
                        }
                        Thread thWh1 = new Thread(Global.wh1.AutoWholeTestStation1);
                        thWh1.IsBackground = true;
                        thWh1.Start();
                        if (!Global.wh2.SuyiStation2.ComPort.IsOpen)//打开工位2串口
                        {
                            Global.wh2.SuyiStation2.ComPort.Open();
                        }
                        Thread thWh2 = new Thread(Global.wh2.AutoWholeTestStation2);
                        thWh2.IsBackground = true;
                        thWh2.Start();

                        if (!Global.wh3.SuyiStation3.ComPort.IsOpen) //打开工位3串口
                        {
                            Global.wh3.SuyiStation3.ComPort.Open();
                        }
                        Thread thWh3 = new Thread(Global.wh3.AutoWholeTestStation3);
                        thWh3.IsBackground = true;
                        thWh3.Start();
                        Global.workState = true;
                    }
                    //else MessageBox.Show("当前已经处于运行状态，请先停止");

                }
                if (btn.Text == "停止")
                {
                    Global.wh1.AutoWork = false;
                    Global.wh2.AutoWork = false;
                    Global.wh3.AutoWork = false;
                    Global.workState = false;
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 松开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                if (!Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btn.Address, 0))
                {
                    MessageBox.Show("plc通信异常");
                }

            }
            catch (Exception ex) 
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void TmrState_Tick(object sender, EventArgs e)
        {
            Display();
            StateDisplay();
            Alarm();
            JudgeResult();
        }
        /// <summary>
        /// 获取存储报警对象的集合
        /// </summary>
        private void ListGet()
        {
            list1 = new List<AlarmObject>()
            {
                new AlarmObject("590000", alarmString[0],false),new AlarmObject("590001", alarmString[1], false),
                new AlarmObject("590002", alarmString[2], false),new AlarmObject("590003", alarmString[3], false),
                new AlarmObject("590004", alarmString[4], false),new AlarmObject("590005", alarmString[5], false),
                new AlarmObject("590006", alarmString[6], false),new AlarmObject("590007", alarmString[7], false),
                new AlarmObject("590008", alarmString[8], false),new AlarmObject("590009", alarmString[9], false),
                new AlarmObject("590010", alarmString[10], false),new AlarmObject("590011", alarmString[11], false),
                new AlarmObject("590012", alarmString[12], false),new AlarmObject("590013", alarmString[13], false),
                new AlarmObject("590014", alarmString[14], false),new AlarmObject("590015", alarmString[15], false),
            };
            list2 = new List<AlarmObject>()
            {
                new AlarmObject("590100", alarmString[16],false),new AlarmObject("590101", alarmString[17], false),
                new AlarmObject("590102", alarmString[18], false),new AlarmObject("590103", alarmString[19], false),
                new AlarmObject("590104", alarmString[20], false),new AlarmObject("590105", alarmString[21], false),
                new AlarmObject("590106", alarmString[22], false),new AlarmObject("590107", alarmString[23], false),
                new AlarmObject("590108", alarmString[24], false),new AlarmObject("590109", alarmString[25], false),
                new AlarmObject("590110", alarmString[26], false),new AlarmObject("590111", alarmString[27], false),
                new AlarmObject("590112", alarmString[28], false),new AlarmObject("590113", alarmString[29], false),
                new AlarmObject("590114", alarmString[30], false),new AlarmObject("590115", alarmString[31], false),
            };
            list3 = new List<AlarmObject>()
            {
                new AlarmObject("590200", alarmString[32],false),new AlarmObject("590201", alarmString[33], false),
                new AlarmObject("590202", alarmString[34], false),new AlarmObject("590203", alarmString[35], false),
                new AlarmObject("590204", alarmString[36], false),new AlarmObject("590205", alarmString[37], false),
                new AlarmObject("590206", alarmString[38], false),new AlarmObject("590207", alarmString[39], false),
                new AlarmObject("590208", alarmString[40], false),new AlarmObject("590209", alarmString[41], false),
                new AlarmObject("590210", alarmString[42], false),new AlarmObject("590211", alarmString[43], false),
                new AlarmObject("590212", alarmString[44], false),new AlarmObject("590213", alarmString[45], false),
                new AlarmObject("590214", alarmString[46], false),new AlarmObject("590215", alarmString[47], false),
            };
            list4 = new List<AlarmObject>()
            {
                new AlarmObject("590300", alarmString[48],false),new AlarmObject("590301", alarmString[49], false),
                new AlarmObject("590302", alarmString[50], false),new AlarmObject("590303", alarmString[51], false),
                new AlarmObject("590304", alarmString[52], false),new AlarmObject("590305", alarmString[53], false),
                new AlarmObject("590306", alarmString[54], false),new AlarmObject("590307", alarmString[55], false),
                new AlarmObject("590308", alarmString[56], false),new AlarmObject("590309", alarmString[57], false),
                new AlarmObject("590310", alarmString[58], false),new AlarmObject("590311", alarmString[59], false),
                new AlarmObject("590312", alarmString[60], false),new AlarmObject("590313", alarmString[61], false),
                new AlarmObject("590314", alarmString[62], false),new AlarmObject("590315", alarmString[63], false),

            };
            list5 = new List<AlarmObject>()
            {
                new AlarmObject("590400", alarmString[64],false),new AlarmObject("590401",  alarmString[65], false),
                new AlarmObject("590402", alarmString[66], false),new AlarmObject("590403", alarmString[67], false),
                new AlarmObject("590404", alarmString[68], false),new AlarmObject("590405", alarmString[69], false),
                new AlarmObject("590406", alarmString[70], false),new AlarmObject("590407", alarmString[71], false),
                new AlarmObject("590408", alarmString[72], false),
            };

        }
        /// <summary>
        /// 动态显示确认按钮（3个工位的整机测试人工确认）
        /// </summary>
        private void JudgeResult()
        {
            try
            {
                if (Global.manualJudge)
                {
                    int cmdcode = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "5601");
                    if (cmdcode == WholeTest.cmdLowVoltageJudge || cmdcode == WholeTest.cmdActionTest1Judge || cmdcode == WholeTest.cmdActionTest2Judge || cmdcode == WholeTest.cmdActionTest3Judge || cmdcode == WholeTest.cmdOverVoltageJudge
                        || cmdcode == WholeTest.cmdUnderVoltageJudge || cmdcode == WholeTest.cmdLosePhaseJudge || cmdcode == WholeTest.cmdZeroPhaseJudge || cmdcode == WholeTest.cmdFinallyJudge)
                    {
                        LblChecking1.Visible = true;
                        label35.Visible = true;
                        label36.Visible = true;
                        BtnOk1.Visible = true;
                        BtnNo1.Visible = true;
                        switch (cmdcode)
                        {
                            case WholeTest.cmdLowVoltageJudge:
                                LblChecking1.Text = "低压合闸检测";
                                break;
                            case WholeTest.cmdActionTest1Judge:
                                LblChecking1.Text = "极限不驱动测试";
                                break;
                            case WholeTest.cmdActionTest2Judge:
                                LblChecking1.Text = "动作值测试";
                                break;
                            case WholeTest.cmdActionTest3Judge:
                                LblChecking1.Text = "动作时间测试";
                                break;
                            case WholeTest.cmdOverVoltageJudge:
                                LblChecking1.Text = "过压测试";
                                break;
                            case WholeTest.cmdUnderVoltageJudge:
                                LblChecking1.Text = "欠压测试";
                                break;
                            case WholeTest.cmdLosePhaseJudge:
                                LblChecking1.Text = "缺相测试";
                                break;
                            case WholeTest.cmdZeroPhaseJudge:
                                LblChecking1.Text = "缺零检测";
                                break;
                            case WholeTest.cmdFinallyJudge:
                                LblChecking1.Text = "整机最终确认";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        LblChecking1.Visible = false;
                        label35.Visible = false;
                        label36.Visible = false;
                        BtnOk1.Visible = false;
                        BtnNo1.Visible = false;
                    }
                    cmdcode = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "5603");
                    if (cmdcode == WholeTest.cmdLowVoltageJudge || cmdcode == WholeTest.cmdActionTest1Judge || cmdcode == WholeTest.cmdActionTest2Judge || cmdcode == WholeTest.cmdActionTest3Judge || cmdcode == WholeTest.cmdOverVoltageJudge
                        || cmdcode == WholeTest.cmdUnderVoltageJudge || cmdcode == WholeTest.cmdLosePhaseJudge || cmdcode == WholeTest.cmdZeroPhaseJudge || cmdcode == WholeTest.cmdFinallyJudge)
                    {
                        LblChecking2.Visible = true;
                        label9.Visible = true;
                        label7.Visible = true;
                        BtnOk2.Visible = true;
                        BtnNo2.Visible = true;
                        switch (cmdcode)
                        {
                            case WholeTest.cmdLowVoltageJudge:
                                LblChecking2.Text = "低压合闸检测";
                                break;
                            case WholeTest.cmdActionTest1Judge:
                                LblChecking2.Text = "极限不驱动测试";
                                break;
                            case WholeTest.cmdActionTest2Judge:
                                LblChecking2.Text = "动作值测试";
                                break;
                            case WholeTest.cmdActionTest3Judge:
                                LblChecking2.Text = "动作时间测试";
                                break;
                            case WholeTest.cmdOverVoltageJudge:
                                LblChecking2.Text = "过压测试";
                                break;
                            case WholeTest.cmdUnderVoltageJudge:
                                LblChecking2.Text = "欠压测试";
                                break;
                            case WholeTest.cmdLosePhaseJudge:
                                LblChecking2.Text = "缺相测试";
                                break;
                            case WholeTest.cmdZeroPhaseJudge:
                                LblChecking2.Text = "缺零检测";
                                break;
                            case WholeTest.cmdFinallyJudge:
                                LblChecking2.Text = "整机最终确认";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        LblChecking2.Visible = false;
                        label9.Visible = false;
                        label7.Visible = false;
                        BtnOk2.Visible = false;
                        BtnNo2.Visible = false;
                    }
                    cmdcode = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "5605");
                    if (cmdcode == WholeTest.cmdLowVoltageJudge || cmdcode == WholeTest.cmdActionTest1Judge || cmdcode == WholeTest.cmdActionTest2Judge || cmdcode == WholeTest.cmdActionTest3Judge || cmdcode == WholeTest.cmdOverVoltageJudge
                        || cmdcode == WholeTest.cmdUnderVoltageJudge || cmdcode == WholeTest.cmdLosePhaseJudge || cmdcode == WholeTest.cmdZeroPhaseJudge || cmdcode == WholeTest.cmdFinallyJudge)
                    {
                        LblChecking3.Visible = true;
                        label15.Visible = true;
                        label13.Visible = true;
                        BtnOk3.Visible = true;
                        BtnNo3.Visible = true;
                        switch (cmdcode)
                        {
                            case WholeTest.cmdLowVoltageJudge:
                                LblChecking3.Text = "低压合闸检测";
                                break;
                            case WholeTest.cmdActionTest1Judge:
                                LblChecking3.Text = "极限不驱动测试";
                                break;
                            case WholeTest.cmdActionTest2Judge:
                                LblChecking3.Text = "动作值测试";
                                break;
                            case WholeTest.cmdActionTest3Judge:
                                LblChecking3.Text = "动作时间测试";
                                break;
                            case WholeTest.cmdOverVoltageJudge:
                                LblChecking3.Text = "过压测试";
                                break;
                            case WholeTest.cmdUnderVoltageJudge:
                                LblChecking3.Text = "欠压测试";
                                break;
                            case WholeTest.cmdLosePhaseJudge:
                                LblChecking3.Text = "缺相测试";
                                break;
                            case WholeTest.cmdZeroPhaseJudge:
                                LblChecking3.Text = "缺零检测";
                                break;
                            case WholeTest.cmdFinallyJudge:
                                LblChecking3.Text = "整机最终确认";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        LblChecking3.Visible = false;
                        label15.Visible = false;
                        label13.Visible = false;
                        BtnOk3.Visible = false;
                        BtnNo3.Visible = false;
                    }
                }
                else
                {
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "5601") == WholeTest.cmdFinallyJudge)
                    {
                        LblChecking1.Visible = true;
                        label35.Visible = true;
                        label36.Visible = true;
                        BtnOk1.Visible = true;
                        BtnNo1.Visible = true;
                        LblChecking1.Text = "等待人工最终确认";

                    }
                    else
                    {
                        LblChecking1.Visible = false;
                        label35.Visible = false;
                        label36.Visible = false;
                        BtnOk1.Visible = false;
                        BtnNo1.Visible = false;
                    }
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "5603") == WholeTest.cmdFinallyJudge)
                    {
                        LblChecking2.Visible = true;
                        label9.Visible = true;
                        label7.Visible = true;
                        BtnOk2.Visible = true;
                        BtnNo2.Visible = true;
                        LblChecking2.Text = "等待人工最终确认";

                    }
                    else
                    {
                        LblChecking2.Visible = false;
                        label9.Visible = false;
                        label7.Visible = false;
                        BtnOk2.Visible = false;
                        BtnNo2.Visible = false;
                    }
                    if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "5605") == WholeTest.cmdFinallyJudge)
                    {
                        LblChecking3.Visible = true;
                        label15.Visible = true;
                        label15.Visible = true;
                        BtnOk3.Visible = true;
                        BtnNo3.Visible = true;
                        LblChecking3.Text = "等待人工最终确认";

                    }
                    else
                    {
                        LblChecking3.Visible = false;
                        label15.Visible = false;
                        label15.Visible = false;
                        BtnOk3.Visible = false;
                        BtnNo3.Visible = false;
                    }
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
            int state1, state2, state3;
            try
            {

                state1 = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, LblState1.Address);
                state2 = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, LblState2.Address);
                state3 = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, LblState3.Address);
                LblState1.Text = stateString[state1];
                LblState2.Text = stateString[state2];
                LblState3.Text = stateString[state3];
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
                LblState1.Text = "erro";
                LblState2.Text = "erro";
                LblState3.Text = "erro";
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
                        if (btnArray[i].StateAddress == "162112")
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
        /// 获取报警信息
        /// </summary>
        /// <param name="address">获取报警地址</param>
        /// <param name="list">报警信息存取集合 </param>
        private void GetAlarmInfo(string address, List<AlarmObject> list)
        {
            if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address) != 0)
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
                        if (item.IsAlarming) //标记为正在报警(需要解除报警)
                        {
                            listAlarm.Remove(dicAlarm[item.AlarmAddress]);
                            dicAlarm.Remove(item.AlarmAddress);
                            item.IsAlarming = false;
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.IsAlarming)
                    {
                        listAlarm.Remove(dicAlarm[item.AlarmAddress]);
                        dicAlarm.Remove(item.AlarmAddress);
                        item.IsAlarming = false;
                    }
                }
            }
        }
        /// <summary>
        /// 显示3工位整机测试时的报警信息
        /// </summary>
        /// <param name="address">获取报警信息的寄存器地址</param>
        /// <param name="workAlarmd">是否报警状态位</param>
        /// <param name="infoAlarm">报警信息对象</param>
        /// <param name="station">工位地址</param>
        private void WorkAlarm(string address, ref int workAlarmd, ref AlarmInfo infoAlarm, int station)
        {

            int alarmCode = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address);
            if (alarmCode != 0) //处于报警状态
            {
                switch (alarmCode)
                {
                    case WholeTest.ngCommunication:
                        if (workAlarmd != 1) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "通讯异常");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 1;
                        }
                        break;
                    case WholeTest.ngRecoveryFactory:
                        if (workAlarmd != 2) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "恢复出厂参数设置不合格");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 2;
                        }
                        break;
                    case WholeTest.ngLowVoltage:
                        if (workAlarmd != 4) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "低压检测不合格");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 4;
                        }
                        break;
                    case WholeTest.ngCloseSwitch:
                        if (workAlarmd != 3) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "产品合闸失败");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 3;
                        }
                        break;
                    case WholeTest.ngActionTest1:
                        if (workAlarmd != 5) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "极限不驱动测试不合格");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 5;
                        }
                        break;
                    case WholeTest.ngActionTest2:
                        if (workAlarmd != 6) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "动作值测试不合格");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 6;
                        }
                        break;
                    case WholeTest.ngActionTest3:
                        if (workAlarmd != 7) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "动作时间测试不合格");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 7;
                        }
                        break;
                    case WholeTest.ngOverVoltage:
                        if (workAlarmd != 8) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "过压检测未脱扣");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 8;
                        }
                        break;
                    case WholeTest.ngOverVoltageReason:
                        if (workAlarmd != 9) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "过压检测跳闸原因不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 9;
                        }
                        break;
                    case WholeTest.ngOverVoltagePhase:
                        if (workAlarmd != 10) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "过压检测跳闸相位不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 10;
                        }
                        break;
                    case WholeTest.ngOverVoltageValue:
                        if (workAlarmd != 11) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "过压检测跳闸电压不在误差范围内");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 11;
                        }
                        break;
                    case WholeTest.ngUnderVoltage:
                        if (workAlarmd != 12) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "欠压检测不未脱扣");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 12;
                        }
                        break;
                    case WholeTest.ngUnderVoltageReason:
                        if (workAlarmd != 13) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "欠压检测跳闸原因不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 13;
                        }
                        break;
                    case WholeTest.ngUnderVoltagePhase:
                        if (workAlarmd != 14) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "欠压检测跳闸相位不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 14;
                        }
                        break;
                    case WholeTest.ngUnderVoltageValue:
                        if (workAlarmd != 15) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "欠压检测跳闸电压不在误差范围内");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 15;
                        }
                        break;
                    case WholeTest.ngLosePhase:
                        if (workAlarmd != 16) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "缺相检测未脱扣");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 16;
                        }
                        break;
                    case WholeTest.ngLosePhaseReason:
                        if (workAlarmd != 17) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "缺相检测跳闸原因不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 17;
                        }
                        break;
                    case WholeTest.ngLosePhaseValue:
                        if (workAlarmd != 18) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "缺相跳闸所缺相不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 18;
                        }
                        break;
                    case WholeTest.ngZeroPhase:
                        if (workAlarmd != 19) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "缺零相检测未脱扣");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 19;
                        }
                        break;
                    case WholeTest.ngZeroPhaseReason:
                        if (workAlarmd != 20) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "缺零检测跳闸原因不匹配");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 20;
                        }
                        break;
                    case WholeTest.ngSwitchState:
                        if (workAlarmd != 21) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "产品分闸信号与实际不符");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 21;
                        }
                        break;
                    case WholeTest.ngClearTestRecord:
                        if (workAlarmd != 22) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "清除测试记录失败");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 22;
                        }
                        break;
                    case WholeTest.ngOpenSwitch:
                        if (workAlarmd != 23) //还没报警
                        {
                            infoAlarm = new AlarmInfo(DateTime.Now, "工位" + station.ToString() + "产品分闸失败");
                            listAlarm.Add(infoAlarm);
                            workAlarmd = 23;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                listAlarm.Remove(infoAlarm);
                workAlarmd = 0;
            }
        }
        /// <summary>
        /// 显示报警信息
        /// </summary>
        private void Alarm()
        {
            try
            {
                ////list1报警
                GetAlarmInfo(address1, list1);
                ////list2报警
                GetAlarmInfo(address2, list2);
                ////list3报警
                GetAlarmInfo(address3, list3);
                ////list4报警
                GetAlarmInfo(address4, list4);
                ///list5报警
                GetAlarmInfo(address5, list5);
                ///工位1报警
                WorkAlarm(workAlarmAddress1, ref workAlarmd1, ref infoAlarm1, 1);
                ///工位2报警
                WorkAlarm(workAlarmAddress2, ref workAlarmd2, ref infoAlarm2, 2);
                ///工位3报警
                WorkAlarm(workAlarmAddress3, ref workAlarmd3, ref infoAlarm3, 3);
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
                    listAlarm.Clear();
                    AlarmInfo alarmPlc = new AlarmInfo(DateTime.Now, "plc通信发生异常");
                    listAlarm.Add(alarmPlc);
                    dicAlarm.Add("plc报错", alarmPlc);
                    plcErro = true;
                    Global.kv.DisConnect();
                }
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            TmrState.Enabled = false;
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        /// <summary>
        /// 获取工作状态信息
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnOk1_Click(object sender, EventArgs e)
        {
            Global.stationJudge1 = 1;
        }

        private void BtnNo1_Click(object sender, EventArgs e)
        {
            Global.stationJudge1 = 2;
        }

        private void BtnOk2_Click(object sender, EventArgs e)
        {
            Global.stationJudge2 = 1;
        }

        private void BtnNo2_Click(object sender, EventArgs e)
        {
            Global.stationJudge2 = 2;
        }

        private void BtnOk3_Click(object sender, EventArgs e)
        {
            Global.stationJudge3 = 1;
        }

        private void BtnNo3_Click(object sender, EventArgs e)
        {
            Global.stationJudge3 = 2;
        }
    }
}
