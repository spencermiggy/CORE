using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CORE.App;
using CORE.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            await RatingTBL.Read();
            await repairer.Read();
        }

        private async void SubBtn_Clicked(object sender, EventArgs e)
        {
              try
                {
                    if (Ratedk.SelectedStarValue == 1)
                    {
                    RatingTBL transact = new RatingTBL
                    {
                        Repid = RepID.Text,
                        star = Ratedk.SelectedStarValue,
                        CusCount = 1
                        };
                    int tota1 = transact.CusCount * transact.star;
                    int tota2 = transact.CusCount * transact.stars;
                    int tota3 = transact.CusCount * transact.starss;
                    int tota4 = transact.CusCount * transact.starsss;
                    int tota5 = transact.CusCount * transact.starssss;
                    int tota6 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota7 = transact.CusCount;
                    int tota8 = tota6 / tota7;
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBL = new RatingTBLL
                    {
                        Repid = transact.Repid,
                        TotRate = tota8
                    };
                    await RatingTBLL.Insert(ratingTBL);
                        await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 2)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            stars = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                    int tota1 = transact.CusCount * transact.star;
                    int tota2 = transact.CusCount * transact.stars;
                    int tota3 = transact.CusCount * transact.starss;
                    int tota4 = transact.CusCount * transact.starsss;
                    int tota5 = transact.CusCount * transact.starssss;
                    int tota6 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota7 = transact.CusCount;
                    int tota8 = tota6 / tota7;
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBL = new RatingTBLL
                    {
                        Repid = transact.Repid,
                        TotRate = tota8
                    };
                    await RatingTBLL.Insert(ratingTBL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 3)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            starss = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                    int tota1 = transact.CusCount * transact.star;
                    int tota2 = transact.CusCount * transact.stars;
                    int tota3 = transact.CusCount * transact.starss;
                    int tota4 = transact.CusCount * transact.starsss;
                    int tota5 = transact.CusCount * transact.starssss;
                    int tota6 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota7 = transact.CusCount;
                    int tota8 = tota6 / tota7;
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBL = new RatingTBLL
                    {
                        Repid = transact.Repid,
                        TotRate = tota8
                    };
                    await RatingTBLL.Insert(ratingTBL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 4)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            starsss = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                    int tota1 = transact.CusCount * transact.star;
                    int tota2 = transact.CusCount * transact.stars;
                    int tota3 = transact.CusCount * transact.starss;
                    int tota4 = transact.CusCount * transact.starsss;
                    int tota5 = transact.CusCount * transact.starssss;
                    int tota6 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota7 = transact.CusCount;
                    int tota8 = tota6 / tota7;
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBL = new RatingTBLL
                    {
                        Repid = transact.Repid,
                        TotRate = tota8
                    };
                    await RatingTBLL.Insert(ratingTBL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 5)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            starssss = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                    int tota1 = transact.CusCount * transact.star;
                    int tota2 = transact.CusCount * transact.stars;
                    int tota3 = transact.CusCount * transact.starss;
                    int tota4 = transact.CusCount * transact.starsss;
                    int tota5 = transact.CusCount * transact.starssss;
                    int tota6 = tota1 + tota2 + tota3 + tota4 + tota5;
                    int tota7 = transact.CusCount;
                    int tota8 = tota6 / tota7;
                    await RatingTBL.Insert(transact);
                    RatingTBLL ratingTBL = new RatingTBLL
                    {
                        Repid = transact.Repid,
                        TotRate = tota8
                    };
                    await RatingTBLL.Insert(ratingTBL);
                    await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 0)
                    {
                        await DisplayAlert("Message", "You didn't select a star", "OK");
                    }
                }
                catch
                {
                    await DisplayAlert("ERROR", "Check Internet Connection", "OK");
                }
        }
    }
}