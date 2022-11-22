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
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select cedula ,usuario, id_direccion, contrasena, nombre, apellido1, apellido2, fecha_nac, telefono            
                            from
                            cliente
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
        public JsonResult Post(Cliente dep)
        {
            string query = @"
                           insert into cliente (cedula ,usuario, id_direccion, contrasena, nombre, apellido1, apellido2, fecha_nac, telefono ) 
                           values (@cedula ,@usuario, @id_direccion, @contrasena, @nombre, @apellido1, @apellido2, @fecha_nac, @telefono )             
                     
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
                    myCommand.Parameters.AddWithValue("@usuario", dep.usuario);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@contrasena", dep.contrasena);
                    myCommand.Parameters.AddWithValue("@nombre", dep.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", dep.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", dep.apellido2);
                    myCommand.Parameters.AddWithValue("@fecha_nac", dep.fecha_nac);
                    myCommand.Parameters.AddWithValue("@telefono", dep.telefono);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Cliente dep)
        {
            string query = @"
                           update Cliente
                           set 
                           cedula =  @cedula,
                            usuario = @usuario,
                            id_direccion = @id_direccion,
                            contrasena = @contrasena,
                            nombre = @nombre,
                            apellido1 = @apellido1,
                            apellido2 = @apellido2,
                            fecha_nac = @fecha_nac,
                            telefono = @telefono,
                           
                          
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
                    myCommand.Parameters.AddWithValue("@usuario", dep.usuario);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@contrasena", dep.contrasena);
                    myCommand.Parameters.AddWithValue("@nombre", dep.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", dep.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", dep.apellido2);
                    myCommand.Parameters.AddWithValue("@fecha_nac", dep.fecha_nac);
                    myCommand.Parameters.AddWithValue("@telefono", dep.telefono);
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
                           delete from cliente
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
        [HttpGet("usuario/{usuario}")]
        public JsonResult GetUsuario( string usuario)
        {
            string query = @"
                            select *            
                            from
                            cliente
                            where usuario = @usuario
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
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
    }
}
