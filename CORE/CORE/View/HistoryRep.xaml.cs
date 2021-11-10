using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CORE.App;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryRep : ContentPage
    {
        public HistoryRep()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await GetRepairer();
            
        }
        private async Task GetRepairer()
        {
            var repairers = await TransactHistory.Read();
            ShowPeople.ItemsSource = repairers.Where(x => x.Repid == repairer_id).ToList();
        }

        private async void refreshme_Refreshing(object sender, EventArgs e)
        {
            await GetRepairer();
            refreshme.IsRefreshing = false;
        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            if (item?.BindingContext is TransactHistory model)
            {
                try
                {
                    TransactHistory transact = new TransactHistory
                    {
                        id = model.id
                    };
                    await TransactHistory.Delete(transact);
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
    }
}