namespace SarasaviLibrary.Models
{
    public class BookCopy
    {
        public string CopyNumber { get; set; } // e.g., "X 9999-1"
        public bool IsReferenceOnly { get; set; }
        public bool IsBorrowed { get; set; }
        public bool IsReserved { get; set; }
    }
}
