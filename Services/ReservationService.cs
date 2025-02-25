using System;
using System.Collections.Generic;
using System.Linq;
using SarasaviLibrary.Models;

namespace SarasaviLibrary.Services
{
    public class ReservationService
    {
        // In-memory list to simulate reservation records.
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        // Add a reservation for a book title.
        public void AddReservation(User user, BookTitle bookTitle)
        {
            var reservation = new Reservation
            {
                ReservationId = Guid.NewGuid().ToString(),
                ReservingUser = user,
                BookTitle = bookTitle,
                ReservationDate = DateTime.Now
            };

            Reservations.Add(reservation);
        }

        // Retrieve the oldest reservation for a given book title.
        public Reservation GetOldestReservation(BookTitle title)
        {
            return Reservations
                .Where(r => r.BookTitle.BookNumber == title.BookNumber)
                .OrderBy(r => r.ReservationDate)
                .FirstOrDefault();
        }

        // Remove a reservation from the list.
        public void RemoveReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
        }
    }
}
