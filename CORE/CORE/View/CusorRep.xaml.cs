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
    public partial class CusorRep : ContentPage
    {
        public CusorRep()
        {
            InitializeComponent();
        }

        private async void cur_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new newCus());
        }

        private async void rep_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ContactAdmin());
        }
    }
}