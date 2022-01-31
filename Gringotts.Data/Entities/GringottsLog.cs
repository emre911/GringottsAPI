using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Data.Entities
{
    public class GringottsLog : BaseEntity
    {
        public string MethodName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime RespondedOn { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
