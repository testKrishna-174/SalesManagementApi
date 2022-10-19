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
    public class Users_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public Users_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetUsersInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetUsersInfo");
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

        public string InsertUsersInfo(Users users)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@FirstName", users.FirstName.Trim()),
                    new MySqlParameter("@MiddleName",users.MiddleName.Trim()),
                    new MySqlParameter("@LastName", users.LastName.Trim()),
                    new MySqlParameter("@Email", users.Email.Trim()),
                    new MySqlParameter("@DesignationId",users.DesignationId),
                    new MySqlParameter("@ManagerId", users.ManagerId),
                    new MySqlParameter("@IsActive", users.IsActive),
                    new MySqlParameter("@UserId",users.CreatedBy),
                    
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertUsersInfo", commandParameters);
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

        public string UpdateUsersInfo(Users users)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                   new MySqlParameter("@FirstName", users.FirstName.Trim()),
                    new MySqlParameter("@MiddleName",users.MiddleName.Trim()),
                    new MySqlParameter("@LastName", users.LastName.Trim()),
                    new MySqlParameter("@Email", users.Email.Trim()),
                    new MySqlParameter("@DesignationId",users.DesignationId),
                    new MySqlParameter("@ManagerId", users.ManagerId),
                    new MySqlParameter("@IsActive", 1),
                    new MySqlParameter("@UserId",users.UpdatedBy),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateUsersInfo", commandParameters);
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

        public string DeleteUsersInfo(Users users)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@FirstName", DBNull.Value),
                    new MySqlParameter("@MiddleName",DBNull.Value),
                    new MySqlParameter("@LastName", DBNull.Value),
                    new MySqlParameter("@Email",DBNull.Value),
                    new MySqlParameter("@DesignationId", DBNull.Value),
                    new MySqlParameter("@ManagerId",DBNull.Value),
                    new MySqlParameter("@IsActive", 0),
                    new MySqlParameter("@UserId",users.UpdatedBy),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateUsersInfo", commandParameters);
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

