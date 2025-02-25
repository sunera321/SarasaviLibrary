namespace SarasaviLibrary.Models
{
    public enum UserType
    {
        Member,   // Can borrow books
        Visitor   // Reference only
    }

    public class User
    {
        public string UserNumber { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public UserType Type { get; set; }
        public List<Loan> CurrentLoans { get; set; } = new List<Loan>();
    }
}
