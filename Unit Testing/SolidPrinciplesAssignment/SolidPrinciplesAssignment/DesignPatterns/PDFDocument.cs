using Interfaces;

namespace DesignPatterns
{
    public class PDFDocument : IDocument
    {
        public string GetContent() => "PDF Document Content";
    }
}
