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
    public class LeadStage_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public LeadStage_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetLeadStageInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetLeadStageInfo");
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

        public string InsertLeadStageInfo(LeadStage leadStage)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@StageName", leadStage.StageName.Trim()),
                    new MySqlParameter("@Description",leadStage.Description.Trim()),
                    new MySqlParameter("@IsActive", leadStage.IsActive),
                    new MySqlParameter("@UserId", leadStage.CreatedBy),
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertLeadStageInfo", commandParameters);
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

        public string UpdateLeadStageInfo(LeadStage leadStage)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@StageName", leadStage.StageName),
                    new MySqlParameter("@Description",leadStage.Description.Trim()),
                    new MySqlParameter("@IsActive", 1),
                    new MySqlParameter("@UserId", leadStage.UpdatedBy),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateLeadStageInfo", commandParameters);
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

        public string DeleteLeadStageInfo(LeadStage leadStage)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@StageName", DBNull.Value),                    
                    new MySqlParameter("@Description",DBNull.Value),
                    new MySqlParameter("@IsActive", 0),
                    new MySqlParameter("@UserId", leadStage.UpdatedBy),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateLeadStageInfo", commandParameters);
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

