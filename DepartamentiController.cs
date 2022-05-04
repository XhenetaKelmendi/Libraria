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
    public class DepartamentiController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public DepartamentiController(IConfiguration _configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult Get()
        {
            string query = @"
                        select DepartamentiId,Departament";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DepartamentiAppCon");
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
        public JsonResult Post(Departamenti dep)
        {
            string query = @"
                        insert into Departmanti values
                        ('" + dep.Departament+ @"') ";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DepartamentiAppCon");
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
        public JsonResult Put(Departamenti dep)
        {
            string query = @"
                        update Departamenti set
                         Departament= '" + dep.Departament + @"'
                        
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DepartamentiAppCon");
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
                        delete from Departamenti
                        where Departament = " + id + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("DepartamentiAppCon");
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

