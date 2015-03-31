using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class BusinessTasks
    {
        public string getTask(string[] list, int n)
        {
            if (list.Length == 1)
            {
                return list[0];
            }
            int index = n % list.Length;
            if (index == 0)
            {
                index = list.Length;
            }
            index -= 1;
            string[] subList = new string[list.Length - 1];
            int j = 0;
            for (int i = index + 1; i < list.Length; i++)
            {
                subList[j] = list[i];
                j++;
            }
            for (int i = 0; i < index; i++)
            {
                subList[j] = list[i];
                j++;
            }
            return getTask(subList, n);
        }
    }
}
