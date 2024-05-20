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
        string identificacion;
        //List<Msolicitudesrecojo> listasolRecojo;
        #endregion
        #region CONSTRUCTOR
        public VMMenuPrincipal(INavigation navigation)
        {
            Navigation = navigation;
            Navegarmenuconfigcomamd = new Command(async () => await NavegarMenuconfig());
            //NavegarAsignacionescomamd = new Command<Msolicitudesrecojo>(async (f) => await NavegarAsignaciones(f));

            //Mostrarsolicitudesrecojo();
        }
        #endregion
        #region OBJETOS 
        /*public List<Msolicitudesrecojo> ListasolRecojo
        {
            get { return listasolRecojo; }
            set { SetValue(ref listasolRecojo, value); }
        }*/
        public string Identificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
        }

        #endregion
        #region PROCESOS
        private async Task NavegarMenuconfig()
        {
            await Navigation.PushAsync(new MenuConfig());
        }
        /*private async Task Mostrarsolicitudesrecojo()
        {

            var funcion = new Dsolicitudesrecojo();
            ListasolRecojo = await funcion.Mostrarsolicitudesrecojo();
        }
        private async Task NavegarAsignaciones(Msolicitudesrecojo parametros)
        {
            string Idsolicitud = parametros.Idsolicitud;
            VMasignaciones.idsolicitud = Idsolicitud;
            await Navigation.PushAsync(new Asignaciones());
        }*/
        #endregion
        #region COMANDOS
        public Command Navegarmenuconfigcomamd { get; }
        public Command NavegarAsignacionescomamd { get; }


        #endregion
    }
}
