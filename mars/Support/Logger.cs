using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Support
{
    public static class Logger
    {
        public static void InitializeLogger()
        {
            string logPath = Path.Combine("D:\\Kelly\\Mars\\Mars", "logs\\testlog.txt");
            Log.Information("Logging to file: {LogFile}", logPath);
            Log.Logger = new LoggerConfiguration().
                MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public static void CloseAndFlushLogger() {
            Log.CloseAndFlush(); //Ensure logs are written and flushed
        }
    }
}
