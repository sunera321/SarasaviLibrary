using System;
using System.Collections.Generic;

namespace SarasaviLibrary.Data
{
    public class LibraryData
    {
        public List<Book> Books { get; private set; }
        public List<Member> Members { get; private set; }
        public List<Loan> Loans { get; private set; }

        public LibraryData()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            Loans = new List<Loan>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterMember(Member member)
        {
            Members.Add(member);
        }

        public void LoanBook(int bookId, int memberId)
        {
            var book = Books.Find(b => b.BookId == bookId);
            var member = Members.Find(m => m.MemberId == memberId);

            if (book != null && member != null && !book.IsLoaned)
            {
                book.IsLoaned = true;
                Loans.Add(new Loan { Book = book, Member = member, LoanDate = DateTime.Now });
            }
        }

        public void ReturnBook(int bookId)
        {
            var loan = Loans.Find(l => l.Book.BookId == bookId);
            if (loan != null)
            {
                loan.Book.IsLoaned = false;
                Loans.Remove(loan);
            }
        }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsLoaned { get; set; } = false;
    }

    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
    }

    public class Loan
    {
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
