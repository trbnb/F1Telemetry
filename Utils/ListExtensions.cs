﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class ListExtensions
    {
        public static T[][] Split<T>(this T[] source, int subsize)
        {
            if (source.Length % subsize != 0)
            {
                throw new ArgumentException("The array is not dividable by given subsize.");
            }

            var targetLength = source.Length / subsize;

            var targetArray = new T[targetLength][];

            for (var i = 0; i < targetLength; i++)
            {
                targetArray[i] = source.Skip(i * subsize).Take(subsize).ToArray();
            }

            return targetArray;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in source)
            {
                action(item, index);
                index++;
            }
        }

        public static bool IsEmpty<T>(this ICollection<T> source) => source.Count == 0;
    }
}
