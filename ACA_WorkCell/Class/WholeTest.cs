/*
 *  整机测试自动流程代码
 * cmd为控制码/
 * ng为异常码
 * *********************************************************************************************************
 * 正常工作流程（整机部分各种环节测试） 2018/06/01
 * 添加分合闸状态判断（原本由通信读取产品分合闸状态，现加入物理（输出形式）判断）2018/06/03
 * 添加用户功能选择（所有流程由用户决定是否做，如不勾选即不做，纯属是搞事，还不想做就不做） 2018/06/03
 * 添加校对人工判断（选择人工判断，需要等待人工确认进行下一步，用户就是做一个让他点一下） 2018/07/05
 * 添加最终人工判断(整机测试完成之后，必须有这个人工判断，可能这样傻逼客户才会放心）2018/07/08
 * 添加跳闸（动作时间，动作值，过压，欠压，缺相，缺零）记录分析，来判断各测试环节是否正确（记录跳闸原因，跳闸相位以及三相电压，依据实际跳闸原因和跳闸相位和通信获取的跳闸原因和相位比对来判定检测是否合格，我不知道想什么，能通信了不起，什么都加上）
 * 添加机械寿命（分分合合）
 * ************************************************************************************************************
 * 该自动测试流程由上位机和plc共同完成，上位机负责与产品通信，记录产品数据，逻辑控制流程（cmd指令） 以及异常报错(ng指令）
 * plc负责输出以及输出完毕的状态回馈 以及异常报错（电气部分）
 * 记录的方式时存入plc的寄存器中
 * *******************************************written by qiupeng *********************************************
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACA_BreakCommunication;
using System.Threading;

namespace ACA_Common.Class
{
    /// <summary>
    /// 整机测试工作类
    /// </summary>
    public class WholeTest //整机测试单元
    {
        private int stationAddress;   //工位地址
        private bool autoWork;
        private SuyiMCCB suyiStation1 = new SuyiMCCB()  //工位1（这个是三个工位的串口，自己傻逼写死了，以后串口不能用了要改这里源代码，懒得改了）
        {
            ComPort = new System.IO.Ports.SerialPort()
            {
                PortName = "COM4",
                BaudRate = 9600,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.One,
                Parity = System.IO.Ports.Parity.Even,
                ReadTimeout = 800,  //这两个属性很重要，信我
                WriteTimeout = 100,
            }
        };
        private SuyiMCCB suyiStation2 = new SuyiMCCB() //工位2
        {
            ComPort = new System.IO.Ports.SerialPort()
            {
                PortName = "COM2",
                BaudRate = 9600,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.One,
                Parity = System.IO.Ports.Parity.Even,
                ReadTimeout = 800,
                WriteTimeout = 100,
            }
        };
        private SuyiMCCB suyiStation3 = new SuyiMCCB() //工位3 
        {
            ComPort = new System.IO.Ports.SerialPort()
            {
                PortName = "COM3",
                BaudRate = 9600,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.One,
                Parity = System.IO.Ports.Parity.Even,
                ReadTimeout = 800,
                WriteTimeout = 100,
            }
        };
        private int meachineNum;  //
        private bool closeSwitch = false;  //分合闸状态
        private bool openSwitch = false;
        private const int overVoltageCloseSwitch = 9;  //过压跳闸对应号（不需要改，谁改谁傻逼）
        private const int losePhaseCloseSwitch = 7;    //缺相跳闸对应号
        private const int loseZeroCloseSwitch = 4;     //缺相跳闸对应号
        private const int underVoltageCloseSwitch = 8; //欠压跳闸对应号
        private const int phaseA = 1;  //相位A
        private const int phaseB = 2;  //相位B
        private const int phaseC = 4;  //相位C，只有老天能够解释为什么不是3
        private const int auto = 1;
        private const int semiAuto = 2;
        private const int stop = 3;
        ///// <summary>
        ///// 下面是控制码，控制测试流程 ，一一对应关系 ，自己看控制流程表就懂了
        ///// </summary>
        public const int cmdWholeTestStart = 1;
        public const int cmdCommunicationTest = 2;
        public const int cmdRecoveryFactorySet = 3;
        public const int cmdReadSwitch = 4;
        public const int cmdJudgeSwitchState = 5;  //PLC判定状态
        public const int cmdLowVoltage = 6;
        public const int cmdLowVoltageJudge = 9;
        public const int cmdCloseSwitch5 = 7;
        public const int cmdJudgeSwitchState5 = 8;
        public const int cmdJudgeSwitchStateOk5 = 10;
        public const int cmdActionTest1 = 11;
        public const int cmdActionTest1Judge = 12;
        public const int cmdActionTest1Ok = 13;
        public const int cmdActionTest2 = 14;
        public const int cmdActionTest2Judge = 15;
        public const int cmdCloseSwitch1 = 16;
        public const int cmdJudgeSwitchState1 = 17;
        public const int cmdJudgeSwitchStateOk1 = 18;
        public const int cmdActionTest3 = 19;
        public const int cmdActionTest3Judge = 20;
        public const int cmdCloseSwitch2 = 21;
        public const int cmdJudgeSwitchState2 = 22;
        public const int cmdJudgeSwitchStateOk2 = 23;
        public const int cmdOverVoltage = 24;
        public const int cmdOverVoltageJudge = 25;
        public const int cmdCloseSwitch3 = 26;
        public const int cmdJudgeSwitchState3 = 27;
        public const int cmdJudgeSwitchStateOk3 = 28;
        public const int cmdUnderVoltage = 29;
        public const int cmdUnderVoltageJudge = 30;
        public const int cmdCloseSwitch4 = 31;
        public const int cmdJudgeSwitchState4 = 32;
        public const int cmdJudgeSwitchStateOk4 = 33;
        public const int cmdLosePhase = 34;
        public const int cmdLosePhaseJudge = 35;
        public const int cmdCloseSwitch6 = 36;
        public const int cmdJudgeSwitchState6 = 37;
        public const int cmdJudgeSwitchStateOk6 = 38;
        public const int cmdZeroPhase = 39;
        public const int cmdZeroPhaseJudge = 40;
        //public const int cmdZeroPhaseRecord = 41;
        public const int cmdCloseSwitch7 = 41;
        public const int cmdJudgeSwitchState7 = 42;
        public const int cmdClearTest = 43;
        public const int cmdWholeTestEnd = 44;
        public const int cmdFinallyJudge = 45;
        public const int cmdOpenSwitch = 50;
        public const int cmdJudgeSwitch = 51;
        public const int cmdCloseSwtich = 52;
        public const int cmdJudgeSwitch1 = 53;
        public const int cmdJudgeEnd = 54;
        ///// <summary>
        ///// / 测试过程中的报错，对应各种报错情况，怎么对应自己悟，全靠悟性
        ///// </summary>
        public const int ngReset = 0;
        public const int ngCommunication = 1;
        public const int ngRecoveryFactory = 2;
        public const int ngCloseSwitch = 3;
        public const int ngLowVoltage = 4;
        public const int ngActionTest1 = 5;
        public const int ngActionTest2 = 6;
        public const int ngActionTest3 = 7;
        public const int ngOverVoltage = 8;
        public const int ngOverVoltageReason = 9;
        public const int ngOverVoltagePhase = 10;
        public const int ngOverVoltageValue = 11;
        public const int ngUnderVoltage = 12;
        public const int ngUnderVoltageReason = 13;
        public const int ngUnderVoltagePhase = 14;
        public const int ngUnderVoltageValue = 15;
        public const int ngLosePhase = 16;
        public const int ngLosePhaseReason = 17;
        public const int ngLosePhaseValue = 18;
        public const int ngZeroPhase = 19;
        public const int ngZeroPhaseReason = 20;
        public const int ngSwitchState = 21;
        public const int ngClearTestRecord = 22;
        public const int ngOpenSwitch = 23;
        public const int ngManualJudge = 24;
        public bool AutoWork
        {
            get
            {
                return autoWork;
            }

            set
            {
                autoWork = value;
            }
        }

        public int StationAddress
        {
            get
            {
                return stationAddress;
            }

            set
            {
                stationAddress = value;
            }
        }





        public SuyiMCCB SuyiStation2
        {
            get
            {
                return suyiStation2;
            }

            set
            {
                suyiStation2 = value;
            }
        }

        public SuyiMCCB SuyiStation1
        {
            get
            {
                return suyiStation1;
            }

            set
            {
                suyiStation1 = value;
            }
        }

        public SuyiMCCB SuyiStation3
        {
            get
            {
                return suyiStation3;
            }

            set
            {
                suyiStation3 = value;
            }
        }

        public WholeTest()
        {

        }

        //public SuyiMCCB Suyi { get{} suyi; set{} suyi = value; }

        public void AutoWholeTestStation1() //自动整机测试
        {

            while (autoWork)
            {
                Thread.Sleep(50);
                int cmdId = GetCmdCode();
                switch (cmdId)
                {
                    case cmdWholeTestStart:
                        break;
                    case cmdCommunicationTest:
                        if (suyiStation1.CommunicationTest()) //通信测试环节（命令代码由苏益给出)
                        {
                            SetCmdCode(1, cmdRecoveryFactorySet);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdRecoveryFactorySet:
                        //发送恢复出场设置指令
                        if (suyiStation1.RecoveryFactorySet())
                        {
                            SetCmdCode(1, cmdReadSwitch);
                        }
                        else SetResult(ngRecoveryFactory);
                        break;
                    case cmdReadSwitch:
                        //通讯判断合闸
                        if (suyiStation1.ReadSwitchState() == 2)  //是分闸状态
                        {
                            SetCmdCode(1, cmdJudgeSwitchState);
                        }
                        else SetResult(ngSwitchState);

                        break;
                    case cmdJudgeSwitchState:
                        //plc 判断开合闸状态
                        break;
                    case cmdLowVoltage:
                        break;
                    case cmdCloseSwitch5:
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState5);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState5:
                        //plc 物理判断分合闸状态
                        break;

                    case cmdLowVoltageJudge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge1 == 1) //用户确认为合格
                            {
                                SetCmdCode(1, cmdJudgeSwitchStateOk5);
                                Global.stationJudge1 = 0;
                            }
                            else if (Global.stationJudge1 == 2)//用户确认为不合格
                            {
                                SetResult(ngLowVoltage);
                                Global.stationJudge1 = 0;
                            }
                        }
                        else SetCmdCode(1, cmdJudgeSwitchStateOk5);
                        break;
                    case cmdJudgeSwitchStateOk5:
                        //为合闸状态，根据设置判断为进行那一步测试
                        if (Global.doActionTest1)
                        {
                            SetCmdCode(1, cmdActionTest1);
                        }
                        else if (Global.doActionTest2)
                        {
                            SetCmdCode(1, cmdActionTest2);
                        }
                        else if (Global.doActionTest3)
                        {
                            SetCmdCode(1, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(1, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(1, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(1, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        else SetCmdCode(1, cmdClearTest);
                        break;
                    case cmdActionTest1: //极限不驱动测试
                                         ///plc进行极限不驱动测试
                                         ///
                        break;
                    case cmdActionTest1Judge://等待上位机确认是否合格
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge1 == 1) //用户确认为合格
                            {
                                SetCmdCode(1, cmdActionTest1Ok);
                                Global.stationJudge1 = 0;
                            }
                            else if (Global.stationJudge1 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest1);
                                Global.stationJudge1 = 0;
                            }
                        }
                        else SetCmdCode(1, cmdActionTest1Ok);
                        break;
                    case cmdActionTest1Ok:
                        ///测试1完成，下一步进行操作
                        if (Global.doActionTest2)
                        {
                            SetCmdCode(1, cmdActionTest2);
                        }
                        else if (Global.doActionTest3)
                        {
                            SetCmdCode(1, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(1, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(1, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(1, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        else SetCmdCode(1, cmdClearTest);
                        break;
                    case cmdActionTest2:
                        //进行慢启动测试
                        break;
                    case cmdActionTest2Judge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge1 == 1) //用户确认为合格
                            {
                                SetCmdCode(1, cmdCloseSwitch1);
                                Global.stationJudge1 = 0;
                            }
                            else if (Global.stationJudge1 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest2);
                                Global.stationJudge1 = 0;
                            }
                        }
                        else SetCmdCode(1, cmdCloseSwitch1);
                        break;
                    case cmdCloseSwitch1:
                        //通信合闸
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState1);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState1:
                        //plc判断合闸
                        break;
                    case cmdJudgeSwitchStateOk1:
                        if (Global.doActionTest3)
                        {
                            SetCmdCode(1, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(1, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(1, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(1, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        else SetCmdCode(1, cmdClearTest);
                        break;
                    case cmdActionTest3: //漏电流动作事件测试
                                         /////plc进行测试2（漏电流动作事件测试）
                        break;
                    case cmdActionTest3Judge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge1 == 1) //用户确认为合格
                            {
                                SetCmdCode(1, cmdCloseSwitch2);
                                Global.stationJudge1 = 0;
                            }
                            else if (Global.stationJudge1 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest3);
                                Global.stationJudge1 = 0;
                            }
                        }
                        else SetCmdCode(1, cmdCloseSwitch2);
                        break;
                    case cmdCloseSwitch2:
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState2);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState2: //需要上位机和plc都进行合闸判断
                        break;                      //Thread.Sleep(Global.wholeTestCloseSwitchTime);
                    case cmdJudgeSwitchStateOk2:
                        if (Global.doOverVoltage)
                        {
                            SetCmdCode(1, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(1, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(1, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        else SetCmdCode(1, cmdClearTest);
                        break;
                    case cmdOverVoltage:
                        //plc做过压测试
                        break;
                    case cmdOverVoltageJudge:
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        bool JudgeResult = false;
                        double[] protectData = suyiStation1.GetSwitchProtect();
                        ////记录数据，当然估计他们也不用
                        WriteMemoryDM(((int)(MemoryAddress1.OverVoltageReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress1.OverVoltagePhase)).ToString(), protectData[1]);
                        WriteMemory(((int)(MemoryAddress1.OverVoltageValueA)).ToString(), protectData[2]);
                        WriteMemory(((int)(MemoryAddress1.OverVoltageValueB)).ToString(), protectData[3]);
                        WriteMemory(((int)(MemoryAddress1.OverVoltageValueC)).ToString(), protectData[4]);
                        if (protectData[0] == overVoltageCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress1.OverVoltagePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                ////判断误差范围，有啥用？
                                switch ((int)protectData[1])
                                {
                                    case phaseA:
                                        if (protectData[2] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[2] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseB:
                                        if (protectData[3] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[3] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;

                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseC:
                                        if (protectData[4] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[4] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                }
                            }
                            else SetResult(ngOverVoltagePhase);
                        }
                        else SetResult(ngOverVoltageReason);
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge1 == 1) //用户确认为合格
                                {
                                    SetCmdCode(1, cmdCloseSwitch3);
                                    Global.stationJudge1 = 0;
                                }
                                else if (Global.stationJudge1 == 2)//用户确认为不合格
                                {
                                    SetResult(ngOverVoltage);
                                    Global.stationJudge1 = 0;
                                }
                            }
                            else SetCmdCode(1, cmdCloseSwitch3);
                        }
                        break;
                    case cmdCloseSwitch3:
                        //合闸呗
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState3);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState3:
                        //plc判断分合闸状态
                        break;
                    case cmdJudgeSwitchStateOk3:
                        //自己再判断一下呗
                        if (Global.dounderVoltage)
                        {
                            SetCmdCode(1, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(1, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        else SetCmdCode(1, cmdClearTest);
                        break;
                    case cmdUnderVoltage:
                        //欠压测试
                        break;
                    case cmdUnderVoltageJudge:
                        ///// 1.先通讯判断是否合格
                        ///// 2.人工按钮判断是否合格
                        ///// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation1.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress1.UnderVoltageReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress1.UnderVoltagePhase)).ToString(), protectData[1]);
                        WriteMemory(((int)(MemoryAddress1.UnderVoltageValueA)).ToString(), protectData[2]);
                        WriteMemory(((int)(MemoryAddress1.UnderVoltageValueB)).ToString(), protectData[3]);
                        WriteMemory(((int)(MemoryAddress1.UnderVoltageValueC)).ToString(), protectData[4]);
                        if (protectData[0] == underVoltageCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress1.UnderVoltagePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                switch ((int)protectData[1])
                                {
                                    case phaseA:
                                        if (protectData[2] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[2] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseB:
                                        if (protectData[3] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[3] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;

                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseC:
                                        if (protectData[4] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[4] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                }
                            }
                            else SetResult(ngUnderVoltagePhase);
                        }
                        else SetResult(ngUnderVoltageReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge1 == 1) //用户确认为合格
                                {
                                    SetCmdCode(1, cmdCloseSwitch4);
                                    Global.stationJudge1 = 0;
                                }
                                else if (Global.stationJudge1 == 2)//用户确认为不合格
                                {
                                    SetResult(ngUnderVoltage);
                                    Global.stationJudge1 = 0;
                                }
                            }
                            else SetCmdCode(1, cmdCloseSwitch4);
                        }
                        break;
                    case cmdCloseSwitch4:
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState4);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState4: // plc 物理判断分合闸
                        break;
                    //case cmdOpenSwitch:
                    case cmdJudgeSwitchStateOk4:
                        //判断是否为合格
                        //若合格进行下一步
                        if (Global.doLosePhase)
                        {
                            SetCmdCode(1, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        else SetCmdCode(1, cmdClearTest);
                        break;
                    case cmdLosePhase:
                        //plc进行缺相检测
                        break;
                    case cmdLosePhaseJudge:

                        //判断是否为合格
                        //若合格进行下一步
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation1.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress1.LosePhaseReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress1.LosePhase)).ToString(), protectData[1]);
                        if (protectData[0] == losePhaseCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress1.LosePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                JudgeResult = true;
                            }
                            else SetResult(ngLosePhaseValue);
                        }
                        else SetResult(ngLosePhaseReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge1 == 1) //用户确认为合格
                                {
                                    SetCmdCode(1, cmdCloseSwitch6);
                                    Global.stationJudge1 = 0;
                                }
                                else if (Global.stationJudge1 == 2)//用户确认为不合格
                                {
                                    SetResult(ngLosePhase);
                                    Global.stationJudge1 = 0;
                                }
                            }
                            else SetCmdCode(1, cmdCloseSwitch6);
                        }
                        break;
                    case cmdCloseSwitch6:
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState6);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState6:
                        //plc 判断分合闸状态
                        break;
                    case cmdJudgeSwitchStateOk6:
                        if (Global.doZeroPhase)
                        {
                            SetCmdCode(1, cmdZeroPhase);
                        }
                        break;
                    case cmdZeroPhase:
                        //进行缺零检测
                        break;
                    case cmdZeroPhaseJudge:
                        //判断是否为合格
                        //若合格进行下一步
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation1.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress1.ZeroPhaseReason)).ToString(), protectData[0]);
                        if (protectData[0] == loseZeroCloseSwitch) //跳闸原因匹配
                        {
                            JudgeResult = true;
                        }
                        else SetResult(ngZeroPhaseReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge1 == 1) //用户确认为合格
                                {
                                    SetCmdCode(1, cmdClearTest);
                                    Global.stationJudge1 = 0;
                                }
                                else if (Global.stationJudge1 == 2)//用户确认为不合格
                                {
                                    SetResult(ngZeroPhase);
                                    Global.stationJudge1 = 0;
                                }
                            }
                            else SetCmdCode(1, cmdClearTest);
                        }
                        break;
                    //case cmdZeroPhaseRecord:
                    //    int zeroPhaseValue = suyiStation1.OpenSwitchRecord();
                    //    WriteMemory(MemoryAddress.LosePhaseValue, zeroPhaseValue);
                    //    SetCmdCode(1,cmdCloseSwitch6);
                    //    break;
                    case cmdCloseSwitch7:
                        if (suyiStation1.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation1.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitchState7);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState7:
                        break;
                    case cmdClearTest:
                        if (suyiStation1.ClearTestRecord())
                        {
                            Thread.Sleep(1000);
                            if (Global.finallyJudge)  //如果选择最终人工判断
                            {
                                SetCmdCode(1, cmdFinallyJudge);
                            }
                            else
                            {
                                if (Global.meachineAge)
                                {
                                    meachineNum = Global.meachineTestNum;
                                    if (meachineNum > 0)
                                    {
                                        SetCmdCode(1, cmdOpenSwitch);
                                    }
                                    else SetCmdCode(1, cmdWholeTestEnd);

                                }
                                else SetCmdCode(1, cmdWholeTestEnd);
                            }

                        }
                        else SetResult(ngClearTestRecord);
                        break;
                    case cmdFinallyJudge:

                        if (Global.stationJudge1 == 1) //用户确认为合格
                        {
                            if (Global.meachineAge)
                            {
                                meachineNum = Global.meachineTestNum;
                                if (meachineNum > 0)
                                {
                                    SetCmdCode(1, cmdOpenSwitch);
                                }
                                else SetCmdCode(1, cmdWholeTestEnd);

                            }
                            else SetCmdCode(1, cmdWholeTestEnd);
                            Global.stationJudge1 = 0;
                        }
                        else if (Global.stationJudge1 == 2)//用户确认为不合格
                        {
                            SetResult(ngManualJudge);
                            Global.stationJudge1 = 0;
                        }
                        break;
                    case cmdOpenSwitch:
                        //看名字你也应该知道是分闸吧
                        if (suyiStation1.OpenSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {

                                if (suyiStation1.ReadSwitchState() == 2)
                                {
                                    openSwitch = true;
                                    break;
                                }
                                else openSwitch = false;
                            }
                            if (openSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitch);
                            }
                            else SetResult(ngOpenSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitch:

                        break;
                    case cmdCloseSwtich:
                        //看名字也应该知道是？？？
                        if (suyiStation1.CloseSwitch())
                        {

                            for (int i = 0; i < 65; i++)
                            {

                                if (suyiStation1.ReadSwitchState() == 1)
                                {
                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;
                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(1, cmdJudgeSwitch1);
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        break;
                    case cmdJudgeSwitch1:
                        break;
                    case cmdJudgeEnd:
                        meachineNum--;
                        if (meachineNum > 0)
                        {
                            SetCmdCode(1, cmdOpenSwitch);
                        }
                        else SetCmdCode(1, cmdWholeTestEnd);
                        break;
                    case cmdWholeTestEnd:  //整机测试一个流程完成

                        break;


                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 为什么要写成三个工位三个方法，有可能是因为存储地址和控制，异常地址都不一样，所以我写了三个方法，懒得传参来做，参数太多
        /// </summary>
        public void AutoWholeTestStation2() //自动整机station 2测试
        {

            while (autoWork)
            {
                Thread.Sleep(50);
                int cmdId = GetCmdCode();
                switch (cmdId)
                {
                    case cmdWholeTestStart:
                        break;
                    case cmdCommunicationTest:
                        if (suyiStation2.CommunicationTest()) //通信测试环节（命令代码由苏益给出)
                        {
                            SetCmdCode(2, cmdRecoveryFactorySet);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdRecoveryFactorySet:
                        //发送恢复出场设置指令
                        if (suyiStation2.RecoveryFactorySet())
                        {
                            SetCmdCode(2, cmdReadSwitch);
                        }
                        else SetResult(ngRecoveryFactory);
                        break;
                    case cmdReadSwitch:
                        //通讯判断合闸
                        if (suyiStation2.ReadSwitchState() == 2)  //是分闸状态
                        {
                            SetCmdCode(2, cmdJudgeSwitchState);
                        }
                        else SetResult(ngSwitchState);
                        break;
                    case cmdJudgeSwitchState:
                        //plc 判断开合闸状态
                        break;
                    case cmdLowVoltage:
                        break;
                    case cmdCloseSwitch5:
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState5);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState5:
                        //plc 物理判断分合闸状态
                        break;

                    case cmdLowVoltageJudge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(2, cmdJudgeSwitchStateOk5);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngLowVoltage);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(2, cmdJudgeSwitchStateOk5);
                        break;
                    case cmdJudgeSwitchStateOk5:
                        //为合闸状态，根据设置判断为进行那一步测试
                        if (Global.doActionTest1)
                        {
                            SetCmdCode(2, cmdActionTest1);
                        }
                        else if (Global.doActionTest2)
                        {
                            SetCmdCode(2, cmdActionTest2);
                        }
                        else if (Global.doActionTest3)
                        {
                            SetCmdCode(2, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(2, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(2, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(2, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        else SetCmdCode(2, cmdClearTest);
                        break;
                    case cmdActionTest1: //极限不驱动测试
                                         ///plc进行极限不驱动测试
                                         ///
                        break;
                    case cmdActionTest1Judge://等待上位机确认是否合格
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(2, cmdActionTest1Ok);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest1);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(2, cmdActionTest1Ok);
                        break;
                    case cmdActionTest1Ok:
                        ///测试1完成，下一步进行操作
                        if (Global.doActionTest2)
                        {
                            SetCmdCode(2, cmdActionTest2);
                        }
                        else if (Global.doActionTest3)
                        {
                            SetCmdCode(2, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(2, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(2, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(2, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        else SetCmdCode(2, cmdClearTest);
                        break;
                    case cmdActionTest2:
                        //进行慢启动测试
                        break;
                    case cmdActionTest2Judge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(2, cmdCloseSwitch1);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest2);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(2, cmdCloseSwitch1);
                        break;
                    case cmdCloseSwitch1:
                        //通信合闸
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState1);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState1:
                        //plc判断合闸
                        break;
                    case cmdJudgeSwitchStateOk1:
                        if (Global.doActionTest3)
                        {
                            SetCmdCode(2, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(2, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(2, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(2, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        else SetCmdCode(2, cmdClearTest);
                        break;
                    case cmdActionTest3: //漏电流动作事件测试
                                         ///plc进行测试2（漏电流动作事件测试）
                        break;
                    case cmdActionTest3Judge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(2, cmdCloseSwitch2);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest3);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(2, cmdCloseSwitch2);
                        break;
                    case cmdCloseSwitch2:
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState2);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState2: //需要上位机和plc都进行合闸判断
                        break;                      //Thread.Sleep(Global.wholeTestCloseSwitchTime);
                    case cmdJudgeSwitchStateOk2:
                        if (Global.doOverVoltage)
                        {
                            SetCmdCode(2, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(2, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(2, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        else SetCmdCode(2, cmdClearTest);
                        break;
                    case cmdOverVoltage:
                        //plc做过压测试
                        break;
                    case cmdOverVoltageJudge:
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        bool JudgeResult = false;
                        double[] protectData = suyiStation2.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress2.OverVoltageReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress2.OverVoltagePhase)).ToString(), protectData[1]);
                        WriteMemory(((int)(MemoryAddress2.OverVoltageValueA)).ToString(), protectData[2]);
                        WriteMemory(((int)(MemoryAddress2.OverVoltageValueB)).ToString(), protectData[3]);
                        WriteMemory(((int)(MemoryAddress2.OverVoltageValueC)).ToString(), protectData[4]);
                        if (protectData[0] == overVoltageCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress2.OverVoltagePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                switch ((int)protectData[1])
                                {
                                    case phaseA:
                                        if (protectData[2] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[2] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseB:
                                        if (protectData[3] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[3] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;

                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseC:
                                        if (protectData[4] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[4] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                }
                            }
                            else SetResult(ngOverVoltagePhase);
                        }
                        else SetResult(ngOverVoltageReason);
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge2 == 1) //用户确认为合格
                                {
                                    SetCmdCode(2, cmdCloseSwitch3);
                                    Global.stationJudge2 = 0;
                                }
                                else if (Global.stationJudge2 == 2)//用户确认为不合格
                                {
                                    SetResult(ngOverVoltage);
                                    Global.stationJudge2 = 0;
                                }
                            }
                            else SetCmdCode(2, cmdCloseSwitch3);
                        }
                        break;
                    case cmdCloseSwitch3:
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState3);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState3:
                        //plc判断分合闸状态
                        break;
                    case cmdJudgeSwitchStateOk3:
                        if (Global.dounderVoltage)
                        {
                            SetCmdCode(2, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(2, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        else SetCmdCode(2, cmdClearTest);
                        break;
                    case cmdUnderVoltage:
                        //欠压测试
                        break;
                    case cmdUnderVoltageJudge:
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation2.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress2.UnderVoltageReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress2.UnderVoltagePhase)).ToString(), protectData[1]);
                        WriteMemory(((int)(MemoryAddress2.UnderVoltageValueA)).ToString(), protectData[2]);
                        WriteMemory(((int)(MemoryAddress2.UnderVoltageValueB)).ToString(), protectData[3]);
                        WriteMemory(((int)(MemoryAddress2.UnderVoltageValueC)).ToString(), protectData[4]);
                        if (protectData[0] == underVoltageCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress2.UnderVoltagePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                switch ((int)protectData[1])
                                {
                                    case phaseA:
                                        if (protectData[2] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[2] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseB:
                                        if (protectData[3] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[3] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;

                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseC:
                                        if (protectData[4] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[4] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                }
                            }
                            else SetResult(ngUnderVoltagePhase);
                        }
                        else SetResult(ngUnderVoltageReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge2 == 1) //用户确认为合格
                                {
                                    SetCmdCode(2, cmdCloseSwitch4);
                                    Global.stationJudge2 = 0;
                                }
                                else if (Global.stationJudge2 == 2)//用户确认为不合格
                                {
                                    SetResult(ngUnderVoltage);
                                    Global.stationJudge2 = 0;
                                }
                            }
                            else SetCmdCode(2, cmdCloseSwitch4);
                        }
                        break;
                    case cmdCloseSwitch4:
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState4);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState4: // plc 物理判断分合闸
                        break;
                    //case cmdOpenSwitch:
                    case cmdJudgeSwitchStateOk4:
                        //判断是否为合格
                        //若合格进行下一步
                        if (Global.doLosePhase)
                        {
                            SetCmdCode(2, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        else SetCmdCode(2, cmdClearTest);
                        break;
                    case cmdLosePhase:
                        //plc进行缺相检测
                        break;
                    case cmdLosePhaseJudge:
                        //判断是否为合格
                        //若合格进行下一步
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation2.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress2.LosePhaseReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress2.LosePhase)).ToString(), protectData[1]);
                        if (protectData[0] == losePhaseCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress2.LosePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                JudgeResult = true;
                            }
                            else SetResult(ngLosePhaseValue);
                        }
                        else SetResult(ngLosePhaseReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge2 == 1) //用户确认为合格
                                {
                                    SetCmdCode(2, cmdCloseSwitch6);
                                    Global.stationJudge2 = 0;
                                }
                                else if (Global.stationJudge2 == 2)//用户确认为不合格
                                {
                                    SetResult(ngLosePhase);
                                    Global.stationJudge2 = 0;
                                }
                            }
                            else SetCmdCode(2, cmdCloseSwitch6);
                        }
                        break;
                    //case cmdLosePhaseRecord:
                    //    int losePhaseValue = suyiStation2.OpenSwitchRecord();
                    //    WriteMemory(MemoryAddress.LosePhaseValue, losePhaseValue);
                    //    SetCmdCode(2,cmdCloseSwitch6);
                    //    break;
                    case cmdCloseSwitch6:
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState6);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState6:
                        //plc 判断分合闸状态
                        break;
                    case cmdJudgeSwitchStateOk6:
                        if (Global.doZeroPhase)
                        {
                            SetCmdCode(2, cmdZeroPhase);
                        }
                        break;
                    case cmdZeroPhase:
                        //进行缺零检测
                        break;
                    case cmdZeroPhaseJudge:
                        //判断是否为合格
                        //若合格进行下一步
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation2.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress2.ZeroPhaseReason)).ToString(), protectData[0]);
                        if (protectData[0] == loseZeroCloseSwitch) //跳闸原因匹配
                        {
                            JudgeResult = true;
                        }
                        else SetResult(ngZeroPhaseReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge2 == 1) //用户确认为合格
                                {
                                    SetCmdCode(2, cmdClearTest);
                                    Global.stationJudge2 = 0;
                                }
                                else if (Global.stationJudge2 == 2)//用户确认为不合格
                                {
                                    SetResult(ngZeroPhase);
                                    Global.stationJudge2 = 0;
                                }
                            }
                            else SetCmdCode(2, cmdClearTest);
                        }
                        break;
                    case cmdCloseSwitch7:
                        if (suyiStation2.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation2.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitchState7);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState7:
                        break;
                    case cmdClearTest:
                        if (suyiStation2.ClearTestRecord())
                        {
                            Thread.Sleep(1000);
                            if (Global.finallyJudge)
                            {
                                SetCmdCode(2, cmdFinallyJudge);
                            }
                            else
                            {
                                if (Global.meachineAge)
                                {
                                    meachineNum = Global.meachineTestNum;
                                    if (meachineNum > 0)
                                    {
                                        SetCmdCode(2, cmdOpenSwitch);
                                    }
                                    else SetCmdCode(2, cmdWholeTestEnd);

                                }
                                else SetCmdCode(2, cmdWholeTestEnd);
                            }
                        }
                        else SetResult(ngClearTestRecord);
                        break;
                    case cmdFinallyJudge:
                        if (Global.stationJudge2 == 1) //用户确认为合格
                        {
                            if (Global.meachineAge)
                            {
                                meachineNum = Global.meachineTestNum;
                                if (meachineNum > 0)
                                {
                                    SetCmdCode(2, cmdOpenSwitch);
                                }
                                else SetCmdCode(2, cmdWholeTestEnd);

                            }
                            else SetCmdCode(2, cmdWholeTestEnd);
                            Global.stationJudge2 = 0;
                        }
                        else if (Global.stationJudge2 == 2)//用户确认为不合格
                        {
                            SetResult(ngManualJudge);
                            Global.stationJudge2 = 0;
                        }
                        break;
                    case cmdOpenSwitch:

                        if (suyiStation2.OpenSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {

                                if (suyiStation2.ReadSwitchState() == 2)
                                {
                                    openSwitch = true;
                                    break;
                                }
                                else openSwitch = false;
                            }
                            if (openSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitch);
                            }
                            else SetResult(ngOpenSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitch:

                        break;
                    case cmdCloseSwtich:
                        if (suyiStation2.CloseSwitch())
                        {

                            for (int i = 0; i < 65; i++)
                            {

                                if (suyiStation2.ReadSwitchState() == 1)
                                {
                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;
                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(2, cmdJudgeSwitch1);
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        break;
                    case cmdJudgeSwitch1:
                        break;
                    case cmdJudgeEnd:
                        meachineNum--;
                        if (meachineNum > 0)
                        {
                            SetCmdCode(2, cmdOpenSwitch);
                        }
                        else SetCmdCode(2, cmdWholeTestEnd);
                        break;
                    case cmdWholeTestEnd:  //整机测试一个流程完成

                        break;


                    default:
                        break;
                }
            }
        }
        public void AutoWholeTestStation3() //自动整机station 3测试
        {
            while (autoWork)
            {
                Thread.Sleep(50);
                int cmdId = GetCmdCode();
                switch (cmdId)
                {
                    case cmdWholeTestStart:
                        break;
                    case cmdCommunicationTest:
                        if (suyiStation3.CommunicationTest()) //通信测试环节（命令代码由苏益给出)
                        {
                            SetCmdCode(3, cmdRecoveryFactorySet);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdRecoveryFactorySet:
                        //发送恢复出场设置指令
                        if (suyiStation3.RecoveryFactorySet())
                        {
                            SetCmdCode(3, cmdReadSwitch);
                        }
                        else SetResult(ngRecoveryFactory);
                        break;
                    case cmdReadSwitch:
                        //通讯判断合闸
                        if (suyiStation3.ReadSwitchState() == 2)  //是分闸状态
                        {
                            SetCmdCode(3, cmdJudgeSwitchState);
                        }
                        else SetResult(ngSwitchState);
                        break;
                    case cmdJudgeSwitchState:
                        //plc 判断开合闸状态
                        break;
                    case cmdLowVoltage:
                        break;
                    case cmdCloseSwitch5:
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState5);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState5:
                        //plc 物理判断分合闸状态
                        break;

                    case cmdLowVoltageJudge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(3, cmdJudgeSwitchStateOk5);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngLowVoltage);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(3, cmdJudgeSwitchStateOk5);
                        break;
                    case cmdJudgeSwitchStateOk5:
                        //为合闸状态，根据设置判断为进行那一步测试
                        if (Global.doActionTest1)
                        {
                            SetCmdCode(3, cmdActionTest1);
                        }
                        else if (Global.doActionTest2)
                        {
                            SetCmdCode(3, cmdActionTest2);
                        }
                        else if (Global.doActionTest3)
                        {
                            SetCmdCode(3, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(3, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(3, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(3, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        else SetCmdCode(3, cmdClearTest);
                        break;
                    case cmdActionTest1: //极限不驱动测试
                                         ///plc进行极限不驱动测试
                                         ///
                        break;
                    case cmdActionTest1Judge://等待上位机确认是否合格
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(3, cmdActionTest1Ok);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest1);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(3, cmdActionTest1Ok); ;
                        break;
                    case cmdActionTest1Ok:
                        ///测试1完成，下一步进行操作
                        if (Global.doActionTest2)
                        {
                            SetCmdCode(3, cmdActionTest2);
                        }
                        else if (Global.doActionTest3)
                        {
                            SetCmdCode(3, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(3, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(3, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(3, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        else SetCmdCode(3, cmdClearTest);
                        break;
                    case cmdActionTest2:
                        //进行慢启动测试
                        break;
                    case cmdActionTest2Judge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(3, cmdCloseSwitch1);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest2);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(3, cmdCloseSwitch1);
                        break;
                    case cmdCloseSwitch1:
                        //通信合闸
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState1);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState1:
                        //plc判断合闸
                        break;
                    case cmdJudgeSwitchStateOk1:
                        if (Global.doActionTest3)
                        {
                            SetCmdCode(3, cmdActionTest3);
                        }
                        else if (Global.doOverVoltage)
                        {
                            SetCmdCode(3, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(3, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(3, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        else SetCmdCode(3, cmdClearTest);
                        break;
                    case cmdActionTest3: //漏电流动作事件测试
                                         ///plc进行测试2（漏电流动作事件测试）
                        break;
                    case cmdActionTest3Judge:
                        if (Global.manualJudge)
                        {
                            if (Global.stationJudge2 == 1) //用户确认为合格
                            {
                                SetCmdCode(3, cmdCloseSwitch2);
                                Global.stationJudge2 = 0;
                            }
                            else if (Global.stationJudge2 == 2)//用户确认为不合格
                            {
                                SetResult(ngActionTest3);
                                Global.stationJudge2 = 0;
                            }
                        }
                        else SetCmdCode(3, cmdCloseSwitch2);
                        break;
                    case cmdCloseSwitch2:
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState2);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState2: //需要上位机和plc都进行合闸判断
                        break;                      //Thread.Sleep(Global.wholeTestCloseSwitchTime);
                    case cmdJudgeSwitchStateOk2:
                        if (Global.doOverVoltage)
                        {
                            SetCmdCode(3, cmdOverVoltage);
                        }
                        else if (Global.dounderVoltage)
                        {
                            SetCmdCode(3, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(3, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        else SetCmdCode(3, cmdClearTest);
                        break;
                    case cmdOverVoltage:
                        //plc做过压测试
                        break;
                    case cmdOverVoltageJudge:
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        bool JudgeResult = false;
                        double[] protectData = suyiStation3.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress3.OverVoltageReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress3.OverVoltagePhase)).ToString(), protectData[1]);
                        WriteMemory(((int)(MemoryAddress3.OverVoltageValueA)).ToString(), protectData[2]);
                        WriteMemory(((int)(MemoryAddress3.OverVoltageValueB)).ToString(), protectData[3]);
                        WriteMemory(((int)(MemoryAddress3.OverVoltageValueC)).ToString(), protectData[4]);
                        if (protectData[0] == overVoltageCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress3.OverVoltagePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                switch ((int)protectData[1])
                                {
                                    case phaseA:
                                        if (protectData[2] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[2] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseB:
                                        if (protectData[3] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[3] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;

                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseC:
                                        if (protectData[4] <= ((1 + Global.VoltageErroRange / 100.00) * Global.overVoltageValue) || (protectData[4] >= ((1 - Global.VoltageErroRange / 100.00) * Global.overVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngOverVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                }
                            }
                            else SetResult(ngOverVoltagePhase);
                        }
                        else SetResult(ngOverVoltageReason);
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge3 == 1) //用户确认为合格
                                {
                                    SetCmdCode(3, cmdCloseSwitch3);
                                    Global.stationJudge3 = 0;
                                }
                                else if (Global.stationJudge3 == 2)//用户确认为不合格
                                {
                                    SetResult(ngOverVoltage);
                                    Global.stationJudge3 = 0;
                                }
                            }
                            else SetCmdCode(3, cmdCloseSwitch3);
                        }
                        break;
                    case cmdCloseSwitch3:
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState3);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState3:
                        //plc判断分合闸状态
                        break;
                    case cmdJudgeSwitchStateOk3:
                        if (Global.dounderVoltage)
                        {
                            SetCmdCode(3, cmdUnderVoltage);
                        }
                        else if (Global.doLosePhase)
                        {
                            SetCmdCode(3, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        else SetCmdCode(3, cmdClearTest);
                        break;
                    case cmdUnderVoltage:
                        //欠压测试
                        break;
                    case cmdUnderVoltageJudge:
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation3.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress3.UnderVoltageReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress3.UnderVoltagePhase)).ToString(), protectData[1]);
                        WriteMemory(((int)(MemoryAddress3.UnderVoltageValueA)).ToString(), protectData[2]);
                        WriteMemory(((int)(MemoryAddress3.UnderVoltageValueB)).ToString(), protectData[3]);
                        WriteMemory(((int)(MemoryAddress3.UnderVoltageValueC)).ToString(), protectData[4]);
                        if (protectData[0] == underVoltageCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress3.UnderVoltagePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                switch ((int)protectData[1])
                                {
                                    case phaseA:
                                        if (protectData[2] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[2] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseB:
                                        if (protectData[3] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[3] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;

                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                    case phaseC:
                                        if (protectData[4] <= ((1 + Global.VoltageErroRange / 100.00) * Global.underVoltageValue) || (protectData[4] >= ((1 - Global.VoltageErroRange / 100.00) * Global.underVoltageValue))) //在误差范围内
                                        {
                                            JudgeResult = true;
                                        }
                                        else
                                        {
                                            SetResult(ngUnderVoltageValue);
                                            JudgeResult = false;
                                        }
                                        break;
                                }
                            }
                            else SetResult(ngUnderVoltagePhase);
                        }
                        else SetResult(ngUnderVoltageReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge3 == 1) //用户确认为合格
                                {
                                    SetCmdCode(3, cmdCloseSwitch4);
                                    Global.stationJudge3 = 0;
                                }
                                else if (Global.stationJudge3 == 2)//用户确认为不合格
                                {
                                    SetResult(ngUnderVoltage);
                                    Global.stationJudge3 = 0;
                                }
                            }
                            else SetCmdCode(3, cmdCloseSwitch4);
                        }
                        break;
                    case cmdCloseSwitch4:
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState4);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState4: // plc 物理判断分合闸
                        break;
                    //case cmdOpenSwitch:
                    case cmdJudgeSwitchStateOk4:
                        //判断是否为合格
                        //若合格进行下一步
                        if (Global.doLosePhase)
                        {
                            SetCmdCode(3, cmdLosePhase);
                        }
                        else if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        else SetCmdCode(3, cmdClearTest);
                        break;
                    case cmdLosePhase:
                        //plc进行缺相检测
                        break;
                    case cmdLosePhaseJudge:
                        //判断是否为合格
                        //若合格进行下一步
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation3.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress3.LosePhaseReason)).ToString(), protectData[0]);
                        WriteMemoryDM(((int)(MemoryAddress3.LosePhase)).ToString(), protectData[1]);
                        if (protectData[0] == losePhaseCloseSwitch) //跳闸原因匹配
                        {
                            if (protectData[1] == ReadMemoryDM(((int)(MemoryAddress3.LosePhaseFromPlc)).ToString())) //跳闸相位匹配
                            {
                                JudgeResult = true;
                            }
                            else SetResult(ngLosePhaseValue);
                        }
                        else SetResult(ngLosePhaseReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge3 == 1) //用户确认为合格
                                {
                                    SetCmdCode(3, cmdCloseSwitch6);
                                    Global.stationJudge3 = 0;
                                }
                                else if (Global.stationJudge3 == 2)//用户确认为不合格
                                {
                                    SetResult(ngLosePhase);
                                    Global.stationJudge3 = 0;
                                }
                            }
                            else SetCmdCode(3, cmdCloseSwitch6);
                        }
                        break;
                    //case cmdLosePhaseRecord:
                    //    int losePhaseValue = suyiStation3.OpenSwitchRecord();
                    //    WriteMemory(MemoryAddress.LosePhaseValue, losePhaseValue);
                    //    SetCmdCode(3,cmdCloseSwitch6);
                    //    break;
                    case cmdCloseSwitch6:
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState6);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState6:
                        //plc 判断分合闸状态
                        break;
                    case cmdJudgeSwitchStateOk6:
                        if (Global.doZeroPhase)
                        {
                            SetCmdCode(3, cmdZeroPhase);
                        }
                        break;
                    case cmdZeroPhase:
                        //进行缺零检测
                        break;
                    case cmdZeroPhaseJudge:
                        //判断是否为合格
                        //若合格进行下一步
                        /// 1.先通讯判断是否合格
                        /// 2.人工按钮判断是否合格
                        /// 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        JudgeResult = false;
                        protectData = suyiStation3.GetSwitchProtect();
                        WriteMemoryDM(((int)(MemoryAddress3.ZeroPhaseReason)).ToString(), protectData[0]);
                        if (protectData[0] == loseZeroCloseSwitch) //跳闸原因匹配
                        {
                            JudgeResult = true;
                        }
                        else SetResult(ngZeroPhaseReason);
                        ///人工判断
                        if (JudgeResult)
                        {
                            if (Global.manualJudge)
                            {
                                if (Global.stationJudge3 == 1) //用户确认为合格
                                {
                                    SetCmdCode(1, cmdClearTest);
                                    Global.stationJudge3 = 0;
                                }
                                else if (Global.stationJudge3 == 2)//用户确认为不合格
                                {
                                    SetResult(ngZeroPhase);
                                    Global.stationJudge3 = 0;
                                }
                            }
                            else SetCmdCode(3, cmdClearTest);
                        }
                        break;
                    //case cmdZeroPhaseRecord:
                    //    int zeroPhaseValue = suyiStation3.OpenSwitchRecord();
                    //    WriteMemory(MemoryAddress.LosePhaseValue, zeroPhaseValue);
                    //    SetCmdCode(3,cmdCloseSwitch6);
                    //    break;
                    case cmdCloseSwitch7:
                        if (suyiStation3.CloseSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {
                                if (suyiStation3.ReadSwitchState() == 1)
                                {

                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;

                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitchState7);
                                closeSwitch = false;
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState7:
                        break;
                    case cmdClearTest:
                        if (suyiStation3.ClearTestRecord())
                        {
                            Thread.Sleep(1000);
                            if (Global.finallyJudge)
                            {
                                SetCmdCode(3, cmdFinallyJudge);
                            }
                            else
                            {
                                if (Global.meachineAge)
                                {
                                    meachineNum = Global.meachineTestNum;
                                    if (meachineNum > 0)
                                    {
                                        SetCmdCode(3, cmdOpenSwitch);
                                    }
                                    else SetCmdCode(3, cmdWholeTestEnd);

                                }
                                else SetCmdCode(3, cmdWholeTestEnd);
                            }
                        }
                        else SetResult(ngClearTestRecord);
                        break;
                    case cmdFinallyJudge:
                        if (Global.stationJudge3 == 1) //用户确认为合格
                        {
                            if (Global.meachineAge)
                            {
                                meachineNum = Global.meachineTestNum;
                                if (meachineNum > 0)
                                {
                                    SetCmdCode(3, cmdOpenSwitch);
                                }
                                else SetCmdCode(3, cmdWholeTestEnd);

                            }
                            else SetCmdCode(3, cmdWholeTestEnd);
                            Global.stationJudge3 = 0;
                        }
                        else if (Global.stationJudge3 == 2)//用户确认为不合格
                        {
                            SetResult(ngManualJudge);
                            Global.stationJudge3 = 0;
                        }
                        break;
                    case cmdOpenSwitch:

                        if (suyiStation3.OpenSwitch())
                        {
                            for (int i = 0; i < 65; i++)
                            {

                                if (suyiStation3.ReadSwitchState() == 2)
                                {
                                    openSwitch = true;
                                    break;
                                }
                                else openSwitch = false;
                            }
                            if (openSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitch);
                            }
                            else SetResult(ngOpenSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitch:

                        break;
                    case cmdCloseSwtich:
                        if (suyiStation3.CloseSwitch())
                        {

                            for (int i = 0; i < 65; i++)
                            {

                                if (suyiStation3.ReadSwitchState() == 1)
                                {
                                    closeSwitch = true;
                                    break;
                                }
                                else closeSwitch = false;
                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(3, cmdJudgeSwitch1);
                            }
                            else SetResult(ngCloseSwitch);
                        }
                        break;
                    case cmdJudgeSwitch1:
                        break;
                    case cmdJudgeEnd:
                        meachineNum--;
                        if (meachineNum > 0)
                        {
                            SetCmdCode(3, cmdOpenSwitch);
                        }
                        else SetCmdCode(3, cmdWholeTestEnd);
                        break;
                    case cmdWholeTestEnd:  //整机测试一个流程完成

                        break;


                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 获取控制码
        /// </summary>
        /// <returns></returns>
        private int GetCmdCode()
        {
            try
            {
                if (stationAddress == 1)
                {
                    return ReadMemory(((int)(MemoryAddress1.CmdCode)).ToString());
                }
                else if (stationAddress == 2)
                {
                    return ReadMemory(((int)(MemoryAddress2.CmdCode)).ToString());
                }
                else if (stationAddress == 3)
                {
                    return ReadMemory(((int)(MemoryAddress3.CmdCode)).ToString());
                }
                return 0;
            }

            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return 0;
            }

        }
        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="stationAddress">工位</param>
        /// <param name="data">命令码</param>
        private void SetCmdCode(int stationAddress, int data)
        {
            try
            {
                if (stationAddress == 1)
                {
                    WriteMemory(((int)(MemoryAddress1.CmdCode)).ToString(), data);
                }
                else if (stationAddress == 2)
                {
                    WriteMemory(((int)(MemoryAddress2.CmdCode)).ToString(), data);
                }
                else if (stationAddress == 3)
                {
                    WriteMemory(((int)(MemoryAddress3.CmdCode)).ToString(), data);
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        /// <summary>
        /// 写结果
        /// </summary>
        /// <param name="data"></param>
        private void SetResult(int data)
        {
            try
            {
                if (stationAddress == 1)
                {
                    WriteMemory(((int)MemoryAddress1.TestResult).ToString(), data);

                }
                else if (stationAddress == 2)
                {
                    WriteMemory(((int)MemoryAddress2.TestResult).ToString(), data);

                }
                else if (stationAddress == 3)
                {
                    WriteMemory(((int)MemoryAddress3.TestResult).ToString(), data);

                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        ///// 
        ///// 后面都是各种写 各种寄存器的方法的重载（很多种数据类型）自己领悟吧
        ///// 
        private void WriteMemoryDM(string address, double data)
        {
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, address, (int)data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void WriteMemory(string address, int data)
        {
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address, data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void WriteMemory(string address, float data)
        {
            uint[] dataReturn = DoubleConvert.Real_to_2Int(data);
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address, (int)dataReturn[1]);
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, (Convert.ToInt32(address) + 1).ToString(), (int)dataReturn[0]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void WriteMemory(string address, double data)
        {
            uint[] dataReturn = DoubleConvert.Real_to_2Int((float)data);
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, address, (int)dataReturn[1]);
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, (Convert.ToInt32(address) + 1).ToString(), (int)dataReturn[0]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        /// <summary>
        /// 读EM寄存器（其实不需要写两个方法，可以传参寄存器类型，但懒得改了。都行）
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private int ReadMemory(string address)
        {
            try
            {
                return Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return -1;
            }

        }
        /// <summary>
        /// 读DM寄存器
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private int ReadMemoryDM(string address)
        {
            try
            {
                return Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, address);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return -1;
            }
        }
        //private void CloseSwitch(int cmdCode)
        //{
        //    if (Suyi.CloseSwitch())
        //    {
        //        if (Suyi.ReadSwitchState() == 1)
        //        {
        //            SetCmdCode(1,cmdCode);
        //        }
        //        else SetResult(ngCloseSwitch);
        //    }
        //    else SetResult(ngCloseSwitch);
        //}
        //工位1需要用到的数据地址枚举
        private enum MemoryAddress1 : int
        {
            CmdCode = 5601,
            TestResult = 5602,
            OverVoltageValueA = 20765,
            OverVoltageValueB = 20840,
            OverVoltageValueC = 20842,
            OverVoltagePhase = 20865,
            OverVoltagePhaseFromPlc = 20826,
            OverVoltageReason = 20864,
            UnderVoltageValueA = 20769,
            UnderVoltageValueB = 20844,
            UnderVoltageValueC = 20846,
            UnderVoltagePhase = 20866,
            UnderVoltagePhaseFromPlc = 20827,
            UnderVoltageReason = 20832,
            LosePhase = 20713,
            LosePhaseFromPlc = 20712,
            LosePhaseReason = 20833,
            ZeroPhaseReason = 20715,
        }
        //工位2需要用到的数据地址枚举
        private enum MemoryAddress2 : int
        {
            CmdCode = 5603,
            TestResult = 5604,
            OverVoltageValueA = 20789,
            OverVoltageValueB = 20848,
            OverVoltageValueC = 20850,
            OverVoltagePhase = 20867,
            OverVoltagePhaseFromPlc = 20828,
            OverVoltageReason = 20834,
            UnderVoltageValueA = 20793,
            UnderVoltageValueB = 20852,
            UnderVoltageValueC = 20854,
            UnderVoltagePhase = 20868,
            UnderVoltagePhaseFromPlc = 20829,
            UnderVoltageReason = 20835,
            LosePhase = 20730,
            LosePhaseFromPlc = 20729,
            LosePhaseReason = 20836,
            ZeroPhaseReason = 20732,
        }

        //工位3需要用到的数据地址枚举
        private enum MemoryAddress3 : int
        {
            CmdCode = 5605,
            TestResult = 5606,
            OverVoltageValueA = 20813,
            OverVoltageValueB = 20856,
            OverVoltageValueC = 20858,
            OverVoltagePhase = 20869,
            OverVoltagePhaseFromPlc = 20830,
            OverVoltageReason = 20837,
            UnderVoltageValueA = 20817,
            UnderVoltageValueB = 20860,
            UnderVoltageValueC = 20862,
            UnderVoltagePhase = 20870,
            UnderVoltagePhaseFromPlc = 20831,
            UnderVoltageReason = 20838,
            LosePhase = 20747,
            LosePhaseFromPlc = 20746,
            LosePhaseReason = 20839,
            ZeroPhaseReason = 20749,
        }
    }
}
