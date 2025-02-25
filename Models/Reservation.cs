namespace SarasaviLibrary.Models
{
    public class Reservation
    {
        public string ReservationId { get; set; }
        public User ReservingUser { get; set; }
        public BookTitle BookTitle { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
