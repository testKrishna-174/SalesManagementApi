using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class FileUploadStaging
    {
		public string Date_Entered { get; set; }
		public string Source { get; set; }
		public string Supervisor_First_Name { get; set; }
		public string Supervisor_Middle_Initial { get; set; }
		public string Supervisor_Last_Name { get; set; }
		public string Salesperson_First_Name { get; set; }
		public string Salesperson_Middle_Initial { get; set; }
		public string Salesperson_Last_Name { get; set; }
		public string COMPANY_NAME { get; set; }
		public string ADDRESS { get; set; }
		public string CITY { get; set; }
		public string STATE { get; set; }
		public string ZIPCODE { get; set; }
		public string County { get; set; }
		public string PHONE_NUMBER { get; set; }
		public string WEBADDRESS { get; set; }
		public string LAST_NAME { get; set; }
		public string FIRST_NAME { get; set; }
		public string CONTACT_TITLE { get; set; }
		public string ACTUAL_EMPLOYEE_SIZE { get; set; }
		public string EMPLOYEE_SIZE_RANGE { get; set; }
		public string ACTUAL_SALES_VOLUME { get; set; }
		public string SALES_VOLUME_RANGE { get; set; }
		public string PRIMARY_SIC { get; set; }
		public string PRIMARY_SIC_DESCRIPTION { get; set; }
		public string SECONDARY_SIC_1 { get; set; }
		public string SECONDARY_SIC_DESCRIPTION_1 { get; set; }
		public string SECONDARY_SIC_2 { get; set; }
		public string SECONDARY_SIC_DESCRIPTION_2 { get; set; }
		public string CREDIT_NUMERIC_SCORE { get; set; }
		public string HEADQUARTERS_BRANCH { get; set; }
		public string FIRM_INDIVIDUAL { get; set; }
		public string PUBLIC_PRIVATE_FLAG { get; set; }
		public string EXECUTIVE_EMAIL { get; set; }
		public string NOTES { get; set; }
		public string LOCATION_ADDRESS { get; set; }
		public string LOCATION_ADDRESS_CITY { get; set; }
		public string LOCATION_ADDRESS_STATE { get; set; }
		public string LOCATION_ADDRESS_ZIP { get; set; }
		public string LOCATION_COUNTY { get; set; }
		public int PageSize { get; set; }
		public int PageCount { get; set; }
	}
}
