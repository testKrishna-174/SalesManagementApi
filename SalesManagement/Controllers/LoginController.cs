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
using SalesManagement_API.BAL;

namespace SalesManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetLoginInfo")]
        public JsonResult GetLoginInfo()
        {
            DataTable table = new DataTable();
            Login_BAO bao = new Login_BAO(_configuration);
            table = bao.GetLoginInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertLoginInfo")]
        public JsonResult InsertLoginInfo(LoginInfo loginInfo)
        {
            Login_BAO bao = new Login_BAO(_configuration);
            string result = bao.InsertLoginInfo(loginInfo);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateLoginInfo")]
        public JsonResult UpdateLoginInfo(LoginInfo loginInfo)
        {
            Login_BAO bao = new Login_BAO(_configuration);
            string result = bao.UpdateLoginInfo(loginInfo);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteLoginInfo")]
        public JsonResult DeleteLoginInfo(LoginInfo loginInfo)
        {
            Login_BAO bao = new Login_BAO(_configuration);
            string result = bao.DeleteLoginInfo(loginInfo);
            return new JsonResult(result);

        }

    }
}



