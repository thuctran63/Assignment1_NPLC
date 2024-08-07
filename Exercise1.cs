using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Exercise1
    {
        public void GetMinAndMaxOfArrray(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine("Minimum value in the array is: " + min);
            Console.WriteLine("Maximum value in the array is: " + max);
        }
    }
}
