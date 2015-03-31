using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TallPeople
    {
        public int[] getPeople(string[] people)
        {
            int[] result = new int[2];
            int[] shortest = new int[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                int min = System.Convert.ToInt32(people[i].Split(' ')[0]);
                for (int j = 0; j < people[i].Split(' ').Length; j++)
                {
                    if (System.Convert.ToInt32(people[i].Split(' ')[j]) < min)
                    {
                        min = System.Convert.ToInt32(people[i].Split(' ')[j]);
                    }
                }
                shortest[i] = min;
            }

            int tallestOfTheShortest = shortest[0];
            for (int i = 0; i < shortest.Length; i++)
            {
                if (shortest[i] > tallestOfTheShortest)
                {
                    tallestOfTheShortest = shortest[i];
                }
            }
            result[0] = tallestOfTheShortest;

            int[] tallest = new int[people[0].Split(' ').Length];
            for (int j = 0; j < people[0].Split(' ').Length; j++)
            {
                int max = System.Convert.ToInt32(people[0].Split(' ')[j]);
                for (int i = 0; i < people.Length; i++)
                {
                    if (System.Convert.ToInt32(people[i].Split(' ')[j]) > max)
                    {
                        max = System.Convert.ToInt32(people[i].Split(' ')[j]);
                    }
                }
                tallest[j] = max;
            }
            int shortestOfTheTallest = tallest[0];
            for (int i = 0; i < tallest.Length; i++)
            {
                if (tallest[i] < shortestOfTheTallest)
                {
                    shortestOfTheTallest = tallest[i];
                }
            }
            result[1] = shortestOfTheTallest;
            return result;
        }
    }
}
