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
            logger.Info(message + "\r\n");
        }
        public static void WriteError(string message)
        {
            logger.Error(message + "\r\n");
        }
        public static void WriteException(string message, Exception ex)
        {
            logger.Log(NLog.LogLevel.Fatal, ex, message + "\r\n");
        }
    }
}