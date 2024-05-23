using AppFlorControl.Conxiones;
using AppFlorControl.Datos;
using AppFlorControl.Models;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFlorControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TecnicoMenu : ContentPage
    {
        public TecnicoMenu()
        {
            InitializeComponent();
            BindingContext = this;
            Task.Run(async () =>
            {
                await obtenerDataUserAsync();
            }).Wait();

            Task.Run(async () =>
            {
                await MostrarAsignaciones(IdUsuario);
            }).Wait();

        }

        #region VARIABLES
        string _nombre;
        string _IdUsuario;
        string _apellido;
        string _correo;
        string _Contraseña;
        string _idAdmin;

        bool _estado;

        public ObservableCollection<MAsignaciones> lisAsig;





        #endregion
        #region OBJETOS 






        public string Apellido
        {
            get => _apellido;
            set
            {
                _apellido = value;
                OnPropertyChanged();
            }
        }

        public string Contraseña
        {
            get => _Contraseña;
            set
            {
                _Contraseña = value;
                OnPropertyChanged();
            }
        }



        public bool Estado
        {
            get => _estado;
            set
            {
                _estado = value;
                OnPropertyChanged();
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }


        public string IdUsuario
        {
            get => _IdUsuario;
            set
            {
                _IdUsuario = value;
                OnPropertyChanged();
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                _correo = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MAsignaciones> LisAsig
        {
            get => lisAsig;
            set
            {
                lisAsig = value;
                OnPropertyChanged(); Debug.WriteLine("LisEncuestaRecomendados changed");
            }
        }

        #endregion
        #region PROCESOS


        private async Task obtenerDataUserAsync()
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Conexiones.WebapyFirebase));
                var guardarId = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var refrescarCOntenido = await authProvider.RefreshAuthAsync(guardarId);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(refrescarCOntenido));
                Correo = guardarId.User.Email;
                var f = new DTecnicos();
                var p = new MTecnico();
                p.Correo = Correo;
                var data = await f.MostTecnicoXcorreo(p);
                Nombre = data[0].Nombre;
                Apellido = data[0].Apellido;
                Contraseña = data[0].Contraseña;
                Estado = data[0].Estado;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "X tu seguridad la sesion se a cerrado", "Ok");

            }
        }

        public async Task MostrarAsignaciones(string idUser)
        {
            DAsignaciones f = new DAsignaciones();
            var asig = await f.MostAsigxIdTecnico(idUser);

            LisAsig = new ObservableCollection<MAsignaciones>(asig);
        }






        #endregion
        #region COMANDOS




        #endregion
    }
}