using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;
using static CORE.App;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CusHistory : ContentPage
    {
        public CusHistory()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await GetRepairer();

        }
        private async Task GetRepairer()
        {
            var repairers = await TransactCus.Read();
            ShowPeople.ItemsSource = repairers.Where(x => x.Cusid == customer_id).ToList();
        }

        private async void refreshme_Refreshing(object sender, EventArgs e)
        {
            await GetRepairer();
            refreshme.IsRefreshing = false;
        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if (item?.BindingContext is TransactCus model)
            {
                try
                {
                    TransactCus transact = new TransactCus
                    {
                        id = model.id
                    };
                    await TransactCus.Delete(transact);
                    await DisplayAlert("Success", "Success Deleted", "Ok");
                    refreshme.IsRefreshing = true;
                    refreshme.IsRefreshing = false;
                }
                catch
                {
                    await DisplayAlert("ERROR", "Check Internet Connection", "OK");
                }
            }
        }

        private void SwipeItem_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}