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
    public partial class PreguntaPage : ContentPage
    {
        UserViewModel viewmodel;
        public PreguntaPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            bool R = await viewmodel.AddAskAsync(
                                         TxtDate.Text.Trim(),
                                         TxtAsk.Text.Trim(),
                                         TxtUserID.Text.Trim(), 
                                         TxtImageURL.Text.Trim(),
                                         TxtAskDetail.Text.Trim());

            if (R)
            {
                await DisplayAlert(":0", "Pregunta creada correctamente!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Algo Salio Mal...", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}