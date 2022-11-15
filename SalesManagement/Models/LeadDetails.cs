using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class LeadDetails
    {
        public int LeadId { get; set; }
        public int LeadFileId { get; set; }
        public string Source { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyName { get; set; }
        public string WebAddress { get; set; }
        public string OfficeEmail { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public string County { get; set; }
        public int EmployeeSize { get; set; }
        public string EmployeeSizeRange { get; set; }
        public decimal SalesVolume { get; set; }
        public string SalesVolumeRange { get; set; }


    }
}
