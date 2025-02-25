namespace SarasaviLibrary.Models
{
    public class BookTitle
    {
        public string BookNumber { get; set; }  
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public List<BookCopy> Copies { get; set; } = new List<BookCopy>();
    }
}
