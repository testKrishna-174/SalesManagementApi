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

    public class MessageController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MessageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetMessageInfo")]
        public JsonResult GetMessageInfo()
        {
            DataTable table = new DataTable();
            Message_BAO bao = new Message_BAO(_configuration);
            table = bao.GetMessageInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("GetMessageInfoById")]
        public JsonResult GetMessageInfoById(Message message)
        {
            DataTable table = new DataTable();
            Message_BAO bao = new Message_BAO(_configuration);
            table = bao.GetMessageInfoById(message);
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertMessagesInfo")]
        public JsonResult InsertMessagesInfo(Message message)
        {
            Message_BAO bao = new Message_BAO(_configuration);
            string result = bao.InsertMessagesInfo(message);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateMessagesInfo")]
        public JsonResult UpdateMessagesInfo(Message message)
        {
            Message_BAO bao = new Message_BAO(_configuration);
            string result = bao.UpdateMessagesInfo(message);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteMessageInfo")]
        public JsonResult DeleteMessageInfo(Message message)
        {
            Message_BAO bao = new Message_BAO(_configuration);
            string result = bao.DeleteMessageInfo(message);
            return new JsonResult(result);

        }

    }
}







