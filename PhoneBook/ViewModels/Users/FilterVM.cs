using System;
using System.ComponentModel;
using System.Linq.Expressions;
using DataAccess.Entity;
using PhoneBook.ViewModels.Shared;

namespace PhoneBook.ViewModels.Users
{
    public class FilterVM
    {
        [DisplayName("Username:")]
        public string Username { get; set; }
        [DisplayName("First Name:")]
        public string FirstName { get; set; }
        [DisplayName("Last Name:")]
        public string LastName { get; set; }

        public Expression<Func<User, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(Username) || i.Username.Contains(Username)) &&
                        (string.IsNullOrEmpty(FirstName) || i.FirstName.Contains(FirstName)) &&
                        (string.IsNullOrEmpty(LastName) || i.LastName.Contains(LastName));
        }
    }
}