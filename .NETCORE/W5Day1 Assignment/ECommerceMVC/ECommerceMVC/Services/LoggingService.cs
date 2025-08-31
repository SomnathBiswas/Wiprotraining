using System.Diagnostics;

namespace ECommerceMVC.Services
{
    public class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Debug.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}
