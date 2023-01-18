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
    public class ProductController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetProductsInfo")]
        public JsonResult GetProductsInfo()
        {
            DataTable table = new DataTable();
            Product_BAO bao = new Product_BAO(_configuration);
            table = bao.GetProductsInfo();
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("GetProductsInfoById")]
        public JsonResult GetProductsInfoById(Product product)
        {
            DataTable table = new DataTable();
            Product_BAO bao = new Product_BAO(_configuration);
            table = bao.GetProductsInfoById(product);
            return new JsonResult(table);
        }

        [HttpPost]
        [Route("InsertProductsInfo")]
        public JsonResult InsertProductsInfo(Product product)
        {
            Product_BAO bao = new Product_BAO(_configuration);
            string result = bao.InsertProductsInfo(product);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("UpdateProductsInfo")]
        public JsonResult UpdateProductsInfo(Product product)
        {
            Product_BAO bao = new Product_BAO(_configuration);
            string result = bao.UpdateProductsInfo(product);
            return new JsonResult(result);

        }

        [HttpPost]
        [Route("DeleteProductsInfo")]
        public JsonResult DeleteProductsInfo(Product product)
        {
            Product_BAO bao = new Product_BAO(_configuration);
            string result = bao.DeleteProductsInfo(product);
            return new JsonResult(result);

        }

    }
}

