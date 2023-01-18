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
    public class ActivityRoleMapping_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public ActivityRoleMapping_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetActivityRoleMappingInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetActivityRoleMappingInfo");
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


        public DataTable GetActivityRoleMappingInfoById(ActivityRoleMapping activityRoleMapping)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_RoleMappingId", activityRoleMapping.ActivityId),
                };
                ds = sqlHelper.SP_DataTable_return("usp_GetActivityRoleMappingInfoById",commandParameters);
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

        public string InsertActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_ActivityId", activityRoleMapping.ActivityId),
                    new MySqlParameter("@U_DesiginationId", activityRoleMapping.DesignationId),
                    new MySqlParameter("@U_IsActive", activityRoleMapping.IsActive),
                    new MySqlParameter("@U_UserId", activityRoleMapping.CreatedBy),
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertActivityRoleMappingInfo", commandParameters);
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

        public string UpdateActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_RoleMappingId", activityRoleMapping.RoleMappingId),
                    new MySqlParameter("@U_ActivityId", activityRoleMapping.ActivityId),
                    new MySqlParameter("@U_DesiginationId", activityRoleMapping.DesignationId),
                    new MySqlParameter("@U_IsActive", 1),
                    new MySqlParameter("@U_UserId", activityRoleMapping.UpdatedBy),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateActivityRoleMappingInfo", commandParameters);
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

        public string DeleteActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@U_RoleMappingId", DBNull.Value),
                    new MySqlParameter("@U_ActivityId", DBNull.Value),
                    new MySqlParameter("@U_DesiginationId",DBNull.Value),
                    new MySqlParameter("@U_IsActive", 0),
                    new MySqlParameter("@U_UserId", activityRoleMapping.UpdatedBy),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateActivityRoleMappingInfo", commandParameters);
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