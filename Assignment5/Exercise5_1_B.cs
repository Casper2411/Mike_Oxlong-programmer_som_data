using System;
using System.Collections.Generic;

namespace exercise5_1_B
{
    public class Assignment
    {
        public static int[] Merge(int[] xs, int[] ys)
        {
            List<int> result = new List<int>();
            int indexXs = 0;
            int indexYs = 0;
            while (indexXs<xs.Length || indexYs<ys.Length)
            {
                if (indexXs == xs.Length)
                {
                    result.Add(ys[indexYs]);
                    indexYs++;
                } else if (indexYs == ys.Length)
                {
                    result.Add(xs[indexXs]);
                    indexXs++;
                }
                else if (xs[indexXs] <= ys[indexYs])
                {
                    result.Add(xs[indexXs]);
                    indexXs++;
                } else if (xs[indexXs] > ys[indexYs])
                {
                    result.Add(ys[indexYs]);
                    indexYs++;
                }
            }
            return result.ToArray();
        }
    }
}


