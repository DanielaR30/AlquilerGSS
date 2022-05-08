using System;
using System.Collections.Generic;

#nullable disable

namespace AlquilerGSS.Models
{
    public partial class Pago
    {
        public int Idpago { get; set; }
        public int Idalquiler { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
    }
}
