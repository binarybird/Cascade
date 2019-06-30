using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using Xunit.Abstractions;

namespace Cascade.CodeAnalysis.Tests
{
    public abstract class TestBase
    {
        internal TestBase(ITestOutputHelper outputHelper)
        {
            Console.WriteLine("Initializing logger");
            LoggingConfiguration config = new LoggingConfiguration();

            ConsoleTarget console = new ConsoleTarget()
            {
                Name = "console",
                Layout = @"[${longdate}] ${level:uppercase=true} ${logger}: ${message} ${exception}"
            };
            config.AddRule(LogLevel.Info, LogLevel.Fatal, console);

            XunitTarget xunit = new XunitTarget(outputHelper)
            {
                Name = "xunit",
                Layout = @"[${longdate}] ${level:uppercase=true} ${logger}: ${message} ${exception}"
            };
            config.AddRule(LogLevel.Info, LogLevel.Fatal, xunit);

            LogManager.Configuration = config;
        }
    }

    internal class XunitTarget : TargetWithLayout
    {
        private readonly ITestOutputHelper _output;

        internal XunitTarget(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }

        protected override void Write(LogEventInfo logEvent)
        {
            _output.WriteLine(this.Layout.Render(logEvent));
        }
    }
}
