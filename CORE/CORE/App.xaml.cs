using CORE.View;
using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("GREENSEA.otf", Alias = "let")]
[assembly: ExportFont("GREENSEA-Awesome.otf", Alias = "lett")]
[assembly: ExportFont("Oswald-Bold.ttf", Alias = "lettt")]
[assembly: ExportFont("Oswald-SemiBold.ttf", Alias = "letttt")]
[assembly: ExportFont("Lobster-Regular.ttf", Alias = "let1")]
namespace CORE
{
    public partial class App : Application
    {
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://core55.azurewebsites.net");
        public static string customer_id;
        public static string repairer_id;
        public static string latt, longg;
        public static string firstnamed, lastnamed, addressed, jobbed, cityed, mobilenum, password,
            propics, picstr, fname, lname, job, city, pnum, pass, addr, activetime, statusact;
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
