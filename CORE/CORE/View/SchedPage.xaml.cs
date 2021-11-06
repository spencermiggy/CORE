using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CORE.Models;
using static CORE.App;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedPage : ContentPage
    {
        public SchedPage()
        {
            InitializeComponent();
            BindingContext = new PickerMVVMViewModel();
        }
        protected override async void OnAppearing()
        {
            try
            {
                var getprofile = (await MobileService.GetTable<repairer>().Where(profile => profile.id == repairer_id).ToListAsync()).FirstOrDefault();
                schedy.BindingContext = getprofile;
            }
            catch
            {
                await DisplayAlert("Error", "Please Check Your Internet Connection", "OK");
            }

        }
        private async void Btnupd(object sender, EventArgs e)
        {
            repairer repairer = new repairer
            {
                id = repairer_id,
                fname = fname,
                lname = lname,
                job = job,
                pnum = pnum,
                addr = addr,
                city = city,
                pass = pass,
                propics = propics,
                latt = latt,
                longg = longg,
                statusact = stat.Text,
                activetime = time.Text
            };
            if (stat.Text == null || time.Text == null)
            {
                await DisplayAlert("Error", "Please fill the blanks", "OK");
            }
            else
            {
                await repairer.Update(repairer);
                await DisplayAlert("Success", "Schedule Submitted", "Ok");
                stat.Text = null;
                time.Text = null;
            }
        }
    }
}