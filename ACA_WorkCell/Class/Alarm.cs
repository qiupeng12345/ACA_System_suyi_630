using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACA_Common.Class
{
    /// <summary>
    /// 用于记录报警信息的类
    /// </summary>
    public class AlarmInfo
    {
        private DateTime time;
        private string info;

        public DateTime Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Info
        {
            get
            {
                return info;
            }

            set
            {
                info = value;
            }
        }
        public AlarmInfo()
        {

        }
        public AlarmInfo(DateTime dt, string inf)
        {
            Time = dt;
            Info = inf;
        }

        //public DateTime Time { get => time; set => time = value; }
        //public string Info { get => info; set => info = value; }
    }
    /// <summary>
    /// 用于对应寄存器地址来判断是否报警的类
    /// </summary>
    public class AlarmObject
    {
        private string alarmAddress;
        private string alarmTip;
        private bool isAlarming;
        //public string AlarmAddress { get => alarmAddress; set => alarmAddress = value; }
        //public string AlarmTip { get => alarmTip; set => alarmTip = value; }
        //public bool IsAlarming { get => isAlarming; set => isAlarming = value; }
        public AlarmObject(string alarmaddress, string alarmtip, bool isalarming)
        {
            AlarmAddress = alarmaddress;
            AlarmTip = alarmtip;
            IsAlarming = isalarming;
        }

        public string AlarmAddress
        {
            get
            {
                return alarmAddress;
            }

            set
            {
                alarmAddress = value;
            }
        }

        public string AlarmTip
        {
            get
            {
                return alarmTip;
            }

            set
            {
                alarmTip = value;
            }
        }

        public bool IsAlarming
        {
            get
            {
                return isAlarming;
            }

            set
            {
                isAlarming = value;
            }
        }
    }
}
