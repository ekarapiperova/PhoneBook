using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class Contact : BaseEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
