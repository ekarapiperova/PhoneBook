using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Entity;
using PhoneBook.ViewModels.Shared;

namespace PhoneBook.ViewModels.Users
{
    public class IndexVM
    {
        public PagerVM Pager { get; set; }
        public FilterVM Filter { get; set; }

        public List<User> Items { get; set; }
    }
}