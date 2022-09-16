using CORE.Models;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CORE.App;

namespace CORE.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profpage : ContentPage
	{
		public Profpage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                if (Clipboard.HasText)
                {
                    var text = await Clipboard.GetTextAsync();
                    RepID.Text = text;
                }
                var profile = (await MobileService.GetTable<repairer>().Where(x => x.id == RepID.Text).ToListAsync()).FirstOrDefault();
                profgrid1.BindingContext = profile;
            }
            catch
            {

                await DisplayAlert("Network Error", "A network error occured, please check your internet connectivity and try again.", "OK");
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(RepID.Text);
            await Navigation.PushModalAsync(new FeedPage());
        }
    }
}