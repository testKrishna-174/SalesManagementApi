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
    public class Login_BAO
    {
        private readonly IConfiguration _configuration;
        private Login_DAO dao;
        public Login_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new Login_DAO(_configuration);
        }
        public DataTable GetLoginInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetLoginInfo();
            return dt;
        }

        public string InsertLoginInfo(LoginInfo loginInfo)
        {
            string result = "Failed";
            if (loginInfo.LoginId>0)
            {
                result = dao.InsertLoginInfo(loginInfo);
            }
            else
            {
                result = "Insert Failed. Login Id not Provided";
            }
            return result;

        }

        public string UpdateLoginInfo(LoginInfo loginInfo)
        {
            string result = "Failed";
            if (loginInfo.LoginId  > 0)
            {
                result = dao.UpdateLoginInfo(loginInfo);
            }
            else
            {
                result = "Update Failed. Invalid Login Id";
            }

            return result;

        }

        public string DeleteLoginInfo(LoginInfo loginInfo)
        {
            string result = "Failed";
            if (loginInfo.LoginId > 0)
            {
                result = dao.DeleteLoginInfo(loginInfo);
            }
            else
            {
                result = "Delete Failed. Invalid Login Id";
            }

            return result;

        }
    }
}







