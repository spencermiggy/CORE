using Plugin.Messaging;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactAdmin : ContentPage
    {
        public ContactAdmin()
        {
            InitializeComponent();
        }

        private void but_Clicked(object sender, EventArgs e)
        {
            var phone = CrossMessaging.Current.SmsMessenger;
            if (phone.CanSendSms)
            {
                phone.SendSms("09959844622", "");
            }
        }

        private void fbbtn_Clicked(object sender, EventArgs e)
        {
            CrossShare.Current.OpenBrowser("https://web.facebook.com/misgkie/");
        }

        private void gbtn_Clicked(object sender, EventArgs e)
        {
            CrossShare.Current.OpenBrowser("https://www.instagram.com/spencermigs/");
        }
    }
}