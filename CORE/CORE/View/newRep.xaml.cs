using CORE.Models;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CORE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class newRep : ContentPage
    {
        private string imgID;
        private string urlImage;
        public newRep()
        {
            InitializeComponent();
        }

        async void sve_Clicked(object sender, EventArgs e)
        {
             repairer repairer = new repairer
            {
                fname = firstname.Text,
                lname = lastname.Text,
                job = Job.Text,
                pnum = Pnumb.Text,
                addr = Addre.Text,
                city = Citys.Text,
                pass = Passw.Text,
                propics = $"{urlImage}/{imgID}.jpg",
                picstr = $"{imgID}.jpg"
             };
            if (firstname.Text == null || lastname.Text == null || Job.Text == null || Pnumb.Text == null || Addre.Text == null || Citys.Text == null || Passw.Text == null)
            {
                await DisplayAlert("Error", "Please fill the blanks", "OK");
            }
            else
            {
                await repairer.Insert(repairer);
                await DisplayAlert("Success", "You are now registered", "Ok");
                App.Current.MainPage = new MainPage();
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
        }
        private async void UploadImage(Stream stream)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=imagestoragecore;AccountKey=TNDP7cpEyUTkc/+sfM7utsBmuyk7Ek8s2bfdh3wJ8LZxLXA2cwo0YT1+oWO9jxocrUNpBJqAG1iSwKXDrdrpig==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("imagestoragecore");
            await container.CreateIfNotExistsAsync();

            imgID = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{imgID}.jpg");
            await blockBlob.UploadFromStreamAsync(stream);

            urlImage = blockBlob.Uri.OriginalString;
        }
    }
}