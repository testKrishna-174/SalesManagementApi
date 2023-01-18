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
    public class LeadSourceController
    {
        private readonly IConfiguration _configuration;
        public LeadSourceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetLeadSourceInfo")]
        public JsonResult GetLeadSourceInfo()
        {
            DataTable table = new DataTable();
            LeadSource_BAO bao = new LeadSource_BAO(_configuration);
            table = bao.GetLeadSourceInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("GetLeadSourceInfoById")]
        public JsonResult GetLeadSourceInfoById(LeadSource leadSource)
        {
            DataTable table = new DataTable();
            LeadSource_BAO bao = new LeadSource_BAO(_configuration);
            table = bao.GetLeadSourceInfoById(leadSource);
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertLeadSourceInfo")]
        public JsonResult InsertLeadSourceInfo(LeadSource leadSource)
        {
            LeadSource_BAO bao = new LeadSource_BAO(_configuration);
            string result = bao.InsertLeadSourceInfo(leadSource);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateLeadSourceInfo")]
        public JsonResult UpdateLeadSourceInfo(LeadSource leadSource)
        {
            LeadSource_BAO bao = new LeadSource_BAO(_configuration);
            string result = bao.UpdateLeadSourceInfo(leadSource);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteLeadSourceInfo")]
        public JsonResult DeleteLeadSourceInfo(LeadSource leadSource)
        {
            LeadSource_BAO bao = new LeadSource_BAO(_configuration);
            string result = bao.DeleteLeadSourceInfo(leadSource);
            return new JsonResult(result);

        }

    }
}

