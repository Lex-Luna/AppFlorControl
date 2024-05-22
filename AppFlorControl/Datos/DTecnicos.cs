using AppFlorControl.Conxiones;
using AppFlorControl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;

namespace AppFlorControl.Datos
{
    public class DTecnicos
    {
        #region Variables
        //string rutafoto;
        public string Idtecnico;
        #endregion
        #region Insertar
        public async Task<bool> InserTecnico(MTecnico tecnicoRequest)
        {
            try
            {
                var data = await Conexiones.firebase
               .Child("Tecnico")
               .PostAsync(new MTecnico()
               {
                   EsAdmin = tecnicoRequest.EsAdmin,
                   Nombre = tecnicoRequest.Nombre,
                   Apellido = tecnicoRequest.Apellido,
                   Correo = tecnicoRequest.Correo,
                   Cedula = tecnicoRequest.Cedula,
                   Estado= tecnicoRequest.Estado,
                   Contraseña= tecnicoRequest.Contraseña
                   
                  
               });
                Idtecnico= data.Key;
            }
            catch (Exception e)
            {

                throw e;
            }
            return true;

        }
        #endregion
        
        #region Buscar
        public async Task<List<MTecnico>> MostrarTecnico()
        {
            return (await Conexiones.firebase
                .Child("Tecnico")
                .OnceAsync<MTecnico>())
                .Select(item => new MTecnico
                {
                    Nombre = item.Object.Nombre,
                    Apellido = item.Object.Apellido,
                    Cedula= item.Object.Cedula,
                    Id = item.Key
                }).ToList();
        }
        public async Task<List<MTecnico>> BuscarTecnico(MTecnico parametrosPedir)
        {
            return (await Conexiones.firebase
                .Child("Tecnico")
                .OrderByKey()
                .OnceAsync<MTecnico>())
                .Where(a => a.Object.Nombre == parametrosPedir.Nombre)
                .Where(b => b.Object.Estado == true)
                .Select(item => new MTecnico
                {
                    Id = item.Key,
                    Nombre = item.Object.Nombre
                }).ToList();
        }

        #endregion


    }
}

