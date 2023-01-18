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
    public class ActivityRoleMapping_BAO
    {
        private readonly IConfiguration _configuration;
        private ActivityRoleMapping_DAO dao;
        public ActivityRoleMapping_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new ActivityRoleMapping_DAO(_configuration);
        }
        public DataTable GetActivityRoleMappingInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetActivityRoleMappingInfo();
            return dt;

        }

        public DataTable GetActivityRoleMappingInfoById(ActivityRoleMapping activityRoleMapping)
        {
            DataTable dt = new DataTable();
            if (activityRoleMapping == null || activityRoleMapping.RoleMappingId <= 0)
            {
                throw new ArgumentException("Values not provided");
            }
            else
            {
                dt = dao.GetActivityRoleMappingInfoById(activityRoleMapping);
            }
            return dt;
        }

        public string InsertActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            if ((activityRoleMapping.ActivityId)>0)
            {
                result = dao.InsertActivityRoleMapping(activityRoleMapping);
            }
            else
            {
                result = "Insert Failed. ActivityId is Invalid";
            }
            return result;

        }

        public string UpdateActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            if (activityRoleMapping.ActivityId > 0)
            {
                result = dao.UpdateActivityRoleMapping(activityRoleMapping);
            }
            else
            {
                result = "Update Failed. Invalid Activity Id";
            }

            return result;

        }

        public string DeleteActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            string result = "Failed";
            if (activityRoleMapping.ActivityId > 0)
            {
                result = dao.DeleteActivityRoleMapping(activityRoleMapping);
            }
            else
            {
                result = "Delete Failed. Invalid Activity Id";
            }

            return result;

        }
    }
}


