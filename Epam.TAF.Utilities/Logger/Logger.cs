using Serilog;

namespace Epam.TAF.Utilities.Logger
{
    public static class Logger
    {
        private static ILogger _logger = null;

        public static void Info(string message)
        {
            _logger.Information(message);
        }

        public static void InitLogger(string loggerName, string pathFolder)
        {
            Directory.CreateDirectory(pathFolder);

            _logger = new LoggerConfiguration().WriteTo
                .File(Path.Combine(pathFolder, loggerName + ".txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
