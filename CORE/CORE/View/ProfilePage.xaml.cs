using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CORE.Models;
using static CORE.App;
using Xamarin.Essentials;
using Plugin.Share;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ProfileViewModel();
        }

        protected override async void OnAppearing()
        {
            try
            {
                var profile = (await MobileService.GetTable<customer>().Where(x => x.id == customer_id).ToListAsync()).FirstOrDefault();
                profgrid.BindingContext = profile;
            }
            catch
            {
                
                await DisplayAlert("Network Error", "A network error occured, please check your internet connectivity and try again.", "OK");
            }
        }

        private async void BtnEdit(object sender, EventArgs e)
        {
                await Navigation.PushModalAsync(new UpdatePage());
        }

        private void BtnLog(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void reportButton_Clicked(object sender, EventArgs e)
        {
            CrossShare.Current.OpenBrowser("https://web.facebook.com/misgkie/");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CusHistory());
        }
    }
}