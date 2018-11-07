using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACA_BreakCommunication;
using System.IO.Ports;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            //KVDH1 kv = new KVDH1();
            //kv.PLC = DATABUILDERAXLibLB.DBPlcId.DBPLC_DKV7K;
            //kv.Peer = "192.168.250.111:8500";
            //if (kv.Connect())
            //{
            //    kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "200", 1000);
            //    int i = kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "200");
            //}
            //SuyiMCCB SU = new SuyiMCCB();
            //SU.Rs485.PortName = "COM4";
            //SU.Rs485.BaudRate = 2400;
            //SU.Rs485.DataBits = 8;
            //SU.Rs485.StopBits = System.IO.Ports.StopBits.One;
            //SU.Rs485.Parity = System.IO.Ports.Parity.Even;
            //SU.Rs485.Open();
            //SU.CommunicationTest();
            SerialPort sp = new SerialPort();
            sp.PortName = "com3";
            sp.BaudRate = 9600;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Parity = Parity.Even;
            sp.ReadTimeout = 1000;
            sp.Open();
            string stt = "";
            //byte[] nb = new byte[]
            //{
            //    0x11,0x22,0x33
            //};
            //string str = byteToHexStr(nb);
            string str = "6800000000000068110435343337B816";
            try
            {
                sp.Write(str);
                byte[] nb = new byte[1024];
                stt= sp.ReadExisting();
            }
            catch (Exception ex)
            {

                throw;
            }
            Console.WriteLine(stt);
            
            //sp.Write(str);    
        }
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
    }
}
