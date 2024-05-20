using AppFlorControl.Datos;
using AppFlorControl.Models;
using AppFlorControl.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    internal class VMAsignaciones  : BaseViewModel
    {
        #region VARIABLES
        string idTecnico;
        public static string idSolicitud;
        string txtidentificacion;
        string txtnombreTecnico;
        #endregion
        #region CONSTRUCTOR
        public VMAsignaciones(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarAsiganciones());
            Volvercomamd = new Command(async () => await Volver());
            Buscarcommand = new Command(async () => await BuscarRecolectores());

        }
        #endregion
        #region OBJETOS 
        public string IdTecnico
        {
            get { return idTecnico; }
            set { SetValue(ref idTecnico, value); }
        }
        public string TxtnombreTecnico
        {
            get { return txtnombreTecnico; }
            set { SetValue(ref txtnombreTecnico, value); }
        }
        public string Txtidentificacion
        {
            get { return txtidentificacion; }
            set { SetValue(ref txtidentificacion, value); }
        }
        #endregion
        #region PROCESOS
        private async Task InsertarAsiganciones()
        {
            if (!string.IsNullOrEmpty(Txtidentificacion))
            {
                var funcion = new DAsignaciones();
                var parametros = new MAsignaciones();
                parametros.Estado = "Pendiente";
                parametros.IdTecnico = IdTecnico;
                parametros.Id = idSolicitud;
                var estadofuncion = await funcion.Insertar(parametros);
                if (estadofuncion == true)
                {
                    await DisplayAlert("Registrado", "Registro realizado", "OK");
                }
            }
            else
            {
                await DisplayAlert("Sin datos", "Asigne un recolector", "OK");
            }

        }
        private async Task BuscarRecolectores()
        {
            /*var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            parametros.Identificacion = Txtidentificacion;
            var lista = await funcion.Buscarrecolectores(parametros);
            foreach (var data in lista)
            {
                txtnombreTecnico = data.Nombre;
                idTecnico = data.idTecnicoes;
            }*/
        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }
        public Command Buscarcommand { get; }

        #endregion
    }
}
