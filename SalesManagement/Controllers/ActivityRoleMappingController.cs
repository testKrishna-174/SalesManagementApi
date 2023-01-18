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
    public class ActivityRoleMappingController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ActivityRoleMappingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetActivityRoleMappingInfo")]
        public JsonResult GetActivityRoleMappingInfo()
        {
            DataTable table = new DataTable();
            ActivityRoleMapping_BAO bao = new ActivityRoleMapping_BAO(_configuration);
            table = bao.GetActivityRoleMappingInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("GetActivityRoleMappingInfoById")]
        public JsonResult GetActivityRoleMappingInfoById(ActivityRoleMapping activityRoleMapping)
        {
            DataTable table = new DataTable();
            ActivityRoleMapping_BAO bao = new ActivityRoleMapping_BAO(_configuration);
            table = bao.GetActivityRoleMappingInfoById(activityRoleMapping);
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertActivityRoleMapping")]
        public JsonResult InsertActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            ActivityRoleMapping_BAO bao = new ActivityRoleMapping_BAO(_configuration);
            string result = bao.InsertActivityRoleMapping(activityRoleMapping);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateActivityRoleMapping")]
        public JsonResult UpdateActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            ActivityRoleMapping_BAO bao = new ActivityRoleMapping_BAO(_configuration);
            string result = bao.UpdateActivityRoleMapping(activityRoleMapping);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteActivityRoleMapping")]
        public JsonResult DeleteActivityRoleMapping(ActivityRoleMapping activityRoleMapping)
        {
            ActivityRoleMapping_BAO bao = new ActivityRoleMapping_BAO(_configuration);
            string result = bao.DeleteActivityRoleMapping(activityRoleMapping);
            return new JsonResult(result);

        }

    }
}




