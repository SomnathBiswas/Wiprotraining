using Interfaces;

namespace SolidPrinciplesAssignment.Formatters
{
    public class PdfReportFormatter : IReportFormatter
    {
        public string Format(string content)
        {
            return $"[PDF] {content}";
        }
    }
}
