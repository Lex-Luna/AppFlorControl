using AppFlorControl.Conxiones;
using AppFlorControl.Models;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Estado = asignacionesRequest.Estado,
                    IdTecnico = asignacionesRequest.IdTecnico,
                    IdFinca= asignacionesRequest.IdFinca,
                    NombreFinca = asignacionesRequest.NombreFinca,

                    Id = asignacionesRequest.Id
                });
            return true;
        }
        public async Task<List<MAsignaciones>> MostAsigxIdTecnico(string p)
        {
            return (await Conexiones.firebase
                .Child("Asignaciones")
                .OnceAsync<MAsignaciones>())
                .Where(a => a.Object.IdTecnico == p)
                .Select(item => new MAsignaciones
                {
                    Estado = item.Object.Estado,
                    IdTecnico = item.Object.IdTecnico,
                    IdFinca = item.Object.IdFinca,
                    NombreFinca = item.Object.NombreFinca,
                    
                })
                .ToList();
        }

    }

}
