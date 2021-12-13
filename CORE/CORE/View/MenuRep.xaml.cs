using CORE.Models;
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
using Acr.UserDialogs;

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
            try
            {
                var profile = (await MobileService.GetTable<repairer>().Where(x => x.id == repairer_id).ToListAsync()).FirstOrDefault();
                pro.BindingContext = profile;
            }
            catch
            {

                await DisplayAlert("Network Error", "A network error occured, please check your internet connectivity and try again.", "OK");
            }
        }
        private async Task GetRepairer()
        {
            var repairers = await Transact.Read();
            ShowPeople.ItemsSource = repairers.Where(x => x.Repid == repairer_id).ToList();
        }

        private void TextBtn(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var smsSend = CrossMessaging.Current.SmsMessenger;
            if (item?.BindingContext is Transact model)
            {
                smsSend.SendSms(model.Cnum, "");
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
                var products = await MobileService.GetTable<Transact>().Take(100).ToListAsync();
                ShowPeople.ItemsSource = products.Where(p => p.Cfname.ToLower().Contains(query.ToLower()) || p.Clname.ToLower().Contains(query.ToLower())).ToList();
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
            if (item?.BindingContext is Transact model)
            {
                smsSend.SendSms("09959844622", $"Name: {model.Cfname} {model.Clname}, " +
                    $" Address: {model.Caddr} , " +
                    $"Mobile Number: {model.Cnum}....... " +
                    $"Your report message:      " +
                    $"    ");
            }
        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if (item?.BindingContext is Transact model)
            {
                await Xamarin.Essentials.Map.OpenAsync(Convert.ToDouble(model.Clatt), Convert.ToDouble(model.Clongg), new MapLaunchOptions 
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
            }
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await GetRepairer();
            try
            {
                var profiles = (await MobileService.GetTable<RatingTBL>().Where(x => x.Repid == repairer_id).ToListAsync()).FirstOrDefault();
                float tot1 = profiles.star + star;
                float tot2 = profiles.stars + stars;
                float tot3 = profiles.starss + starss;
                float tot4 = profiles.starsss + starsss;
                float tot5 = profiles.starssss + starssss;
                float tota1 = tot1 * 1;
                float tota2 = tot2 * 2;
                float tota3 = tot3 * 3;
                float tota4 = tot4 * 4;
                float tota5 = tot5 * 5;
                float tota6 = tot1 + tot2 + tot3 + tot4 + tot5;
                float tota7 = tota1 + tota2 + tota3 + tota4 + tota5;
                float tota8 = tota7 / tota6;
                repairer repairer = new repairer
                    {
                        id = repairer_id,
                        activetime = activetime,
                        addr = addr,
                        city = city,
                        currentloc = currentloc,
                        fname = fname,
                        job = job,
                        latt = latt,
                        lname = lname,
                        longg = longg,
                        pass = pass,
                        picstr = picstr,
                        pnum = pnum,
                        propics = propics,
                        statusact = statusact,
                        star = tot1,
                        stars = tot2,
                        starss = tot3,
                        starsss = tot4,
                        starssss = tot5,
                        TotalRate = tota8
                    };
                    star = repairer.star;
                    stars = repairer.stars;
                    starss = repairer.starss;
                    starsss = repairer.starsss;
                    starssss = repairer.starssss;
                    await repairer.Update(repairer);
                RatingTBL ratingTBL = new RatingTBL
                {
                    id = profiles.id
                };
                await RatingTBL.Delete(ratingTBL);
                }
            catch
            {

                await GetRepairer();
            }
            refreshme.IsRefreshing = false;
        }

        private void accepted_Clicked(object sender, EventArgs e)
        {
            var ongo = "Ongoing";
            var item = sender as SwipeItem;
            var sms = CrossMessaging.Current.SmsMessenger;
            _ = UserDialogs.Instance.Confirm(new ConfirmConfig
            {
                Message = "Do you want to Accept this request?",
                OkText = "Confirm",
                CancelText = "Later",
                Title = "ARE YOU SURE?",
                OnAction = async (confirmed) =>
                {
                    if (confirmed)
                    {
                        if (item?.BindingContext is Transact model)
                        {
                            try
                            {
                                Transact transact = new Transact
                                {
                                    id = model.id,
                                    Cfname = model.Cfname,
                                    Clname = model.Clname,
                                    Cusid = model.Cusid,
                                    Caddr = model.Caddr,
                                    Clatt = model.Clatt,
                                    Clongg = model.Clongg,
                                    Cnum = model.Cnum,
                                    Repid = model.Repid,
                                    Raddr = model.Raddr,
                                    Rnum = model.Rnum,
                                    Rlname = model.Rlname,
                                    Rfname = model.Rfname,
                                    Accdec = ongo
                                };
                                await Transact.Update(transact);
                                repairer repairer = new repairer
                                {
                                    id = repairer_id,
                                    fname = fname,
                                    lname = lname,
                                    activetime = "Not Available",
                                    addr = addr,
                                    city = city,
                                    currentloc = currentloc,
                                    job = job,
                                    latt = latt,
                                    longg = longg,
                                    pass = pass,
                                    picstr = picstr,
                                    pnum = pnum,
                                    propics = propics,
                                    star = star,
                                    stars = stars,
                                    starss = starss,
                                    starsss = starsss,
                                    starssss = starssss,
                                    statusact = "Inactive",
                                    TotalRate = TotalRate,
                                };
                                await repairer.Update(repairer);
                                refreshme.IsRefreshing = true;
                                if (sms.CanSendSmsInBackground)
                                {
                                    sms.SendSmsInBackground(model.Cnum, "I Accepted your request");
                                }
                                await DisplayAlert("MESSAGE","Request Accepted","DONE");
                                refreshme.IsRefreshing = false;
                            }
                            catch
                            {
                                
                            }
                        }
                    }
                },
            });
        }

        private async void DoneBtn_Clicked(object sender, EventArgs e)
        {
            var ongo = "Done";
                var item = sender as SwipeItem;
                if (item?.BindingContext is Transact model)
                {
                    try
                    {
                    if(model.Accdec == "Pending")
                    {
                        await DisplayAlert("INFO","You Did not accepted a job!","OK");
                    }
                    else
                    {
                        TransactHistory transact = new TransactHistory
                        {
                            Transid = model.id,
                            Cfname = model.Cfname,
                            Clname = model.Clname,
                            Cusid = model.Cusid,
                            Caddr = model.Caddr,
                            Clatt = model.Clatt,
                            Clongg = model.Clongg,
                            Cnum = model.Cnum,
                            Repid = model.Repid,
                            Accdec = ongo
                        };
                        await TransactHistory.Insert(transact);

                        TransactCus transactss = new TransactCus
                        {
                            Transid = model.id,
                            Cfname = model.Rfname,
                            Clname = model.Rlname,
                            Cusid = model.Cusid,
                            Caddr = model.Raddr,
                            Clatt = model.Clatt,
                            Clongg = model.Clongg,
                            Cnum = model.Rnum,
                            Repid = model.Repid,
                            Accdec = ongo
                        };
                        await TransactCus.Insert(transactss);
                        repairer repairer = new repairer
                        {
                            id = repairer_id,
                            fname = fname,
                            lname = lname,
                            activetime = "Available",
                            addr = addr,
                            city = city,
                            currentloc = currentloc,
                            job = job,
                            latt = latt,
                            longg = longg,
                            pass = pass,
                            picstr = picstr,
                            pnum = pnum,
                            propics = propics,
                            star = star,
                            stars = stars,
                            starss = starss,
                            starsss = starsss,
                            starssss = starssss,
                            statusact = "Active",
                            TotalRate = TotalRate,
                        };
                        await repairer.Update(repairer);
                        await DisplayAlert("Success", "Done Transaction", "Ok");

                        Transact transacts = new Transact
                        {
                            id = model.id
                        };
                        await Transact.Delete(transacts);
                        refreshme.IsRefreshing = true;
                        refreshme.IsRefreshing = false;
                    }

                    }
                    catch
                    {
                        await DisplayAlert("ERROR", "Check Internet Connection", "OK");
                    }
                }
        }
    }
}