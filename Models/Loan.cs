namespace SarasaviLibrary.Models
{
    public class Loan
    {
        public string LoanId { get; set; }
        public User Borrower { get; set; }
        public BookCopy BookCopy { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
