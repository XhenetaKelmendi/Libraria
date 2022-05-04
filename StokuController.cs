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
    public class StokuController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public StokuController(IConfiguration _configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult Get()
        {
            string query = @"
                        select StokuId,Libri,Sasia";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StokuAppCon");
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
        public JsonResult Post(Stoku st)
        {
            string query = @"
                        insert into Stoku values
                        ('" + st.Libri + @"')
                        ('" + st.Sasia + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StokuAppCon");
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
        public JsonResult Put(Stoku st)
        {
            string query = @"
                        update Stoku set
                         Libri= '" + st.Libri + @"'
                         Sasia= '" + st.Sasia + @"'
                        
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StokuAppCon");
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
                        delete from Stoku 
                        where Libri = " + id + @"
                        Sasia = " + id + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("StokuAppCon");
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

