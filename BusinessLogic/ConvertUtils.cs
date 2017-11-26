using System;
using System.Collections.Generic;
using System.Text;
using F1Telemetry.Models;
using Utils;

namespace BusinessLogic
{
    public static class ConvertUtils
    {
        public static XYZ ToXYZ(this float[] raw)
        {
            if (raw.Length < 3)
            {
                throw new ArgumentException("Array is not long enough to convert to XYZ.");
            }

            return new XYZ(raw[0], raw[1], raw[2]);
        }

        public static TimeSpan ToTimeSpan(this float timeInSeconds)
        {
            return TimeSpan.FromSeconds(timeInSeconds);
        }

        public static TimeSpan? ToNullableTimeSpan(this float timeInSeconds)
        {
            return timeInSeconds == 0 ? (TimeSpan?)null : timeInSeconds.ToTimeSpan();
        }

        public static WheelInfo<T> ParseWheelInfo<T>(this T[] raw)
        {
            return new WheelInfo<T>(raw[0], raw[1], raw[2], raw[3]);
        }

        public static void RemoveOldestItems<T>(this IList<T> source, float timestamp, Func<T, double> getTimestamp)
        {
            while (!source.IsEmpty() && getTimestamp(source[source.Count - 1]) >= timestamp)
            {
                source.RemoveAt(source.Count - 1);
            }
        }
    }
}
