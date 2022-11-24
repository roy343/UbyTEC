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
    public class AdministradorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public AdministradorController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("EmployeeAppCon");
        }



        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select cedula ,usuario, id_direccion, contrasena, nombre, apellido1, apellido2            
                            from
                            administrador
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
        public JsonResult Post(Administrador dep)
        {
            string query = @"
                           insert into administrador (cedula ,usuario, id_direccion, contrasena, nombre, apellido1, apellido2) 
                           values (@cedula ,@usuario, @id_direccion, @contrasena, @nombre, @apellido1, @apellido2)             
                     
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", dep.cedula);
                    myCommand.Parameters.AddWithValue("@usuario", dep.usuario);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@contrasena", dep.contrasena);
                    myCommand.Parameters.AddWithValue("@nombre", dep.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", dep.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", dep.apellido2);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Administrador dep)
        {
            string query = @"
                           update administrador
                           set 
                            usuario = @usuario,
                            id_direccion = @id_direccion,
                            contrasena = @contrasena,
                            nombre = @nombre,
                            apellido1 = @apellido1,
                            apellido2 = @apellido2,

                            where cedula = @cedula
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", dep.cedula);
                    myCommand.Parameters.AddWithValue("@usuario", dep.usuario);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@contrasena", dep.contrasena);
                    myCommand.Parameters.AddWithValue("@nombre", dep.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", dep.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", dep.apellido2);
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
                           delete from administrador
                            where cedula=@cedula
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
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
        [HttpGet("usuario/{usuario}")]
        public JsonResult GetUsuario( string usuario)
        {
            string query = @"
                            select *            
                            from
                            administrador
                            where usuario = @usuario
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@usuario", usuario);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }

            }
            return new JsonResult(table);
        }
        [HttpGet("cedula/{cedula}")]
        public JsonResult GetCedula( string cedula)
        {
            string query = @"
                            select *            
                            from
                            administrador
                            where cedula = @cedula
                            ";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_connectionString))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@cedula", int.Parse(cedula));
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
