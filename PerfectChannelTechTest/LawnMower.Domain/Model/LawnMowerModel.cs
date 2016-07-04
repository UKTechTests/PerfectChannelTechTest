using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Domain.Model
{
    public class LawnMowerModel
    {
        public Directions Direction { get; set; }

        public GeoCoordinate Position { get; set; }
    }
}
