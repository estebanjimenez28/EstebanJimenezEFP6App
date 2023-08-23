using Acr.UserDialogs;
using EstebanJimenezEFP6App.Models;
using EstebanJimenezEFP6App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstebanJimenezEFP6App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BienvenidaPage : ContentPage
    {
        UserViewModel viewModel;
        public BienvenidaPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserViewModel();
        }
      

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreguntaPage());




        }
    }
}
