using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
