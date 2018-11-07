using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACA_BreakCommunication;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            KVDH1 KV1 = new KVDH1();
            KV1.AxdbCm.PLC = DATABUILDERAXLibLB.DBPlcId.DBPLC_DKV5000;
            KV1.AxdbCm.Peer = "192.168.1.10:8000";
        }
    }
}
