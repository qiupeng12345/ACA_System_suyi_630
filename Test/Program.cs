using System;
using ACA_BreakCommunication;
using System.Threading;
using ACA_Common.Class;
using log4net;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            frmTest f1 = new frmTest();
            f1.ShowDialog();
            //double z = 2.88;
            //int y = (int)z;
            //Console.WriteLine(y.ToString());
            //LogTest log = new LogTest();
            //log.print();

            //LogHelper.WriteLog("111112233");
            //int a; int b;
            //Thread th1 = new Thread(test);
            //th1.IsBackground = true;
            //th1.Start();
            //if (th1.ThreadState!=ThreadState.Running)
            //{
            //    th1.Start();
            //}

            //frmTest frmTest = new frmTest();
            //frmTest.ShowDialog();
            KVDH1 kv = new KVDH1();
            //DATABUILDERAXLibLB.DBCommManagerClass kv = new DATABUILDERAXLibLB.DBCommManagerClass();
            kv.PLC = DATABUILDERAXLibLB.DBPlcId.DBPLC_DKV7K;
            kv.Peer = "192.168.250.111:8500";
            int[] a = new int[1000];
            int[] b = new int[2000];
            //for (int i = 0; i < a.Length; i++)
            // {
            //     a[i] = 1000+i;
            // }
            //string strWrite = "111111111111111111111122222222222222222233333333333333333333333";
            //string strResult = "";
            try
            {
                Thread.Sleep(1000);
                kv.Connect();
                kv.WriteMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, 100, 1000, a);
                kv.ReadMemory(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, 100, 1000, ref b);
                //kv.WriteText(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "100", 200, strWrite);*/
                //kv.ReadText(DATABUILDERAXLibLB.DBPlcDevice.DKV7K_EM, "100", 200, out strResult);
                //kv.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, "170000", 1);
                //kv.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_B, "170001", 1);
                //int i = kv.ReadDevice(DATABUILDERAXLibLB.DBPlcDevice.DKV7KXYM_RLY_W, "10");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                Console.WriteLine(ex.ToString());
            }

            //uint a = 16;
            //uint b = 17;
            //person a = new person();
            //a.Name = "duyangyang";
            //a.Age = 13;
            //a.eat();
            //person b = new person();
            //b.Name = "yanxiaocheng";
            //b.Age = 11;
            //b.eat();
            //Console.ReadLine();


            ////double result = Dint_to_Real(b, a);
            //double result1 = qp1(b, a);
            //Console.WriteLine(result.ToString());
            //Console.WriteLine(result1.ToString());
            //Console.ReadKey();

        }
       
        private static void test()
        {

        }
        public class LogTest
        {
            public void print()
            {
                ILog m_log = LogManager.GetLogger("log");
                m_log.Debug("这是一个Debug日志" + 2);
                m_log.Info("这是一个Info日志");
                m_log.Warn("这是一个Warn日志");
                m_log.Error("这是一个Error日志");
                m_log.Fatal("这是一个Fatal日志");
            }
        }
        public class person
        {
            private string name;
            private int age;

            public string Name { get { return name; } set { name = value; } }
            public int Age { get { return age; } set { age = value; } }

            public void eat()
            {
                Console.WriteLine(name + "吃饭");
            }
        }

        public static double qp1(uint h, uint l)
        {
            UInt32 a = (UInt32)((h << 16) + l);
            string b = ToBin(a);
            char[] b1 = b.ToCharArray();
            int c = 0;
            string c1 = "1.";
            for (int i = 1; i < 9; i++)
            {
                c = c * 2 + Convert.ToInt16(b1[i].ToString());
            }
            for (int i = 9; i < 32; i++)
            {
                c1 += b1[i].ToString();
            }
            int c2 = Convert.ToInt32(c1);
            if (b1[0] == '1')
            {
                return c2 * Math.Pow(2, (c - 127));
            }
            else
            {
                return (c2 * Math.Pow(2, (c - 127))) * -1;
            }

        }
        private static string ToBin(UInt32 c)
        {
            string result = "";
            for (int i = 0; i < 32; i++)
            {
                if ((c & 0x80000000) == 0x80000000)
                {
                    result += "1";
                }
                else result += "0";
                c = c << 1;
            }
            return result;
        }
    }
}
