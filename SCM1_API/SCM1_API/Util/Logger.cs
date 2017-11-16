using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCM1_API.Util
{
    public static class Logger
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Write(string message)
        {
            logger.Info(message);
        }
        public static void WriteError(string message)
        {
            logger.Error(message);
        }
        public static void WriteException(string message, Exception ex)
        {
            logger.Log(NLog.LogLevel.Fatal, ex, message);
        }
    }
}