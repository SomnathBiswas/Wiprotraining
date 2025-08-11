using Interfaces;

namespace DesignPatterns
{
    public class DocumentFactory
    {
        public IDocument CreateDocument(string type)
        {
            return type switch
            {
                "PDF" => new PDFDocument(),
                "Word" => new WordDocument(),
                _ => throw new ArgumentException("Invalid document type")
            };
        }
    }
}
