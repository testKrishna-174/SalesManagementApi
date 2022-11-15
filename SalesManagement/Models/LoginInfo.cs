using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class LoginInfo
    {
        public int LoginId { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public DateTime LastLoggedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
