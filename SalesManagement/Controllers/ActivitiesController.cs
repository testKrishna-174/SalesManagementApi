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
    public class ActivitiesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ActivitiesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetActivitiesInfo")]
        public JsonResult GetActivitiesInfo()
        {
            DataTable table = new DataTable();
            Activities_BAO bao = new Activities_BAO(_configuration);
            table = bao.GetActivitiesInfo();
            return new JsonResult(table);
        }
        [HttpPost]
        [Route("GetActivitiesInfoById")]
        public JsonResult GetActivitiesInfoById(Activities activities)
        {
            DataTable table = new DataTable();
            Activities_BAO bao = new Activities_BAO(_configuration);
            table = bao.GetActivitiesInfoById(activities);
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertActivities")]
        public JsonResult InsertActivities(Activities activities)
        {
            Activities_BAO bao = new Activities_BAO(_configuration);
            string result = bao.InsertActivities(activities);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateActivities")]
        public JsonResult UpdateActivities(Activities activities)
        {
            Activities_BAO bao = new Activities_BAO(_configuration);
            string result = bao.UpdateActivities(activities);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteActivites")]
        public JsonResult DeleteActivites(Activities activities)
        {
            Activities_BAO bao = new Activities_BAO(_configuration);
            string result = bao.DeleteActivites(activities);
            return new JsonResult(result);

        }

    }
}



    

