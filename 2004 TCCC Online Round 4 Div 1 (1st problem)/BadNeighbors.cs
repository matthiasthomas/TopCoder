using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadNeighbors
{
    class BadNeighbors
    {
        public int maxDonations(int[] donations)
        {
            // Find max1 between i=0 and i=length-2
            // Find max2 between i=1 and i=length-1
            // Return max of max1 max2
            return Math.Max(getMax(donations, 0, donations.Length - 2), getMax(donations, 1, donations.Length - 1));
        }

        public int getMax(int[] donations, int from, int to)
        {
            int max = 0;
            int[] maxForI = new int[donations.Length];
            for (int i = from; i <= to; i++)
            {
                maxForI[i] = donations[i];
                for (int j = 0; j < i - 1; j++)
                {
                    maxForI[i] = Math.Max(maxForI[i], maxForI[j] + donations[i]);
                }
                max = Math.Max(max, maxForI[i]);
            }
            return max;
        }
    }
}