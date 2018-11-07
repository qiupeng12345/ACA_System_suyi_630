using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ACA_BreakCommunication
{
    /// <summary>
    /// 苏益MCCB类 （用于和苏益产品进行通信）
    /// </summary>
    /// 这个写的比较乱，本想用结构体或者类来写对应码，便于理解通信的指令对应什么情况（就像通信测试和读指令）
    public class SuyiMCCB
    {
        private SerialPort comPort = new SerialPort(); //485通信串口
        private static int connectAddress;
        protected const int NoMatch_Max = 5;  //超过5次通信仍未连接判断为通信失败
        protected const byte Start = 0x68; //通信起始符号
        protected const byte End = 0x16; //通信结束符号
        protected const byte Mask = 0x33; //掩码
        private Dictionary<DataIdentification, DI> dic = new Dictionary<DataIdentification, DI>(); //功能码集合
        private AddressByte Address = new AddressByte(connectAddress);
        private bool communicationOK = false;  //通信结果标志位
        private bool CommunicationState = false;

        public SuyiMCCB()
        {
            ///添加功能码
            AddDataIdentification();
        }
        public SerialPort ComPort { get { return comPort; } set { comPort = value; } } //用于通信的serialport
        public int ConnectAddress { get { return connectAddress; } set { connectAddress = value; } }  //配置地址属性
        /// <summary>
        /// 添加功能码,因为这个需要作为参数来调用放法
        /// </summary>
        private void AddDataIdentification()
        {
            dic.Add(DataIdentification.CommunicationTest, new DI(0x01, 0x01, 0x00, 0x04));
            dic.Add(DataIdentification.ReadCurrent, new DI(0x00, 0xff, 0x02, 0x02));
            dic.Add(DataIdentification.ReadVoltage, new DI(0x00, 0xff, 0x01, 0x02));
            dic.Add(DataIdentification.ReadResidualCurrent, new DI(0x00, 0x01, 0x90, 0x02));
            dic.Add(DataIdentification.CloseSwitch, new DI(0x01, 0x02, 0x01, 0x06));
            dic.Add(DataIdentification.OpenSwitch, new DI(0x01, 0x01, 0x01, 0x06));
            dic.Add(DataIdentification.ReadStateWord1, new DI(0x01, 0x05, 0x00, 0x04));
            dic.Add(DataIdentification.EnterCurrentDebuggingMode, new DI(0x00, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.CurrentProofreading1, new DI(0x01, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.CurrentProofreading2, new DI(0x02, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.CurrentProofreading3, new DI(0x03, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.CurrentProofreading4, new DI(0x04, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.CurrentProofreading5, new DI(0x05, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.QuitCurrentDebuggingMode, new DI(0x06, 0x02, 0x00, 0x00));
            dic.Add(DataIdentification.EnterVoltageDebuggingMode, new DI(0x00, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.VoltageProofreading1, new DI(0x01, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.VoltageProofreading2, new DI(0x02, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.VoltageProofreading3, new DI(0x03, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.VoltageProofreading4, new DI(0x04, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.VoltageProofreading5, new DI(0x05, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.QuitVoltageDebuggingMode, new DI(0x06, 0x01, 0x00, 0x00));
            dic.Add(DataIdentification.EnterResidualCurrentDebuggingMode, new DI(0x00, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.ResidualCurrentProofreading1, new DI(0x01, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.ResidualCurrentProofreading2, new DI(0x02, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.ResidualCurrentProofreading3, new DI(0x03, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.ResidualCurrentProofreading4, new DI(0x04, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.ResidualCurrentProofreading5, new DI(0x05, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.QuitResidualCurrentDebuggingMode, new DI(0x06, 0x03, 0x00, 0x00));
            dic.Add(DataIdentification.EnterTransientCurrentMode, new DI(0x00, 0x04, 0x00, 0x00));
            dic.Add(DataIdentification.CurrentInstantaneousValue, new DI(0x01, 0x04, 0x00, 0x00));
            dic.Add(DataIdentification.QuitTransientCurrentMode, new DI(0x02, 0x04, 0x00, 0x00));
            dic.Add(DataIdentification.FactorySet, new DI(0x90, 0x90, 0x92, 0x90));
            dic.Add(DataIdentification.ClearTestRecord, new DI(0x90, 0x90, 0x93, 0x90));
            dic.Add(DataIdentification.GetSwitchProtect, new DI(0x01, 0x00, 0x8E, 0x03));
            dic.Add(DataIdentification.ReadPeakValue, new DI(0x01, 0x04, 0x00, 0x00));
        }
        /// <summary>
        ///  测试通信的方法，通信成功返回true，失败返回false；
        /// </summary>
        /// <returns></returns>
        public bool CommunicationTest() //测试通信
        {
            communicationOK = false;
            ReadCmd readCmd = new ReadCmd();
            readCmd.start = Start;
            readCmd.address0 = Address.a0;
            readCmd.address1 = Address.a1;
            readCmd.address2 = Address.a2;
            readCmd.address3 = Address.a3;
            readCmd.address4 = Address.a4;
            readCmd.address5 = Address.a5; ;
            readCmd.datastart = Start;
            readCmd.controlCode = (byte)ControlCode.Read;
            readCmd.dataLength = 0x04;
            readCmd.di0 = (byte)(dic[DataIdentification.CommunicationTest].di0 + Mask);
            readCmd.di1 = (byte)(dic[DataIdentification.CommunicationTest].di1 + Mask);
            readCmd.di2 = (byte)(dic[DataIdentification.CommunicationTest].di2 + Mask);
            readCmd.di3 = (byte)(dic[DataIdentification.CommunicationTest].di3 + Mask);
            readCmd.cs = GetCS(new byte[]{readCmd.start,readCmd.address0,readCmd.address1,readCmd.address2,readCmd.address3,readCmd.address4,readCmd.address5
            ,readCmd.datastart,readCmd.controlCode,readCmd.dataLength,readCmd.di0,readCmd.di1,readCmd.di2,readCmd.di3}, 14);
            readCmd.end = End;
            byte[] bytes = {readCmd.start,readCmd.address0,readCmd.address1,readCmd.address2,readCmd.address3,readCmd.address4,readCmd.address5
            ,readCmd.datastart,readCmd.controlCode,readCmd.dataLength,readCmd.di0,readCmd.di1,readCmd.di2,readCmd.di3,readCmd.cs,readCmd.end};
            SendData(bytes);
            if (communicationOK)
            {
                CommunicationState = true;
                communicationOK = false;
            }
            else CommunicationState = false;
            return CommunicationState;
        }
        /// <summary>
        /// 读取分合闸状态 返回1为合闸，返回2为分闸
        /// </summary>
        /// <returns></returns>
        public int ReadSwitchState()
        {
            communicationOK = false;
            ReadCmd readCmd = new ReadCmd();
            int state1 = 0;
            readCmd.start = Start;
            readCmd.address0 = Address.a0;
            readCmd.address1 = Address.a1;
            readCmd.address2 = Address.a2;
            readCmd.address3 = Address.a3;
            readCmd.address4 = Address.a4;
            readCmd.address5 = Address.a5; ;
            readCmd.datastart = Start;
            readCmd.controlCode = (byte)ControlCode.Read;
            readCmd.dataLength = 0x04;
            readCmd.di0 = (byte)(dic[DataIdentification.ReadStateWord1].di0 + Mask);
            readCmd.di1 = (byte)(dic[DataIdentification.ReadStateWord1].di1 + Mask);
            readCmd.di2 = (byte)(dic[DataIdentification.ReadStateWord1].di2 + Mask);
            readCmd.di3 = (byte)(dic[DataIdentification.ReadStateWord1].di3 + Mask);
            readCmd.cs = GetCS(new byte[]{readCmd.start,readCmd.address0,readCmd.address1,readCmd.address2,readCmd.address3,readCmd.address4,readCmd.address5
            ,readCmd.datastart,readCmd.controlCode,readCmd.dataLength,readCmd.di0,readCmd.di1,readCmd.di2,readCmd.di3}, 14);
            readCmd.end = End;
            byte[] bytes = {readCmd.start,readCmd.address0,readCmd.address1,readCmd.address2,readCmd.address3,readCmd.address4,readCmd.address5
            ,readCmd.datastart,readCmd.controlCode,readCmd.dataLength,readCmd.di0,readCmd.di1,readCmd.di2,readCmd.di3,readCmd.cs,readCmd.end};
            byte[] ByteBack = SendData(bytes);
            if ((ByteBack[0] == Start) && (ByteBack[8] == 0x91)) //返回数据的判断
            {
                state1 = ByteBack[14]; //获取状态字
            }
            if (((state1 - Mask) & 0x60) == 0x20)   //如果为合闸位为1
            {
                return 1;  //1为合闸
            }
            else if (((state1 - Mask) & 0x60) == 0x00)
            {
                return 2;
            }
            return 0;
        }
        /// <summary>
        /// 读取数据方法，返回数据为处理之后的数据，为双精度浮点数组
        /// </summary>
        /// <param name="dataIdentification">对应数据的标识码</param>
        /// <returns></returns>
        public double[] Read(DataIdentification dataIdentification)   //读取方法负责（状态指令1，电流指令）
        {
            communicationOK = false;
            List<int> list = new List<int>();
            double[] result = new double[6];
            ReadCmd readCmd = new ReadCmd();
            readCmd.start = Start;
            readCmd.address0 = Address.a0;
            readCmd.address1 = Address.a1;
            readCmd.address2 = Address.a2;
            readCmd.address3 = Address.a3;
            readCmd.address4 = Address.a4;
            readCmd.address5 = Address.a5; ;
            readCmd.datastart = Start;
            readCmd.controlCode = (byte)ControlCode.Read;
            readCmd.dataLength = 0x04;
            readCmd.di0 = (byte)(dic[dataIdentification].di0 + Mask);
            readCmd.di1 = (byte)(dic[dataIdentification].di1 + Mask);
            readCmd.di2 = (byte)(dic[dataIdentification].di2 + Mask);
            readCmd.di3 = (byte)(dic[dataIdentification].di3 + Mask);
            readCmd.cs = GetCS(new byte[]{readCmd.start,readCmd.address0,readCmd.address1,readCmd.address2,readCmd.address3,readCmd.address4,readCmd.address5
            ,readCmd.datastart,readCmd.controlCode,readCmd.dataLength,readCmd.di0,readCmd.di1,readCmd.di2,readCmd.di3}, 14);
            readCmd.end = End;
            byte[] bytes = {readCmd.start,readCmd.address0,readCmd.address1,readCmd.address2,readCmd.address3,readCmd.address4,readCmd.address5
            ,readCmd.datastart,readCmd.controlCode,readCmd.dataLength,readCmd.di0,readCmd.di1,readCmd.di2,readCmd.di3,readCmd.cs,readCmd.end};
            byte[] ByteBack = SendData(bytes);
            if ((ByteBack[0] == Start) && (ByteBack[8] == 0x91)) //返回数据的判断
            {
                switch (dataIdentification)
                {
                    case DataIdentification.ReadCurrent:    //get three phase current
                        result = GetThreePhaseCurrent(ByteBack);
                        break;
                    case DataIdentification.ReadVoltage:   //get three phase voltage
                        result = GetThreePhaseVoltage(ByteBack);
                        break;
                    case DataIdentification.ReadResidualCurrent:
                        result = GetResidualCurrent(ByteBack);
                        break;
                    case DataIdentification.GetSwitchProtect:
                        result = GetProtectData(ByteBack);
                        break;

                }


            }
            return result;
        }
        /// <summary>
        /// 获取跳闸保护记录
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        private double[] GetProtectData(byte[] Byte)
        {
            List<int> list = new List<int>();
            double[] result = new double[5];
            for (int i = 0; i < Byte[9] - 4; i++)
            {
                list.Add((Byte[i + 14] - Mask) & 0x0f);
                list.Add(((Byte[i + 14] - Mask) & 0xf0) >> 4);
            }
            if (list.Count == 54)  //
            {
                result[0] = list[0] + list[1] * 10; //跳闸原因
                result[1] = list[2] + list[3] * 10; //跳闸相位
                result[2] = list[20] / 10.00 + list[21] + list[22] * 10 + list[23] * 100;  //A相跳闸前电压
                result[3]= list[24] / 10.00 + list[25] + list[26] * 10 + list[27] * 100;   //B相跳闸前电压
                result[4]= list[28] / 10.00 + list[29] + list[30] * 10 + list[31] * 100;   //C相跳闸前电压

            }
            return result;
        }
        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Write(DataIdentification dt, int data)
        {
            communicationOK = false;
            return true;
        }
        /// <summary>
        /// 合闸操作方法
        /// </summary>
        /// <param name="data">执行合闸的预约时间</param>
        /// <returns></returns>
        public bool CloseSwitch()   //合闸操作
        {
            communicationOK = false;
            byte[] ByteSend = new byte[]
            {
              Start,Address.a0,Address.a1,Address.a2,Address.a3,Address.a4,Address.a5,Start,(byte)ControlCode.control,14,(byte)(dic[DataIdentification.CloseSwitch].di0+Mask),
               (byte)(dic[DataIdentification.CloseSwitch].di1+Mask),(byte)(dic[DataIdentification.CloseSwitch].di2+Mask),(byte)(dic[DataIdentification.CloseSwitch].di3+Mask),(byte)(Password.pa+Mask)
                ,(byte)(Password.p0+Mask),(byte)(Password.p1+Mask),(byte)(Password.p2+Mask),(byte)(Operator.c0+Mask),(byte)(Operator.c1+Mask),(byte)(Operator.c2+Mask),(byte)(Operator.c3+Mask),0x33,0x35,0,0x16
            };
            byte cs = GetCS(ByteSend, ByteSend.Length - 2);
            ByteSend[ByteSend.Length - 2] = cs;
            byte[] ByteBack = SendData(ByteSend);
            if ((ByteBack[0] == Start) && (ByteBack[8] == 0x9c) && (ByteBack[9] == 0x00))
            {
                return true;
            }
            else return false;

        }
        /// <summary>
        /// 获取跳闸保护记录
        /// </summary>
       public double[] GetSwitchProtect()
        {
            communicationOK = false;
            return Read(DataIdentification.GetSwitchProtect);
        }
        /// <summary>
        /// 通讯分闸
        /// </summary>
        /// <returns></returns>
        public bool OpenSwitch()
        {
            communicationOK = false;
            byte[] ByteSend = new byte[]
            {
              Start,Address.a0,Address.a1,Address.a2,Address.a3,Address.a4,Address.a5,Start,(byte)ControlCode.control,14,(byte)(dic[DataIdentification.OpenSwitch].di0+Mask),
               (byte)(dic[DataIdentification.OpenSwitch].di1+Mask),(byte)(dic[DataIdentification.OpenSwitch].di2+Mask),(byte)(dic[DataIdentification.OpenSwitch].di3+Mask),(byte)(Password.pa+Mask)
                ,(byte)(Password.p0+Mask),(byte)(Password.p1+Mask),(byte)(Password.p2+Mask),(byte)(Operator.c0+Mask),(byte)(Operator.c1+Mask),(byte)(Operator.c2+Mask),(byte)(Operator.c3+Mask),0x33,0x35,0,0x16
            };
            byte cs = GetCS(ByteSend, ByteSend.Length - 2);
            ByteSend[ByteSend.Length - 2] = cs;
            byte[] ByteBack = SendData(ByteSend);
            if ((ByteBack[0] == Start) && (ByteBack[8] == 0x9c) && (ByteBack[9] == 0x00))
            {
                return true;
            }
            else return false;

        }
        /// <summary>
        /// 远程调试模式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataIdentification">不同调试功能的标识符</param>
        /// <returns></returns>
        public bool Debugging(DataIdentification dataIdentification)
        {
            communicationOK = false;
            byte[] ByteSend = new byte[]
            {
                 Start,Address.a0,Address.a1,Address.a2,Address.a3,Address.a4,Address.a5,Start,(byte)ControlCode.debugging,12,
                 (byte)(dic[dataIdentification].di0+Mask),(byte)(dic[dataIdentification].di1+Mask),(byte)(dic[dataIdentification].di2+Mask),
                 (byte)(dic[dataIdentification].di3+Mask),(byte)(Password.pa+Mask),(byte)(Password.p0+Mask),(byte)(Password.p1+Mask)
                 ,(byte)(Password.p2+Mask),(byte)(Operator.c0+Mask),(byte)(Operator.c1+Mask), (byte)(Operator.c2+Mask),(byte)(Operator.c3+Mask)
                 ,0,0x16

            };
            ByteSend[ByteSend.Length - 2] = GetCS(ByteSend, ByteSend.Length - 2);
            byte[] ByteBack = SendData(ByteSend);
            if ((ByteBack[0] == Start) && (ByteBack[8] == 0x9f) && (ByteBack[9] != 0x00))
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 校对指令
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataIdentification"></param>
        /// <returns></returns>
        public double[] Proof(int data, DataIdentification dataIdentification)
        {
            communicationOK = false;
            byte[] ByteSend = new byte[]
           {
                 Start,Address.a0,Address.a1,Address.a2,Address.a3,Address.a4,Address.a5,Start,(byte)ControlCode.debugging,13,
                 (byte)(dic[dataIdentification].di0+Mask),(byte)(dic[dataIdentification].di1+Mask),(byte)(dic[dataIdentification].di2+Mask),
                 (byte)(dic[dataIdentification].di3+Mask),(byte)(Password.pa+Mask),(byte)(Password.p0+Mask),(byte)(Password.p1+Mask)
                 ,(byte)(Password.p2+Mask),(byte)(Operator.c0+Mask),(byte)(Operator.c1+Mask), (byte)(Operator.c2+Mask),(byte)(Operator.c3+Mask)
                 ,(byte)(data+Mask),0,0x16

           };
            ByteSend[ByteSend.Length - 2] = GetCS(ByteSend, ByteSend.Length - 2);
            byte[] ByteBack = SendData(ByteSend);
            if ((ByteBack[0] == Start) && (ByteBack[8] == 0x9f) && (ByteBack[9] != 0x00))
            {
                switch (dataIdentification)
                {
                    case DataIdentification.CurrentProofreading1:
                        return GetThreePhaseCurrent(ByteBack);
                    case DataIdentification.CurrentProofreading2:
                        return GetThreePhaseCurrent(ByteBack);
                    case DataIdentification.CurrentProofreading3:
                        return GetThreePhaseCurrent(ByteBack);
                    case DataIdentification.CurrentProofreading4:
                        return GetThreePhaseCurrent(ByteBack);
                    case DataIdentification.CurrentProofreading5:
                        return GetThreePhaseCurrent(ByteBack);
                    case DataIdentification.VoltageProofreading1:
                        return GetThreePhaseVoltage(ByteBack);
                    case DataIdentification.VoltageProofreading2:
                        return GetThreePhaseVoltage(ByteBack);
                    case DataIdentification.VoltageProofreading3:
                        return GetThreePhaseVoltage(ByteBack);
                    case DataIdentification.VoltageProofreading4:
                        return GetThreePhaseVoltage(ByteBack);
                    case DataIdentification.VoltageProofreading5:
                        return GetThreePhaseVoltage(ByteBack);
                    case DataIdentification.ResidualCurrentProofreading1:
                        return GetResidualCurrent(ByteBack);
                    case DataIdentification.ResidualCurrentProofreading2:
                        return GetResidualCurrent(ByteBack);
                    case DataIdentification.ResidualCurrentProofreading3:
                        return GetResidualCurrent(ByteBack);
                    case DataIdentification.ResidualCurrentProofreading4:
                        return GetResidualCurrent(ByteBack);
                    case DataIdentification.ResidualCurrentProofreading5:
                        return GetResidualCurrent(ByteBack);
                    case DataIdentification.FactorySet:
                        return new double[] { 0 };
                    case DataIdentification.ReadPeakValue:
                        return GetPeakValue(ByteBack);
                    case DataIdentification.ClearTestRecord:
                        return new double[] { 0 };
                    default:
                        break;
                }

            }
            return new double[] { -1 };
        }
        /// <summary>
        /// 获取瞬时电流值
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        private double[] GetPeakValue(Byte[] Byte)
        {
            List<int> list = new List<int>();
            double[] result = new double[2];
            for (int i = 0; i < Byte[9] - 4; i++)
            {
                list.Add((Byte[i + 14] - Mask) & 0x0f);
                list.Add(((Byte[i + 14] - Mask) & 0xf0) >> 4);
            }
            if (list.Count == 8)  //
            {
                result[0] = list[0] / 10.00 + list[1] + list[2] * 10 + list[3] * 100 + list[4] * 1000 + list[5] * 10000; //瞬时电流值
                result[1] = list[6] + list[7];//瞬时电流相位
            }
            return result;
        }
        /// <summary>
        /// 发送恢复出场设置指令
        /// </summary>
        /// <returns></returns>
        public bool RecoveryFactorySet() //恢复出厂设置
        {
            communicationOK = false;
            if (Proof(0x00, DataIdentification.FactorySet)[0] == 0) //recovery factory set ok
            {
                return true;
            }
            else return false;
            
        }
        /// <summary>
        /// 清除测试记录
        /// </summary>
        /// <returns></returns>
        public bool ClearTestRecord()
        {
            communicationOK = false;
            if (Proof(0x00,DataIdentification.ClearTestRecord)[0]==0) //清除测试记录成功
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 断路器分闸记录
        /// </summary>
        /// <returns></returns>
        public int OpenSwitchRecord()//断路器分闸记录
        {
            communicationOK = false;
            return 1;
        }
        /// <summary>
        ///  get three phase current
        /// </summary>
        /// <param name="Byte"> current byte</param>
        /// <returns></returns>
        private double[] GetThreePhaseCurrent(byte[] Byte)
        {
            List<int> list = new List<int>();
            double[] result = new double[3];
            for (int i = 0; i < Byte[9] - 4; i++)
            {
                list.Add((Byte[i + 14] - Mask) & 0x0f);
                list.Add(((Byte[i + 14] - Mask) & 0xf0) >> 4);
            }
            if (list.Count == 18)//一共18个数据对应着三相电流
            {
                result[0] = list[0] / 10.00 + list[1] + list[2] * 10 + list[3] * 100 + list[4] * 1000 + list[5] * 10000; //A相电流值
                result[1] = list[6] / 10.00 + list[7] + list[8] * 10 + list[9] * 100 + list[10] * 1000 + list[11] * 10000; //B相电流值
                result[2] = list[12] / 10.00 + list[13] + list[14] * 10 + list[15] * 100 + list[16] * 1000 + list[17] * 10000;//C相电流值

            }
            return result;
        }
        /// <summary>
        /// 获取三相电压值
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        private double[] GetThreePhaseVoltage(byte[] Byte)
        {
            List<int> list = new List<int>();
            double[] result = new double[3];
            for (int i = 0; i < Byte[9] - 4; i++)
            {
                list.Add((Byte[i + 14] - Mask) & 0x0f);
                list.Add(((Byte[i + 14] - Mask) & 0xf0) >> 4);
            }
            if (list.Count == 12)  //一共12个数据对应着三相电压
            {
                result[0] = list[0]/10.00 + list[1]  + list[2] * 10 + list[3] * 100; //A相电压值
                result[1] = list[4]/10.00 + list[5]  + list[6] * 10 + list[7] * 100; //B相电压值
                result[2] = list[8]/10.00 + list[9]  + list[10] * 10 + list[11] * 100; //C相电压值
            }
            return result;
        }
        /// <summary>
        /// 获取剩余电流值
        /// </summary>
        /// <param name="Byte"></param>
        /// <returns></returns>
        private double[] GetResidualCurrent(byte[] Byte)
        {
            List<int> list = new List<int>();
            double[] result=new double[3];
            for (int i = 0; i < Byte[9] - 4; i++)
            {
                list.Add((Byte[i + 14] - Mask) & 0x0f);
                list.Add(((Byte[i + 14] - Mask) & 0xf0) >> 4);
            }
            if (list.Count==4) //一共4个数据对应着剩余电流
            {
                result[0] = list[0] + list[1] * 10 + list[2] * 100 + list[3] * 1000; //剩余电流值
            }
            return result;
        }
        /// <summary>
        /// 串口发送字节数组并读取产品返回的数据
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public byte[] SendData(byte[] bytes)   //发送字节数组（485），并处理设备返回来的数据
        {
            int ErroCount = 0;
            byte[] byteBack = new byte[60];
            byte[] ReturnByte = new byte[60];
            while (!communicationOK)
            {
                try
                {
                    if (ErroCount < NoMatch_Max)
                    {

                        if (comPort.IsOpen)
                        {
                            comPort.Write(bytes, 0, bytes.Length);
                            //TimeDelay(50);
                            Thread.Sleep(900);
                            comPort.Read(byteBack, 0, 60);
                            //comPort.ReadExisting(); //读取返回的信息
                            ReturnByte = GetByteCorrect(byteBack, ref communicationOK);
                            ErroCount++;
                        }
                        else comPort.Open();
                    }
                    else break;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.ToString());
                    ErroCount++;
                }
            }
            return ReturnByte;
        }
        /// <summary>
        /// 获取正确的返回数据（防止干扰导致的杂乱数据）
        /// </summary>
        /// <param name="byteBack">返回字节数组</param>
        /// <param name="communicationState">通信状态</param>
        /// <returns></returns>
        private byte[] GetByteCorrect(byte[] byteBack, ref bool communicationState)
        {
            int count = 0;
            bool ReceiveStart = false;
            bool ReceiveEnd = false;
            byte[] ByteReceive = new byte[100];
            foreach (byte item in byteBack)
            {
                if (item == Start)   //有起始符号
                {
                    ReceiveStart = true;
                }
                if (ReceiveStart)
                {
                    ByteReceive[count] = item;
                    count++;
                }
                if (item == End) //有结束字符
                {
                    if ((ByteReceive[count - 2]) == GetCS(ByteReceive, count - 2))    //接收过来的字节cs校验正确
                    {
                        ReceiveEnd = true;//接收数据完成
                        communicationState = true;
                        break;
                    }
                }
            }
            if (ReceiveEnd)
            {
                byte[] ByteCorrect = new byte[count];
                for (int i = 0; i < count; i++)
                {
                    ByteCorrect[i] = ByteReceive[i];
                }
                return ByteCorrect;
            }
            else return new byte[] { 0xff, 0xff, 0xff, 0xff };    //返回错误数组，表明bytebcak中不包含正确的字节帧
        }
        /// <summary>
        /// 字节获取校验码
        /// </summary>
        /// <param name="bt">字节数组</param>
        /// <param name="n">长度</param>
        /// <returns></returns>
        private Byte GetCS(byte[] bt, int n)
        {
            int ByteSum = 0;
            for (int i = 0; i < n; i++)
            {
                ByteSum += bt[i];
            }
            ByteSum = ByteSum % 256;
            return (byte)(ByteSum & 0xff);

        }
        /// <summary>
        /// 控制码枚举
        /// </summary>
        private enum ControlCode : byte
        {
            Read = 0x11,
            control = 0x1c,
            debugging = 0x1f,

        }
        /// <summary>
        /// 密码枚举
        /// </summary>
        public enum Password : byte
        {
            pa = 0x00,
            p0 = 0x00,
            p1 = 0x00,
            p2 = 0x00,
        }
        /// <summary>
        /// 操作者代码枚举
        /// </summary>
        public enum Operator : byte
        {
            c0 = 0x00,
            c1 = 0x00,
            c2 = 0x00,
            c3 = 0x00,
        }
        /// <summary>
        /// 功能标识码枚举
        /// </summary>
        public enum DataIdentification
        {
            CommunicationTest,//读取当前时期指令，默认为用来测试通信
            ReadCurrent,//读取当前A,B,C三相电流值
            ReadVoltage,//读取当前ABC三相电压值
            ReadResidualCurrent,//读取当前剩余电流值
            OpenSwitch,//开闸
            CloseSwitch,//合闸
            ReadStateWord1,//读取状态字1，里面有开关闸状态
            EnterVoltageDebuggingMode,//进入电压调试模式
            VoltageProofreading1,    //电压调试校准点1电压
            VoltageProofreading2,    //电压调试校准点2电压
            VoltageProofreading3,     //电压调试校准点3电压
            VoltageProofreading4,    //电压调试校准点4电压
            VoltageProofreading5,     //电压调试校准点5电压
            QuitVoltageDebuggingMode,  //退出电压调试模式
            EnterCurrentDebuggingMode,//进入电流调试模式
            CurrentProofreading1,//电流调试校准点1电流
            CurrentProofreading2,//电流调试校准点2电流
            CurrentProofreading3,//电流调试校准点3电流
            CurrentProofreading4,//电流调试校准点2电流
            CurrentProofreading5,//电流调试校准点3电流
            QuitCurrentDebuggingMode, //退出电流调试模式
            EnterResidualCurrentDebuggingMode,//进入剩余电流调试模式
            ResidualCurrentProofreading1, //剩余电流调试校准点1电流
            ResidualCurrentProofreading2, //剩余电流调试校准点2电流
            ResidualCurrentProofreading3, //剩余电流调试校准点3电流
            ResidualCurrentProofreading4, //剩余电流调试校准点2电流
            ResidualCurrentProofreading5, //剩余电流调试校准点3电流
            QuitResidualCurrentDebuggingMode, //退出剩余电流调试模式
            EnterTransientCurrentMode,//进入瞬时电流测试状态
            CurrentInstantaneousValue,//当前瞬时电流值和电流相位
            QuitTransientCurrentMode,//退出瞬时电流调试模式
            ReadPeakValue,//发送实际峰值
            FactorySet,//恢复出厂设置
            ClearTestRecord,//清除测试记录
            GetSwitchProtect,//获取断路器跳闸记录
            EnterVoltageAndResidualCurrentDebuggingMode,//进入电压和漏电流校对模式
            VoltageAndResidualCurrentProofreading1,//电压和漏电流校对1
            VoltageAndResidualCurrentProofreading2,//电压和漏电流校对2
            VoltageAndResidualCurrentProofreading3,//电压和漏电流校对3
            VoltageAndResidualCurrentProofreading4,//电压和漏电流校对4
            VoltageAndResidualCurrentProofreading5,//电压和漏电流校对5
            QuitVoltageAndResidualCurrentDebuggingMode, //退出剩余电流调试模式

        }
        /// <summary>
        /// 延时函数
        /// </summary>
        /// <param name="time"></param>
        private void TimeDelay(int time)
        {
            for (int i = 0; i < time * 100000; i++)
            {
                i++;
            }
        }
        /// <summary>
        /// 产品通信地址
        /// </summary>
        public struct AddressByte
        {
            public byte a0;
            public byte a1;
            public byte a2;
            public byte a3;
            public byte a4;
            public byte a5;
            public AddressByte(int connectAddress)
            {
                this.a0 = (byte)(connectAddress & 0xff);
                this.a1 = (byte)((connectAddress & 0xff00) >> 8);
                this.a2 = (byte)((connectAddress & 0xff0000) >> 16);
                this.a3 = (byte)((connectAddress & 0xff000000) >> 24);
                this.a4 = (byte)((connectAddress & 0xff00000000) >> 32);
                this.a5 = (byte)((connectAddress & 0xff0000000000) >> 40);
            }
        }
        /// <summary>
        /// 读命令结构体
        /// </summary>
        protected struct ReadCmd
        {
            public byte start;
            public byte address0;
            public byte address1;
            public byte address2;
            public byte address3;
            public byte address4;
            public byte address5;
            public byte datastart;
            public byte controlCode;
            public byte dataLength;
            public byte di0;
            public byte di1;
            public byte di2;
            public byte di3;
            public byte cs;
            public byte end;
        }
        /// <summary>
        /// 功能码结构体
        /// </summary>
        public struct DI
        {
            public byte di0;
            public byte di1;
            public byte di2;
            public byte di3;
            public DI(byte di0, byte di1, byte di2, byte di3)
            {
                this.di0 = di0;
                this.di1 = di1;
                this.di2 = di2;
                this.di3 = di3;
            }
        }
    }

}
