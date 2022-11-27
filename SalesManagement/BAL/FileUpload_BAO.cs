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
    public class FileUpload_BAO
    {
        private readonly IConfiguration _configuration;
        private FileUpload_DAO dao;
        public FileUpload_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new FileUpload_DAO(_configuration);
        }

        public DataTable GetFileUploadInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetFileUploadInfo();
            return dt;
        }


        public string InsertFileUploadDetails(FileUpload fileUploadDetais)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(fileUploadDetais.FileName) && !string.IsNullOrEmpty(fileUploadDetais.LocalFilePath))
            {
                result = dao.InsertFileUploadDetails(fileUploadDetais);
            }
            else
            {
                result = "Insert Failed. Provided File details are not correct";
            }
            return result;

        }

    }
}
