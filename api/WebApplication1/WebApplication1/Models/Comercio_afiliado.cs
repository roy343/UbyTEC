using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Comercio_afiliado
    {
        public int cedula { get; set; }

        public string nombre_comercio { get; set; }

        public int id_direccion { get; set; }

        public int sinpe { get; set; }

        public string email { get; set; }

        public int tipo { get; set; }

    }
}