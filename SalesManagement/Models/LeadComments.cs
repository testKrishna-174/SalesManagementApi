using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class LeadComments
    {
        public int CommentId { get; set; }
        public int LeadId { get; set; }
        public int LeadStageId { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

    }
}
