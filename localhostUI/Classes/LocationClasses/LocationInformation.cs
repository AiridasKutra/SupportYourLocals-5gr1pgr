using GoogleMaps.LocationServices;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace localhostUI.Classes.LocationClasses
{
    static class LocationInformation
    {
        private static readonly string apiKey = ApiKeys.GoogleApiKey;
        private static GoogleLocationService locationService = new GoogleLocationService(apiKey);
        public static MapPoint LatLongFromString(this string address, string country = "Lithuana")
        {
            AddressData addressObject = new AddressData
            {
                Address = address,
                State = null,
                Country = country
            };

            return locationService.GetLatLongFromAddress(addressObject);
        }
        public static MapPoint LatLongFromAddress(string address, string country = "Lithuania")
        {
            AddressData addressObject = new AddressData
            {
                Address = address,
                State = null,
                Country = country
            };

            return locationService.GetLatLongFromAddress(addressObject);
        }
        public static AddressData AddressFromLatLong(double latitude, double longitude)
        {
            return locationService.GetAddressFromLatLang(latitude, longitude);
        }
        public static string CityFromCoordinates(double latitude, double longitude)
        {
            AddressData addressData = locationService.GetAddressFromLatLang(latitude, longitude);
            var city = addressData.City;
            return city;
        }
        public static AddressData AddressFromLatLong(MapPoint latLong)
        {
            return locationService.GetAddressFromLatLang(latLong.Latitude, latLong.Longitude);
        }
        public static AddressData AddressFromMapPoint(this MapPoint latLong)
        {
<<<<<<< Updated upstream
=======
            var locationService = new GoogleLocationService(apiKey);
   
>>>>>>> Stashed changes
            return locationService.GetAddressFromLatLang(latLong.Latitude, latLong.Longitude);
        }
        public static string FormatAddress(string address)
        {
            var addressData = locationService.GetAddressesListFromAddress(address);
            return addressData[0];
        }
        public static string FormatAddressString(this string address)
        {
            var addressData = locationService.GetAddressesListFromAddress(address);
            return addressData[0];
        }
        public static void OpenAdressInBrowser(string address)
        {
            //Deleted the "," from the array, so if error pile up, add it back in.
            char[] invalidCharacters = "!*'();:@&=+$/?%#[]".ToCharArray();
            string url = "https://www.google.lt/maps/search/";
            string temp = address.Replace(' ', '+');
            temp.Replace(",", "%2C");
            url += temp;
            //Testing output

            if (address.Length == 0)
            {
                return;
            }
            else if (address.Any(c => invalidCharacters.Contains(c)))
            {
                throw new FormatException("Illegal characters");
            }

            //Constructing the link.


            //Searches up the location on your browser on google maps.
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {

                    throw;
                }
            }
        }
<<<<<<< Updated upstream
=======

        //Returned values are in meters
        public static double Distance(MapPoint user, MapPoint destination)
        {
            return Distance(user.Latitude, user.Longitude, destination.Latitude, destination.Longitude);
        }
        public static double Distance(double userLatitude, double userLongitude, double destinationLatitude, double destinationLongitude)
        {
            try
            {
                double resultLatitude = MathSupplement.DegreesToRadians(destinationLatitude - userLatitude);
                double resultLongitude = MathSupplement.DegreesToRadians(destinationLongitude - userLongitude);

                userLatitude = MathSupplement.DegreesToRadians(userLatitude);
                destinationLatitude = MathSupplement.DegreesToRadians(destinationLatitude);

                double coordinateDestination = Math.Pow(Math.Sin(resultLatitude / 2), 2) +
                                            Math.Pow(Math.Sin(resultLongitude / 2), 2) * Math.Cos(userLatitude) * Math.Cos(destinationLatitude);
                double tangededDestination = 2 * Math.Atan2(Math.Sqrt(coordinateDestination), Math.Sqrt(1 - coordinateDestination));

                return MathSupplement.EarthRadius * tangededDestination * 1000;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        
        
>>>>>>> Stashed changes
        public static bool IsValidAddress(string address)
        {
            try
            {
                MapPoint location = LatLongFromAddress(address);
                if (location == null) return false;
                location.ToString();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
