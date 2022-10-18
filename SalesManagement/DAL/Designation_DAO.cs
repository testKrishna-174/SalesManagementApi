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
    public class Designation_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;
        public Designation_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper  = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }
        public DataTable GetDesignationInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                ds = sqlHelper.SP_DataTable_return("usp_GetDesignationInfo");
                if(ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return dt;
        }

        public string InsertDesignation(Designation designation)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                { 
                    new MySqlParameter("@DesiginationValue", designation.DesignationName.Trim()),
                    new MySqlParameter("@Lvl", designation.Level),
                    new MySqlParameter("@IsActive", designation.IsActive),
                    new MySqlParameter("@UserId", designation.CreatedBy),
                };
                
                ds = sqlHelper.SP_DataTable_return("usp_InsertDesignation", commandParameters);
                if(ds.Tables[0].Rows.Count > 0)
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

        public string UpdateDesignation(Designation designation)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@DesiginationValue", designation.DesignationName.Trim()),
                    new MySqlParameter("@Lvl", designation.Level),
                    new MySqlParameter("@IsActive", 1),
                    new MySqlParameter("@UserId", designation.UpdatedBy),
                    new MySqlParameter("@Id", designation.DesignationId),
                    new MySqlParameter("@OperationType", "UPDATE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateDesignation", commandParameters);
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

        public string DeleteDesignation(Designation designation)
        {
            string result = "Failed";
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                     new MySqlParameter("@DesiginationValue", DBNull.Value),
                    new MySqlParameter("@Lvl", DBNull.Value),
                    new MySqlParameter("@IsActive", 0),
                    new MySqlParameter("@UserId", designation.UpdatedBy),
                    new MySqlParameter("@Id", designation.DesignationId),
                    new MySqlParameter("@OperationType", "DELETE"),
                };

                ds = sqlHelper.SP_DataTable_return("usp_UpdateDesignation", commandParameters);
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
