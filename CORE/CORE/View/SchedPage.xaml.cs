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
                picstr = picstr,
                latt = latt,
                longg = longg,
                currentloc = currentloc,
                TotalRate = TotalRate,
                statusact = stat.Text,
                activetime = time.Text
            };
            if (stat.Text == null || time.Text == null)
            {
                await DisplayAlert("Error", "Please fill the blanks", "OK");
            }
            else
            {
                statusact = stat.Text;
                activetime = time.Text;
                await repairer.Update(repairer);
                await DisplayAlert("Success", "Schedule Submitted", "Ok");
                stat.Text = null;
                time.Text = null;
            }
        }
    }
}