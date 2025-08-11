using Interfaces;

namespace Formatters
{
    public class ExcelReportFormatter : IReportFormatter
    {
        public string Format(string content)
        {
            return $"[Excel] {content}";
        }
    }
}
