using System;

namespace Tools
{
    public class Logger
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Logger));

        public static void Fatal(string message, Exception err = null)
        {
            if (err == null)
                logger.Fatal(message);
            else
            {
                logger.Fatal(message, err);
            }
        }

        public static void Info(string message, Exception err = null)
        {
            if (err == null)
                logger.Info(message);
            else
            {
                logger.Info(message, err);
            }
        }
    }
}