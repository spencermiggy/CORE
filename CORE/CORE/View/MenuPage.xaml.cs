﻿using System;
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

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
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
                await Navigation.PushModalAsync(new ProfilePage());
        }
        private async Task XSearch(string query)
        {
            try
            {
                if (Search1.Text != "")
                {
                    var products = await MobileService.GetTable<repairer>().Take(100).ToListAsync();
                    ShowPeople.ItemsSource = products.Where(p => p.job.ToLower().Contains(query.ToLower())).ToList();
                }
                else
                {
                    var repairers = await repairer.Read();
                    ShowPeople.ItemsSource = repairers.Where(x => x.city == city).ToList();
                }
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
    }
}