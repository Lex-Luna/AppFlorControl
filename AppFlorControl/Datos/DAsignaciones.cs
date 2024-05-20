using AppFlorControl.Conxiones;
using AppFlorControl.Models;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFlorControl.Datos
{
    public class DAsignaciones
    {
        public async Task<bool> Insertar(MAsignaciones asignacionesRequest)
        {
            await Conexiones.firebase
                .Child("Asignaciones")
                .PostAsync(new MAsignaciones()
                {
                    IdSolicitud = asignacionesRequest.IdSolicitud,
                    Estado = asignacionesRequest.Estado,
                    IdTecnico = asignacionesRequest.IdTecnico,
                    IdControlcalidad= asignacionesRequest.IdControlcalidad
                });
            return true;
        }
    }
}
