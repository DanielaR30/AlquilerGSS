using System;
using System.Collections.Generic;

#nullable disable

namespace AlquilerGSS.Models
{
    public partial class Cliente
    {
        public int Idcliente { get; set; }
        public decimal Cedula { get; set; }
        public string Nombre { get; set; }
        public decimal Telefono1 { get; set; }
        public decimal? Telefono2 { get; set; }
    }
}
