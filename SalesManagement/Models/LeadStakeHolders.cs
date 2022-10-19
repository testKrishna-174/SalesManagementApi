using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class LeadStakeHolders
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int StakeHolderId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdateBy { get; set; }

    }
}
