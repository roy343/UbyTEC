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
    public class PedidoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PedidoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id ,comprobante, id_direccion, cedula_cliente, id_repartidor, direc_exacta, estado, monto_total, monto_servicio, comercio            
                            from
                            pedido
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
        public JsonResult Post(Pedido dep)
        {
            string query = @"
                           insert into dbo.pedido (id ,comprobante, id_direccion, cedula_cliente, id_repartidor, direc_exacta, estado, monto_total, monto_servicio, comercio  ) 
                           values (@id ,@comprobante, @id_direccion, @cedula_cliente, @id_repartidor, @direc_exacta, @estado, @monto_total, @monto_servicio, @comercio )             
                     
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
                    myCommand.Parameters.AddWithValue("@comprobante", dep.comprobante);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@cedula_cliente", dep.cedula_cliente);
                    myCommand.Parameters.AddWithValue("@id_repartidor", dep.id_repartidor);
                    myCommand.Parameters.AddWithValue("@direc_exacta", dep.direc_exacta);
                    myCommand.Parameters.AddWithValue("@estado", dep.estado);
                    myCommand.Parameters.AddWithValue("@monto_total", dep.monto_total);
                    myCommand.Parameters.AddWithValue("@monto_servicio", dep.monto_servicio);
                    myCommand.Parameters.AddWithValue("@comercio", dep.comercio);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Pedido dep)
        {
            string query = @"
                           update pedido
                           set 
                           id = @id,
                           comprobante = @comprobante, 
                           id_direccion = @id_direccion, 
                           cedula_cliente =@cedula_cliente, 
                           id_repartidor = @id_repartidor, 
                           direc_exacta = @direc_exacta, 
                           estado = @estado, 
                           monto_total = @monto_total, 
                           monto_servicio = @monto_servicio, 
                           comercio =@comercio
                           
                          
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
                    myCommand.Parameters.AddWithValue("@id", dep.id);
                    myCommand.Parameters.AddWithValue("@comprobante", dep.comprobante);
                    myCommand.Parameters.AddWithValue("@id_direccion", dep.id_direccion);
                    myCommand.Parameters.AddWithValue("@cedula_cliente", dep.cedula_cliente);
                    myCommand.Parameters.AddWithValue("@id_repartidor", dep.id_repartidor);
                    myCommand.Parameters.AddWithValue("@direc_exacta", dep.direc_exacta);
                    myCommand.Parameters.AddWithValue("@estado", dep.estado);
                    myCommand.Parameters.AddWithValue("@monto_total", dep.monto_total);
                    myCommand.Parameters.AddWithValue("@monto_servicio", dep.monto_servicio);
                    myCommand.Parameters.AddWithValue("@comercio", dep.comercio);
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
                           delete from pedido
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
    }
}
