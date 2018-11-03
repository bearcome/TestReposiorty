using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.Common
{
    public class Log4netHelper
    {
        public static void ErrorLog(Exception ex)
        {
            ErrorLog(MethodBase.GetCurrentMethod().DeclaringType, ex.ToString());
        }
        public static void ErrorLog(Type type, Exception ex)
        {
            ErrorLog(type, ex.ToString());
        }
        public static void ErrorLog(Type type, string msg)
        {
            BaseLog(Log4NetTypeEnum.Error, type, msg);
        }
        public static void ErrorLog(string msg)
        {
            ErrorLog(MethodBase.GetCurrentMethod().DeclaringType, msg);
        }
        public static void InfoLog(Type type, string msg)
        {
            BaseLog(Log4NetTypeEnum.Info, type, msg);
        }
        public static void InfoLog(string msg)
        {
            InfoLog(MethodBase.GetCurrentMethod().DeclaringType, msg);
        }
        public static void BaseLog(Log4NetTypeEnum logType, Type type, string msg)
        {
            ILog log = LogManager.GetLogger(type);
            switch (logType)
            {
                case Log4NetTypeEnum.Error:
                    log.Error(msg);
                    break;
                case Log4NetTypeEnum.Info:
                    log.Info(msg);
                    break;
            }
        }
    }
    public enum Log4NetTypeEnum
    {
        Error,
        Info
    }
}
