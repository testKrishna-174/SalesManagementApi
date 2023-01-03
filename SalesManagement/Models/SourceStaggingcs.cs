namespace SalesManagement_API.Models
{
    public class SourceStaggingcs
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public string DateEntered { get; set; }
        public string Source { get; set; }
        public string Supervisor_First_Name { get; set; }
        public string Supervisor_Middle_Initial { get; set; }
        public string Supervisor_Last_Name { get; set; }
        public string Salesperson_First_Name { get; set; }
        public string Salesperson_Middle_Initial { get; set; }
        public string Salesperson_Last_Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactTitle { get; set; }
        public string ActualEmployeeSize { get; set; }
        public string EmployeeSizeRange { get; set; }
        public string ActualSalesVolume { get; set; }
        public string SalesVolumeRange { get; set; }
        public string Primary_SIC { get; set; }
        public string Primary_SIC_Description { get; set; }
        public string Secondary_SIC1 { get; set; }
        public string Secondary_SIC_Description1 { get; set; }
        public string Secondary_SIC2 { get; set; }
        public string Secondary_SIC_Description2 { get; set; }
        public string Credit_Numeric_Score { get; set; }
        public string Headquaters_Branch { get; set; }
        public string Firm_Individual { get; set; }
        public string Public_Private_Flag { get; set; }
        public string Executive_Flag { get; set; }
        public string Notes { get; set; }
        public string Location_Address { get; set; }
        public string Location_Address_City { get; set; }
        public string Location_Address_State { get; set; }
        public string Location_Address_Zip { get; set; }
        public string Location_County { get; set; }
        public bool IsProcessed { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

    }
}
