using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZag
{
    public class ZigZag
    {
        public int longestZigZag(int[] sequence)
        {
            bool[] positive = new bool[sequence.Length];
            int[] longest = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                if (i == 0)
                {
                    longest[i] = 1;
                }

                if (i == 1)
                {
                    longest[i] = 2;
                    positive[i] = (sequence[i] - sequence[i - 1] > 0);
                }

                if (i > 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (j == 0)
                        {
                            positive[i] = (sequence[i] - sequence[j] > 0);
                            longest[i] = 2;
                        }
                        else if (((positive[j] && sequence[i] - sequence[j] < 0) || (!positive[j] && sequence[i] - sequence[j] > 0)) && (longest[j] + 1 > longest[i]))
                        {
                            positive[i] = (sequence[i] - sequence[j] > 0);
                            longest[i] = longest[j] + 1;
                        }
                    }
                }
            }

            int result = longest[0];
            for (int i = 0; i < longest.Length; i++)
            {
                if (longest[i] > result) result = longest[i];
            }
            return result;
        }
    }
}
