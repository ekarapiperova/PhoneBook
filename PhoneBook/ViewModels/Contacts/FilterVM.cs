using System;
using System.ComponentModel;
using System.Linq.Expressions;
using DataAccess.Entity;
using PhoneBook.ViewModels.Shared;

namespace PhoneBook.ViewModels.Contacts
{
    public class FilterVM
    {
        public int UserId { get; set; }
        [DisplayName("Full Name:")]
        public string FullName { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }

        public Expression<Func<Contact, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(FullName) || i.FullName.Contains(FullName)) &&
                        (string.IsNullOrEmpty(Email) || i.Email.Contains(Email)) &&
                        (i.UserId == UserId);
        }
    }
}