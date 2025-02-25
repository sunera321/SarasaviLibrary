using System;
using System.Collections.Generic;
using System.Linq;
using SarasaviLibrary.Models;

namespace SarasaviLibrary.Services
{
    public class BookService
    {
        // In-memory list to simulate the library's book catalogue.
        public List<BookTitle> BookTitles { get; set; } = [];

        // Register a new book title into the catalogue.
        public void RegisterBookTitle(BookTitle bookTitle)
        {
            if (BookTitles.Any(bt => bt.BookNumber == bookTitle.BookNumber))
            {
                throw new Exception("A book title with the same Book Number already exists.");
            }
            BookTitles.Add(bookTitle);
        }

        // Add a new copy to an existing book title.
        // A maximum of 10 copies are allowed per title.
        public void RegisterBookCopy(string bookNumber, BookCopy copy)
        {
            var bookTitle = BookTitles.FirstOrDefault(bt => bt.BookNumber == bookNumber);
            if (bookTitle == null)
            {
                throw new Exception("Book title not found.");
            }
            if (bookTitle.Copies.Count >= 10)
            {
                throw new Exception("Maximum number of copies reached for this book title.");
            }
            // Generate a copy number (e.g., "X 9999-1").
            copy.CopyNumber = $"{bookNumber}-{bookTitle.Copies.Count + 1}";
            bookTitle.Copies.Add(copy);
        }

        // Inquiry process: search by accession number, title, or author.
        public BookTitle Inquiry(string searchTerm)
        {
            return BookTitles.FirstOrDefault(bt =>
                bt.BookNumber.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                bt.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                bt.Author.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
