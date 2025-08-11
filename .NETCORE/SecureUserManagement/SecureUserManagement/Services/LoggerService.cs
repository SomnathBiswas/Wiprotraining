using NLog;

namespace SecureUserManagement.Services
{
    public class LoggerService
    {
        //private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message) => logger.Info(message);
        public void LogError(string message, Exception ex) => logger.Error(ex, message);
    }
}
