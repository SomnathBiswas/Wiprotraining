using Formatters;
using Interfaces;
using Services;
using DesignPatterns;
using SolidPrinciplesAssignment.Formatters;

class Program
{
    static void Main()
    {
        IReportFormatter formatter = new PdfReportFormatter();
        IReportService reportService = new ReportService(formatter);
        reportService.GenerateAndSaveReport();
        Console.WriteLine("Report generated and saved.");


        var factory = new DocumentFactory();
        var doc = factory.CreateDocument("PDF");
        Console.WriteLine(doc.GetContent());
    }

   

}
