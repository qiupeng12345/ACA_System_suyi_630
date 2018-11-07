using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
namespace ACA_Common.Class
{
    public  class LogHelper
    {

        public static log4net.ILog loginfo = log4net.LogManager.GetLogger("log");

        public static log4net.ILog logerror = log4net.LogManager.GetLogger("log");

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void WriteLog(string info)
        {
            loginfo.Info(info);
        }

        public static void WriteLog( Exception se)
        {
            logerror.Error( se);
        }
    }
}
