using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Exercise3
    {
        public int GetGreatestComonDivisor(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        public int GetGreatestComonDivisorOfArrray(int[] arrray)
        {
            int rs = arrray[0];
            for (int i = 1; i < arrray.Length - 1; i++)
            {
                rs = GetGreatestComonDivisor(arrray[i], rs);
            }
            return rs;
        }
    }
}
