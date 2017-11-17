using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Telemetry.Models
{
    public class WheelInfo<T>
    {
        public WheelInfo(T leftRear, T rightRear, T leftFront, T rightFront)
        {
            LeftRear = leftRear;
            RightRear = rightRear;
            LeftFront = leftFront;
            RightFront = rightFront;
        }

        public T LeftRear { get; }
        public T RightRear { get; }
        public T LeftFront { get; }
        public T RightFront { get; }
    }
}
