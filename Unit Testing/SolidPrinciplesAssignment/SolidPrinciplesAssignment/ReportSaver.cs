using System.IO;

namespace Services
{
    public class ReportSaver
    {
        public void SaveReport(string reportContent, string filePath)
        {
            File.WriteAllText(filePath, reportContent);
        }
    }
}
