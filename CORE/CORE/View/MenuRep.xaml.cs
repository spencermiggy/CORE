﻿using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static CORE.App;

using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuRep : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();
        public MenuRep()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await GetRepairer();
        }
        private async Task GetRepairer()
        {
            var repairers = await repairer.Read();
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
            await Navigation.PushModalAsync(new ProfileRep());
        }

        private async Task XSearch(string query)
        {
            try
            {
                var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
                ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(query.ToLower())).ToList();
            }
            catch
            {
                await DisplayAlert("Error", "Check your internet connection", "OK");
            }

        }

        private async void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Search1.Text != "")
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
            if (item?.BindingContext is repairer model)
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
            if (item?.BindingContext is repairer model)
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
                await Navigation.PushModalAsync(new MapPage1());
            }
            catch
            {
                await DisplayAlert("Error", "Please turn on your Location", "OK");
                return;
            }
        }
        private async void Laptop_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Laptop.Text.ToLower())).ToList();
        }

        private async void Android_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Android.Text.ToLower())).ToList();
        }

        private async void IOS_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(IOS.Text.ToLower())).ToList();
        }

        private async void Desktop_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Desktop.Text.ToLower())).ToList();
        }

        private async void Plumber_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Plumber.Text.ToLower())).ToList();
        }
        private async void Developer_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Developer.Text.ToLower())).ToList();
        }
        private async void Electric_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Electric.Text.ToLower())).ToList();
        }
        private async void Keypad_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Keypad.Text.ToLower())).ToList();
        }
        private async void Technician_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Technician.Text.ToLower())).ToList();
        }
        private async void Internet_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Internet.Text.ToLower())).ToList();
        }
        private async void Openline_Clicked(object sender, EventArgs e)
        {
            var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
            ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(Openline.Text.ToLower())).ToList();
        }
        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await GetRepairer();
            refreshme.IsRefreshing = false;
        }
    }
}