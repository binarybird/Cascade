using System;
using System.Collections.Generic;
using System.IO;
using Cascade.CodeAnalysis.Common.Roslyn;
using Cascade.CodeAnalysis.Common.Simulation;
using Cascade.CodeAnalysis.Core.Simulator.Visitors;
using Cascade.Rule;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Cascade.CodeAnalysis.Cli
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            InitLogger();
            //TODO - actual args
        }

        static void InitLogger()
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