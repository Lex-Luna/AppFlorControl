using AppFlorControl.Conxiones;
using AppFlorControl.Datos;
using AppFlorControl.Models;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    internal class VMtecnico : BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string txtcorreo;
        string txtcontraseña;
        string txtapellido;
        bool bEsAdmin;
        #endregion
        #region CONSTRUCTOR
        public VMtecnico(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarRecolectores());
            Volvercomamd = new Command(async () => await Volver());

        }
        #endregion
        #region OBJETOS 
        public bool BEsAdmin
        {
            get { return bEsAdmin; }
            set { SetValue(ref bEsAdmin, value); }
        }
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }
        public string Txtapellido
        {
            get { return txtapellido; }
            set { SetValue(ref txtapellido, value); }
        }
        public string txtCorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }
        public string TxtContraseña
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
        private async Task InsertarRecolectores()
        {
            var funcion = new DTecnicos();
            var tecnicosRequest = new MTecnico();
            tecnicosRequest.Nombre = Txtnombre;
            tecnicosRequest.Apellido = Txtapellido;
            tecnicosRequest.Correo = txtCorreo;
            tecnicosRequest.Contraseña = TxtContraseña;
            
            
            
            var estadofuncion = await funcion.InserTecnico(tecnicosRequest);
            if (estadofuncion == true)
            {
                await CrearCorreo(txtCorreo, TxtContraseña);
            }

        }
        private async Task CrearCorreo(string correo, string contraseña)
        {
            var config = new FirebaseAuthConfig
            {
                // Aquí va tu clave de API web
                ApiKey = Conexiones.WebapyFirebase
            };
            var authProvider = new  FirebaseAuthClient(config);
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
