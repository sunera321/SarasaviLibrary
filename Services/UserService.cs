using System;
using System.Collections.Generic;
using System.Linq;
using SarasaviLibrary.Models;

namespace SarasaviLibrary.Services
{
    public class UserService
    {
        // In-memory list to store registered users.
        public List<User> Users { get; set; } = [];

        // Register a new user.
        public void RegisterUser(User user)
        {
            if (Users.Any(u => u.UserNumber == user.UserNumber))
            {
                throw new Exception("A user with the same User Number already exists.");
            }
            Users.Add(user);
        }

        // Retrieve a user by user number or NIC.
        public User GetUser(string searchTerm)
        {
            return Users.FirstOrDefault(u =>
                u.UserNumber.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                u.NIC.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}
