﻿using AppFlorControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFlorControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuConfig : ContentPage
    {
        public MenuConfig()
        {
            InitializeComponent();
            BindingContext = new VMMenuConfig(Navigation);
        }
    }
}