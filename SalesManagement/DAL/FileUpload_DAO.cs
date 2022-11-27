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

namespace SalesManagement_API.DAL
{
    public class FileUpload_DAO
    {
        private readonly IConfiguration _configuration;
        public SalesManagement_API.Helpers.MySqlHelper sqlHelper;

        public FileUpload_DAO(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlHelper = new SalesManagement_API.Helpers.MySqlHelper(_configuration.GetConnectionString("dbSales"));
        }

        public string InsertFileUploadDetails(FileUpload fileUploadDetais)
        {
            string result = "Failed";
            UInt64 file_Id = 0;
            try
            {
                DataSet ds = new DataSet();
                MySqlParameter[] commandParameters = new MySqlParameter[]
                {
                    new MySqlParameter("@FileName", fileUploadDetais.FileName.Trim()),
                    new MySqlParameter("@LocalFilePath", fileUploadDetais.LocalFilePath.Trim()),
                    new MySqlParameter("@IsProcessed", 0 ),
                    new MySqlParameter("@UserId", fileUploadDetais.UploadedBy),
                    new MySqlParameter("@ErrorMessage", fileUploadDetais.ErrorMessage.Trim()),
                };

                ds = sqlHelper.SP_DataTable_return("usp_InsertFileSource", commandParameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        file_Id = Convert.ToUInt64(dr["FileId"]);
                        result = Convert.ToString(dr["Result"]);
                    }
                }
                if(file_Id > 0)
                {
                    BulkCopyMySQL bulkCopy = new BulkCopyMySQL(_configuration);
                    bulkCopy.Start("tbl_source_stagging", fileUploadDetais.stagingFileDetails, file_Id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
