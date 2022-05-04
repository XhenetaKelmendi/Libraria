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
    public class PunëtorëtController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public PunëtorëtController(IConfiguration _configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult Get()
        {
            string query = @"
                        select PunëtorëtId,Punëtorët,Ndrrimi,Orari_i_punës";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("PunëtorëtAppCon");
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
        public JsonResult Post(Punëtorët pu)
        {
            string query = @"
                        insert into Punëtorët values
                        ('" + pu.Punëtori+ @"')
                        ('" + pu.Ndërrimi + @"')
                        ('" + pu.Orari_i_punës + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("PunëtorëtAppCon");
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
        public JsonResult Put(Punëtorët pu)
        {
            string query = @"
                        update Punëtorët set
                         Punetori=  '" + pu.Punëtori + @"'
                         Ndërrimi= '" + pu.Ndërrimi + @"'
                         Orari_i_punës= '" + pu.Orari_i_punës + @"'
                        
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("PunëtorëtAppCon");
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
                        delete from Punëtorët 
                        where Punetori = " + id + @"
                        Ndërrimi = " + id + @"
                        Orari_i_punës = " + id + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("PunëtorëtAppCon");
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

