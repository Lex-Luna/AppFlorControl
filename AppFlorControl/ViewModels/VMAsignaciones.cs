using AppFlorControl.Datos;
using AppFlorControl.Models;
using AppFlorControl.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    internal class VMAsignaciones : BaseViewModel
    {
        #region VARIABLES
        string idtecnico;
        public static string idFinca;
        List<MTecnico> lisTecnico;
        string txtnombrefinca;
        string txtnombretecnico;
        #endregion
        #region CONSTRUCTOR
        public VMAsignaciones(INavigation navigation)
        {

            Navigation = navigation;
            Insertarcomamd = new Command<MTecnico>(async (tecnico) => await Insertarasiganciones(tecnico));
            Volvercomamd = new Command(async () => await Volver());
            MostrarTecnico();
            //Mostrarcommand = new Command(async () => await MostrarTecnico());
            //Buscarcommand = new Command(async () => await BuscarTecnico());
            //BuscarFcommand = new Command(async () => await BuscarFinca());

        }
        #endregion
        #region OBJETOS 
        public List<MTecnico> LisTecnico
        {
            get { return lisTecnico; }
            set { SetValue(ref lisTecnico, value); }
        }
        public string Id
        {
            get { return idtecnico; }
            set { SetValue(ref idtecnico, value); }
        }
        public string IdFinca
        {
            get { return idFinca; }
            set { SetValue(ref idFinca, value); }
        }
        
        public string Txtnombretecnico
        {
            get { return txtnombretecnico; }
            set { SetValue(ref txtnombretecnico, value); }
        }
        public string txtNombrefinca
        {
            get { return txtnombrefinca; }
            set { SetValue(ref txtnombrefinca, value); }
        }
        #endregion
        #region PROCESOS
        //public ICommand SumQuantity => new Command<MTecnico>((p) => Insertarasiganciones(p));
        
        private async Task Insertarasiganciones(MTecnico tecnico)
        {

            var parametros = new MAsignaciones();
            var funcion = new DAsignaciones();
            parametros.Estado = "Pendiente";
            parametros.IdTecnico = tecnico.Id; 
            parametros.IdFinca= IdFinca;
            var estadofuncion = await funcion.Insertar(parametros);

        }

        private async Task MostrarTecnico()
        {

            var funcion = new DTecnicos();
            LisTecnico = await funcion.MostrarTecnico();
        }
        
        
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        
        
        public Command Volvercomamd { get; }

        public Command Buscarcommand { get; }
        public Command Mostrarcommand { get; }
        public Command Insertarcomamd { get; }

        

        #endregion
    }

}
