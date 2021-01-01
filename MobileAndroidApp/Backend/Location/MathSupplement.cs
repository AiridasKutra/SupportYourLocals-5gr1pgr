using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhost.Backend.Location
{
    class MathSupplement
    {
        public static int EarthRadius { get; } = 6371;
        public static double DegreesToRadians(double degrees)
        { 
            return degrees * Math.PI / 180;
        }

        public static double Distance(MapPoint user, MapPoint destination)
        {
            return Distance(user.Latitude, user.Longitude, destination.Latitude, destination.Longitude);
        }
        public static double Distance(double userLatitude, double userLongitude, double destinationLatitude, double destinationLongitude)
        {
            try
            {
                double resultLatitude = DegreesToRadians(destinationLatitude - userLatitude);
                double resultLongitude = DegreesToRadians(destinationLongitude - userLongitude);

                userLatitude = DegreesToRadians(userLatitude);
                destinationLatitude = DegreesToRadians(destinationLatitude);

                double coordinateDestination = Math.Pow(Math.Sin(resultLatitude / 2), 2) +
                                            Math.Pow(Math.Sin(resultLongitude / 2), 2) * Math.Cos(userLatitude) * Math.Cos(destinationLatitude);
                double tangededDestination = 2 * Math.Atan2(Math.Sqrt(coordinateDestination), Math.Sqrt(1 - coordinateDestination));

                return EarthRadius * tangededDestination * 1000;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}
