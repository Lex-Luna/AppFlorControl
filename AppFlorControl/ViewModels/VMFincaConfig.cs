using AppFlorControl.Conxiones;
using AppFlorControl.Datos;
using AppFlorControl.Models;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    public class VMFincaConfig : BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string txtsector;
        string txttamaño;
        
        #endregion
        #region CONSTRUCTOR
        public VMFincaConfig(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarFinca());
            Volvercomamd = new Command(async () => await Volver());

        }
        #endregion
        #region OBJETOS 
        
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }
        public string Txttamaño
        {
            get { return txttamaño; }
            set { SetValue(ref txttamaño, value); }
        }
        public string txtSector
        {
            get { return txtsector; }
            set { SetValue(ref txtsector, value); }
        }
        #endregion
        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        private async Task InsertarFinca()
        {
            var funcion = new DFinca();
            var parametros = new MFinca();
            parametros.Nombre = Txtnombre;
            parametros.Tamaño = Txttamaño;
            parametros.Sector = txtSector;
            var estadofuncion = await funcion.InserFinca(parametros);

        }

        
        #endregion
        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }

        #endregion

    }
}
