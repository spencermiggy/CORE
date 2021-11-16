using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CORE.App;
using CORE.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPage : ContentPage
    {
        public RatingPage()
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
        }

        private async void SubBtn_Clicked(object sender, EventArgs e)
        {
            var modell = sender as RatingTBL;
            try
            {
                if (Ratedk.SelectedStarValue == 1 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        star = Ratedk.SelectedStarValue
                    };
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBLL = new RatingTBLL
                    {
                        Repid = RepID.Text,
                        CusComment = Comment.Text,
                        TotalRate = Ratedk.SelectedStarValue
                    };
                    await RatingTBLL.Insert(ratingTBLL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    App.Current.MainPage = new MenuPage();
                }
                else if (Ratedk.SelectedStarValue == 2 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        stars = Ratedk.SelectedStarValue
                    };
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBLL = new RatingTBLL
                    {
                        Repid = RepID.Text,
                        CusComment = Comment.Text,
                        TotalRate = Ratedk.SelectedStarValue
                    };
                    await RatingTBLL.Insert(ratingTBLL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    App.Current.MainPage = new MenuPage();
                }
                else if (Ratedk.SelectedStarValue == 3 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        starss = Ratedk.SelectedStarValue
                    };
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBLL = new RatingTBLL
                    {
                        Repid = RepID.Text,
                        CusComment = Comment.Text,
                        TotalRate = Ratedk.SelectedStarValue
                    };
                    await RatingTBLL.Insert(ratingTBLL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    App.Current.MainPage = new MenuPage();
                }
                else if (Ratedk.SelectedStarValue == 4 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        starsss = Ratedk.SelectedStarValue
                    };
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBLL = new RatingTBLL
                    {
                        Repid = RepID.Text,
                        CusComment = Comment.Text,
                        TotalRate = Ratedk.SelectedStarValue
                    };
                    await RatingTBLL.Insert(ratingTBLL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    App.Current.MainPage = new MenuPage();
                }
                else if (Ratedk.SelectedStarValue == 5 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        starssss = Ratedk.SelectedStarValue
                    };
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBLL = new RatingTBLL
                    {
                        Repid = RepID.Text,
                        CusComment = Comment.Text,
                        TotalRate = Ratedk.SelectedStarValue
                    };
                    await RatingTBLL.Insert(ratingTBLL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    App.Current.MainPage = new MenuPage();
                }

                else if (Ratedk.SelectedStarValue == 0)
                {
                    await DisplayAlert("Message", "You didn't select a star", "OK");
                }
            }
            catch
            {
                await DisplayAlert("Error","Check your internet connection","OK");
            }
        }
    }
}