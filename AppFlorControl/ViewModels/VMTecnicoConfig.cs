using AppFlorControl.Conxiones;
using AppFlorControl.Datos;
using AppFlorControl.Models;
using Firebase.Auth;
//using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    internal class VMTecnicoConfig : BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string txtcorreo;
        string txtcedula;
        string txtcontraseña;
        bool estado;
        #endregion
        #region CONSTRUCTOR
        public VMTecnicoConfig(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarTecnico());
            Volvercomamd = new Command(async () => await Volver());

        }
        #endregion
        #region OBJETOS 
        public string Txtcontraseña
        {
            get { return txtcontraseña; }
            set { SetValue(ref txtcontraseña, value); }
        }
        public bool Estado
        {
            get { return estado; }
            set { SetValue(ref estado, value); }
        }
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }
        public string Txtcedula
        {
            get { return txtcedula; }
            set { SetValue(ref txtcedula, value); }
        }
        public string Txtcorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }
        #endregion
        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        private async Task InsertarTecnico()
        {
            var funcion = new DTecnicos();
            var parametros = new MTecnico();
            parametros.Nombre = Txtnombre;
            parametros.Cedula = Txtcedula;
            parametros.Correo = Txtcorreo;
            parametros.Contraseña = Txtcontraseña;
            parametros.Estado = true;
            parametros.EsAdmin = false;
            var estadofuncion = await funcion.InserTecnico(parametros);
            if (estadofuncion == true)
            {
                await CrearCorreo(Txtcorreo, Txtcontraseña);
            }

        }

        private async Task CrearCorreo(string correo, string contraseña)
        {



            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Conexiones.WebapyFirebase));
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, contraseña);
            await DisplayAlert("Estado", "Registro realizado", "OK");
        }
        #endregion
        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }

        #endregion

    }
}
