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
            var modell = sender as RatingTBLL;
            try
            {
                if (Ratedk.SelectedStarValue == 1 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        star = Ratedk.SelectedStarValue,
                        CusComment = Comment.Text
                    };
                    await RatingTBL.Insert(transact);
                    int tota1 = transact.star.ToString().Count() * 1;
                    int tota2 = transact.stars.ToString().Count() * 2;
                    int tota3 = transact.starss.ToString().Count() * 3;
                    int tota4 = transact.starsss.ToString().Count() * 4;
                    int tota5 = transact.starssss.ToString().Count() * 5;
                    int tota6 = transact.star.ToString().Count() + transact.stars.ToString().Count() + transact.starss.ToString().Count() +
                        transact.starsss.ToString().Count() + transact.starssss.ToString().Count();
                    int tota7 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota8 = tota7 / tota6;
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                }
                else if (Ratedk.SelectedStarValue == 2 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        stars = Ratedk.SelectedStarValue,
                        CusComment = Comment.Text
                    };
                    await RatingTBL.Insert(transact);
                    int tota1 = transact.star.ToString().Count() * 1;
                    int tota2 = transact.stars.ToString().Count() * 2;
                    int tota3 = transact.starss.ToString().Count() * 3;
                    int tota4 = transact.starsss.ToString().Count() * 4;
                    int tota5 = transact.starssss.ToString().Count() * 5;
                    int tota6 = transact.star.ToString().Count() + transact.stars.ToString().Count() + transact.starss.ToString().Count() +
                        transact.starsss.ToString().Count() + transact.starssss.ToString().Count();
                    int tota7 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota8 = tota7 / tota6;
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                }
                else if (Ratedk.SelectedStarValue == 3 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        starss = Ratedk.SelectedStarValue,
                        CusComment = Comment.Text
                    };
                    await RatingTBL.Insert(transact);
                    int tota1 = transact.star.ToString().Count() * 1;
                    int tota2 = transact.stars.ToString().Count() * 2;
                    int tota3 = transact.starss.ToString().Count() * 3;
                    int tota4 = transact.starsss.ToString().Count() * 4;
                    int tota5 = transact.starssss.ToString().Count() * 5;
                    int tota6 = transact.star.ToString().Count() + transact.stars.ToString().Count() + transact.starss.ToString().Count() +
                        transact.starsss.ToString().Count() + transact.starssss.ToString().Count();
                    int tota7 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota8 = tota7 / tota6;
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                }
                else if (Ratedk.SelectedStarValue == 4 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        starsss = Ratedk.SelectedStarValue,
                        CusComment = Comment.Text
                    };
                    await RatingTBL.Insert(transact);
                    int tota1 = transact.star.ToString().Count() * 1;
                    int tota2 = transact.stars.ToString().Count() * 2;
                    int tota3 = transact.starss.ToString().Count() * 3;
                    int tota4 = transact.starsss.ToString().Count() * 4;
                    int tota5 = transact.starssss.ToString().Count() * 5;
                    int tota6 = transact.star.ToString().Count() + transact.stars.ToString().Count() + transact.starss.ToString().Count() +
                        transact.starsss.ToString().Count() + transact.starssss.ToString().Count();
                    int tota7 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota8 = tota7 / tota6;
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                }
                else if (Ratedk.SelectedStarValue == 5 && Comment.Text != "")
                {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        starssss = Ratedk.SelectedStarValue,
                        CusComment = Comment.Text
                    };
                    await RatingTBL.Insert(transact);
                    int tota1 = transact.star.ToString().Count() * 1;
                    int tota2 = transact.stars.ToString().Count() * 2;
                    int tota3 = transact.starss.ToString().Count() * 3;
                    int tota4 = transact.starsss.ToString().Count() * 4;
                    int tota5 = transact.starssss.ToString().Count() * 5;
                    int tota6 = transact.star.ToString().Count() + transact.stars.ToString().Count() + transact.starss.ToString().Count() +
                        transact.starsss.ToString().Count() + transact.starssss.ToString().Count();
                    int tota7 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota8 = tota7 / tota6;
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
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