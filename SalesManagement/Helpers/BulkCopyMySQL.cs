using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SalesManagement_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Helpers
{
    public class BulkCopyMySQL
    {
        private readonly IConfiguration _configuration;
        public BulkCopyMySQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Start(string tableName, List<FileUploadStaging> linkList, UInt64 fileId)
        {
            DataTable table = new DataTable();

            // Getting datatable layout from database
            table = GetDataTableLayout(tableName);

            // Pupulate datatable
            foreach (FileUploadStaging link in linkList)
            {
                DataRow row = table.NewRow();
                row["FileId"] = Convert.ToUInt64(fileId);
                row["Date_Entered"] = link.Date_Entered;
                row["Source"] = link.Source;
                row["Supervisor_First_Name"] = link.Supervisor_First_Name;
                row["Supervisor_Middle_Initial"] = link.Supervisor_Middle_Initial;
                row["Supervisor_Last_Name"] = link.Supervisor_Last_Name;
                row["Salesperson_First_Name"] = link.Salesperson_First_Name;
                row["Salesperson_Middle_Initial"] = link.Salesperson_Middle_Initial;
                row["Salesperson_Last_Name"] = link.Salesperson_Last_Name;
                row["COMPANY_NAME"] = link.COMPANY_NAME;
                row["ADDRESS"] = link.ADDRESS;
                row["CITY"] = link.CITY;
                row["STATE"] = link.STATE;
                row["ZIPCODE"] = link.ZIPCODE;
                row["County"] = link.County;
                row["PHONE_NUMBER"] = link.PHONE_NUMBER;
                row["WEBADDRESS"] = link.WEBADDRESS;
                row["LAST_NAME"] = link.LAST_NAME;
                row["FIRST_NAME"] = link.FIRST_NAME;
                row["CONTACT_TITLE"] = link.CONTACT_TITLE;
                row["ACTUAL_EMPLOYEE_SIZE"] = link.ACTUAL_EMPLOYEE_SIZE;
                row["EMPLOYEE_SIZE_RANGE"] = link.EMPLOYEE_SIZE_RANGE;
                row["ACTUAL_SALES_VOLUME"] = link.ACTUAL_SALES_VOLUME;
                row["SALES_VOLUME_RANGE"] = link.SALES_VOLUME_RANGE;
                row["PRIMARY_SIC"] = link.PRIMARY_SIC;
                row["PRIMARY_SIC_DESCRIPTION"] = link.PRIMARY_SIC_DESCRIPTION;
                row["SECONDARY_SIC_1"] = link.SECONDARY_SIC_1;
                row["SECONDARY_SIC_DESCRIPTION_1"] = link.SECONDARY_SIC_DESCRIPTION_1;
                row["SECONDARY_SIC_2"] = link.SECONDARY_SIC_2;
                row["SECONDARY_SIC_DESCRIPTION_2"] = link.SECONDARY_SIC_DESCRIPTION_2;
                row["CREDIT_NUMERIC_SCORE"] = link.CREDIT_NUMERIC_SCORE;
                row["HEADQUARTERS_BRANCH"] = link.HEADQUARTERS_BRANCH;
                row["FIRM_INDIVIDUAL"] = link.FIRM_INDIVIDUAL;
                row["PUBLIC_PRIVATE_FLAG"] = link.PUBLIC_PRIVATE_FLAG;
                row["EXECUTIVE_EMAIL"] = link.EXECUTIVE_EMAIL;
                row["NOTES"] = link.NOTES;
                row["LOCATION_ADDRESS"] = link.LOCATION_ADDRESS;
                row["LOCATION_ADDRESS_CITY"] = link.LOCATION_ADDRESS_CITY;
                row["LOCATION_ADDRESS_STATE"] = link.LOCATION_ADDRESS_STATE;
                row["LOCATION_ADDRESS_ZIP"] = link.LOCATION_ADDRESS_ZIP;
                row["LOCATION_COUNTY"] = link.LOCATION_COUNTY;
                row["IsProcessed"] = Convert.ToBoolean(0);				

                table.Rows.Add(row);
            }

            BulkInsertMySQL(table, tableName);
            // Enjoy
        }


        public DataTable GetDataTableLayout(string tableName)
        {
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("dbSales")))
            {
                connection.Open();
                // Select * is not a good thing, but in this cases is is very usefull to make the code dynamic/reusable 
                // We get the tabel layout for our DataTable
                string query = @"SELECT  FileId,
                                Date_Entered,
                                Source,
                                Supervisor_First_Name,
                                Supervisor_Middle_Initial,
                                Supervisor_Last_Name,
                                Salesperson_First_Name,
                                Salesperson_Middle_Initial,
                                Salesperson_Last_Name,
                                COMPANY_NAME,
                                ADDRESS,
                                CITY,
                                STATE,
                                ZIPCODE,
                                County,
                                PHONE_NUMBER,
                                WEBADDRESS,
                                LAST_NAME,
                                FIRST_NAME,
                                CONTACT_TITLE,
                                ACTUAL_EMPLOYEE_SIZE,
                                EMPLOYEE_SIZE_RANGE,
                                ACTUAL_SALES_VOLUME,
                                SALES_VOLUME_RANGE,
                                PRIMARY_SIC,
                                PRIMARY_SIC_DESCRIPTION,
                                SECONDARY_SIC_1,
                                SECONDARY_SIC_DESCRIPTION_1,
                                SECONDARY_SIC_2,
                                SECONDARY_SIC_DESCRIPTION_2,
                                CREDIT_NUMERIC_SCORE,
                                HEADQUARTERS_BRANCH,
                                FIRM_INDIVIDUAL,
                                PUBLIC_PRIVATE_FLAG,
                                EXECUTIVE_EMAIL,
                                NOTES,
                                LOCATION_ADDRESS,
                                LOCATION_ADDRESS_CITY,
                                LOCATION_ADDRESS_STATE,
                                LOCATION_ADDRESS_ZIP,
                                LOCATION_COUNTY,
                                IsProcessed
                            FROM " + tableName + " limit 0";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                };
            }

            return table;
        }

        public void BulkInsertMySQL(DataTable table, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("dbSales")))
            {
                connection.Open();

                using (MySqlTransaction tran = connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = tran;
                        cmd.CommandText = @"SELECT  FileId,
                                Date_Entered,
                                Source,
                                Supervisor_First_Name,
                                Supervisor_Middle_Initial,
                                Supervisor_Last_Name,
                                Salesperson_First_Name,
                                Salesperson_Middle_Initial,
                                Salesperson_Last_Name,
                                COMPANY_NAME,
                                ADDRESS,
                                CITY,
                                STATE,
                                ZIPCODE,
                                County,
                                PHONE_NUMBER,
                                WEBADDRESS,
                                LAST_NAME,
                                FIRST_NAME,
                                CONTACT_TITLE,
                                ACTUAL_EMPLOYEE_SIZE,
                                EMPLOYEE_SIZE_RANGE,
                                ACTUAL_SALES_VOLUME,
                                SALES_VOLUME_RANGE,
                                PRIMARY_SIC,
                                PRIMARY_SIC_DESCRIPTION,
                                SECONDARY_SIC_1,
                                SECONDARY_SIC_DESCRIPTION_1,
                                SECONDARY_SIC_2,
                                SECONDARY_SIC_DESCRIPTION_2,
                                CREDIT_NUMERIC_SCORE,
                                HEADQUARTERS_BRANCH,
                                FIRM_INDIVIDUAL,
                                PUBLIC_PRIVATE_FLAG,
                                EXECUTIVE_EMAIL,
                                NOTES,
                                LOCATION_ADDRESS,
                                LOCATION_ADDRESS_CITY,
                                LOCATION_ADDRESS_STATE,
                                LOCATION_ADDRESS_ZIP,
                                LOCATION_COUNTY,
                                IsProcessed
                            FROM " + tableName + " limit 0";

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.UpdateBatchSize = 10000;
                            using (MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter))
                            {
                                cb.SetAllValues = true;
                                adapter.Update(table);
                                tran.Commit();
                            }
                        };
                    }
                }
            }
        }
    }
}
