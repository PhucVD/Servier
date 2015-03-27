using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servier.Common
{
    class LogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Debug(string message)
        {
        
        }


        //public static void Info(string message)
        //{
        //    string settingLog = ConfigurationSettings.GetConfig("GetConfigSetting(CommonConstants.CONFIG_LOG_NODE,
        //        CommonConstants.CONFIG_LOG_ISLOGFILE_NODE);
        //    if (settingLog.ToLower() == "true")
        //    {
        //        Logger.Info(message);
        //    }
        //}

        //public static void Error(string message)
        //{
        //    string settingLog = ConfigurationSettingHelper.GetConfigSetting(CommonConstants.CONFIG_LOG_NODE,
        //        CommonConstants.CONFIG_LOG_ISLOGEXCEPTION_NODE);
        //    if (settingLog.ToLower() == "true")
        //    {
        //        Logger.Error(message);
        //    }
        //}

        //public static void Error(string message, Exception exception)
        //{
        //    string settingLog = ConfigurationSettingHelper.GetConfigSetting(CommonConstants.CONFIG_LOG_NODE,
        //        CommonConstants.CONFIG_LOG_ISLOGEXCEPTION_NODE);
        //    if (settingLog.ToLower() == "true")
        //    {
        //        Logger.Error(message, exception);
        //    }
        //}
    }
}
