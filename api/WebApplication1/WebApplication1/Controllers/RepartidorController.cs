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
    public class  RepartidorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RepartidorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id ,usuario, id_direccion, contrasena, nombre, apellido1, apellido2, email, disponibilidad            
                            from
                            dbo.repartidor
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
        public JsonResult Post(Repartidor dep)
        {
            string query = @"
                           insert into dbo.repartidor (id ,usuario, id_direccion, contrasena, nombre, apellido1, apellido2, email, disponibilidad ) 
                           values (@id ,@usuario, @id_direccion, @contrasena, @nombre, @apellido1, @apellido2, @email, @disponibilidad )             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", dep.id);
                    myCommand.Parameters.AddWithValue("@usuario", dep.usuario);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@contrasena", dep.contrasena);
                    myCommand.Parameters.AddWithValue("@nombre", dep.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", dep.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", dep.apellido2);
                    myCommand.Parameters.AddWithValue("@email", dep.email);
                    myCommand.Parameters.AddWithValue("@disponibilidad", dep.disponibilidad);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Repartidor dep)
        {
            string query = @"
                           update dbo.repartidor
                           set 
                           id =  @id,
                            usuario = @usuario,
                            id_direccion = @id_direccion,
                            contrasena = @contrasena,
                            nombre = @nombre,
                            apellido1 = @apellido1,
                            apellido2 = @apellido2,
                            email = @email,
                            disponibilidad = @disponibilidad,
                           
                          
                           where id= @id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", dep.id);
                    myCommand.Parameters.AddWithValue("@usuario", dep.usuario);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@contrasena", dep.contrasena);
                    myCommand.Parameters.AddWithValue("@nombre", dep.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", dep.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", dep.apellido2);
                    myCommand.Parameters.AddWithValue("@email", dep.email);
                    myCommand.Parameters.AddWithValue("@disponibilidad", dep.disponibilidad);
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
                           delete from dbo.repartidor
                            where id=@id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
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
                            dbo.repartidor
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
        [HttpGet("cedula/{cedula}")]
        public JsonResult GetCedula( string cedula)
        {
            string query = @"
                            select *            
                            from
                            dbo.repartidor
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
                            dbo.repartidor
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
