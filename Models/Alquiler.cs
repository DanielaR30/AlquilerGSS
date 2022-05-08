using System;
using System.Collections.Generic;

#nullable disable

namespace AlquilerGSS.Models
{
    public partial class Alquiler
    {
        public int Idalquiler { get; set; }
        public int Idcarro { get; set; }
        public int Idcliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Dias { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public decimal Abonoinicial { get; set; }
        public bool Devuelto { get; set; }
    }
}
