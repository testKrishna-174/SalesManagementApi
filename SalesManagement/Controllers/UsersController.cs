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
    public class UsersController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetUsersInfo")]
        public JsonResult GetUsersInfo()
        {
            DataTable table = new DataTable();
            Users_BAO bao = new Users_BAO(_configuration);
            table = bao.GetUsersInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertUsersInfo")]
        public JsonResult InsertUsersInfo(Users users)
        {
            Users_BAO bao = new Users_BAO(_configuration);
            string result = bao.InsertUsersInfo(users);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateUsersInfo")]
        public JsonResult UpdateUsersInfo(Users users)
        {
            Users_BAO bao = new Users_BAO(_configuration);
            string result = bao.UpdateUsersInfo(users);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteUsersInfo")]
        public JsonResult DeleteUsersInfo(Users users)
            {
            Users_BAO bao = new Users_BAO(_configuration);
            string result = bao.DeleteUsersInfo(users);
            return new JsonResult(result);

        }

    }
}









