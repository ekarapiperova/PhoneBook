using System;
using System.ComponentModel;
using System.Linq.Expressions;
using DataAccess.Entity;
using PhoneBook.ViewModels.Shared;

namespace PhoneBook.ViewModels.Phones
{
    public class FilterVM
    {
        public int ContactId { get; set; }
        [DisplayName("Phone Number:")]
        public string PhoneNumber { get; set; }

        public Expression<Func<Phone, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(PhoneNumber) || i.PhoneNumber.Contains(PhoneNumber)) &&
                        (i.ContactId == ContactId);
        }
    }
}