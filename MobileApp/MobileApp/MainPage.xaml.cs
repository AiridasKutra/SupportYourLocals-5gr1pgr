using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Pin mifPin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(54.729729, 25.263571),
                Label = "MIFAS",
                Address = "Didlaukio bbz kiek",
                Tag = "id_Mif"
            };

            map.Pins.Add(mifPin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(mifPin.Position, Distance.FromMeters(500)));
        }
    }
}
