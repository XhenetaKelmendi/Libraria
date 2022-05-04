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
    public class AdresaController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AdresaController(IConfiguration _configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult Get()
        {
            string query = @"
                        select AdresaId,Email,Telefoni";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AdresaAppCon");
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
        public JsonResult Post(Adresa ad)
        {
            string query = @"
                        insert into Adresa values
                        ('" + ad.Email+ @"')
                        ('" +ad.Telefoni + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AdresaAppCon");
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
        public JsonResult Put(Adresa ad)
        {
            string query = @"
                        update Adresa set
                         Email= '" + ad.Email + @"'
                         Telefoni= '" + ad.Telefoni + @"'
                        
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AdresaAppCon");
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
                        delete from Adresa 
                        where Email = " + id + @"
                        Telefoni = " + id + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("AdresaAppCon");
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

