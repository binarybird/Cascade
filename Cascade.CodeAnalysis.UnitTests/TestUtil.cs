using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Cascade.CodeAnalysis.UnitTests
{
    public class TestUtil
    {
        public static void InitLogger()
        {
            Console.WriteLine("Initializing logger");
            LoggingConfiguration config = new LoggingConfiguration();
            ConsoleTarget console = new ConsoleTarget()
            {
                Name = "console",
                Layout = @"[${longdate}] ${level:uppercase=true} ${logger}: ${message} ${exception}"
            };
            config.AddRule(LogLevel.Info, LogLevel.Fatal, console);
            LogManager.Configuration = config;
        }
    }
}
