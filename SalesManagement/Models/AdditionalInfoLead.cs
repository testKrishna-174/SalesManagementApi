using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class AdditionalInfoLead
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string Primary_SIC { get; set; }
        public string Primary_SIC_Description { get; set; }
        public string Secondary_SIC_1{ get; set; }
        public string Secondary_SIC_Description_1 { get; set; }
        public string Secondary_SIC_2 { get; set; }
        public string Secondary_SIC_Description_2 { get; set; }
        public string Credit_Numeric_Score { get; set; }
        public string Headquarters_Branch { get; set; }
        public string Firm_Individual { get; set; }
        public string Public_Private_Flag { get; set; }
        public string Notes { get; set; }
        public string Location_Address  { get; set; }
        public string Location_Address_City { get; set; }
        public string Location_Address_State { get; set; }
        public string Location_Address_Zip { get; set; }
        public string Location_County { get; set; }
        public DateTime Date_Entered { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

    }
}
