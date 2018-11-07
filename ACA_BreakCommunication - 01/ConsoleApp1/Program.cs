using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ACA_BreakCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] b = new byte[]
            //{
            //    1,2,3,4
            //};
            //b[b.Length] = 5;
            //int a = 29264;
            //byte z = (byte)a;
            //Console.WriteLine(b.ToString());
            //Console.ReadKey();
            SuyiMCCB si = new SuyiMCCB();
            
            si.Rs485.PortName = "COM1";
            si.Rs485.BaudRate = 9600;
            si.ConnectAddress = 1200;
            si.CommunicationTest();
        }
    }
}
