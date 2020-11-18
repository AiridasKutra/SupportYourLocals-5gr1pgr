using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Classes.LocationClasses
{
    class MathSupplement
    {
        public static int EarthRadius { get; } = 6371;
        public static double DegreesToRadians(double degrees)
        { 
            return degrees * Math.PI / 180;
        }
    }
}
