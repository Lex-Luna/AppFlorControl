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
    public class DFinca
    {
        public string idFinca;
        public async Task<bool> InserFinca(MFinca fincaRequest)
        {
            try
            {
                var data = await Conexiones.firebase
               .Child("Finca")
               .PostAsync(new MFinca()
               {
                   Nombre = fincaRequest.Nombre,
                   Sector = fincaRequest.Sector,
                   Tamaño= fincaRequest.Tamaño,
                   Solicitud= fincaRequest.Solicitud
                   
                   
               });
                idFinca = data.Key;
            }
            catch (Exception e)
            {

                throw e;
            }
            return true;

        }

        public async Task<List<MFinca>> MostrarSolicitud()
        {
            return (await Conexiones.firebase
                .Child("Finca")
                .OnceAsync<MFinca>())
                .Select(item => new MFinca
                {
                    Solicitud = item.Object.Solicitud,
                    Nombre= item.Object.Nombre,
                    Sector= item.Object.Sector,
                    Id = item.Key
                }).ToList();
        }

        public async Task<List<MFinca>> Buscarfinca(MFinca parametrosPedir)
        {
            return (await Conexiones.firebase
                .Child("inca")
                .OrderByKey()
                .OnceAsync<MFinca>())
                .Where(a => a.Object.Nombre == parametrosPedir.Nombre)
                .Select(item => new MFinca
                {
                    Id= item.Key,
                    Nombre = item.Object.Nombre
                }).ToList();
        }
    }

}
