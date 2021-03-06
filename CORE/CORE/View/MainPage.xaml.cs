using CORE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CORE.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void addAcc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CusorRep());
        }

        private async void CusLog_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool isphonenumberempty = string.IsNullOrEmpty(Pnumb.Text);
                bool ispasswordempty = string.IsNullOrEmpty(Passw.Text);
                if (isphonenumberempty || ispasswordempty)
                {
                    await DisplayAlert("Error", "Please enter your user name and password", "OK");
                }
                else
                {
                    var users = (await App.MobileService.GetTable<customer>().Where(x => x.pnum == Pnumb.Text).ToListAsync()).FirstOrDefault();
                    if (users != null)
                    {
                        if (users.pass == Passw.Text)
                        {
                            App.customer_id = users.id;
                            App.fname = users.fname;
                            App.lname = users.lname;
                            App.addr = users.addr;
                            App.city = users.city;
                            App.pass = users.pass;
                            App.pnum = users.pnum;
                            App.propics = users.propics;
                            App.picstr = users.picstr;
                            App.latt = users.latt;
                            App.longg = users.longg;
                            App.Current.MainPage = new MenuPage();
                        }
                        else
                        {
                            await DisplayAlert("Error", "Password Not Found", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Number Not Found", "OK");
                    }
                }
            }
            catch
            {
                await DisplayAlert("Error","No Internet Connection","OK");
            }
        }

        private async void RepLog_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool isphonenumberempty = string.IsNullOrEmpty(Pnumb.Text);
                bool ispasswordempty = string.IsNullOrEmpty(Passw.Text);
                if (isphonenumberempty || ispasswordempty)
                {
                    await DisplayAlert("Error", "Please enter your user name and password", "OK");
                }
                else
                {
                    var users = (await App.MobileService.GetTable<repairer>().Where(x => x.pnum == Pnumb.Text).ToListAsync()).FirstOrDefault();
                    if (users != null)
                    {
                        if (users.pass == Passw.Text)
                        {
                            App.repairer_id = users.id;
                            App.fname = users.fname;
                            App.lname = users.lname;
                            App.job = users.job;
                            App.pnum = users.pnum;
                            App.addr = users.addr;
                            App.city = users.city;
                            App.pass = users.pass;
                            App.propics = users.propics;
                            App.picstr = users.picstr;
                            App.activetime = users.activetime;
                            App.statusact = users.statusact;
                            App.latt = users.latt;
                            App.longg = users.longg;
                            App.currentloc = users.currentloc;
                            App.TotalRate = users.TotalRate;
                            App.star = users.star;
                            App.stars = users.stars;
                            App.starss = users.starss;
                            App.starsss = users.starsss;
                            App.starssss = users.starssss;
                            App.Current.MainPage = new MenuRep();
                        }
                        else
                        {
                            await DisplayAlert("Error", "Password Not Found", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Number Not Found", "OK");
                    }
                }
            }
            catch
            {
                await DisplayAlert("Error","No Internet Connection","OK");
            }
        }

        private void ShowPass_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(ShowPass.IsChecked == true)
            {
                Passw.IsPassword = false;
            }
            else
            {
                Passw.IsPassword = true;
            }
        }
    }
}
