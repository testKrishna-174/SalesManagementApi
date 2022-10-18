using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class ActivityRoleMapping
    {
        public int RoleMappingId { get; set; }
        public int ActivityId { get; set; } 
        public int DesignationId { get; set; }
        public  bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

    }
}
