using Interfaces;

namespace DesignPatterns
{
    public class WordDocument : IDocument
    {
        public string GetContent() => "Word Document Content";
    }
}
