using Common;
using GoogleMaps.LocationServices;
using localhostUI.Classes.LocationClasses;
using System;

namespace localhostUI.Classes.UserInformationClasses
{   
    class UserData
    {
        //-----------Properties-----------------------------------
        public string Address { get;  set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Username { get; set; }
        public string SavedEmail { get; set; }
        public string SavedPassword { get; set; }
        //--------------------------------------------------------
        private void Init()
        {
            Address = "";
            Latitude = 0;
            Longitude = 0;
            Username = "Anon";
            SavedEmail = "";
            SavedPassword = "";
        }
        public UserData()
        {
            Init();
        }
        public UserData(string address, string userName)
        {
            Init();
            this.Address = LocationInformation.FormatAddress(address);
            this.Username = userName;

            MapPoint location = LocationInformation.LatLongFromAddress(address);
            this.Latitude = location.Latitude;
            this.Longitude = location.Longitude;
        }
        public UserData(string address, double latitude, double longitude, string username)
        {
            Init();
            this.Address = LocationInformation.FormatAddress(address);
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Username = username;
        }
        public UserData(string userName)
        {
            Init();
            this.Username = userName;
        }
        public UserData(DataList dataList)
        {
            Init();
            try
            {
                if (dataList == null) throw new ArgumentNullException();

                object username = dataList.Get("username");
                object address = dataList.Get("address");
                object latitude = dataList.Get("latitude");
                object longitude = dataList.Get("longitude");
                object email = dataList.Get("email");
                object password = dataList.Get("password");

                if (username != null && address != null)
                {
                    this.Username = (string)username;
                    this.Address = LocationInformation.FormatAddress((string)address);
                    if (latitude == null || longitude == null)
                    {
                        MapPoint location = LocationInformation.LatLongFromAddress(this.Address);
                        this.Latitude = location.Latitude;
                        this.Longitude = location.Longitude;
                    }
                    else
                    {
                        this.Longitude = (double)longitude;
                        this.Latitude = (double)latitude;
                    }
                }
                if (email != null && password != null)
                {
                    this.SavedEmail = (string)email;
                    this.SavedPassword = (string)password;
                }
            }
            catch(Exception e)
            {
                this.Username = null;
                this.Address = null;
                this.Latitude = 0;
                this.Longitude = 0;
            }
        }
        public bool ChangeAddress(string address)
        {
            if (!LocationInformation.IsValidAddress(address)) return false;
            MapPoint location = LocationInformation.LatLongFromAddress(address);
            this.Address = LocationInformation.FormatAddress(address);
            this.Longitude = location.Longitude;
            this.Latitude = location.Latitude;
            return true;
        }
        public static DataList ToDataList(UserData userData)
        {
            DataList data = new DataList();
            data.Add(userData.Username, "username");
            data.Add(userData.Address, "address");
            data.Add(userData.Latitude, "latitude");
            data.Add(userData.Longitude, "longitude");
            data.Add(userData.SavedEmail, "email");
            data.Add(userData.SavedPassword, "password");
            return data;
        }
        public MapPoint ToMapPoint()
        {
            return LocationInformation.LatLongFromAddress(this.Address);
        }
        public override string ToString()
        {
            return $"Username: {Username}; Address: {Address}";
        }
    }
}
