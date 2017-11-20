using System;
using System.Linq;

namespace Utils
{
    public static class ListExtensions
    {
        public static T[][] Split<T>(this T[] source, int subsize)
        {
            if (source.Length % subsize == 0)
            {
                throw new ArgumentException("The array is not dividable by given subsize.");
            }

            var targetLength = source.Length / subsize;

            var targetArray = new T[targetLength][];

            for (var i = 0; i < subsize; i++)
            {
                targetArray[i] = source.Skip(i * subsize).Take(subsize).ToArray();
            }

            return targetArray;
        }
    }
}
