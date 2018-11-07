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
using System.Threading;
using System.Windows;

namespace ACA_System_InTest
{
    public partial class FrmAuto : Form
    {
        private delegate void UpdateDisplay(); //显示方法的委托
        System.Threading.Timer Timer; //线程定时器
        ButtonNew[] btnArray = new ButtonNew[6]; //按钮数组
        LabelNew[] lblArray = new LabelNew[2]; //标签数组
        string[] alarmString = new string[29]; //报警信息数组
        string[] stateString = new string[54]; //状态信息数组
        Dictionary<int, string> dicState = new Dictionary<int, string>(); //状态字典
        List<AlarmObject> list;  //报警集合
        string stateAddress = "4601"; //获取状态的地址
        string address1 = "4900"; //获取是否报警的地址1
        string address2 = "4901";//获取是否报警的地址2
        BindingList<AlarmInfo> listAlarm; //存储报警记录的jihe（绑定DGV)
        Dictionary<string, AlarmInfo> dicAlarm = new Dictionary<string, AlarmInfo>();//报警信息字典
        bool plcErro = false;
        int workAlarmd;         //报警标志位
        AlarmInfo infoAlarm;   //报警信息对象
        public FrmAuto()
        {
            InitializeComponent();
            GetConfig();
            ListGet();
        }

