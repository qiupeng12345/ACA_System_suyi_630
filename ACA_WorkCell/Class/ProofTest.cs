/*
 *  校对测试自动流程代码
 * cmd为控制码/
 * ng为异常码
 * *********************************************************************************************************
 * 正常工作流程（电流电压剩余电流三相校对以及校对结果检测） 2018/06/01
 * 添加分合闸状态判断（原本由通信读取产品分合闸状态，现加入物理（输出形式）判断）2018/06/03
 * 添加用户功能选择（所有流程由用户决定是否做，如不勾选即不做） 2018/06/03
 * 添加校对人工判断（选择人工判断，需要等待人工确认进行下一步） 2018/07/05
 * 添加校对前后电流电压剩余电流记录（校对前通信获取产品的三相电流电压剩余电流值（需要记录）,校过程中通信获取产品内部三相值，与实际输出值比较在判断误差范围内为合格） 2018/07/08
 * 添加零位值判断（当校对输出为0时判断依据为零位值判断） 2018/07/20
 * 添加选择产品进入判断分闸或者合闸（功能勾选）（选择分闸状态进入，则判断为分闸继续，选择合闸状态进入，则判断为合闸进入，不一致报警） 2018/07/25
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
using System.ComponentModel;

namespace ACA_Common.Class
{
    /// <summary>
    /// 电流电压剩余电流校对工作类
    /// </summary>
    public class ProofTest
    {
        private bool closeSwitch = false;
        private bool openSwitch = false;
        private bool proofResult;
        private int CmdId;
        private SuyiMCCB suyi = new SuyiMCCB()
        {
            ComPort = new System.IO.Ports.SerialPort()
            {
                PortName = "COM1",
                BaudRate = 9600,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.One,
                Parity = System.IO.Ports.Parity.Even,
                ReadTimeout = 800,
                WriteTimeout = 100,
            }
        };
        public ProofTest()
        {

        }
        private int meachineNum = 0;
        private const int proofErrorMax = 2;
        private bool autoWork;
        private const int auto = 1;
        private const int semiAuto = 2;
        private const int stop = 3;
        public const int cmdCurrentStart = 1;
        public const int cmdCurrentCommunicationTest = 2;
        public const int cmdJudgeSwitchStateCurrent1 = 3;
        public const int cmdJudgeSwitchStateCurrent2 = 4;
        public const int cmdJudgeSwitchStateCurrent3 = 5;
        public const int cmdCurrentCloseSwitch = 6;
        public const int cmdEnterCurrentProof = 7;
        public const int cmdCurrentOutput1 = 8;
        public const int cmdCurrentProof1Ready = 10;
        public const int cmdCurrentProof1Start = 9;
        public const int cmdCurrentOutput2 = 11;
        public const int cmdCurrentProof2Ready = 13;
        public const int cmdCurrentProof2Start = 12;
        public const int cmdCurrentOutput3 = 14;
        public const int cmdCurrentProof3Ready = 16;
        public const int cmdCurrentProof3Start = 15;
        public const int cmdCurrentOutput4 = 17;
        public const int cmdCurrentProof4Ready = 19;
        public const int cmdCurrentProof4Start = 18;
        public const int cmdCurrentOutput5 = 20;
        public const int cmdCurrentProof5Ready = 22;
        public const int cmdCurrentProof5Start = 21;
        public const int cmdQuitCurrentProof = 23;
        public const int cmdCurrentCheckOutput = 24;
        public const int cmdCurrentProofCheck = 25;
        public const int cmdCurrentEnd = 26;
        public const int cmdVoltageStart = 31;
        public const int cmdVoltageCommunicationTest = 32;
        public const int cmdJudgeSwitchStateVoltage = 33;
        public const int cmdEnterVoltageProof = 34;
        public const int cmdVoltageOutput1 = 35;
        public const int cmdVoltageProof1Ready = 37;
        public const int cmdVoltageProof1Start = 36;
        public const int cmdVoltageOutput2 = 38;
        public const int cmdVoltageProof2Ready = 39;
        public const int cmdVoltageProof2Start = 40;
        public const int cmdVoltageOutput3 = 41;
        public const int cmdVoltageProof3Ready = 42;
        public const int cmdVoltageProof3Start = 43;
        public const int cmdVoltageOutput4 = 44;
        public const int cmdVoltageProof4Ready = 45;
        public const int cmdVoltageProof4Start = 46;
        public const int cmdVoltageOutput5 = 47;
        public const int cmdVoltageProof5Ready = 48;
        public const int cmdVoltageProof5Start = 49;
        public const int cmdQuitVoltageProof = 50;
        public const int cmdVoltageCheckOutput = 51;
        public const int cmdVoltageProofCheck = 52;
        public const int cmdVoltageEnd = 53;
        public const int cmdResidualCurrentStart = 61;
        public const int cmdResidualCurrentCommunicationTest = 62;
        public const int cmdJudgeSwitchStateResidualCurrent = 63;
        public const int cmdEnterResidualCurrentProof = 64;
        public const int cmdResidualCurrentOutput1 = 65;
        public const int cmdResidualCurrentProof1Ready = 67;
        public const int cmdResidualCurrentProof1Start = 66;
        public const int cmdResidualCurrentOutput2 = 68;
        public const int cmdResidualCurrentProof2Ready = 70;
        public const int cmdResidualCurrentProof2Start = 69;
        public const int cmdResidualCurrentOutput3 = 71;
        public const int cmdResidualCurrentProof3Ready = 73;
        public const int cmdResidualCurrentProof3Start = 72;
        public const int cmdResidualCurrentOutput4 = 74;
        public const int cmdResidualCurrentProof4Ready = 76;
        public const int cmdResidualCurrentProof4Start = 75;
        public const int cmdResidualCurrentOutput5 = 77;
        public const int cmdResidualCurrentProof5Ready = 79;
        public const int cmdResidualCurrentProof5Start = 78;
        public const int cmdQuitResidualCurrentProof = 80;
        public const int cmdResidualCurrentCheckOutput = 81;
        public const int cmdResidualCurrentProofCheck = 82;
        public const int cmdResidualCurrentEnd = 83;
        public const int cmdOpenSwitch = 90;
        public const int cmdJudgeSwitch = 91;
        public const int cmdCloseSwtich = 92;
        public const int cmdJudgeSwitch1 = 93;
        public const int cmdJudgeEnd = 94;
        public const int cmdCurrentJudge1 = 100;
        public const int cmdCurrentJudge2 = 101;
        public const int cmdCurrentJudge3 = 102;
        public const int cmdCurrentJudge4 = 103;
        public const int cmdCurrentJudge5 = 104;
        public const int cmdVoltageJudge1 = 110;
        public const int cmdVoltageJudge2 = 111;
        public const int cmdVoltageJudge3 = 112;
        public const int cmdVoltageJudge4 = 113;
        public const int cmdVoltageJudge5 = 114;
        public const int cmdResidualJudge1 = 120;
        public const int cmdResidualJudge2 = 121;
        public const int cmdResidualJudge3 = 122;
        public const int cmdResidualJudge4 = 123;
        public const int cmdResidualJudge5 = 124;
        public const int ngReset = 0;
        public const int ngCommunication = 1;
        public const int ngCloseSwitch = 2;
        public const int ngEnterProof = 3;
        public const int ngProofFail = 4;
        public const int ngCheckFail = 5;
        public const int ngSwitchState1 = 6;
        public const int ngPlc = 7;
        public const int ngOpenSwitch = 8;
        public const int ngSwitchState2 = 9;

        public SuyiMCCB Suyi
        {
            get
            {
                return suyi;
            }

            set
            {
                suyi = value;
            }
        }

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


        //public SuyiMCCB Suyi { get{} suyi; set{} suyi = value; }
        //public bool AutoWork { get{} autoWork; set{} autoWork = value; }

        public void AutoTest()
        {
            int proofErro = 0;
            //将校对次数和预设值写给plc
            //SetCmdCode(cmdCurrentStart);//告诉PLC开始进行测试
            while (AutoWork)//当前为自动工作状态
            {
                try
                {
                    Thread.Sleep(50);

                    CmdId = GetCmdCode();  //从plc中获取命令
                    switch (CmdId)
                    {
                        case cmdCurrentStart:    //开始测试环节
                            proofErro = 0;
                            break;

                        case cmdCurrentCommunicationTest:
                            if (Suyi.CommunicationTest()) //通信测试环节
                            {
                                SetCmdCode(cmdJudgeSwitchStateCurrent1);
                            }
                            else
                            {
                                CurrentSetResult(ngCommunication);

                            }
                            break;
                        case cmdJudgeSwitchStateCurrent1:
                            //判断是否为分闸，由下位机开始做
                            if(Global.openLine) //产品分闸进入
                            {
                                if (Suyi.ReadSwitchState() == 1)//合闸状态
                                {
                                    CurrentSetResult(ngSwitchState2); //报警分合闸状态错误
                                }
                                else SetCmdCode(cmdCurrentCloseSwitch);
                            }
                            else if (Global.closeLine) //产品合闸进入
                            {
                                if (suyi.ReadSwitchState() == 2) //分闸状态
                                {
                                    CurrentSetResult(ngSwitchState2);//报警分合闸状态错误
                                }
                                else SetCmdCode(cmdEnterCurrentProof); //判定为合闸直接进入校对模式
                            }
                            break;
                        case cmdCurrentCloseSwitch:
                            if (Suyi.CloseSwitch())
                            {
                                SetCmdCode(cmdJudgeSwitchStateCurrent2);
                            }
                            else
                            {
                                CurrentSetResult(ngCloseSwitch);
                            }
                            //for (int i = 0; i < 30; i++)
                            //{
                            //    if (suyi.CloseSwitch())
                            //    {
                            //        if (suyi.ReadSwitchState() == 1) //如果已经合闸
                            //        {
                            //            SetCmdCode(cmdEnterCurrentProof);
                            //            closeSwitchErro = 0;
                            //            break;
                            //        }
                            //        else closeSwitchErro++;
                            //        if (closeSwitchErro == 30) //如果合闸失败次数达到30次
                            //        {
                            //            CurrentSetResult(ngCloseSwitch);//告诉plc NG
                            //            
                            //        }
                            //        Thread.Sleep(2000);
                            //    }
                            //}
                            break;
                        case cmdJudgeSwitchStateCurrent2: //判断产品合闸信号
                            for (int i = 0; i < 70; i++)
                            {
                                if (Suyi.ReadSwitchState() == 1)//合闸状态
                                {
                                    closeSwitch = true; //告诉plc输出判定开合闸状态
                                    break;
                                }
                                else closeSwitch = false;
                            }
                            if (closeSwitch)
                            {
                                SetCmdCode(cmdJudgeSwitchStateCurrent3);
                            }
                            else CurrentSetResult(ngCloseSwitch);
                            //else CurrentSetResult(ngCloseSwitch);
                            break;
                        case cmdJudgeSwitchStateCurrent3:
                            //plc进行合闸判断
                            break;
                        case cmdEnterCurrentProof:
                            if (Suyi.Debugging(SuyiMCCB.DataIdentification.EnterCurrentDebuggingMode))//进入调试模式成功
                            {
                                ///给plc里写设定的输出值

                                if (Global.doCurrent1)
                                {
                                    SetCmdCode(cmdCurrentOutput1);  //输出预设值1
                                }
                                else if (Global.doCurrent2)
                                {
                                    SetCmdCode(cmdCurrentOutput2);  //输出预设值2
                                }
                                else if (Global.doCurrent3)
                                {
                                    SetCmdCode(cmdCurrentOutput3);  //输出预设值3
                                }
                                else if (Global.doCurrent4)
                                {
                                    SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doCurrent5)
                                {
                                    SetCmdCode(cmdCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitCurrentProof);
                            }
                            else
                            {
                                CurrentSetResult(ngEnterProof);

                            }
                            break;
                        case cmdCurrentOutput1:
                            //plc输出预设电流1
                            break;
                        case cmdCurrentProof1Ready:
                            //plc输出预设电流1 记录输出值和产品校对前值
                            double[] readCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadCurrent);
                            if (readCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.CurrentProof1RecordA1, readCurrent[0]); //记录校验前的A值
                                WriteMemory(MemoryAddress.CurrentProof1RecordB1, readCurrent[1]); //记录校验前的B值
                                WriteMemory(MemoryAddress.CurrentProof1RecordC1, readCurrent[2]); //记录校验前的C值
                                SetCmdCode(cmdCurrentProof1Start);
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        ////////////////////////
                        case cmdCurrentProof1Start:    //校验1环节
                            double[] proofCurrentValue = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.CurrentProofreading1);
                            if (proofCurrentValue[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.CurrentProof1RecordA2, proofCurrentValue[0]); //记录校验后的A值
                                //WriteMemory(MemoryAddress.CurrentProof1RecordB2, proofCurrentValue[1]); //记录校验后的B值
                                //WriteMemory(MemoryAddress.CurrentProof1RecordC2, proofCurrentValue[2]); //记录校验后的C值
                                if (Global.presetCurrentValue1 != 0)  //非零位校对
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= (1 - Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue1) && (proofCurrentValue[i] <= (1 + Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue1)) //反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= 0) && (proofCurrentValue[i] <= Global.currentZero))//反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                if (proofResult)
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.doCurrent2)
                                        {
                                            SetCmdCode(cmdCurrentProof2Start);//通知plc输出预设电流2
                                        }
                                        else if (Global.doCurrent3)
                                        {
                                            SetCmdCode(cmdCurrentOutput3);  //输出预设值3
                                        }
                                        else if (Global.doCurrent4)
                                        {
                                            SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                        }
                                        else if (Global.doCurrent5)
                                        {
                                            SetCmdCode(cmdCurrentOutput5);  //输出预设值1
                                        }
                                        else SetCmdCode(cmdQuitCurrentProof);
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdCurrentJudge1);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        CurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        case cmdCurrentJudge1:
                            if (Global.proofJudge == 1)  //人工判定为合格
                            {
                                if (Global.doCurrent2)
                                {
                                    SetCmdCode(cmdCurrentProof2Start);//通知plc输出预设电流2
                                }
                                else if (Global.doCurrent3)
                                {
                                    SetCmdCode(cmdCurrentOutput3);  //输出预设值3
                                }
                                else if (Global.doCurrent4)
                                {
                                    SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doCurrent5)
                                {
                                    SetCmdCode(cmdCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitCurrentProof);
                            }
                            else if (Global.proofJudge == 2)  //人工判定为不合格
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    CurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdCurrentOutput2:
                            //plc输出预设电流2

                            break;
                        case cmdCurrentProof2Ready:
                            readCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadCurrent);
                            if (readCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.CurrentProof2RecordA1, readCurrent[0]); //记录校验前的A值
                                WriteMemory(MemoryAddress.CurrentProof2RecordB1, readCurrent[1]); //记录校验前的B值
                                WriteMemory(MemoryAddress.CurrentProof2RecordC1, readCurrent[2]); //记录校验前的C值
                                SetCmdCode(cmdCurrentProof2Start);
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        //////////////////////////////////////////////////////////
                        case cmdCurrentProof2Start:  //校验2环节
                            proofCurrentValue = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.CurrentProofreading2);
                            if (proofCurrentValue[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.CurrentProof2RecordA2, proofCurrentValue[0]); //记录校验后的A值
                                //WriteMemory(MemoryAddress.CurrentProof2RecordB2, proofCurrentValue[1]); //记录校验后的B值
                                //WriteMemory(MemoryAddress.CurrentProof2RecordC2, proofCurrentValue[2]); //记录校验后的C值
                                if (Global.presetCurrentValue2 != 0)  //非零位校对
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= (1 - Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue2) && (proofCurrentValue[i] <= (1 + Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue2)) //反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= 0) && (proofCurrentValue[i] <= Global.currentZero))//反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.doCurrent3)
                                        {
                                            SetCmdCode(cmdCurrentOutput3);  //输出预设值3
                                        }
                                        else if (Global.doCurrent4)
                                        {
                                            SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                        }
                                        else if (Global.doCurrent5)
                                        {
                                            SetCmdCode(cmdCurrentOutput5);  //输出预设值1
                                        }
                                        else SetCmdCode(cmdQuitCurrentProof);
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdCurrentJudge2);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    //SetCmdCode(cmdCurrentOutput1);
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        CurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        case cmdCurrentJudge2:
                            if (Global.proofJudge == 1)  //人工判定为合格
                            {
                                if (Global.doCurrent3)
                                {
                                    SetCmdCode(cmdCurrentOutput3);  //输出预设值3
                                }
                                else if (Global.doCurrent4)
                                {
                                    SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doCurrent5)
                                {
                                    SetCmdCode(cmdCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitCurrentProof);
                                Global.proofJudge = 0;
                            }
                            else if (Global.proofJudge == 2)  //人工判定为不合格
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    CurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdCurrentOutput3:
                            //plc输出预设电流3
                            break;
                        case cmdCurrentProof3Ready:
                            readCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadCurrent);
                            if (readCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.CurrentProof3RecordA1, readCurrent[0]); //记录校验前的A值
                                WriteMemory(MemoryAddress.CurrentProof3RecordB1, readCurrent[1]); //记录校验前的B值
                                WriteMemory(MemoryAddress.CurrentProof3RecordC1, readCurrent[2]); //记录校验前的C值
                                SetCmdCode(cmdCurrentProof3Start);
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        /////////////////////////////////////////////////////////////////////////////////
                        case cmdCurrentProof3Start:  //校验3环节
                            proofCurrentValue = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.CurrentProofreading3);
                            if (proofCurrentValue[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.CurrentProof3RecordA2, proofCurrentValue[0]); //记录校验后的A值
                                //WriteMemory(MemoryAddress.CurrentProof3RecordB2, proofCurrentValue[1]); //记录校验后的B值
                                //WriteMemory(MemoryAddress.CurrentProof3RecordC2, proofCurrentValue[2]); //记录校验后的C值
                                if (Global.presetCurrentValue3 != 0)  //非零位校对
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= (1 - Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue3) && (proofCurrentValue[i] <= (1 + Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue3)) //反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= 0) && (proofCurrentValue[i] <= Global.currentZero))//反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.currentProofNum_model1 > 3)  //如果校验档位大于3
                                        {
                                            if (Global.doCurrent4)
                                            {
                                                SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                            }
                                            else if (Global.currentProofNum_model1 == 5 && Global.doCurrent5)
                                            {
                                                SetCmdCode(cmdCurrentOutput5);  //输出预设值5
                                            }
                                            else SetCmdCode(cmdQuitCurrentProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdQuitCurrentProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdCurrentJudge3);
                                        Global.proofJudge = 0;
                                    }

                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        CurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        case cmdCurrentJudge3:
                            if (Global.proofJudge == 1)  //人工判定为合格
                            {
                                if (Global.doCurrent4)
                                {
                                    SetCmdCode(cmdCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doCurrent5)
                                {
                                    SetCmdCode(cmdCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitCurrentProof);
                            }
                            else if (Global.proofJudge == 2)  //人工判定为不合格
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    CurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdCurrentOutput4:
                            //plc输出预设电流4
                            break;
                        case cmdCurrentProof4Ready:
                            readCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadCurrent);
                            if (readCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.CurrentProof4RecordA1, readCurrent[0]); //记录校验前的A值
                                WriteMemory(MemoryAddress.CurrentProof4RecordB1, readCurrent[1]); //记录校验前的B值
                                WriteMemory(MemoryAddress.CurrentProof4RecordC1, readCurrent[2]); //记录校验前的C值
                                SetCmdCode(cmdCurrentProof4Start);
                            }
                            break;
                        //////////////////////////////////////////////////////
                        case cmdCurrentProof4Start:  //校验4环节
                            proofCurrentValue = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.CurrentProofreading4);
                            if (proofCurrentValue[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.CurrentProof4RecordA2, proofCurrentValue[0]); //记录校验后的A值
                                //WriteMemory(MemoryAddress.CurrentProof4RecordB2, proofCurrentValue[1]); //记录校验后的B值
                                //WriteMemory(MemoryAddress.CurrentProof4RecordC2, proofCurrentValue[2]); //记录校验后的C值
                                if (Global.presetCurrentValue4 != 0)  //非零位校对
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= (1 - Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue4) && (proofCurrentValue[i] <= (1 + Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue4)) //反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= 0) && (proofCurrentValue[i] <= Global.currentZero))//反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                if (proofResult)
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.currentProofNum_model1 > 4)  //如果校验档位大于4
                                        {
                                            if (Global.doCurrent5)
                                            {
                                                SetCmdCode(cmdCurrentOutput5);//通知plc输出预设电流5
                                            }
                                            else SetCmdCode(cmdQuitCurrentProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdQuitCurrentProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdCurrentJudge4);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        CurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        case cmdCurrentJudge4:
                            if (Global.proofJudge == 1)  //人工判定为合格
                            {
                                if (Global.currentProofNum_model1 > 4)  //如果校验档位大于4
                                {
                                    if (Global.doCurrent5)
                                    {
                                        SetCmdCode(cmdCurrentOutput5);//通知plc输出预设电流5
                                    }
                                    else SetCmdCode(cmdQuitCurrentProof);
                                }
                                else
                                {
                                    SetCmdCode(cmdQuitCurrentProof);
                                }
                            }
                            else if (Global.proofJudge == 2)  //人工判定为不合格
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    CurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdCurrentOutput5:
                            //plc输出预设电流5
                            break;
                        case cmdCurrentProof5Ready:  //该命令由plc记录输出值之后给出
                            readCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadCurrent);
                            if (readCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.CurrentProof5RecordA1, readCurrent[0]); //记录校验前的A值
                                WriteMemory(MemoryAddress.CurrentProof5RecordB1, readCurrent[1]); //记录校验前的B值
                                WriteMemory(MemoryAddress.CurrentProof5RecordC1, readCurrent[2]); //记录校验前的C值
                                SetCmdCode(cmdCurrentProof5Start);
                            }
                            break;
                        /////////////////////////////////////////////////////////
                        case cmdCurrentProof5Start:  //校验5环节
                            proofCurrentValue = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.CurrentProofreading5);
                            if (proofCurrentValue[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.CurrentProof5RecordA2, proofCurrentValue[0]); //记录校验后的A值
                                //WriteMemory(MemoryAddress.CurrentProof5RecordB2, proofCurrentValue[1]); //记录校验后的B值
                                //WriteMemory(MemoryAddress.CurrentProof5RecordC2, proofCurrentValue[2]); //记录校验后的C值
                                if (Global.presetCurrentValue5 != 0)  //非零位校对
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= (1 - Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue5) && (proofCurrentValue[i] <= (1 + Global.proofCurrentErrorRange / 100.00) * Global.presetCurrentValue5)) //反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < proofCurrentValue.Length; i++)
                                    {

                                        if ((proofCurrentValue[i] >= 0) && (proofCurrentValue[i] <= Global.currentZero))//反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }

                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.currentProofNum_model1 == 5)  //如果校验档位等于5
                                        {
                                            SetCmdCode(cmdQuitCurrentProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdCurrentJudge5);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        CurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else CurrentSetResult(ngCommunication);
                            break;
                        case cmdCurrentJudge5:
                            if (Global.proofJudge == 1)  //人工判定为合格
                            {
                                if (Global.currentProofNum_model1 == 5)  //如果校验档位等于5
                                {
                                    SetCmdCode(cmdQuitCurrentProof);
                                }
                            }
                            else if (Global.proofJudge == 2)  //人工判定为不合格
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    CurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdQuitCurrentProof:
                            if (Suyi.Debugging(SuyiMCCB.DataIdentification.QuitCurrentDebuggingMode))//退出电流校对模式
                            {

                                SetCmdCode(cmdCurrentCheckOutput);
                            }
                            break;
                        case cmdCurrentCheckOutput:
                            //plc输出设定的检验电流
                            break;
                        case cmdCurrentProofCheck:
                            double[] CurrentTestValue = Suyi.Read(SuyiMCCB.DataIdentification.ReadCurrent);
                            //记录校验成功检验时断路器反馈的值
                            WriteMemory(MemoryAddress.CurrentCheckReturnA, CurrentTestValue[0]);
                            WriteMemory(MemoryAddress.CurrentCheckReturnB, CurrentTestValue[1]);
                            WriteMemory(MemoryAddress.CurrentCheckReturnC, CurrentTestValue[2]);
                            for (int i = 0; i < CurrentTestValue.Length; i++)
                            {
                                if ((CurrentTestValue[i] >= (1 - Global.checkCurrentErrorRange / 100.00) * Global.currentCheck) && (CurrentTestValue[i] <= (1 + Global.checkCurrentErrorRange / 100.00) * Global.currentCheck)) //反馈的值在误差范围内
                                {
                                    proofResult = true;
                                }
                                else
                                {
                                    proofResult = false;
                                    break;
                                }
                            }
                            if (proofResult)
                            {
                                
                                SetCmdCode(cmdCurrentEnd); //调试完成
                            }
                            else
                            {
                                //不在误差范围内
                                CurrentSetResult(ngCheckFail);
                            }
                            break;

                        case cmdCurrentEnd:  //电流校对测试结束
                                             //告诉plc校验成功，并且记录输出的检测值
                            proofErro = 0;
                            SetCmdCode(cmdVoltageStart);
                            break;
                        case cmdVoltageStart:    //开始测试环节
                            proofErro = 0;
                            SetCmdCode(cmdVoltageCommunicationTest);
                            break;

                        case cmdVoltageCommunicationTest:
                            if (Suyi.CommunicationTest()) //通信测试环节
                            {
                                SetCmdCode(cmdJudgeSwitchStateVoltage);
                            }
                            else
                            {
                                VoltageSetResult(ngCommunication);

                            }
                            break;
                        case cmdJudgeSwitchStateVoltage:
                            //plc检测是否分合闸
                            break;
                        case cmdEnterVoltageProof:
                            if (Suyi.Debugging(SuyiMCCB.DataIdentification.EnterVoltageDebuggingMode))//进入电压调试模式成功
                            {
                                ///给plc里写设定的输出值

                                if (Global.doVoltage1)
                                {
                                    SetCmdCode(cmdVoltageOutput1);  //输出预设值1
                                }
                                else if (Global.doVoltage2)
                                {
                                    SetCmdCode(cmdVoltageOutput2);  //输出预设值2
                                }
                                else if (Global.doVoltage3)
                                {
                                    SetCmdCode(cmdVoltageOutput3);  //输出预设值3
                                }
                                else if (Global.doVoltage4)
                                {
                                    SetCmdCode(cmdVoltageOutput4);  //输出预设值4
                                }
                                else if (Global.doVoltage5)
                                {
                                    SetCmdCode(cmdVoltageOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitVoltageProof);
                            }
                            else
                            {
                                VoltageSetResult(ngEnterProof);

                            }
                            break;
                        case cmdVoltageOutput1:
                            //plc输出预设电压1
                            break;
                        case cmdVoltageProof1Ready:
                            //plc输出预设电压1 记录输出值(plc给出信号)
                            //记录产品校对前值
                            double[] readVoltage = Suyi.Read(SuyiMCCB.DataIdentification.ReadVoltage);
                            if (readVoltage[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.VoltageProof1RecordA1, readVoltage[0]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof1RecordB1, readVoltage[1]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof1RecordC1, readVoltage[2]); //记录校验前的值
                                SetCmdCode(cmdVoltageProof1Start);
                            }
                            break;
                        ////////////////////////
                        case cmdVoltageProof1Start:    //校验1环节
                            double[] proofVoltageValue1 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.VoltageProofreading1);
                            if (proofVoltageValue1[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.VoltageProof1RecordA2, proofVoltageValue1[0]);
                                //WriteMemory(MemoryAddress.VoltageProof1RecordB2, proofVoltageValue1[1]);
                                //WriteMemory(MemoryAddress.VoltageProof1RecordC2, proofVoltageValue1[2]);
                                if (Global.presetVoltageValue1 != 0)
                                {
                                    for (int i = 0; i < proofVoltageValue1.Length; i++)
                                    {
                                        if ((proofVoltageValue1[i] >= (1 - Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue1) && (proofVoltageValue1[i] <= (1 + Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue1)) //反馈的值在误差范围内
                                        {
                                            proofResult = true;
                                        }
                                        else
                                        {
                                            proofResult = false;
                                            break;
                                        }
                                    }
                                }

                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.doVoltage2)
                                        {
                                            SetCmdCode(cmdVoltageProof2Start);//通知plc输出预设电流2
                                        }
                                        else if (Global.doVoltage3)
                                        {
                                            SetCmdCode(cmdVoltageProof3Start);  //输出预设值3
                                        }
                                        else if (Global.doVoltage4)
                                        {
                                            SetCmdCode(cmdVoltageProof4Start);  //输出预设值4
                                        }
                                        else if (Global.doVoltage5)
                                        {
                                            SetCmdCode(cmdVoltageProof5Start);  //输出预设值1
                                        }
                                        else SetCmdCode(cmdQuitVoltageProof);
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdVoltageJudge1);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        VoltageSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                                }
                            }
                            else VoltageSetResult(ngCommunication);
                            break;
                        case cmdVoltageJudge1:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.doVoltage2)
                                {
                                    SetCmdCode(cmdVoltageProof2Start);//通知plc输出预设电流2
                                }
                                else if (Global.doVoltage3)
                                {
                                    SetCmdCode(cmdVoltageProof3Start);  //输出预设值3
                                }
                                else if (Global.doVoltage4)
                                {
                                    SetCmdCode(cmdVoltageProof4Start);  //输出预设值4
                                }
                                else if (Global.doVoltage5)
                                {
                                    SetCmdCode(cmdVoltageProof5Start);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitVoltageProof);
                            }
                            else
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    VoltageSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdVoltageOutput2:
                            //输出预设电压2
                            break;
                        case cmdVoltageProof2Ready:
                            readVoltage = Suyi.Read(SuyiMCCB.DataIdentification.ReadVoltage);
                            if (readVoltage[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.VoltageProof2RecordA1, readVoltage[0]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof2RecordB1, readVoltage[1]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof2RecordC1, readVoltage[2]); //记录校验前的值
                                SetCmdCode(cmdVoltageProof2Start);
                            }
                            break;
                        //////////////////////////////////////////////////////////
                        case cmdVoltageProof2Start:  //校验2环节
                            double[] proofVoltageValue2 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.VoltageProofreading2);
                            if (proofVoltageValue2[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.VoltageProof2RecordA2, proofVoltageValue2[0]); //记录校验后的值
                                //WriteMemory(MemoryAddress.VoltageProof2RecordB2, proofVoltageValue2[1]); //记录校验后的值
                                //WriteMemory(MemoryAddress.VoltageProof2RecordC2, proofVoltageValue2[2]); //记录校验后的值
                                for (int i = 0; i < proofVoltageValue2.Length; i++)
                                {
                                    if ((proofVoltageValue2[i] >= (1 - Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue2) && (proofVoltageValue2[i] <= (1 + Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue2)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else
                                    {
                                        proofResult = false;
                                        break;
                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.doVoltage3)
                                        {
                                            SetCmdCode(cmdVoltageProof3Start);  //输出预设值3
                                        }
                                        else if (Global.doVoltage4)
                                        {
                                            SetCmdCode(cmdVoltageProof4Start);  //输出预设值4
                                        }
                                        else if (Global.doVoltage5)
                                        {
                                            SetCmdCode(cmdVoltageProof5Start);  //输出预设值1
                                        }
                                        else SetCmdCode(cmdQuitVoltageProof);
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdVoltageJudge2);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    //SetCmdCode(cmdVoltageOutput1);
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        VoltageSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                                }
                            }
                            else VoltageSetResult(ngCommunication);

                            break;
                        case cmdVoltageJudge2:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.doVoltage3)
                                {
                                    SetCmdCode(cmdVoltageProof3Start);  //输出预设值3
                                }
                                else if (Global.doVoltage4)
                                {
                                    SetCmdCode(cmdVoltageProof4Start);  //输出预设值4
                                }
                                else if (Global.doVoltage5)
                                {
                                    SetCmdCode(cmdVoltageProof5Start);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitVoltageProof);
                            }
                            else
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    VoltageSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdVoltageOutput3:
                            //输出预设电压3
                            break;
                        case cmdVoltageProof3Ready:
                            readVoltage = Suyi.Read(SuyiMCCB.DataIdentification.ReadVoltage);
                            if (readVoltage[0] != -1) //获取当前电压值
                            {
                                WriteMemory(MemoryAddress.VoltageProof3RecordA1, readVoltage[0]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof3RecordB1, readVoltage[1]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof3RecordC1, readVoltage[2]); //记录校验前的值
                                SetCmdCode(cmdVoltageProof3Start);
                            }
                            break;
                        /////////////////////////////////////////////////////////////////////////////////
                        case cmdVoltageProof3Start:  //校验3环节
                            double[] proofVoltageValue3 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.VoltageProofreading3);
                            if (proofVoltageValue3[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.VoltageProof3RecordA2, proofVoltageValue3[0]);
                                //WriteMemory(MemoryAddress.VoltageProof3RecordB2, proofVoltageValue3[1]);
                                //WriteMemory(MemoryAddress.VoltageProof3RecordC2, proofVoltageValue3[2]);
                                for (int i = 0; i < proofVoltageValue3.Length; i++)
                                {
                                    if ((proofVoltageValue3[i] >= (1 - Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue3) && (proofVoltageValue3[i] <= (1 + Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue3)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else
                                    {
                                        proofResult = false;
                                        break;
                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.voltageProofNum_model1 > 3)  //如果校验档位大于3
                                        {
                                            if (Global.doVoltage4)
                                            {
                                                SetCmdCode(cmdVoltageProof4Start);  //输出预设值4
                                            }
                                            else if (Global.voltageProofNum_model1 == 5 && Global.doVoltage5)
                                            {
                                                SetCmdCode(cmdVoltageProof5Start);  //输出预设值5
                                            }
                                            else SetCmdCode(cmdQuitVoltageProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdQuitVoltageProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdVoltageJudge3);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        VoltageSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                                }
                            }
                            else VoltageSetResult(ngCommunication);
                            break;
                        case cmdVoltageJudge3:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.doVoltage4)
                                {
                                    SetCmdCode(cmdVoltageProof4Start);  //输出预设值4
                                }
                                else if (Global.doVoltage5)
                                {
                                    SetCmdCode(cmdVoltageProof5Start);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitVoltageProof);
                            }
                            else
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    VoltageSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdVoltageOutput4:
                            //输出预设电压4
                            break;
                        case cmdVoltageProof4Ready:
                            readVoltage = Suyi.Read(SuyiMCCB.DataIdentification.ReadVoltage);
                            if (readVoltage[0] != -1) //获取当前电压值
                            {
                                WriteMemory(MemoryAddress.VoltageProof4RecordA1, readVoltage[0]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof4RecordB1, readVoltage[1]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof4RecordC1, readVoltage[2]); //记录校验前的值
                                SetCmdCode(cmdVoltageProof4Start);
                            }
                            break;
                        //////////////////////////////////////////////////////
                        case cmdVoltageProof4Start:  //校验4环节
                            double[] proofVoltageValue4 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.VoltageProofreading4);
                            if (proofVoltageValue4[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.VoltageProof4RecordA2, proofVoltageValue4[0]);
                                //WriteMemory(MemoryAddress.VoltageProof4RecordB2, proofVoltageValue4[1]);
                                //WriteMemory(MemoryAddress.VoltageProof4RecordC2, proofVoltageValue4[2]);
                                for (int i = 0; i < proofVoltageValue4.Length; i++)
                                {
                                    if ((proofVoltageValue4[i] >= (1 - Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue4) && (proofVoltageValue4[i] <= (1 + Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue4)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else
                                    {
                                        proofResult = false;
                                        break;
                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.voltageProofNum_model1 > 4)  //如果校验档位大于4
                                        {
                                            if (Global.doVoltage5)
                                            {
                                                SetCmdCode(cmdVoltageProof5Start);//通知plc输出预设电压5
                                            }
                                            else SetCmdCode(cmdQuitVoltageProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdQuitVoltageProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdVoltageJudge4);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        VoltageSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                                }
                            }
                            else VoltageSetResult(ngCommunication);
                            break;
                        case cmdVoltageJudge4:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.voltageProofNum_model1 > 4)  //如果校验档位大于4
                                {
                                    if (Global.doVoltage5)
                                    {
                                        SetCmdCode(cmdVoltageProof5Start);//通知plc输出预设电压5
                                    }
                                    else SetCmdCode(cmdQuitVoltageProof);
                                }
                                else
                                {
                                    SetCmdCode(cmdQuitVoltageProof);
                                }
                            }
                            else
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    VoltageSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdVoltageOutput5:
                            //输出预设电压5

                            break;
                        case cmdVoltageProof5Ready:
                            readVoltage = Suyi.Read(SuyiMCCB.DataIdentification.ReadVoltage);
                            if (readVoltage[0] != -1) //获取当前电压值
                            {
                                WriteMemory(MemoryAddress.VoltageProof5RecordA1, readVoltage[0]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof5RecordB1, readVoltage[1]); //记录校验前的值
                                WriteMemory(MemoryAddress.VoltageProof5RecordB1, readVoltage[2]); //记录校验前的值
                                SetCmdCode(cmdVoltageProof5Start);
                            }
                            break;
                        /////////////////////////////////////////////////////////
                        case cmdVoltageProof5Start:  //校验5环节
                            double[] proofVoltageValue5 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.VoltageProofreading5);
                            if (proofVoltageValue5[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.VoltageProof5RecordA2, proofVoltageValue5[0]); //记录校验后的值
                                //WriteMemory(MemoryAddress.VoltageProof5RecordB2, proofVoltageValue5[1]); //记录校验后的值
                                //WriteMemory(MemoryAddress.VoltageProof5RecordC2, proofVoltageValue5[2]); //记录校验后的值
                                for (int i = 0; i < proofVoltageValue5.Length; i++)
                                {
                                    if ((proofVoltageValue5[i] >= (1 - Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue5) && (proofVoltageValue5[i] <= (1 + Global.proofVoltageErrorRange / 100.00) * Global.presetVoltageValue5)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else
                                    {
                                        proofResult = false;
                                        break;
                                    }
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.voltageProofNum_model1 == 5)  //如果校验档位等于5
                                        {
                                            SetCmdCode(cmdQuitVoltageProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdVoltageJudge5);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        VoltageSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                                }
                            }
                            else VoltageSetResult(ngCommunication);

                            break;
                        case cmdVoltageJudge5:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.voltageProofNum_model1 == 5)  //如果校验档位等于5
                                {
                                    SetCmdCode(cmdQuitVoltageProof);
                                }
                            }
                            else
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    VoltageSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdVoltageOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdQuitVoltageProof:
                            if (Suyi.Debugging(SuyiMCCB.DataIdentification.QuitVoltageDebuggingMode))//退出电压校对模式
                            {
                                SetCmdCode(cmdVoltageCheckOutput);
                            }
                            break;
                        case cmdVoltageCheckOutput:
                            //输出校验检验电压
                            break;
                        case cmdVoltageProofCheck:
                            double[] VoltageTestValue = Suyi.Read(SuyiMCCB.DataIdentification.ReadVoltage);
                            //记录校验成功检验时断路器反馈的值
                            WriteMemory(MemoryAddress.VolatgeCheckReturnA, VoltageTestValue[0]);
                            WriteMemory(MemoryAddress.VolatgeCheckReturnB, VoltageTestValue[1]);
                            WriteMemory(MemoryAddress.VolatgeCheckReturnC, VoltageTestValue[2]);
                            for (int i = 0; i < VoltageTestValue.Length; i++)
                            {
                                if ((VoltageTestValue[i] >= (1 - Global.checkVoltageErrorRange / 100.00) * Global.voltageCheck) && (VoltageTestValue[i] <= (1 + Global.checkVoltageErrorRange / 100.00) * Global.voltageCheck)) //反馈的值在误差范围内
                                {
                                    proofResult = true;
                                }
                                else
                                {
                                    proofResult = false;
                                    break;
                                }
                            }
                            if (proofResult) //判断是否在误差范围内
                            {
                                
                                SetCmdCode(cmdVoltageEnd); //调试完成
                            }
                            else
                            {
                                //不在误差范围内
                                VoltageSetResult(ngCheckFail);
                            }
                            break;

                        case cmdVoltageEnd:  //电压校对测试结束
                            proofErro = 0;
                            SetCmdCode(cmdResidualCurrentStart);
                            break;
                        case cmdResidualCurrentStart:    //开始测试环节
                            proofErro = 0;
                            SetCmdCode(cmdResidualCurrentCommunicationTest);
                            break;

                        case cmdResidualCurrentCommunicationTest:
                            if (Suyi.CommunicationTest()) //通信测试环节
                            {
                                SetCmdCode(cmdJudgeSwitchStateResidualCurrent);
                            }
                            else
                            {
                                ResidualCurrentSetResult(ngCommunication);

                            }
                            break;
                        case cmdJudgeSwitchStateResidualCurrent:
                            //plc输出判断分合闸状态
                            break;
                        case cmdEnterResidualCurrentProof:
                            if (Suyi.Debugging(SuyiMCCB.DataIdentification.EnterResidualCurrentDebuggingMode))//进入调试模式成功
                            {
                                ///给plc里写设定的输出值

                                if (Global.doResidualCurrent1)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput1);  //输出预设值1
                                }
                                else if (Global.doResidualCurrent2)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput2);  //输出预设值2
                                }
                                else if (Global.doResidualCurrent3)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput3);  //输出预设值3
                                }
                                else if (Global.doResidualCurrent4)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doResidualCurrent5)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值5
                                }
                                else SetCmdCode(cmdQuitResidualCurrentProof);
                            }
                            else
                            {
                                ResidualCurrentSetResult(ngEnterProof);

                            }
                            break;
                        case cmdResidualCurrentOutput1:
                            //输出预设剩余电流1
                            break;

                        case cmdResidualCurrentProof1Ready:
                            //plc输出预设剩余电流1 记录输出值和产品校对前值
                            double[] readResidualCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadResidualCurrent);
                            if (readResidualCurrent[0] != -1) //获取当前剩余电流值
                            {
                                WriteMemory(MemoryAddress.ResidualCurrentProof1Record1, readResidualCurrent[0]); //记录校验前的值
                                SetCmdCode(cmdResidualCurrentProof1Start);
                            }
                            break;
                        ////////////////////////
                        case cmdResidualCurrentProof1Start:    //校验1环节开始
                            Thread.Sleep(Global.delayTime);
                            double[] proofResidualCurrentValue1 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ResidualCurrentProofreading1);
                            if (proofResidualCurrentValue1[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.ResidualCurrentProof1Record2, proofResidualCurrentValue1[0]);
                                if (Global.presetResidualCurrentValue1 != 0)
                                {
                                    if ((proofResidualCurrentValue1[0] >= (1 - Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue1) && (proofResidualCurrentValue1[0] <= (1 + Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue1)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                else
                                {
                                    if ((proofResidualCurrentValue1[0] >= 0) && (proofResidualCurrentValue1[0] <= Global.residualCurrentZero)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.doResidualCurrent2)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput2);//通知plc输出预设剩余电流2
                                        }
                                        else if (Global.doResidualCurrent3)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput3);  //输出预设值3
                                        }
                                        else if (Global.doResidualCurrent4)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                        }
                                        else if (Global.doResidualCurrent5)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值1
                                        }
                                        else SetCmdCode(cmdQuitResidualCurrentProof);
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdResidualJudge1);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        ResidualCurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else ResidualCurrentSetResult(ngCommunication);
                            break;
                        case cmdResidualJudge1:
                            if (Global.proofJudge==1)
                            {
                                if (Global.doResidualCurrent2)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput2);//通知plc输出预设剩余电流2
                                }
                                else if (Global.doResidualCurrent3)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput3);  //输出预设值3
                                }
                                else if (Global.doResidualCurrent4)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doResidualCurrent5)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitResidualCurrentProof);
                            }
                            else if (Global.proofJudge==2)
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    ResidualCurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdResidualCurrentOutput2:
                            //输出剩余电流2
                            break;

                        case cmdResidualCurrentProof2Ready:
                            readResidualCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadResidualCurrent);
                            if (readResidualCurrent[0] != -1) //获取当前剩余电流值
                            {
                                WriteMemory(MemoryAddress.ResidualCurrentProof2Record1, readResidualCurrent[0]); //记录校验前的值
                                SetCmdCode(cmdResidualCurrentProof2Start);
                            }
                            break;
                        //////////////////////////////////////////////////////////
                        case cmdResidualCurrentProof2Start:  //校验2环节
                            Thread.Sleep(Global.delayTime);
                            double[] proofResidualCurrentValue2 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ResidualCurrentProofreading2);
                            if (proofResidualCurrentValue2[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.ResidualCurrentProof2Record2, proofResidualCurrentValue2[0]);
                                if (Global.presetResidualCurrentValue2 != 0)
                                {
                                    if ((proofResidualCurrentValue2[0] >= (1 - Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue2) && (proofResidualCurrentValue2[0] <= (1 + Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue2)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                else
                                {
                                    if ((proofResidualCurrentValue2[0] >= 0) && (proofResidualCurrentValue2[0] <= Global.residualCurrentZero)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.doResidualCurrent3)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput3);  //输出预设值3
                                        }
                                        else if (Global.doResidualCurrent4)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                        }
                                        else if (Global.doResidualCurrent5)
                                        {
                                            SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值1
                                        }
                                        else SetCmdCode(cmdQuitResidualCurrentProof);
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdResidualJudge2);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    //SetCmdCode(cmdResidualCurrentOutput1);
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        ResidualCurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else ResidualCurrentSetResult(ngCommunication);
                            break;

                        case cmdResidualJudge2:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.doResidualCurrent3)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput3);  //输出预设值3
                                }
                                else if (Global.doResidualCurrent4)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doResidualCurrent5)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitResidualCurrentProof);
                            }
                            else if (Global.proofJudge == 2)
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    ResidualCurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                            }
                            break;

                        case cmdResidualCurrentOutput3:
                            //输出预设剩余电流3
                            //plc要记录输出值
                            break;

                        case cmdResidualCurrentProof3Ready:
                            readResidualCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadResidualCurrent);
                            if (readResidualCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.ResidualCurrentProof3Record1, readResidualCurrent[0]); //记录校验前的值
                                SetCmdCode(cmdResidualCurrentProof3Start);
                            }
                            break;
                        /////////////////////////////////////////////////////////////////////////////////
                        case cmdResidualCurrentProof3Start:  //校验3环节
                            Thread.Sleep(Global.delayTime);
                            double[] proofResidualCurrentValue3 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ResidualCurrentProofreading3);
                            if (proofResidualCurrentValue3[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.ResidualCurrentProof3Record2, proofResidualCurrentValue3[0]);
                                if (Global.presetResidualCurrentValue3 != 0)
                                {
                                    if ((proofResidualCurrentValue3[0] >= (1 - Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue3) && (proofResidualCurrentValue3[0] <= (1 + Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue3)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                else
                                {
                                    if ((proofResidualCurrentValue3[0] >= 0) && (proofResidualCurrentValue3[0] <= Global.residualCurrentZero)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.currentProofNum_model1 > 3)  //如果校验档位大于3
                                        {
                                            if (Global.doResidualCurrent4)
                                            {
                                                SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                            }
                                            else if (Global.currentProofNum_model1 == 5 && Global.doResidualCurrent5)
                                            {
                                                SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值5
                                            }
                                            else SetCmdCode(cmdQuitResidualCurrentProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdQuitResidualCurrentProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdResidualJudge3);
                                        Global.proofJudge = 0;
                                    }

                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        ResidualCurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else ResidualCurrentSetResult(ngCommunication);
                            break;

                        case cmdResidualJudge3:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.doResidualCurrent4)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput4);  //输出预设值4
                                }
                                else if (Global.doResidualCurrent5)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput5);  //输出预设值1
                                }
                                else SetCmdCode(cmdQuitResidualCurrentProof);
                            }
                            else if (Global.proofJudge == 2)
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    ResidualCurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                            }
                            break;

                        case cmdResidualCurrentOutput4:
                            //输出预设剩余电流4
                            break;

                        case cmdResidualCurrentProof4Ready:
                            readResidualCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadResidualCurrent);
                            if (readResidualCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.ResidualCurrentProof4Record1, readResidualCurrent[0]); //记录校验前的值
                                SetCmdCode(cmdResidualCurrentProof4Start);
                            }
                            break;
                        //////////////////////////////////////////////////////
                        case cmdResidualCurrentProof4Start:  //校验4环节
                            Thread.Sleep(Global.delayTime);
                            double[] proofResidualCurrentValue4 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ResidualCurrentProofreading4);
                            if (proofResidualCurrentValue4[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.ResidualCurrentProof4Record2, proofResidualCurrentValue4[0]);
                                if (Global.presetResidualCurrentValue4 != 0)
                                {
                                    if ((proofResidualCurrentValue4[0] >= (1 - Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue4) && (proofResidualCurrentValue4[0] <= (1 + Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue4)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                else
                                {
                                    if ((proofResidualCurrentValue4[0] >= 0) && (proofResidualCurrentValue4[0] <= Global.residualCurrentZero)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.currentProofNum_model1 > 4)  //如果校验档位大于4
                                        {
                                            if (Global.doResidualCurrent5)
                                            {
                                                SetCmdCode(cmdResidualCurrentOutput5);//通知plc输出预设电流5
                                            }
                                            else SetCmdCode(cmdQuitResidualCurrentProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdQuitResidualCurrentProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdResidualJudge4);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        ResidualCurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                                }
                            }
                            else ResidualCurrentSetResult(ngCommunication);
                            break;
                        case cmdResidualJudge4:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.currentProofNum_model1 > 4)  //如果校验档位大于4
                                {
                                    if (Global.doResidualCurrent5)
                                    {
                                        SetCmdCode(cmdResidualCurrentOutput5);//通知plc输出预设电流5
                                    }
                                    else SetCmdCode(cmdQuitResidualCurrentProof);
                                }
                                else
                                {
                                    SetCmdCode(cmdQuitResidualCurrentProof);
                                }
                            }
                            else if (Global.proofJudge == 2)
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    ResidualCurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdResidualCurrentOutput5:
                            //输出预设剩余电流5
                            break;
                        case cmdResidualCurrentProof5Ready:
                            readResidualCurrent = Suyi.Read(SuyiMCCB.DataIdentification.ReadResidualCurrent);
                            if (readResidualCurrent[0] != -1) //获取当前电流值
                            {
                                WriteMemory(MemoryAddress.ResidualCurrentProof5Record1, readResidualCurrent[0]); //记录校验前的值
                                SetCmdCode(cmdResidualCurrentProof5Start);
                            }
                            break;
                        /////////////////////////////////////////////////////////
                        case cmdResidualCurrentProof5Start:  //校验5环节
                            Thread.Sleep(Global.delayTime);
                            double[] proofResidualCurrentValue5 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ResidualCurrentProofreading5);
                            if (proofResidualCurrentValue5[0] != -1)
                            {
                                //WriteMemory(MemoryAddress.ResidualCurrentProof5Record2, proofResidualCurrentValue5[0]);
                                if (Global.presetResidualCurrentValue5 != 0)
                                {
                                    if ((proofResidualCurrentValue5[0] >= (1 - Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue5) && (proofResidualCurrentValue5[0] <= (1 + Global.proofResidualCurrentErrorRange / 100.00) * Global.presetResidualCurrentValue5)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                else
                                {
                                    if ((proofResidualCurrentValue5[0] >= 0) && (proofResidualCurrentValue5[0] <= Global.residualCurrentZero)) //反馈的值在误差范围内
                                    {
                                        proofResult = true;
                                    }
                                    else proofResult = false;
                                }
                                if (proofResult) //反馈的值在误差范围内
                                {
                                    if (!Global.manualJudge)
                                    {
                                        if (Global.currentProofNum_model1 == 5)  //如果校验档位等于5
                                        {
                                            SetCmdCode(cmdQuitResidualCurrentProof);
                                        }
                                    }
                                    else
                                    {
                                        SetCmdCode(cmdResidualJudge5);
                                        Global.proofJudge = 0;
                                    }
                                }
                                else
                                {
                                    proofErro++;
                                    if (proofErro > proofErrorMax)
                                    {
                                        ResidualCurrentSetResult(ngProofFail);

                                    }
                                    else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                                }
                            }

                            break;
                        case cmdResidualJudge5:
                            if (Global.proofJudge == 1)
                            {
                                if (Global.doResidualCurrent5)
                                {
                                    SetCmdCode(cmdResidualCurrentOutput5);//通知plc输出预设电流5
                                }
                                else SetCmdCode(cmdQuitResidualCurrentProof);
                            }
                            else if (Global.proofJudge == 2)
                            {
                                proofErro++;
                                if (proofErro > proofErrorMax)
                                {
                                    ResidualCurrentSetResult(ngProofFail);

                                }
                                else SetCmdCode(cmdResidualCurrentOutput1);//从校对1重新开始做
                            }
                            break;
                        case cmdQuitResidualCurrentProof:
                            if (Suyi.Debugging(SuyiMCCB.DataIdentification.QuitResidualCurrentDebuggingMode))//退出电流校对模式
                            {
                                SetCmdCode(cmdResidualCurrentCheckOutput);
                            }
                            break;
                        case cmdResidualCurrentCheckOutput:
                            // output residualcheck
                            break;
                        case cmdResidualCurrentProofCheck:
                            Thread.Sleep(Global.delayTime);
                            double[] ResidualCurrentTestValue = Suyi.Read(SuyiMCCB.DataIdentification.ReadResidualCurrent);
                            //记录校验成功检验时断路器反馈的值
                            WriteMemory(MemoryAddress.ResidualCurrentCheckReturn, ResidualCurrentTestValue[0]);
                            if ((ResidualCurrentTestValue[0] >= (1 - Global.checkResidualCurrentErrorRange / 100.00) * Global.residualCurrentCheck) && (ResidualCurrentTestValue[0] <= (1 + Global.checkResidualCurrentErrorRange / 100.00) * Global.residualCurrentCheck)) //判断是否在误差范围内
                            {
                                

                                if (Global.meachineAge)
                                {
                                    meachineNum = Global.meachineTestNum;
                                    if (meachineNum > 0)
                                    {
                                        SetCmdCode(cmdOpenSwitch);
                                    }
                                    else SetCmdCode(cmdResidualCurrentEnd);
                                }
                                else SetCmdCode(cmdResidualCurrentEnd); //调试完成
                            }
                            else
                            {
                                //不在误差范围内
                                ResidualCurrentSetResult(ngCheckFail);
                            }
                            break;

                        case cmdResidualCurrentEnd:  //剩余电流校对测试结束
                            proofErro = 0;
                            break;
                        case cmdOpenSwitch:

                            if (suyi.OpenSwitch())
                            {
                                for (int i = 0; i < 65; i++)
                                {
                                    if (suyi.ReadSwitchState() == 2)
                                    {
                                        openSwitch = true;
                                        break;
                                    }
                                    else openSwitch = false;
                                }
                                if (openSwitch)
                                {
                                    SetCmdCode(cmdJudgeSwitch);
                                }
                                else ResidualCurrentSetResult(ngOpenSwitch);
                            }
                            else ResidualCurrentSetResult(ngCommunication);
                            break;
                        case cmdJudgeSwitch:

                            break;
                        case cmdCloseSwtich:
                            if (suyi.CloseSwitch())
                            {

                                for (int i = 0; i < 65; i++)
                                {
                                    if (suyi.ReadSwitchState() == 1)
                                    {
                                        closeSwitch = true;
                                        break;
                                    }
                                    else closeSwitch = false;
                                }
                                if (closeSwitch)
                                {
                                    SetCmdCode(cmdJudgeSwitch1);
                                }
                                else ResidualCurrentSetResult(ngCloseSwitch);
                            }
                            break;
                        case cmdJudgeSwitch1:

                            break;
                        case cmdJudgeEnd:
                            meachineNum--;
                            if (meachineNum > 0)
                            {
                                SetCmdCode(cmdOpenSwitch);
                            }
                            else SetCmdCode(cmdResidualCurrentEnd);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex);
                }
            }

        }

        private int GetWorkState()
        {

            return ReadMemory(MemoryAddress.workState.ToString());

        }
        private int GetCmdCode()
        {
            return ReadMemory(((int)MemoryAddress.CmdCode).ToString());
        }
        private void SetCmdCode(int data)
        {
            WriteMemory(MemoryAddress.CmdCode, data);

        }
        private bool CurrentGetResult()
        {
            if (ReadMemory(MemoryAddress.CurrentTestResult.ToString()) == ngReset)
            {
                return true;
            }
            else return false;


        }
        private void CurrentSetResult(int data)
        {
            WriteMemory(MemoryAddress.CurrentTestResult, data);
            WriteMemory(MemoryAddress.CmdCode, 0);


        }
        private void VoltageSetResult(int data)
        {
            WriteMemory(MemoryAddress.VoltageTestResult, data);


        }
        private void ResidualCurrentSetResult(int data)
        {
            WriteMemory(MemoryAddress.ResidualCurrentTestResult, data);

        }
        private void WriteMemory(MemoryAddress address, int data)
        {

            Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, ((int)address).ToString(), data);

        }
        private void WriteMemory(MemoryAddress address, double data)
        {
            uint[] dataReturn = DoubleConvert.Real_to_2Int((float)data);
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, ((int)address).ToString(), (int)dataReturn[1]);
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, ((int)(address) + 1).ToString(), (int)dataReturn[0]);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private int ReadMemory(string address)
        {
            return Global.kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, address);

        }

        public enum MemoryAddress : int
        {
            workState,
            CmdCode = 3601,
            CurrentTestResult,
            VoltageTestResult,
            ResidualCurrentTestResult,
            //******************************************//
            CurrentProof1RecordA1 = 10832, //1代表记录前 2代表记录后
            CurrentProof1RecordB1 = 10834, //1代表记录前 2代表记录后
            CurrentProof1RecordC1 = 10836, //1代表记录前 2代表记录后
            CurrentProof1RecordA2 = 10838, //2代表记录前 2代表记录后
            CurrentProof1RecordB2 = 10840, //2代表记录前 2代表记录后
            CurrentProof1RecordC2 = 10842, //2代表记录前 2代表记录后
            //*************************************************//
            CurrentProof2RecordA1 = 10844, //1代表记录前 2代表记录后
            CurrentProof2RecordB1 = 10846, //1代表记录前 2代表记录后
            CurrentProof2RecordC1 = 10848, //1代表记录前 2代表记录后
            CurrentProof2RecordA2 = 10850, //2代表记录前 2代表记录后
            CurrentProof2RecordB2 = 10852, //2代表记录前 2代表记录后
            CurrentProof2RecordC2 = 10854, //2代表记录前 2代表记录后
            //************************************************//
            CurrentProof3RecordA1 = 10856, //1代表记录前 2代表记录后
            CurrentProof3RecordB1 = 10858, //1代表记录前 2代表记录后
            CurrentProof3RecordC1 = 10860, //1代表记录前 2代表记录后
            CurrentProof3RecordA2 = 10862, //2代表记录前 2代表记录后
            CurrentProof3RecordB2 = 10864, //2代表记录前 2代表记录后
            CurrentProof3RecordC2 = 10866, //2代表记录前 2代表记录后
            //*************************************************//
            CurrentProof4RecordA1 = 10868, //1代表记录前 2代表记录后
            CurrentProof4RecordB1 = 10870, //1代表记录前 2代表记录后
            CurrentProof4RecordC1 = 10872, //1代表记录前 2代表记录后
            CurrentProof4RecordA2 = 10874, //2代表记录前 2代表记录后
            CurrentProof4RecordB2 = 10876, //2代表记录前 2代表记录后
            CurrentProof4RecordC2 = 10878, //2代表记录前 2代表记录后
            //*************************************************//
            CurrentProof5RecordA1 = 10880, //1代表记录前 2代表记录后
            CurrentProof5RecordB1 = 10882, //1代表记录前 2代表记录后
            CurrentProof5RecordC1 = 10884, //1代表记录前 2代表记录后  
            CurrentProof5RecordA2 = 10886, //2代表记录前 2代表记录后
            CurrentProof5RecordB2 = 10888, //2代表记录前 2代表记录后
            CurrentProof5RecordC2 = 10890, //2代表记录前 2代表记录后
            CurrentCheckReturnA = 10892,
            CurrentCheckReturnB = 10894,
            CurrentCheckReturnC = 10896,

            /// <summary>
            /// 电压
            /// </summary>
            VoltageProof1RecordA1 = 10910, //1代表记录前 2代表记录后
            VoltageProof1RecordB1 = 10912, //1代表记录前 2代表记录后
            VoltageProof1RecordC1 = 10914, //1代表记录前 2代表记录后
            VoltageProof1RecordA2 = 10916, //1代表记录前 2代表记录后
            VoltageProof1RecordB2 = 10918, //1代表记录前 2代表记录后
            VoltageProof1RecordC2 = 10920, //1代表记录前 2代表记录后
            VoltageProof2RecordA1 = 10922, //1代表记录前 2代表记录后
            VoltageProof2RecordB1 = 10924, //1代表记录前 2代表记录后
            VoltageProof2RecordC1 = 10926, //1代表记录前 2代表记录后
            VoltageProof2RecordA2 = 10928, //1代表记录前 2代表记录后
            VoltageProof2RecordB2 = 10930, //1代表记录前 2代表记录后
            VoltageProof2RecordC2 = 10932, //1代表记录前 2代表记录后
            VoltageProof3RecordA1 = 10934, //1代表记录前 2代表记录后
            VoltageProof3RecordB1 = 10936, //1代表记录前 2代表记录后
            VoltageProof3RecordC1 = 10938, //1代表记录前 2代表记录后
            VoltageProof3RecordA2 = 10940, //1代表记录前 2代表记录后
            VoltageProof3RecordB2 = 10942, //1代表记录前 2代表记录后
            VoltageProof3RecordC2 = 10944, //1代表记录前 2代表记录后
            VoltageProof4RecordA1 = 10946, //1代表记录前 2代表记录后
            VoltageProof4RecordB1 = 10948, //1代表记录前 2代表记录后
            VoltageProof4RecordC1 = 10950, //1代表记录前 2代表记录后
            VoltageProof4RecordA2 = 10952, //1代表记录前 2代表记录后
            VoltageProof4RecordB2 = 10954, //1代表记录前 2代表记录后
            VoltageProof4RecordC2 = 10956, //1代表记录前 2代表记录后
            VoltageProof5RecordA1 = 10958, //1代表记录前 2代表记录后
            VoltageProof5RecordB1 = 10960, //1代表记录前 2代表记录后
            VoltageProof5RecordC1 = 10962, //1代表记录前 2代表记录后
            VoltageProof5RecordA2 = 10964, //1代表记录前 2代表记录后
            VoltageProof5RecordB2 = 10966, //1代表记录前 2代表记录后
            VoltageProof5RecordC2 = 10968, //1代表记录前 2代表记录后
            VolatgeCheckReturnA = 10970,
            VolatgeCheckReturnB = 10972,
            VolatgeCheckReturnC = 10974,
            /// <summary>
            /// 剩余电流
            /// </summary>
            ResidualCurrentProof1Record1 = 10988,//1代表记录前 2代表记录后
            ResidualCurrentProof1Record2 = 10990,
            ResidualCurrentProof2Record1 = 10992,
            ResidualCurrentProof2Record2 = 10994,
            ResidualCurrentProof3Record1 = 10996,
            ResidualCurrentProof3Record2 = 10998,
            ResidualCurrentProof4Record1 = 11000,
            ResidualCurrentProof4Record2 = 11002,
            ResidualCurrentProof5Record1 = 11004,
            ResidualCurrentProof5Record2 = 11006,
            ResidualCurrentCheckReturn = 11008,
        }
    }
}

