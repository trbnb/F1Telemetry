using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{
    public class LatLng
    {
        public LatLng(float lat, float lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public float Lat { get; }
        public float Lng { get; }
    }
}
