using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Data.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int YearBirth { get; set; }
        public string Gender { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
