using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class LeadStatus
    {
        public int StatusId { get; set; }
        public int LeadId { get; set; }
        public int LeadStageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

    }
}
