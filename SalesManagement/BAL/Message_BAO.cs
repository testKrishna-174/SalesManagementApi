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
    public class Message_BAO
    {
        private readonly IConfiguration _configuration;
        private Message_DAO dao;
        public Message_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new Message_DAO(_configuration);
        }
        public DataTable GetMessageInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetMessageInfo();
            return dt;
        }

        public DataTable GetMessageInfoById(Message message)
        {
            DataTable dt = new DataTable();
            if (message == null || message.MessageId <= 0)
            {
                throw new ArgumentException("Values not provided");
            }
            else
            {
                dt = dao.GetMessageInfoById(message);
            }
            return dt;
        }

        public string InsertMessagesInfo(Message message)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(message.Name))
            {
                result = dao.InsertMessagesInfo(message);
            }
            else
            {
                result = "Insert Failed. Name not Provided";
            }
            return result;

        }

        public string UpdateMessagesInfo(Message message)
        {
            string result = "Failed";
            if (message.MessageId > 0)
            {
                result = dao.UpdateMessagesInfo(message);
            }
            else
            {
                result = "Update Failed. Invalid Message Id";
            }

            return result;

        }

        public string DeleteMessageInfo(Message message)
        {
            string result = "Failed";
            if (message.MessageId > 0)
            {
                result = dao.DeleteMessageInfo(message);
            }
            else
            {
                result = "Delete Failed. Invalid Message Id";
            }

            return result;

        }
    }
}


