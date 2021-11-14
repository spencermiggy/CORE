using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CORE.Models;
using System.Threading.Tasks;
using static CORE.App;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();
        public MenuPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await GetRepairer();
            try
            {
                var profile = (await MobileService.GetTable<customer>().Where(x => x.id == customer_id).ToListAsync()).FirstOrDefault();
                pro.BindingContext = profile;
            }
            catch
            {

                await DisplayAlert("Network Error", "A network error occured, please check your internet connectivity and try again.", "OK");
            }
        }
        private async Task GetRepairer()
        {
            var repairers = await View_1.Read();
            ShowPeople.ItemsSource = repairers.Where(x => x.city.ToLower() == city.ToLower()).ToList();
        }

        private void TextBtn(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var smsSend = CrossMessaging.Current.SmsMessenger;
            if (item?.BindingContext is repairer model)
            {
                smsSend.SendSms(model.pnum, "");
            }
        }

        private async void ProfBtn(object sender, EventArgs e)
        {
                await Navigation.PushModalAsync(new ProfilePage());
        }
        private async Task XSearch(string query)
        {
            try
            {
                var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
                ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(query.ToLower())).ToList();
            }
            catch
            {
                await DisplayAlert("Error","Check your internet connection","OK");
            }

        }

        private async void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search1.Text != "")
            {
                await XSearch(Search1.Text);
            }
            else
            {
                await GetRepairer();
            }
        }
        private void reportButton_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var smsSend = CrossMessaging.Current.SmsMessenger;
            if (item?.BindingContext is View_1 model)
            {
                smsSend.SendSms("09959844622", $"Name: {model.fname} {model.lname}, " +
                    $"Job: {model.job}," +
                    $" Address: {model.addr} , " +
                    $"Mobile Number: {model.pnum}....... " +
                    $"Your report message:      " +
                    $"    ");
            }
        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if (item?.BindingContext is View_1 model)
            {
                await Xamarin.Essentials.Map.OpenAsync(Convert.ToDouble(model.latt), Convert.ToDouble(model.longg), new MapLaunchOptions
                {
                    NavigationMode = NavigationMode.Driving
                });
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushModalAsync(new MapPage());
            }
            catch
            {
                await DisplayAlert("Error","Please turn on your Location","OK");
            }
        }

        private async void Laptop_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Laptop.Text.ToLower())).ToList();
        }

        private async void Android_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Android.Text.ToLower())).ToList();
        }

        private async void IOS_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(IOS.Text.ToLower())).ToList();
        }

        private async void Desktop_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Desktop.Text.ToLower())).ToList();
        }

        private async void Plumber_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Plumber.Text.ToLower())).ToList();
        }
        private async void Developer_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Developer.Text.ToLower())).ToList();
        }
        private async void Electric_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Electric.Text.ToLower())).ToList();
        }
        private async void Keypad_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Keypad.Text.ToLower())).ToList();
        }
        private async void Technician_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Technician.Text.ToLower())).ToList();
        }
        private async void Internet_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Internet.Text.ToLower())).ToList();
        }
        private async void Openline_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<View_1>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Openline.Text.ToLower())).ToList();
        }
        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await GetRepairer();
            refreshme.IsRefreshing = false;
        }

        private async void SwipeItem_Clicked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var smsSend = CrossMessaging.Current.SmsMessenger;
            if (item?.BindingContext is View_1 model)
            {
                try
                {
                    Transact transact = new Transact
                    {
                        Cfname = fname,
                        Clname = lname,
                        Cusid = customer_id,
                        Caddr = addr,
                        Clatt = latt,
                        Clongg = longg,
                        Cnum = pnum,
                        Repid = model.id,
                        Accdec = "Pending"
                    };
                    await Transact.Insert(transact);
                    smsSend.SendSms(model.pnum, "HI please check your app for my request");
                    await DisplayAlert("Success", "Your Request is Send", "Ok");
                }
                catch
                {
                    await DisplayAlert("INFO","Auto Message didn't sent please load your sim","OK");
                }
            }
        }

        private async void SwipeItem_Clicked_2(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if(item?.BindingContext is View_1 model)
            {
                await Clipboard.SetTextAsync(model.id);
            }
        }
    }
}