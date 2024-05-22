using System;
using System.Collections.Generic;
using System.Text;

namespace AppFlorControl.Models
{
    public class MTecnico
    {
        
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }

        public string Contraseña { get; set; }
        public bool EsAdmin { get; set; }
        public bool Estado{ get; set; }
    }
}
