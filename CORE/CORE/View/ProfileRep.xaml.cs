using CORE.Models;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CORE.App;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileRep : ContentPage
    {
        public ProfileRep()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                var profile = (await MobileService.GetTable<repairer>().Where(x => x.id == repairer_id).ToListAsync()).FirstOrDefault();
                profgrid1.BindingContext = profile;
            }
            catch
            {

                await DisplayAlert("Network Error", "A network error occured, please check your internet connectivity and try again.", "OK");
            }
        }

        private async void BtnEdit(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UpdateRep());
        }

        private void BtnLog(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private async void Btnsched(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SchedPage());
        }

        private async void reportButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HistoryRep());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var item = await RatingTBLL.Read();
            var items = new RatingTBLL();
            repairer repairer = new repairer
            {
                id = repairer_id,
                fname = fname,
                lname = lname,
                latt = latt,
                longg = longg,
                activetime = activetime,
                statusact = statusact,
                addr = addr,
                city = city,
                currentloc = currentloc,
                job = job,
                pass = pass,
                picstr = picstr,
                pnum = pnum,
                propics = propics,
                TotalRate = items.TotRate
            };
            TotalRate = items.TotRate;
            await repairer.Update(repairer);
            await DisplayAlert("Success","Done Refreshing","OK");
        }
    }
}