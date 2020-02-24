using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SievePrime
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] a = new bool[100];
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = true;
            }
            for(int i = 2; i < a.Length/2; i++)
            {
                for(int m = 2; m < a.Length; m++) {
                    if (m % i != 0)
                    {
                        continue;
                    }
                    else if (m == i)
                        continue;
                    else
                        a[m] = false;
                }
            }
            for(int i = 2; i < a.Length; i++)
            {
                if (a[i])
                {
                    Console.WriteLine(i);
                }
            }
            
        }
        


    }
}
