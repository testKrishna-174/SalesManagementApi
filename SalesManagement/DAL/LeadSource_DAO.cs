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
    public class LeadSource_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public LeadSource_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetLeadSourceInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetLeadSourceInfo");
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

        public DataTable GetLeadSourceInfoById(LeadSource leadSource)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_SourceId", leadSource.SourceId),
                };
                ds = sqlHelper.SP_DataTable_return("usp_GetLeadSourceInfoById");
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

        public string InsertLeadSourceInfo(LeadSource leadSource)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_SourceNameValue", leadSource.SourceName.Trim()),
                    new MySqlParameter("@U_DescriptionValue",leadSource.Description.Trim()),
                    new MySqlParameter("@U_IsActive", leadSource.IsActive),
                    new MySqlParameter("@U_UserId", leadSource.CreatedBy),
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertLeadSourceInfo", commandParameters);
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

        public string UpdateLeadSourceInfo(LeadSource leadSource)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                   new MySqlParameter("@U_SourceId", leadSource.SourceId),
                    new MySqlParameter("@U_SourceNameValue", leadSource.SourceName.Trim()),
                    new MySqlParameter("@U_DescriptionValue",leadSource.Description.Trim()),
                    new MySqlParameter("@U_IsActive", 1),
                    new MySqlParameter("@U_UserId", leadSource.UpdatedBy),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateLeadSourceInfo", commandParameters);
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

        public string DeleteLeadSourceInfo(LeadSource leadSource)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@U_SourceId", DBNull.Value),
                    new MySqlParameter("@U_SourceNameValue", DBNull.Value),
                    new MySqlParameter("@U_DescriptionValue",DBNull.Value),
                    new MySqlParameter("@U_IsActive", 0),
                    new MySqlParameter("@U_UserId", leadSource.UpdatedBy),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateLeadSourceInfo", commandParameters);
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
    }
}  
    
