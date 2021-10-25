using CORE.View;
using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CORE
{
    public partial class App : Application
    {
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://core5.azurewebsites.net");
        public static string customer_id;
        public static string repairer_id;
        public static string firstnamed, lastnamed, addressed, jobbed, cityed, mobilenum, password, propics, picstr, fname, lname, job, city, pnum, pass, addr, activetime, statusact;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
