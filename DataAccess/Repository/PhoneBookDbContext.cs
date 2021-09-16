using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public PhoneBookDbContext() : base("PhoneBookDbConnection")
        {
            this.Users = this.Set<User>();
            this.Contacts = this.Set<Contact>();
            this.Phones = this.Set<Phone>();
        }
    }
}
