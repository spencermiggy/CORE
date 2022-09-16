using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CORE.App;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedPage : ContentPage
    {
        public FeedPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Clipboard.HasText)
            {
                var text = await Clipboard.GetTextAsync();
                RepID.Text = text;
            }
            var repairers = await RatingTBLL.Read();
            ShowPeople.ItemsSource = repairers.Where(x => x.Repid == RepID.Text).ToList();
        }
    }
}