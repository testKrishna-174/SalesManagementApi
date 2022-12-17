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
    public class FileUploadController : Controller
    {
        private readonly IConfiguration _configuration;
        public FileUploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetFileUploadInfo")]
        public JsonResult GetFileUploadInfo()
        {
            DataTable table = new DataTable();
            FileUpload_BAO bao = new FileUpload_BAO(_configuration);
            table = bao.GetFileUploadInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertFileUpload")]
        public JsonResult InsertDesignation(FileUpload fileUploadDetais)
        {
            FileUpload_BAO bao = new FileUpload_BAO(_configuration);
            string result = bao.InsertFileUploadDetails(fileUploadDetais);
            return new JsonResult(result);

        }
    }
}
