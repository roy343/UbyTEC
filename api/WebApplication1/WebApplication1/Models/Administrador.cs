using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Administrador
    {
        public int cedula { get; set; }

        public string usuario { get; set; }

        public int id_direccion { get; set; }

        public string contrasena { get; set; }

        public string nombre { get; set; }

        public string apellido1 { get; set; }

        public string apellido2 { get; set; }
    }
}