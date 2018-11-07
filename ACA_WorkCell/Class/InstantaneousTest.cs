/*
 * 瞬时测试自动流程代码
 * cmd为控制码/
 * ng为异常码
 * *********************************************************************************************************
 * 正常工作流程（瞬时校对（B->C->A三相）高低倍测试） 2018/06/01
 * 添加分合闸状态判断（原本由通信读取产品分合闸状态，现加入物理（输出形式）判断）2018/06/03
 * 添加用户功能选择（所有流程由用户决定是否做，如不勾选即不做） 2018/06/03
 * 添加瞬时人工判断（选择人工判断，需要等待人工确认进行下一步） 2018/07/05
 * 添加校对峰值判断（通信获取产品瞬时峰值和相位（需要记录）,与实际瞬时值和施加相位比较，在判断误差范围内为合格） 2018/07/08
 * 添加高低倍跳闸保护记录（高低倍测试时如果跳闸，读取产品跳闸记录，分析跳闸原因以及跳闸相位与实际判断） 2018/07/20
 * 添加产品瞬时结束最终分闸保证（结束前判断产品分合闸状态，分闸继续，合闸先分闸再继续,确保产品能够以分闸的形式出去，到整机测试） 2018/07/25
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
using log4net;
using log4net.Config;

namespace ACA_Common.Class
{
    /// <summary>
    /// 瞬时检测工作类
    /// </summary>
    public class InstantaneousTest  //瞬时检验单元
    {
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
        private int meachineNum;
        private bool closeSwitch = false;
        private bool openSwitch = false;
        private bool autoWork = false;
        private const int auto = 1;
        private const int semiAuto = 2;
        private const int stop = 3;
        public const int cmdReady = 0;
        public const int cmdInstantaneousStart = 1; //瞬时测试开始
        public const int cmdCommunicationTest = 2; //通信测试
        public const int cmdJudgeSwitchState1 = 3; //判断分合闸状态
        public const int cmdEnterProof = 4;  //进入瞬时校对模式
        public const int cmdOutput1 = 5;  //瞬时输出1
        public const int cmdReadPeakValue1 = 6; //读取瞬时峰值1
        public const int cmdGetSwitchState1 = 7; //获取分合闸状态1
        public const int cmdOutput2 = 8;
        public const int cmdReadPeakValue2 = 9;
        public const int cmdGetSwitchState2 = 10;
        public const int cmdOutput3 = 11;
        public const int cmdReadPeakValue3 = 12;
        public const int cmdGetSwitchState3 = 13;
        public const int cmdLowTimes = 14; //输出低倍瞬时
        public const int cmdReadSwitch1 = 15;
        public const int cmdHighTimes = 16; //输高倍瞬时出
        public const int cmdReadSwitch2 = 17;
        public const int cmdQuitProof = 18; //退出瞬时校对模式
        public const int cmdJudgeSwitchState2 = 19;
        public const int cmdCloseSwitch = 20;  //通信合闸
        public const int cmdJudgeSwitchState3 = 21;
        public const int cmdJudgeSwitchState4 = 22;
        public const int cmdInstantaneousEnd = 23; //瞬时测试结束
        public const int cmdEnterproof1 = 31; //再次进入瞬时校对模式
        public const int cmdCloseVoltage = 30; //通信合闸
        public const int cmdRecordLow = 32;  //记录低倍跳闸保护记录
        public const int cmdRecordEnd = 33; 
        public const int cmdJudgeDoMeachine = 40; //判断是否最机械寿命
        public const int cmdOpenSwitch = 41;  //通信分闸
        public const int cmdJudgeSwitch = 42;
        public const int cmdCloseSwtich = 43;
        public const int cmdJudgeSwitch1 = 44;
        public const int cmdJudgeEnd = 45;
        public const int cmdInsJudge1 = 46;
        public const int cmdInsJudge2 = 47;
        public const int cmdInsJudge3 = 48;
        public const int cmdInsJudge4 = 49;
        public const int cmdInsJudge5 = 50;
        public const int cmdJudgeOpenSwitch = 51;
        public const int cmdOpenSwitchFinally = 52; //最终分闸执行，确保瞬时结束产品以分闸形式出去
        public const int cmdJudgeOpenSwitchPlc1= 53;
        public const int cmdJudgeOpenSwitchPlc2= 54;
        public const int ngReset = 0;
        public const int ngCommunication = 1;  //通信异常
        public const int ngCloseSwitch = 2;    //合闸失败
        public const int ngEnterProof = 3;     //进入瞬时校对失败
        public const int ngProofFailB = 4;     //B相瞬时校对失败
        public const int ngProofFailC = 5;     //C相瞬时校对失败
        public const int ngProofFailA = 6;     //A相瞬时校对失败
        public const int ngProofFailLow = 7;   //低倍测试失败
        public const int ngProofFailHigh = 8;  //高倍测试失败
        public const int ngSwitchState = 9;    //分合闸状态异常
        public const int ngPlcError = 10;      //plc电气异常
        public const int ngQuitProof = 11;     //退出瞬时校对失败
        public const int ngOpenSwitch = 12;    //分闸失败
        private double[] actualPeakValue1;     
        private double[] actualPeakValue2;
        private double[] actualPeakValue3;
        private const double phaseA = 1;
        private const double phaseB = 2;
        private const double phaseC = 4;
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

        public bool AutoWork { get { return autoWork; } set { autoWork = value; } }

        public void AutoInstantaneousTest()
        {

            while (AutoWork)
            {
                int cmdId = GetCmdCode();

                switch (cmdId)
                {
                    case cmdReady:
                        //SetCmdCode(cmdInstantaneousStart);
                        break;
                    case cmdInstantaneousStart:
                        break;
                    case cmdCommunicationTest:
                        if (Suyi.CommunicationTest()) //通信测试环节
                        {
                            SetCmdCode(cmdJudgeSwitchState1);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitchState1:
                        //plc进行开合闸状态判断
                        break;
                    case cmdEnterProof:
                        if (Suyi.Debugging(SuyiMCCB.DataIdentification.EnterTransientCurrentMode))//进入调试模式成功
                        {
                            if (Global.doOutPut1)
                            {
                                SetCmdCode(cmdOutput1);  //输出预设值1
                            }
                            else if (Global.doOutPut2)
                            {
                                SetCmdCode(cmdOutput2);
                            }
                            else if (Global.doOutPut3)
                            {
                                SetCmdCode(cmdOutput3);
                            }
                            else if (Global.doLow)
                            {
                                SetCmdCode(cmdLowTimes);
                            }
                            else if (Global.doHigh)
                            {
                                SetCmdCode(cmdHighTimes);
                            }
                            else SetCmdCode(cmdQuitProof);

                        }
                        else SetResult(ngEnterProof);
                        break;
                    case cmdOutput1:
                        //plc输出1
                        break;
                    case cmdReadPeakValue1:
                        if (suyi.ReadSwitchState() == 1)
                        {
                            Thread.Sleep(100);
                            actualPeakValue1 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ReadPeakValue);
                            if (actualPeakValue1[0] != -1)
                            {
                                WriteMemory(MemoryAddress.PeakValue1, actualPeakValue1[0]);//记录读取的瞬时电流值
                                WriteMemoryDM(MemoryAddress.peakValuePhase1, actualPeakValue1[1]);
                                if (actualPeakValue1[0] >= (1 - Global.errorRange / 100.00) * Global.outPutCurrent && actualPeakValue1[0] <= (1 + Global.errorRange / 100.00) * Global.outPutCurrent)
                                {

                                    if (actualPeakValue1[1] == phaseB)
                                    {
                                        if (!Global.manualJudge)
                                        {
                                            if (Global.doOutPut2)
                                            {
                                                SetCmdCode(cmdOutput2);
                                            }
                                            else if (Global.doOutPut3)
                                            {
                                                SetCmdCode(cmdOutput3);
                                            }
                                            else SetCmdCode(cmdQuitProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdInsJudge1);
                                            Global.insJudge = 0;
                                        }
                                    }
                                    else SetResult(ngProofFailB);
                                }
                                else SetResult(ngProofFailB);
                            }
                            else SetResult(ngCommunication);
                        }
                        else SetResult(ngProofFailB);
                        break;
                    case cmdInsJudge1:
                        
                        if (Global.insJudge==1)
                        {
                            if (Global.doOutPut2)
                            {
                                SetCmdCode(cmdOutput2);
                            }
                            else if (Global.doOutPut3)
                            {
                                SetCmdCode(cmdOutput3);
                            }
                            else SetCmdCode(cmdQuitProof);
                        }
                        else if (Global.insJudge==2)
                        {
                              SetResult(ngProofFailB);
                        }
                        break;
                    case cmdEnterproof1:
                        if (Suyi.Debugging(SuyiMCCB.DataIdentification.EnterTransientCurrentMode))
                        {
                            if (Global.doOutPut3)
                            {
                                SetCmdCode(cmdOutput3);
                            }
                            else SetCmdCode(cmdQuitProof);
                        }
                        break;
                    case cmdOutput2:
                        //输出2
                        break;

                    case cmdReadPeakValue2:
                        if (suyi.ReadSwitchState() == 1)
                        {
                            Thread.Sleep(100);
                            actualPeakValue2 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ReadPeakValue);
                            if (actualPeakValue2[0] != -1)
                            {
                                WriteMemory(MemoryAddress.PeakValue2, actualPeakValue2[0]);//记录读取的瞬时电流值
                                WriteMemoryDM(MemoryAddress.peakValuePhase2, actualPeakValue2[1]);
                                if (actualPeakValue2[0] >= (1 - Global.errorRange / 100.00) * Global.outPutCurrent && actualPeakValue2[0] <= (1 + Global.errorRange / 100.00) * Global.outPutCurrent)
                                {
                                    if (actualPeakValue2[1] == phaseC)
                                    {
                                        if (!Global.manualJudge)
                                        {
                                            SetCmdCode(cmdCloseVoltage);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdInsJudge2);
                                            Global.insJudge = 0;
                                        }

                                    }
                                    else SetResult(ngProofFailC);
                                }
                                else SetResult(ngProofFailC);
                            }
                            else SetResult(ngCommunication);
                        }
                        else SetResult(ngProofFailC);
                        break;
                    case cmdInsJudge2:
                        if (Global.insJudge==1)
                        {
                            SetCmdCode(cmdCloseVoltage);
                        }
                        else if (Global.insJudge==2)
                        {
                            SetResult(ngProofFailC);
                        }
                        break;
                    case cmdOutput3:
                        //输出3
                        break;
                    case cmdReadPeakValue3:
                        if (suyi.ReadSwitchState() == 1)
                        {
                            Thread.Sleep(100);
                            actualPeakValue3 = Suyi.Proof(0x00, SuyiMCCB.DataIdentification.ReadPeakValue);
                            if (actualPeakValue3[0] != -1)
                            {
                                WriteMemory(MemoryAddress.PeakValue3, actualPeakValue3[0]);//记录读取的瞬时电流值
                                WriteMemoryDM(MemoryAddress.peakValuePhase3, (int)actualPeakValue3[1]);
                                if (actualPeakValue3[0] >= (1 - Global.errorRange / 100.00) * Global.outPutCurrent && actualPeakValue3[0] <= (1 + Global.errorRange / 100.00) * Global.outPutCurrent)
                                {
                                    if (actualPeakValue3[1] == phaseA)
                                    {
                                        if (!Global.manualJudge)
                                        {
                                            SetCmdCode(cmdQuitProof);
                                        }
                                        else
                                        {
                                            SetCmdCode(cmdInsJudge3);
                                            Global.insJudge = 0;
                                        }
                                    }
                                    else SetResult(ngProofFailA);
                                }
                                else SetResult(ngProofFailA);
                            }
                            else SetResult(ngCommunication);
                        }
                        else SetResult(ngProofFailA);
                        break;
                    case cmdInsJudge3:
                        if (Global.insJudge==1)
                        {
                            SetCmdCode(cmdQuitProof);
                        }
                        else if (Global.insJudge==2)
                        {
                            SetResult(ngProofFailA);
                        }
                        break;
                    case cmdLowTimes:
                        //输出低倍
                        break;
                    case cmdRecordLow:
                        // 返回的数组 0 跳闸原因 1 跳闸相 2跳闸前A相电压 3跳闸前B相电压 4跳闸前C相电压
                        double[] protectData = suyi.GetSwitchProtect();
                        WriteMemoryDM(MemoryAddress.RecordLow, protectData[0]);
                        WriteMemoryDM(MemoryAddress.RecordLowPhase, protectData[1]);
                        SetCmdCode(cmdRecordEnd);
                        break;
                    case cmdRecordEnd:
                        //记录完成(报警下料）
                        break;
                    case cmdReadSwitch1:
                        Thread.Sleep(300);
                        int switchState = Suyi.ReadSwitchState();
                        WriteMemoryDM(MemoryAddress.SwitchState4,switchState);
                        if (switchState == 1)//如果是合闸状态，为正常
                        {
                            if (!Global.manualJudge)
                            {
                                if (Global.doHigh)
                                {
                                    SetCmdCode(cmdHighTimes);
                                }
                                else SetCmdCode(cmdJudgeDoMeachine);
                            }
                            else
                            {
                                SetCmdCode(cmdInsJudge4);
                                Global.insJudge = 0;
                            }
                        }
                        else SetResult(ngProofFailLow);
                        break;
                    case cmdInsJudge4:
                        if (Global.insJudge==1)
                        {
                            if (Global.doHigh)
                            {
                                SetCmdCode(cmdHighTimes);
                            }
                            else SetCmdCode(cmdJudgeDoMeachine);
                        }
                        else if (Global.insJudge==2)
                        {
                            SetResult(ngProofFailLow);
                        }
                        break;
                    case cmdHighTimes:
                        //输出高倍
                        break;
                    case cmdReadSwitch2:
                        protectData = suyi.GetSwitchProtect();
                        WriteMemoryDM(MemoryAddress.RecordHigh, protectData[0]);
                        WriteMemoryDM(MemoryAddress.RecordHighPhase, protectData[1]);
                        Thread.Sleep(200);
                        switchState = Suyi.ReadSwitchState();
                        WriteMemoryDM(MemoryAddress.SwitchState5,switchState);
                        if (switchState == 2)//如果是分闸状态，为正常
                        {
                            if (!Global.manualJudge)
                            {
                                SetCmdCode(cmdJudgeDoMeachine);
                            }
                           else
                            {
                                SetCmdCode(cmdInsJudge5);
                                Global.insJudge = 0;
                            }
                        }
                        else SetResult(ngProofFailHigh);
                        break;
                    case cmdInsJudge5:
                        if (Global.insJudge==1)
                        {
                            SetCmdCode(cmdJudgeDoMeachine);
                        }
                        else
                        {
                            SetResult(ngProofFailHigh);
                        }
                        break;
                    case cmdQuitProof:
                        if (Suyi.Debugging(SuyiMCCB.DataIdentification.QuitTransientCurrentMode))//退出瞬时校对模式
                        {
                            
                            if (Global.doLow)
                            {
                                SetCmdCode(cmdLowTimes);
                            }
                            else if (Global.doHigh)
                            {
                                SetCmdCode(cmdHighTimes);
                            }
                            else SetCmdCode(cmdJudgeDoMeachine);
                        }
                        break;
                    case cmdJudgeSwitchState2:
                        //plc输出判断分合闸状态
                        break;
                    case cmdCloseSwitch:
                        if (Suyi.CloseSwitch())
                        {
                            SetCmdCode(cmdJudgeSwitchState3);//告诉plc进行分合闸检验
                        }
                        else SetResult(ngCloseSwitch);
                        break;
                    case cmdJudgeSwitchState3: //该判断需要上位机和plc都进行判断
                                               //Thread.Sleep(Global.instantaneousCloseSwitchTime);
                        if (Suyi.ReadSwitchState() == 1) //通信读取当前状态为合闸(另需输出判断结果)
                        {
                            SetCmdCode(cmdJudgeSwitchState4);
                        }
                        else SetResult(ngCloseSwitch);
                        break;
                    case cmdJudgeSwitchState4:
                        //plc判断是否合闸
                        break;
                    case cmdJudgeDoMeachine:
                    
                        if (Global.meachineAge)  //确定为不做
                        {
                            meachineNum = Global.meachineTestNum;
                            if (meachineNum > 0)
                            {
                                SetCmdCode(cmdOpenSwitch);
                            }
                            else SetCmdCode(cmdJudgeOpenSwitch);

                        }
                        else SetCmdCode(cmdJudgeOpenSwitch);
                        break;
                    case cmdJudgeOpenSwitch:
                        if (suyi.ReadSwitchState() == 1) //为合闸状态//需要分闸出去
                        {
                            SetCmdCode(cmdOpenSwitchFinally); //最终分闸
                        }
                        else SetCmdCode(cmdJudgeOpenSwitchPlc1);
                        break;
                    case cmdJudgeOpenSwitchPlc1: 
                        //plc最终确认分闸状态1
                        break;
                    case cmdOpenSwitchFinally:
                        //最终分闸（确保产品分闸出去）
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
                                SetCmdCode(cmdJudgeOpenSwitchPlc1);
                            }
                            else SetResult(ngOpenSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeOpenSwitchPlc2:
                        //plc最终确认分闸状态2
                        break;
                    case cmdOpenSwitch:
                        //通信分闸
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
                            else SetResult(ngOpenSwitch);
                        }
                        else SetResult(ngCommunication);
                        break;
                    case cmdJudgeSwitch:

                        break;
                    case cmdCloseSwtich:
                        //通信合闸
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
                            else SetResult(ngCloseSwitch);
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
                        else SetCmdCode(cmdInstantaneousEnd);
                        break;
                    case cmdInstantaneousEnd:  //瞬时校验结束 

                        break;
                    default:
                        break;
                }
            }

        }
        private int GetCmdCode()
        {
            try
            {
                return ReadMemory(((int)(MemoryAddress.CmdCode)).ToString());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return 0;
            }

        }
        private void SetCmdCode(int data)
        {
            try
            {
                WriteMemory(MemoryAddress.CmdCode, data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void SetResult(int data)
        {
            try
            {
                WriteMemory(MemoryAddress.TestResult, data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void WriteMemory(MemoryAddress address, int data)
        {
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, ((int)address).ToString(), data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void WriteMemoryDM(MemoryAddress address,double data)
        {
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, ((int)address).ToString(), (int)data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void WriteMemoryDM(MemoryAddress address, int  data)
        {
            try
            {
                Global.kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_DM, ((int)address).ToString(),data);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
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
        /// 寄存器地址枚举
        /// </summary>
        private enum MemoryAddress : int
        {
            CmdCode = 4601,
            TestResult=4602,
            PeakValue1=15708,
            peakValuePhase1=15728,
            PeakValue2=15712,
            peakValuePhase2=15729,
            PeakValue3=15716,
            peakValuePhase3=15730,
            //OutputCurrent,
            //OutputTime,
            //LowTimesCurrent,
            //LowTimesTime,
            //HighTimesCurrent,
            //HighTimesTime,
            ////SwitchState1,
            ////SwitchState2,
            ////SwitchState3,
            SwitchState4=15734,
            SwitchState5=15735,
            RecordLow=15737,
            RecordLowPhase=15738,
            RecordHigh=15739,
            RecordHighPhase=15740,
        }
    }
}
