using CORE.View;
using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("GREENSEA.otf", Alias = "let")]
[assembly: ExportFont("GREENSEA-Awesome.otf", Alias = "lett")]
[assembly: ExportFont("Font-Awesome-6-Brands-Regular-400.otf", Alias = "lettt")]
[assembly: ExportFont("BUNCH-BONARIE.ttf", Alias = "letttt")]
[assembly: ExportFont("RompiesRegular-WyKYG.otf", Alias = "lettttt")]
namespace CORE
{
    public partial class App : Application
    {
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("https://core55.azurewebsites.net");
        public static string customer_id;
        public static string repairer_id;
        public static int TotalRate;
        public static string latt, longg, currentloc;
        public static string Transact_id, Cusid, Repid, Caddr, Cfname, Clname, Cnum, Clatt, Clongg, Accdec;
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
