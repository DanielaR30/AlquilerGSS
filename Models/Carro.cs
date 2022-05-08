using System;
using System.Collections.Generic;

#nullable disable

namespace AlquilerGSS.Models
{
    public partial class Carro
    {
        public int Idcarro { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Costo { get; set; }
        public bool? Disponible { get; set; }
    }
}
