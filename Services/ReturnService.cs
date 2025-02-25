using System;
using System.Linq;
using SarasaviLibrary.Models;

namespace SarasaviLibrary.Services
{
    public class ReturnService
    {
        private readonly ReservationService _reservationService;
        private readonly BookService _bookService;

        public ReturnService(ReservationService reservationService)
        {
        }

        // Constructor with dependency injection.
        public ReturnService(ReservationService reservationService, BookService bookService)
        {
            _reservationService = reservationService;
            _bookService = bookService;
        }

        // Processes the return of a loan.
        public void ProcessReturn(Loan loan)
        {
            if (loan == null)
                throw new ArgumentNullException(nameof(loan));

            // Mark the loan as returned and update the copy status.
            loan.IsReturned = true;
            loan.BookCopy.IsBorrowed = false;

            // Check if the returned copy is marked as reserved.
            if (loan.BookCopy.IsReserved)
            {
                // Extract the book number from the copy's CopyNumber.
                // Expected format: "X 9999-1" where "X 9999" is the BookNumber.
                string[] parts = loan.BookCopy.CopyNumber.Split('-');
                if (parts.Length > 0)
                {
                    string bookNumber = parts[0];

                    // Find the corresponding BookTitle using the BookService.
                    BookTitle bookTitle = _bookService.BookTitles
                        .FirstOrDefault(bt => bt.BookNumber.Equals(bookNumber, StringComparison.OrdinalIgnoreCase));

                    if (bookTitle != null)
                    {
                        // Retrieve the oldest reservation for the book title.
                        Reservation oldestReservation = _reservationService.GetOldestReservation(bookTitle);
                        if (oldestReservation != null)
                        {
                            // Notify the reserving user.
                            // In a real-world app, this might trigger an email or UI notification.
                            Console.WriteLine($"Notification: Dear {oldestReservation.ReservingUser.Name}, " +
                                              $"the book '{bookTitle.Title}' is now available for pickup.");

                            // After notifying, remove the reservation.
                            _reservationService.RemoveReservation(oldestReservation);
                        }
                    }
                }
            }
        }
    }
}
