using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppFlorControl.Conxiones
{
    public class Conexiones
    {
        public static FirebaseClient firebase = new FirebaseClient("https://appcontrolflor-default-rtdb.firebaseio.com/");
        public const string WebapyFirebase = "AIzaSyAutzcS5TFRERVGKjRlaDIfVqC5CBcrYTQ";
        /*
        public static string storage = "huecasapp-d8da1.appspot.com";

        public const string GoogleMapsApiKey = "AIzaSyDkbzFWQC_jmqn6NY1_F92aOLVfoKbrRr8";*/
    }
}
