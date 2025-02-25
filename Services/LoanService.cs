using System;
using SarasaviLibrary.Models;

namespace SarasaviLibrary.Services
{
    public class LoanService
    {
        // Check if the user is eligible to borrow a book.
        public bool CanBorrow(User user)
        {
            // Only members can borrow books.
            if (user.Type == UserType.Visitor)
                return false;

            // A maximum of 5 active loans allowed.
            if (user.CurrentLoans.Count >= 5)
                return false;

            // Check for any overdue loans.
            foreach (var loan in user.CurrentLoans)
            {
                if (!loan.IsReturned && loan.DueDate < DateTime.Now)
                    return false;
            }
            return true;
        }

        // Create a new loan if the user is eligible and the book copy is borrowable.
        public Loan CreateLoan(User user, BookCopy copy)
        {
            if (!CanBorrow(user))
                throw new Exception("User cannot borrow any more books.");

            if (copy.IsReferenceOnly)
                throw new Exception("This copy is for reference only and cannot be borrowed.");

            var loan = new Loan
            {
                LoanId = Guid.NewGuid().ToString(),
                Borrower = user,
                BookCopy = copy,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                IsReturned = false
            };

            // Mark the copy as borrowed.
            copy.IsBorrowed = true;
            user.CurrentLoans.Add(loan);
            return loan;
        }
    }
}
