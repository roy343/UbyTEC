using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Cliente
    {
        public int cedula { get; set; }

        public string usuario { get; set; }

        public int id_direccion { get; set; }

        public string contrasena { get; set; }

        public string nombre { get; set; }

        public int apellido1 { get; set; }

        public string apellido2 { get; set; }

        public int telefono { get; set; }

        public int fecha_nac { get; set; }
    }
}