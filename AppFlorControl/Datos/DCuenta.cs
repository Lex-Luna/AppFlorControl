using AppFlorControl.Conxiones;
using AppFlorControl.Models;
using AppFlorControl.Views;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AppFlorControl.Datos
{
    
    
        public class DCuenta
        {
            string _correo;
            bool _admin;
            public string Correo
            {
                get => _correo;
                set
                {
                    _correo = value;

                }
            }
            public bool Admin
            {
                get => _admin;
                set
                {
                    _admin = value;

                }
            }
            public async Task ValidCuenta(string correo, string pass)
            {
                try
                {


                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Conexiones.WebapyFirebase));
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(correo, pass);
                    /*vamos a generar un nuevo token*/
                    var serializartoken = JsonConvert.SerializeObject(auth);
                    Preferences.Set("MyFirebaseRefreshToken", serializartoken);
                    var guardarId = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.
                        Get("MyFirebaseRefreshToken", ""));
                    //await App.Current.MainPage
                    var refrescarCOntenido = await authProvider.RefreshAuthAsync(guardarId);
                    Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(refrescarCOntenido));

                    Correo = guardarId.User.Email;
                    var f = new DTecnicos();
                    var p = new MTecnico();
                    p.Correo = Correo;
                    var data = await f.MostTecnicoXcorreo(p);
                    Admin = data[0].EsAdmin;
                    if (Admin == false)
                    {
                        Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new TecnicoMenu());
                    }
                    else
                    {
                        Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new Menuprincipal());
                    }

                }
                catch (Exception er)
                {
                    throw er;
                }

            }

        }
    

}
