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
    public class LeadSource_BAO
    {
        private readonly IConfiguration _configuration;
        private LeadSource_DAO dao;
        public LeadSource_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new LeadSource_DAO(_configuration);
        }
        public DataTable GetLeadSourceInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetLeadSourceInfo();
            return dt;
        }
        public DataTable GetLeadSourceInfoById(LeadSource leadSource)
        {
            DataTable dt = new DataTable();
            if (leadSource == null || leadSource.SourceId <= 0)
            {
                throw new ArgumentException("Values not provided");
            }
            else
            {
                dt = dao.GetLeadSourceInfoById(leadSource);
            }
            return dt;
        }

        public string InsertLeadSourceInfo(LeadSource leadSource)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(leadSource.SourceName))
            {
                result = dao.InsertLeadSourceInfo(leadSource);
            }
            else
            {
                result = "Insert Failed. Source Name not Provided";
            }
            return result;

        }

        public string UpdateLeadSourceInfo(LeadSource leadSource)
        {
            string result = "Failed";
            if (leadSource.SourceId > 0)
            {
                result = dao.UpdateLeadSourceInfo(leadSource);
            }
            else
            {
                result = "Update Failed. Invalid Source Id";
            }

            return result;

        }

        public string DeleteLeadSourceInfo(LeadSource leadSource)
        {
            string result = "Failed";
            if (leadSource.SourceId > 0)
            {
                result = dao.DeleteLeadSourceInfo(leadSource);
            }
            else
            {
                result = "Delete Failed. Invalid Source Id";
            }

            return result;

        }
    }
}

