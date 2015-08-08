using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class AvoidRoads
    {
        public long numWays(int width, int height, String[] bad)
        {
            long[,] numberOfWaysForThisIntersection = new long[width + 1, height + 1];
            for (int i = 0; i <= width; i++)
            {
                for (int j = 0; j <= height; j++)
                {
                    numberOfWaysForThisIntersection[i, j] = 0;
                }
            }
            numberOfWaysForThisIntersection[0, 0] = 1;
            for (int i = 0; i <= width; i++)
            {
                for (int j = 0; j <= height; j++)
                {
                    // Add all the neighbors possibilities if path exist and isn't forbidden
                    // from below
                    if ((j - 1 > -1) && !forbidden(i, j - 1, i, j, bad))
                        numberOfWaysForThisIntersection[i, j] += numberOfWaysForThisIntersection[i, j - 1];

                    // from left
                    if (i - 1 > -1 && !forbidden(i - 1, j, i, j, bad))
                        numberOfWaysForThisIntersection[i, j] += numberOfWaysForThisIntersection[i - 1, j];
                }
            }
            return numberOfWaysForThisIntersection[width, height];
        }

        public bool forbidden(int x1, int y1, int x2, int y2, String[] bad)
        {
            if (bad.Length == 0) return false;
            bool result = false;
            int badX1, badY1, badX2, badY2;
            for (int i = 0; i < bad.Length; i++)
            {
                badX1 = Convert.ToInt32(bad[i].Split(' ')[0]);
                badY1 = Convert.ToInt32(bad[i].Split(' ')[1]);
                badX2 = Convert.ToInt32(bad[i].Split(' ')[2]);
                badY2 = Convert.ToInt32(bad[i].Split(' ')[3]);
                if ((x1.Equals(badX1) && y1.Equals(badY1) && x2.Equals(badX2) && y2.Equals(badY2)) || (x1.Equals(badX2) && y1.Equals(badY2) && x2.Equals(badX1) && y2.Equals(badY1)))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
