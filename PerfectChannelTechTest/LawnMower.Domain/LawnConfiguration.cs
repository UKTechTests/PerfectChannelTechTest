using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Domain
{
    public class LawnConfiguration
    {
        public double LawnArea { get; set; }

        public void CalculateLawnArea(GeoCoordinate topRightCoords)
        {
            var botomLeftCoords = new GeoCoordinate(0, 0);
            var topLeftCoords = new GeoCoordinate(topRightCoords.Latitude, 0);
            var bottomrightCoords = new GeoCoordinate(0, topRightCoords.Longitude);
            
            var width = botomLeftCoords.GetDistanceTo(bottomrightCoords);
            var height = topRightCoords.GetDistanceTo(bottomrightCoords);

            LawnArea = width * height;
        }
    }
}
