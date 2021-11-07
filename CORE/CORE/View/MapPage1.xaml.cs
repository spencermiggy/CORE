using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;
using static CORE.App;
using CORE.Models;
using System.Linq;

namespace CORE.View
{
    public partial class MapPage1 : ContentPage
    {
        IGeolocator locator = CrossGeolocator.Current;
        public MapPage1()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            locator.StopListeningAsync();
        }

        private async void GetLocation()
        {
            var status = await CheckAndRequestLocationPermission();

            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLocationAsync();

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(new TimeSpan(0, 1, 0), 100);

                locationsMap.IsShowingUser = true;
                CenterMap(location.Latitude, location.Longitude);

            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            CenterMap(e.Position.Latitude, e.Position.Longitude);
        }

        private void CenterMap(double latitude, double longitude)
        {
            Position center = new Position(latitude, longitude);
            MapSpan span = new MapSpan(center, 1, 1);

            locationsMap.MoveToRegion(span);
        }

        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // promt the user to turn on the permission in settings
                return status;
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }

        private async void GetLoc_Clicked(object sender, EventArgs e)
        {
                repairer repairer = new repairer
                {
                    id = repairer_id,
                    fname = fname,
                    lname = lname,
                    job = job,
                    statusact = statusact,
                    activetime = activetime,
                    pnum = pnum,
                    addr = addr,
                    city = city,
                    pass = pass,
                    propics = propics,
                    picstr = picstr,
                    latt = Lat.Text,
                    longg = Long.Text,
                    currentloc = lugar.Text
                };
            latt = Lat.Text;
            longg = Long.Text;
            currentloc = lugar.Text;
                await repairer.Update(repairer);
                await DisplayAlert("Message", "SUCCESS", "Ok");
        }

        private void SetLoc_Clicked(object sender, EventArgs e)
        {
            GetLocation1();
        }
        public async void GetLocation1()
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                }); ;
            }
            Lat.Text = location.Latitude.ToString();
            Long.Text = location.Longitude.ToString();
            var placemark = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            var place = placemark?.FirstOrDefault();
            var geocodeaddress = $"{place.Locality}, {place.SubThoroughfare}, {place.FeatureName}, {place.CountryName}";
            lugar.Text = geocodeaddress;
        }
    }
}
