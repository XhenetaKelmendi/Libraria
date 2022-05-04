using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Libraria.Models;

namespace Libraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthorsController(IConfiguration _configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult Get()
        {
            string query = @"
                        select AuthorsId,Autori,Vendi";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AuthorsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Authors au)
        {
            string query = @"
                        insert into Authors values
                        ('" + au.Autori + @"')
                        ('" + au.Vendi + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AuthorsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Suscesfully");
        }
        [HttpPut]
        public JsonResult Put(Authors au)
        {
            string query = @"
                        update Authors set
                         Autori= '" + au.Autori + @"'
                         Vendi= '" + au.Vendi + @"'
                        
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AuthorsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Suscesfully");
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from Authors
                        where Autori = " + id + @"
                        Vendi = " + id + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AuthorsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Suscesfully");
        }

    }
}

