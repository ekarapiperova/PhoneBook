using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Phone : BaseEntity
    {
        public int ContactId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
