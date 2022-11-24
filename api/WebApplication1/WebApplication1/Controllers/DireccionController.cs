using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DireccionController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("EmployeeAppCon");
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id_direccion, provincia, canton, distrito           
                            from
                            direccion
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
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
        public JsonResult Post(Direccion dep)
        {
            string query = @"
                           insert into direccion (id_direccion, provincia, canton, distrito ) 
                           values (@id_direccion, @provincia, @canton, @distrito  )             
                     
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                   
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@provincia", dep.provincia);
                    myCommand.Parameters.AddWithValue("@canton", dep.canton);
                    myCommand.Parameters.AddWithValue("@distrito", dep.distrito);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }

            return new JsonResult("Added Successfully");
        }}

        [HttpPut]
        public JsonResult Put(Direccion dep)
        {
            string query = @"
                           update direccion
                           set 
                           id_direccion = @id_direccion, 
                           provincia = @provincia, 
                           canton = @canton, 
                           distrito = @distrito
                           
                          
                           where cedula= @cedula
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@provincia", dep.provincia);
                    myCommand.Parameters.AddWithValue("@canton", dep.canton);
                    myCommand.Parameters.AddWithValue("@distrito", dep.distrito);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from direccion
                            where id_direccion = @id_direccion
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id_direccion", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}