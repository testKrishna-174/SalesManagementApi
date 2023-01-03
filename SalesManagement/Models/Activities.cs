using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class Activities
    {
     public int ActivityId { get; set; }
     public string ActivityCode { get; set; }
     public string ActivityName { get; set; }
     public string Description { get; set; }
     public bool IsActive { get; set; }
     public DateTime CreatedOn { get; set; } 
     public int CreatedBy{ get; set; }
     public DateTime UpdatedOn { get; set; }
     public int UpdatedBy { get; set; }
     public int PageSize { get; set; }
     public int PageCount { get; set; }

    }
}
