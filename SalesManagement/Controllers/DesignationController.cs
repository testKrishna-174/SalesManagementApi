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
    public class DesignationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DesignationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetDesignationInfo")]
        public JsonResult GetDesignation()
        {
            DataTable table = new DataTable();
            Designation_BAO bao = new Designation_BAO(_configuration);            
            table = bao.GetDesignationInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertDesignation")]
        public JsonResult InsertDesignation(Designation designation)
        {
            Designation_BAO bao = new Designation_BAO(_configuration);
            string result = bao.InsertDesignation(designation);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateDesignation")]
        public JsonResult UpdateDesignation(Designation designation)
        {
            Designation_BAO bao = new Designation_BAO(_configuration);
            string result = bao.UpdateDesignation(designation);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteDesignation")]
        public JsonResult DeleteDesignation(Designation designation)
        {
            Designation_BAO bao = new Designation_BAO(_configuration);
            string result = bao.DeleteDesignation(designation);
            return new JsonResult(result);

        }

    }
}
