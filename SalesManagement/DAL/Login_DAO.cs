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
    public class Login_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public Login_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetLoginInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetLoginInfo");
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

        public string InsertLoginInfo(LoginInfo loginInfo)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@UserId", loginInfo.UserId),
                    new MySqlParameter("@Password",loginInfo.Password.Trim()),
                    new MySqlParameter("@IsActive", loginInfo.IsActive),
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertLoginInfo", commandParameters);
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

        public string UpdateLoginInfo(LoginInfo loginInfo)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@UserId", loginInfo.UserId),
                    new MySqlParameter("@Password",loginInfo.Password.Trim()),
                    new MySqlParameter("@IsActive", 1),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateLoginInfo", commandParameters);
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

        public string DeleteLoginInfo(LoginInfo loginInfo)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@Username", DBNull.Value),
                    new MySqlParameter("@Password",DBNull.Value),
                    new MySqlParameter("@IsActive", 0),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateLoginInfo", commandParameters);
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
