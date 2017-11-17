using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{
    public class GForce : LatLng
    {
        public GForce(float lat, float lng, float vertical)
            : base(lat, lng)
        {
            Vertical = vertical;
        }

        public float Vertical { get; set; }
    }
}
