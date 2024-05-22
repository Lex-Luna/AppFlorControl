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
    public class VMMenuPrincipal : BaseViewModel
    {
        #region VARIABLES
        string nomTecnico;
        List<MFinca> listaSolFinca;
        #endregion
        #region CONSTRUCTOR
        public VMMenuPrincipal(INavigation navigation)
        {
            Navigation = navigation;
            Navegarmenuconfigcomamd = new Command(async () => await NavegarMenuconfig());
            NavegarAsignacionescomamd = new Command<MFinca>(async (idFinca) => await NavegarAsignaciones(idFinca));

            MostrarSolicitudFinca();
        }
        #endregion
        #region OBJETOS 
        public List<MFinca> ListaSolFinca
        {
            get { return listaSolFinca; }
            set { SetValue(ref listaSolFinca, value); }
        }
        public string NomTecnico
        {
            get { return nomTecnico; }
            set { SetValue(ref nomTecnico, value); }
        }

        #endregion
        #region PROCESOS
        private async Task NavegarMenuconfig()
        {
            await Navigation.PushAsync(new MenuConfig());
        }
        private async Task MostrarSolicitudFinca()
        {

            var funcion = new DFinca();
            ListaSolFinca = await funcion.MostrarSolicitud();
        }
        private async Task NavegarAsignaciones(MFinca parametros)
        {
            //Iguala el id de Asignaciones con el de MFInca
            //para enviar idFinca a Asignaciones
            string IdFinca= parametros.Id;
            VMAsignaciones.idFinca = IdFinca;
            await Navigation.PushAsync(new Asignaciones());
        }
        #endregion
        #region COMANDOS
        public Command Navegarmenuconfigcomamd { get; }
        public Command NavegarAsignacionescomamd { get; }


        #endregion
    }
}
