using System;
using System.Collections.Generic;
using System.Text;

namespace AppFlorControl.Models
{
    public class MControlCalidad
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string IdFlor { get; set; }
        public string IdTecnico{ get; set; }
        public int Puntuacion{ get; set; }

    }
}