        private void FrmAuto_Load(object sender, EventArgs e)
        {
            lblArray[0] = LblCurrentValue;
            lblArray[1] = LblTimeValue;
            btnArray[0] = BtnStart;
            btnArray[1] = BtnStop;
            btnArray[2] = BtnAlarm;
            btnArray[3] = BtnReady;
            btnArray[4] = BtnJigs;
            btnArray[5] = BtnEnd;
            if (!Global.manualJudge)
            {
                BtnOk.Visible = false;
                BtnNo.Visible = false;
                LblManualJudge.Visible = false;
            }
            if (Global.autoLine)
            {
                BtnReady.Visible = false;
                BtnJigs.Visible = false;
                BtnEnd.Visible = false;
            }
            listAlarm = new BindingList<AlarmInfo>();
            DgvAlarm.DataSource = listAlarm;
            Timer = new System.Threading.Timer(UiDisplay, this, 0, 1000);

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Timer.Dispose();
            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.ShowDialog();
        }
        //获取报警信息的list
        private void ListGet()
        {
            list = new List<AlarmObject>()
            {
                new AlarmObject("490000", alarmString[0],false),new AlarmObject("490001", alarmString[1], false),
                new AlarmObject("490002", alarmString[2], false),new AlarmObject("490003", alarmString[3], false),
                new AlarmObject("490004", alarmString[4], false),new AlarmObject("490005", alarmString[5], false),
                new AlarmObject("490006", alarmString[6], false),new AlarmObject("490007", alarmString[7], false),
                new AlarmObject("490008", alarmString[8], false),new AlarmObject("490009", alarmString[9], false),
                new AlarmObject("490010", alarmString[10], false),new AlarmObject("490011", alarmString[11], false),
                new AlarmObject("490012", alarmString[12], false),new AlarmObject("490013", alarmString[13], false),
                new AlarmObject("490014", alarmString[14], false),new AlarmObject("490015", alarmString[15], false),
                new AlarmObject("490100", alarmString[16], false),new AlarmObject("490101", alarmString[17], false),
                new AlarmObject("490102", alarmString[18], false),new AlarmObject("490103", alarmString[19], false),
                new AlarmObject("490104", alarmString[20], false),new AlarmObject("490105", alarmString[21], false),
                new AlarmObject("490106", alarmString[22], false),new AlarmObject("490107", alarmString[23], false),
                new AlarmObject("490108", alarmString[24], false),new AlarmObject("490109", alarmString[25], false),
                new AlarmObject("490110", alarmString[26], false),new AlarmObject("490111", alarmString[27], false),
                new AlarmObject("490112", alarmString[28], false),
            };
        }
        /// <summary>
        /// 从Config获取配置好的报警信息和状态信息
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
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, btn.Address, 1);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 工作过程中报警信息显示（瞬时检测）
        /// </summary>
        private void WorkAlarm()
        {
            try
            {
                int alarmCode = Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "4602");
                if (alarmCode != 0) //处于报警状态
                {
                    switch (alarmCode)
                    {
                        case InstantaneousTest.ngCommunication:
                            if (workAlarmd != 1) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "通讯异常");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 1;
                            }
                            break;
                        case InstantaneousTest.ngCloseSwitch:
                            if (workAlarmd != 2) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "产品不能重合闸");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 2;
                            }
                            break;
                        case InstantaneousTest.ngEnterProof:
                            if (workAlarmd != 3) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "无法进入校对模式");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 3;
                            }
                            break;
                        case InstantaneousTest.ngProofFailB:
                            if (workAlarmd != 4) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "B相校对不合格");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 4;
                            }
                            break;
                        case InstantaneousTest.ngProofFailC:
                            if (workAlarmd != 5) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "C相校对不合格");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 5;
                            }
                            break;
                        case InstantaneousTest.ngProofFailA:
                            if (workAlarmd != 6) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "A相校对不合格");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 6;
                            }
                            break;
                        case InstantaneousTest.ngProofFailLow:
                            if (workAlarmd != 7) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "瞬时低倍检测不合格");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 7;
                            }
                            break;
                        case InstantaneousTest.ngProofFailHigh:
                            if (workAlarmd != 8) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "瞬时高倍检测不合格");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 8;
                            }
                            break;
                        case InstantaneousTest.ngSwitchState:
                            if (workAlarmd != 9) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "产品分合闸信号与实际不符");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 9;
                            }
                            break;
                        case InstantaneousTest.ngPlcError:
                            if (workAlarmd != 10) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "设备故障");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 10;
                            }
                            break;
                        case InstantaneousTest.ngQuitProof:
                            if (workAlarmd != 11) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "退出瞬时校对模式失败");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 11;
                            }
                            break;
                        case InstantaneousTest.ngOpenSwitch:
                            if (workAlarmd!=12) //还没报警
                            {
                                infoAlarm = new AlarmInfo(DateTime.Now, "产品分闸失败");
                                listAlarm.Add(infoAlarm);
                                workAlarmd = 12;
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
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        /// <summary>
        /// 按钮松开事件指向的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonNew btn = (ButtonNew)sender;
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, btn.Address, 0);

                if (btn.Text == "启动")
                {
                    if (!Global.workState)
                    {
                        Global.intest.Suyi.ComPort.BaudRate = Global.baudRate;
                        if (!Global.intest.Suyi.ComPort.IsOpen)
                        {
                            Global.intest.Suyi.ComPort.Open();
                        }
                        Global.intest.AutoWork = true;
                        Thread thIntest = new Thread(Global.intest.AutoInstantaneousTest);
                        thIntest.IsBackground = true;
                        thIntest.Start();

                        Global.workState = true;
                    }
                    //proof.AutoWork = true;
                    //Thread thAuto = new Thread(proof.AutoTest);
                    //thAuto.IsBackground = true;
                    //thAuto.Start();
                }
                else if (btn.Text == "停止")
                {
                    Global.intest.AutoWork = false;
                    Global.workState = false;
                    Global.intest.Suyi.ComPort.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        //private void TmrState_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Global.kv.Active)
        //        {
        //            Display();
        //            StateDisplay();
        //            Alarm();

        //        }
        //        else
        //        {
        //            MessageBox.Show("PLC断开连接，正在重连");
        //            Global.kv.Connect();
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        /// <summary>
        /// 获取当前工作状态
        /// </summary>
        //private void GetState()
        //{
        //      (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM,stateAddress)

        //}

        private void UiDisplay(object state)
        {
            if (InvokeRequired)
            {
                this.Invoke(new UpdateDisplay(() =>
                {
                    ShowDisplay();
                }));
            }
        }
        /// <summary>
        /// 界面显示（状态显示，工作状态显示，设备报警显示，工作报警显示）
        /// </summary>
        private void ShowDisplay()
        {
            StateDisplay();
            Display();
            Alarm();
            WorkAlarm();

        }
        /// <summary>
        /// 状态显示
        /// </summary>
        private void StateDisplay()
        {
            try
            {
                LblStateValue.Text = stateString[(Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, stateAddress))];
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
                //MessageBox.Show(ex.ToString());
                LblStateValue.Text = "erro";
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

                }
                for (int i = 0; i < btnArray.Length; i++)
                {
                    if ((Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_RLY_B, btnArray[i].StateAddress) == 1))
                    {
                        if (btnArray[i].StateAddress == "142112")
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
                switch (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, LblTestPhase.Address))
                {
                    case 1:
                        LblTestPhase.Text = "A相";
                        break;
                    case 2:
                        LblTestPhase.Text = "B相";
                        break;
                    case 3:
                        LblTestPhase.Text = "C相";
                        break;
                    default:
                        break;
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
                if (Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address1) != 0 || Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address2) != 0)
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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Global.insJudge = 1;  //用户确认为合格
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            Global.insJudge = 2; //用户确认为不合格
        }
    }
}
