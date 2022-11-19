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
    public class Comercio_afiliadoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public Comercio_afiliadoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select cedula ,nombre_comercio, id_direccion, sinpe, email, tipo           
                            from
                            dbo.comercio_afiliado
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
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
        public JsonResult Post(Comercio_afiliado dep)
        {
            string query = @"
                           insert into dbo.comercio_afiliado (cedula ,nombre_comercio, id_direccion, sinpe, email, tipo ) 
                           values (@cedula ,@nombre_comercio, @id_direccion, @sinpe, @email, @tipo )             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", dep.cedula);
                    myCommand.Parameters.AddWithValue("@nombre_comercio", dep.nombre_comercio);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@sinpe", dep.sinpe);
                    myCommand.Parameters.AddWithValue("@email", dep.email);
                    myCommand.Parameters.AddWithValue("@tipo", dep.tipo);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Comercio_afiliado dep)
        {
            string query = @"
                           update dbo.comercio_afiliado
                           set 
                           cedula = @cedula,
                           nombre_comercio = @nombre_comercio, 
                           id_direccion = @id_direccion, 
                           sinpe = @sinpe, 
                           email = @email,
                           tipo = @tipo,
                           
                          
                           where cedula= @cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", dep.cedula);
                    myCommand.Parameters.AddWithValue("@nombre_comercio", dep.nombre_comercio);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@sinpe", dep.sinpe);
                    myCommand.Parameters.AddWithValue("@email", dep.email);
                    myCommand.Parameters.AddWithValue("@tipo", dep.tipo);
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
                           delete from dbo.comercio_afiliado
                            where cedula=@cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }
        [HttpGet("cedula/{cedula}")]
        public JsonResult GetCedula( string cedula)
        {
            string query = @"
                            select *            
                            from
                            dbo.comercio_afiliado
                            where cedula = @cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@cedula", cedula);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }
        [HttpGet("email/{email}")]
        public JsonResult GetEmail( string email)
        {
            string query = @"
                            select *            
                            from
                            dbo.comercio_afiliado
                            where email = @email
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@email", email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }
    }
}
