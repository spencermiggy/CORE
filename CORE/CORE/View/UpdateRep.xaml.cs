using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CORE.App;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Azure.Storage.Blobs;
using Xamarin.Essentials;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateRep : ContentPage
    {
        private string imgID;
        private string urlImage;
        public UpdateRep()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                var getprofile = (await MobileService.GetTable<repairer>().Where(profile => profile.id == repairer_id).ToListAsync()).FirstOrDefault();
                profgrid2.BindingContext = getprofile;
            }
            catch
            {
                await DisplayAlert("Error", "Please Check Your Internet Connection", "OK");
            }

        }

        private async void SaveBtn(object sender, EventArgs e)
        {
            repairer repairer = new repairer
            {
                id = repairer_id,
                fname = firstname.Text,
                lname = lastname.Text,
                job = Job.Text,
                pnum = Pnumb.Text,
                addr = Addre.Text,
                city = Citys.Text,
                pass = Passw.Text,
                activetime = activetime,
                latt = latt,
                longg = longg,
                statusact = statusact,
                currentloc = currentloc,
                propics = $"{urlImage}",
                picstr = $"{imgID}.jpg"
            };
            if (firstname.Text == null || lastname.Text == null || Job.Text == null || Pnumb.Text == null || Addre.Text == null || Citys.Text == null || Passw.Text == null || SelectedImage.Source is null)
            {
                await DisplayAlert("Error", "Please fill the blanks or Change the Profile Picture", "OK");
            }
            else
            {
                city = Citys.Text;
                await repairer.Update(repairer);
                await DisplayAlert("Success", "Info Updated", "Ok");
                App.Current.MainPage = new MenuRep();
            }
        }

        private async void SelectButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not supported on your device", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImageFile == null)
            {
                await DisplayAlert("Error", "There was an error when trying to get your image, please try again", "Ok");
                return;
            }

            SelectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());

            UploadImage(selectedImageFile.GetStream());
            await DisplayAlert("Success", "Image Successfully Selected", "OK");
        }
        private async void UploadImage(Stream stream)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=picturestorages;AccountKey=xJI7ywyt+8/Et5JJ5g190+brznK6/yvPigs/X8FMInd/LsAiQv4CXThETiT9VzsKG0RvMH58ocXCQ/0+tqKEdw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("imagefile");
            await container.CreateIfNotExistsAsync();

            imgID = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{imgID}.jpg");
            await blockBlob.UploadFromStreamAsync(stream);

            urlImage = blockBlob.Uri.OriginalString;
        }
    }
}