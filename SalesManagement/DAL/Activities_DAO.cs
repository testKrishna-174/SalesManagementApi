﻿using Microsoft.AspNetCore.Http;
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
    public class Activities_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public Activities_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetActivitiesInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetActivitiesInfo");
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

        public DataTable GetActivitiesInfoById(Activities activities)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_ActivityId", activities.ActivityId),
                };

                ds = sqlHelper.SP_DataTable_return("usp_GetActivitiesInfo", commandParameters);
                if (ds.Tables[0].Rows.Count > 0)
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
        public string InsertActivities(Activities activities)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_ActivityCode", activities.ActivityCode.Trim()),
                    new MySqlParameter("@U_ActivityName", activities.ActivityName.Trim()),
                    new MySqlParameter("@U_DescriptionValue", activities.Description.Trim()),
                    new MySqlParameter("@U_IsActive", activities.IsActive),
                    new MySqlParameter("@U_UserId", activities.CreatedBy),
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertActivitiesInfo", commandParameters);
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

        public string UpdateActivities(Activities activities)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_ActivityId",activities.ActivityId),
                    new MySqlParameter("@U_ActivityCode", activities.ActivityCode.Trim()),
                    new MySqlParameter("@U_ActivityName", activities.ActivityName.Trim()),
                    new MySqlParameter("@U_DescriptionValue", activities.Description.Trim()),
                    new MySqlParameter("@U_IsActive", 1),
                    new MySqlParameter("@U_UserId", activities.UpdatedBy),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateActivitiesInfo", commandParameters);
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

        public string DeleteActivites(Activities activities)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@U_ActivityId",activities.ActivityId),
                     new MySqlParameter("@U_ActivityCode", DBNull.Value),
                    new MySqlParameter("@U_ActivityName", DBNull.Value),
                    new MySqlParameter("@U_DescriptionValue",DBNull.Value),
                    new MySqlParameter("@U_IsActive", 0),
                    new MySqlParameter("@U_UserId", activities.UpdatedBy),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateActivitiesInfo", commandParameters);
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

    
