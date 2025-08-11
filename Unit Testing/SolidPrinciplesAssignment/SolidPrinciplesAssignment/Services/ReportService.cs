using Interfaces;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly IReportFormatter _formatter;
        private readonly ReportGenerator _generator;
        private readonly ReportSaver _saver;

        public ReportService(IReportFormatter formatter)
        {
            _formatter = formatter;
            _generator = new ReportGenerator();
            _saver = new ReportSaver();
        }

        public void GenerateAndSaveReport()
        {
            string raw = _generator.GenerateReport();
            string formatted = _formatter.Format(raw);
            _saver.SaveReport(formatted, "report.txt");
        }
    }
}
