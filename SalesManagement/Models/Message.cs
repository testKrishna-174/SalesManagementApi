using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Name  { get; set; }
        public string DisplayText { get; set; }
        public string StatusCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }


    }
}
