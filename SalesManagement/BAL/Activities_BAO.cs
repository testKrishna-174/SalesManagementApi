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
    public class Activities_BAO
    {
       
            private readonly IConfiguration _configuration;
            private Activities_DAO dao;
            public Activities_BAO(IConfiguration configuration)
            {
                _configuration = configuration;
                dao = new Activities_DAO(_configuration);
            }
            public DataTable GetActivitiesInfo()
            {
                DataTable dt = new DataTable();
                dt = dao.GetActivitiesInfo();
                return dt;
            }

        public DataTable GetActivitiesInfoById(Activities activities)
        {
            DataTable dt = new DataTable();
            if (activities == null || activities.ActivityId <= 0)
            {
                throw new ArgumentException("Values not provided");
            }
            else
            {
                dt = dao.GetActivitiesInfoById(activities);
            }
            return dt;
        }


        public string InsertActivities(Activities activities)
            {
                string result = "Failed";
                if (!string.IsNullOrEmpty(activities.ActivityName))
                {
                    result = dao.InsertActivities(activities);
                }
                else
                {
                    result = "Insert Failed. Activity Name not Provided";
                }
                return result;

            }

            public string UpdateActivities(Activities activities)
            {
                string result = "Failed";
                if (activities.ActivityId > 0)
                {
                    result = dao.UpdateActivities(activities);
                }
                else
                {
                    result = "Update Failed. Invalid Acitivity Id";
                }

                return result;

            }

            public string DeleteActivites(Activities activities)
            {
                string result = "Failed";
                if (activities.ActivityId > 0)
                {
                    result = dao.DeleteActivites(activities);
                }
                else
                {
                    result = "Delete Failed. Invalid Acitivity Id";
                }

                return result;

            }
        }
    }



