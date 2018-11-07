using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABUILDERAXLibLB;
using System.Windows.Forms;

namespace ACA_BreakCommunication
{
    /// <summary>
    /// 基恩士PLC通讯类
    /// </summary>
    public class KVDH1
    {
        public DBCommManagerClass dbCm = new DBCommManagerClass();
        public DBPlcId PLC
        {
            get { return dbCm.PLC; }
            set { dbCm.PLC = value; }
        }
        public string Peer
        {
            get {return dbCm.Peer; }
            set { dbCm.Peer = value; }
        }
        

        public bool Active
        {
            get { return dbCm.Active; }
        }

        public KVDH1()
        {

        }
        /// <summary>
        /// plc连接
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            dbCm.Connect();
            return true;
        }
        /// <summary>
        /// plc断开连接
        /// </summary>
        /// <returns></returns>
        public bool DisConnect()
        {
            dbCm.Disconnect();
            return true;
        }
        /// <summary>
        /// 读寄存器
        /// </summary>
        /// <param name="dbPlc"></param>
        /// <param name="memoryStart"></param>
        /// <returns></returns>
        public int ReadMemory(DBPlcDevice dbPlc, string memoryStart)
        {
                return dbCm.ReadDevice(dbPlc, memoryStart);
        }
        /// <summary>
        /// 读寄存器（多读）
        /// </summary>
        /// <param name="dbplc"></param>
        /// <param name="startAddress"></param>
        /// <param name="length"></param>
        /// <param name="resultArray"></param>
        /// <returns></returns>
        public bool ReadMemory(DBPlcDevice dbplc, int startAddress, int length, ref int[] resultArray)
        {
            if (resultArray.Length >= length)
            {
                for (int i = 0; i < length; i++)
                {
                    resultArray[i] = dbCm.ReadDevice(dbplc, (startAddress + i).ToString());
                }
                return true;

            }
            else return false;

        }
        /// <summary>
        /// 写寄存器
        /// </summary>
        /// <param name="dbPlc"></param>
        /// <param name="memoryStart"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteMemory(DBPlcDevice dbPlc, string memoryStart, int data)
        {
            dbCm.WriteDevice(dbPlc, memoryStart, data);
            return true;
        }
        /// <summary>
        /// 写寄存器（多写）
        /// </summary>
        /// <param name="dBPlc"></param>
        /// <param name="startAddress"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteMemory(DBPlcDevice dBPlc, int startAddress, int length, int[] value)
        {
            if (value.Length >= length)
            {
                for (int i = 0; i < length; i++)
                {
                    dbCm.WriteDevice(dBPlc, (startAddress + i).ToString(), value[i]);
                }
                return true;
            }
            else return false;
        }

    }
}
