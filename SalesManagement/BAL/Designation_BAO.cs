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
using SalesManagement_API.DAL;

namespace SalesManagement_API.BAL
{
    public class Designation_BAO
    {
        private readonly IConfiguration _configuration;
        private Designation_DAO dao;
        public Designation_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new Designation_DAO(_configuration);
        }
        public DataTable GetDesignationInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetDesignationInfo();
            return dt;
        }

        public string InsertDesignation(Designation designation)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(designation.DesignationName))
            {
                result = dao.InsertDesignation(designation);
            }
            else
            {
                result = "Insert Failed. Designation Name not Provided";
            }
            return result;

        }

        public string UpdateDesignation(Designation designation)
        {
            string result = "Failed";
            if (designation.DesignationId > 0)
            {
                result = dao.UpdateDesignation(designation);
            }
            else
            {
                result = "Update Failed. Invalid Designation Id";
            }
            
            return result;

        }

        public string DeleteDesignation(Designation designation)
        {
            string result = "Failed";
            if (designation.DesignationId > 0)
            {
                result = dao.DeleteDesignation(designation);
            }
            else
            {
                result = "Delete Failed. Invalid Designation Id";
            }

            return result;

        }
    }
}
