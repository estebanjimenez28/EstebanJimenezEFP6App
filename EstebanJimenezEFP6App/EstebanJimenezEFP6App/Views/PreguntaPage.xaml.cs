using EstebanJimenezEFP6App.Models;
using EstebanJimenezEFP6App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstebanJimenezEFP6App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntaPage : ContentPage
    {
        UserViewModel viewmodel;
        public PreguntaPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();
            LoadAskStatusAsync();

        }
        private async void LoadAskStatusAsync()
        {
            PkrAskStatus.ItemsSource = await viewmodel.GetAskStatusAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el rol que se haya seleccionado en el picker

             AskStatus SelectedAskStatus= PkrAskStatus.SelectedItem as AskStatus;

            bool R = await viewmodel.AddAskAsync(DateTime.Now,
                                                  TxtAsk.Text.Trim(),
                                                  GlobalObjects.MyLocalUser.UserId,
                                                  TxtImageURL.Text.Trim(),
                                                  TxtAskDetail.Text.Trim(),
                                                  SelectedAskStatus.AskStatusId);

            if (R)
            {
                await DisplayAlert(":0", "User created Ok!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong...", "OK");
            }


        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}