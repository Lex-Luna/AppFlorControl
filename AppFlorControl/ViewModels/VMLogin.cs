using AppFlorControl.Conxiones;
using AppFlorControl.Datos;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    public class VMLogin : BaseViewModel
    {

        #region CONSTRUCTOR
        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
            

        }
        #endregion
        #region VARIABLES
        string correo;
        string contraseña;
        bool panelLogin;
        bool recuperarContrasenia;
        #endregion

        #region OBJETOS 
        public bool PanelLogin
        {
            get { return panelLogin; }
            set { SetValue(ref panelLogin, value); }
        }
        public bool RecuperarContrasenia
        {
            get { return recuperarContrasenia; }
            set { SetValue(ref recuperarContrasenia, value); }
        }
        public string Correo
        {
            get { return correo; }
            set { SetValue(ref correo, value); }
        }


        public string Contraseña
        {
            get { return contraseña; }
            set { SetValue(ref contraseña, value); }
        }

        #endregion

        #region PROCESOS

        
        


        public async Task ValidarDatos()
        {
            try
            {
                var funcion = new DCuenta();
                await funcion.ValidCuenta(Correo, Contraseña);

            }
            catch (Exception)
            {

                await DisplayAlert("Alerta", "Correo o contraseña invlidaa", "OK");
            }
        }
        private async Task btnIniciar()
        {
            try
            {
                if (!string.IsNullOrEmpty(Correo))
                {
                    if (!string.IsNullOrEmpty(Contraseña))
                    {
                        await ValidarDatos();
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Ingrese su contraseña", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Ingrese su correo", "OK");
                }
            }
            catch (Exception exs)
            {

                throw exs;
            }

        }

        
        #endregion
        #region COMANDOS

        public ICommand btnIniciarcomamd => new Command(async () => await btnIniciar());

        #endregion
    }

}
