using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement_API.Models;
using SalesManagement_API.Helpers;

namespace SalesManagement_API.DAL
{
    public class AdditionalInfoLead_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public AdditionalInfoLead_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetAdditionalInfoLead()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetAdditionalInfoLead");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return dt;
        }

        public string InsertAdditionalInfoLead(AdditionalInfoLead additionalInfoLead)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@LeadId", additionalInfoLead.LeadId),
                    new MySqlParameter("@Primary_SIC", additionalInfoLead.Primary_SIC.Trim()),
                    new MySqlParameter("@Primary_SIC_Description", additionalInfoLead.Primary_SIC_Description.Trim()),
                    new MySqlParameter("@Secondary_SIC_1", additionalInfoLead.Secondary_SIC_1.Trim()),
                    new MySqlParameter("@Secondary_SIC_Description_1", additionalInfoLead.Secondary_SIC_Description_1.Trim()),
                    new MySqlParameter("@Secondary_SIC_2", additionalInfoLead.Secondary_SIC_2.Trim()),
                    new MySqlParameter("@Secondary_SIC_Description_2", additionalInfoLead.Secondary_SIC_Description_2.Trim()),
                    new MySqlParameter("@Credit_Numeric_Score", additionalInfoLead.Credit_Numeric_Score.Trim()),
                    new MySqlParameter("@Headquarters_Branch", additionalInfoLead.Headquarters_Branch.Trim()),
                    new MySqlParameter("@Firm_Individual", additionalInfoLead.Firm_Individual.Trim()),
                    new MySqlParameter("@Public_Private_Flag", additionalInfoLead.Public_Private_Flag.Trim()),
                    new MySqlParameter("@Notes", additionalInfoLead.Notes.Trim()),
                    new MySqlParameter("@Location_Address", additionalInfoLead.Location_Address.Trim()),
                    new MySqlParameter("@Location_Address_City", additionalInfoLead.Location_Address_City.Trim()),
                    new MySqlParameter("@Location_Address_State", additionalInfoLead.Location_Address_State.Trim()),
                    new MySqlParameter("@Location_Address_Zip", additionalInfoLead.Location_Address_Zip.Trim()),
                    new MySqlParameter("@Location_County", additionalInfoLead.Location_County.Trim()),
                    
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertAdditionalInfoLead", commandParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = Convert.ToString((from DataRow dr in ds.Tables[0].Rows
                                               select (string)dr["Result"]).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public string UpdateAdditionalInfoLead(AdditionalInfoLead additionalInfoLead)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@LeadId", additionalInfoLead.LeadId),
                    new MySqlParameter("@Primary_SIC", additionalInfoLead.Primary_SIC.Trim()),
                    new MySqlParameter("@Primary_SIC_Description", additionalInfoLead.Primary_SIC_Description.Trim()),
                    new MySqlParameter("@Secondary_SIC_1", additionalInfoLead.Secondary_SIC_1.Trim()),
                    new MySqlParameter("@Secondary_SIC_Description_1", additionalInfoLead.Secondary_SIC_Description_1.Trim()),
                    new MySqlParameter("@Secondary_SIC_2", additionalInfoLead.Secondary_SIC_2.Trim()),
                    new MySqlParameter("@Secondary_SIC_Description_2", additionalInfoLead.Secondary_SIC_Description_2.Trim()),
                    new MySqlParameter("@Credit_Numeric_Score", additionalInfoLead.Credit_Numeric_Score),
                    new MySqlParameter("@Headquarters_Branch", additionalInfoLead.Headquarters_Branch),
                    new MySqlParameter("@Firm_Individual", additionalInfoLead.Firm_Individual),
                    new MySqlParameter("@Public_Private_Flag", additionalInfoLead.Public_Private_Flag),
                    new MySqlParameter("@Notes", additionalInfoLead.Notes),
                    new MySqlParameter("@Location_Address", additionalInfoLead.Location_Address),
                    new MySqlParameter("@Location_Address_City", additionalInfoLead.Location_Address_City),
                    new MySqlParameter("@Location_Address_State", additionalInfoLead.Location_Address_State),
                    new MySqlParameter("@Location_Address_Zip", additionalInfoLead.Location_Address_Zip),
                    new MySqlParameter("@Location_County", additionalInfoLead.Location_County),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateAdditionalInfoLead", commandParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = Convert.ToString((from DataRow dr in ds.Tables[0].Rows
                                               select (string)dr["Result"]).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

       /* public string ActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@ActivityCode", DBNull.Value),
                    new MySqlParameter("@ActivityName", DBNull.Value),
                    new MySqlParameter("@DesignationId",DBNull.Value),
                    new MySqlParameter("@IsActive", 0),
                    new MySqlParameter("@UserId", activities.UpdatedBy),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateAdditionalInfoLead", commandParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = Convert.ToString((from DataRow dr in ds.Tables[0].Rows
                                               select (string)dr["Result"]).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
*/
    }
}