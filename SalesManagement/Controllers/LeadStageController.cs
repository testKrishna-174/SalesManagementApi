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

    public class LeadStageController
    {
            private readonly IConfiguration _configuration;
            public LeadStageController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            [Route("GetLeadStageInfo")]
            public JsonResult GetLeadStageInfo()
            {
                DataTable table = new DataTable();
                LeadStage_BAO bao = new LeadStage_BAO(_configuration);
                table = bao.GetLeadStageInfo();
                return new JsonResult(table);
            }

            [HttpPost]
            [Route("InsertLeadStageInfo")]
            public JsonResult InsertLeadStageInfo(LeadStage leadStage)
        {
                LeadStage_BAO bao = new LeadStage_BAO(_configuration);
                bao = new LeadStage_BAO(_configuration);
                string result = bao.InsertLeadStageInfo(leadStage);
                return new JsonResult(result);

            }

            [HttpPost]
            [Route("UpdateLeadStageInfo")]
            public JsonResult UpdateLeadStageInfo(LeadStage leadStage)
        {
                LeadStage_BAO bao = new LeadStage_BAO(_configuration);
                string result = bao.UpdateLeadStageInfo(leadStage);
                return new JsonResult(result);

            }

            [HttpPost]
            [Route("DeleteLeadStageInfo")]
            public JsonResult DeleteLeadStageInfo(LeadStage leadStage)
        {
                LeadStage_BAO bao = new LeadStage_BAO(_configuration);
                string result = bao.DeleteLeadStageInfo(leadStage);
                return new JsonResult(result);

            }

        }
    }


