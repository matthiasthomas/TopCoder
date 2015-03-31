using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Test
{
    public class MedalTable
    {
        public static string[] generate(string[] results)
        {
            Dictionary<string, int[]> dict = new Dictionary<string, int[]>();
            int i;
            for (i = 0; i < results.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!dict.ContainsKey(results[i].Split(' ')[j]))
                    {
                        dict.Add(results[i].Split(' ')[j], new int[] { 0, 0, 0 });
                    }
                    dict[results[i].Split(' ')[j]][j]++;
                }
            }
            string[] medals = new string[dict.Count];
            i = 0;
            foreach (string key in dict.Keys)
            {
                string medal = key + ' ' + dict[key][0].ToString() + ' ' + dict[key][1].ToString() + ' ' + dict[key][2].ToString();
                medals[i] = medal;
                i++;
            }
            // Sort
            medals = medals.OrderByDescending(s => s.Split(' ')[1]).ThenByDescending(s => s.Split(' ')[2]).ThenByDescending(s => s.Split(' ')[3]).ThenBy(s => s.Split(' ')[0]).ToArray();
            return medals;
        }
    }
}