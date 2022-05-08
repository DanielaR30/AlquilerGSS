using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlquilerGSS.Models;

namespace AlquilerGSS.PocoClass
{
    public partial class DetalleAlquiler : Alquiler
    {

        public decimal Cedulacliente { get; set; }
        public string Nombrecliente { get; set; }
        public string Placacarro { get; set; }
        public string Marcacarro { get; set; }

    }
}
