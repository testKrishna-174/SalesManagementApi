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
    public class LeadStage_BAO
    {
        private readonly IConfiguration _configuration;
        private LeadStage_DAO dao;
        public LeadStage_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new LeadStage_DAO(_configuration);
        }
        public DataTable GetLeadStageInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetLeadStageInfo();
            return dt;
        }

        public string InsertLeadStageInfo(LeadStage leadStage)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(leadStage.StageName))
            {
                result = dao.InsertLeadStageInfo(leadStage);
            }
            else
            {
                result = "Insert Failed. Stage Name not Provided";
            }
            return result;

        }

        public string UpdateLeadStageInfo(LeadStage leadStage)
        {
            string result = "Failed";
            if (leadStage.LeadStageId > 0)
            {
                result = dao.UpdateLeadStageInfo(leadStage);
            }
            else
            {
                result = "Update Failed. Invalid Lead Stage Id Id";
            }

            return result;

        }

        public string DeleteLeadStageInfo(LeadStage leadStage)
        {
            string result = "Failed";
            if (leadStage.LeadStageId > 0)
            {
                result = dao.DeleteLeadStageInfo(leadStage);
            }
            else
            {
                result = "Delete Failed. Invalid Lead Stage Id Id";
            }

            return result;

        }
    }
}


