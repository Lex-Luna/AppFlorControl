using AppFlorControl.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFlorControl.ViewModels
{
    public class VMMenuConfig : BaseViewModel
    {
        #region VARIABLES
        string identificacion;
        #endregion
        #region CONSTRUCTOR
        public VMMenuConfig(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomamd = new Command(async () => await Volver());
            NavegarTecnicocomamd = new Command(async () => await NavegarTecnico());
            NavegarProductosconfigcomamd = new Command(async () => await Navegarproductosconfig());

        }
        #endregion
        #region OBJETOS 
        public string Identificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
        }

        #endregion
        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        private async Task NavegarTecnico()
        {
            await Navigation.PushAsync(new tecnicoConfig());
        }
        private async Task Navegarproductosconfig()
        {
            //await Navigation.PushAsync(new Productosconfig());
        }
        #endregion
        #region COMANDOS
        public Command Volvercomamd { get; }
        public Command NavegarTecnicocomamd { get; }
        public Command NavegarProductosconfigcomamd { get; }
        #endregion
    }
}
