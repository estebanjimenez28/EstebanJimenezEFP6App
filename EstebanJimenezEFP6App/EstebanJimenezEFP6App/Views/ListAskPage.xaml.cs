using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EstebanJimenezEFP6App.ViewModels;

namespace EstebanJimenezEFP6App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAskPage : ContentPage
    {
        AskViewModel askViewModel;
        public ListAskPage()
        {
            InitializeComponent();
            BindingContext = askViewModel = new AskViewModel();

            LoadAskList();
        }
        private async void LoadAskList()
        {
            GlobalObjects.MyLocalUser.UserId = 14;
           
            LvList.ItemsSource = await askViewModel.GetAsksAsync(GlobalObjects.MyLocalUser.UserId);
        }
    }
}