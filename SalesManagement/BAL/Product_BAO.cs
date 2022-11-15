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
    public class Product_BAO
    {
        private readonly IConfiguration _configuration;
        private Product_DAO dao;
        public Product_BAO(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new Product_DAO(_configuration);
        }
        public DataTable GetProductsInfo()
        {
            DataTable dt = new DataTable();
            dt = dao.GetProductsInfo();
            return dt;
        }

        public string InsertProductsInfo(Product product)
        {
            string result = "Failed";
            if (!string.IsNullOrEmpty(product.ProductName))
            {
                result = dao.InsertProductsInfo(product);
            }
            else
            {
                result = "Insert Failed. Product Name not Provided";
            }
            return result;

        }

        public string UpdateProductsInfo(Product product)
        {
            string result = "Failed";
            if (product.ProductId > 0)
            {
                result = dao.UpdateProductsInfo(product);
            }
            else
            {
                result = "Update Failed. Invalid Product Id";
            }

            return result;

        }

        public string DeleteProductsInfo(Product product)
        {
            string result = "Failed";
            if (product.ProductId > 0)
            {
                result = dao.DeleteProductsInfo(product);
            }
            else
            {
                result = "Delete Failed. Invalid Product Id";
            }

            return result;

        }
    }
}




