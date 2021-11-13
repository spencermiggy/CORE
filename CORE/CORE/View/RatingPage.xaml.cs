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
            var item = sender as SwipeItem;
            if (item?.BindingContext is repairer model)
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
                        await RatingTBL.Insert(transact);
                        await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 2)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            star = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                        await RatingTBL.Insert(transact);
                        await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 3)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            star = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                        await RatingTBL.Insert(transact);
                        await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 4)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            star = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                        await RatingTBL.Insert(transact);
                        await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }
                    else if (Ratedk.SelectedStarValue == 5)
                    {
                        RatingTBL transact = new RatingTBL
                        {
                            Repid = RepID.Text,
                            star = Ratedk.SelectedStarValue,
                            CusCount = 1
                        };
                        await RatingTBL.Insert(transact);
                        await DisplayAlert("Success", "THANK YOU FOR GIVING YOUR FEEDBACK", "OK");
                    }

                    else if (Ratedk.SelectedStarValue == 0)
                    {
                        await DisplayAlert("Message", "You didn't select a star", "OK");
                    }
                }
                catch
                {
                    //await DisplayAlert("ERROR", "Check Internet Connection", "OK");
                }
            }
        }
    }
}