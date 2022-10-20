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
    public class Users_BAO
    {
        private readonly IConfiguration _configuration;
        private Users_DAO dao;
        public Users_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new Users_DAO(_configuration);
        }
        public DataTable GetUsersInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetUsersInfo();
            return dt;
        }

        public string InsertUsersInfo(Users users)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(users.FirstName))
            {
                result = dao.InsertUsersInfo(users);
            }
            else
            {
                result = "Insert Failed. First Name not Provided";
            }
            return result;

        }

        public string UpdateUsersInfo(Users users)
        {
            string result = "Failed";
            if (users.UserId > 0)
            {
                result = dao.UpdateUsersInfo(users);
            }
            else
            {
                result = "Update Failed. Invalid User Id";
            }

            return result;

        }

        public string DeleteUsersInfo(Users users)
        {
            string result = "Failed";
            if (users.UserId > 0)
            {
                result = dao.DeleteUsersInfo(users);
            }
            else
            {
                result = "Delete Failed. Invalid User Id";
            }

            return result;

        }
    }
}






