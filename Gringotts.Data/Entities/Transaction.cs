using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Data.Entities
{
    public class Transaction : BaseEntity
    {
        public long CustomerNumber { get; set; }
        public long AccountNumber { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
