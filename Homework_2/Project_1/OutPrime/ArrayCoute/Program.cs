using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCoute
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            int Sum = ArraySum(a);
            int Aver = ArrayAver(a);
            int Max = ArrayMax(a);
            int Min = ArrayMin(a);
            Console.WriteLine(Sum);
            Console.WriteLine(Aver);
            Console.WriteLine(Max);
            Console.WriteLine(Min);
        }
        static int ArraySum(int[] a)
        {
            int sum=0;
            foreach(int b in a)
            {
                sum += b;
            }
            return sum;
        }
        static int ArrayAver(int[] a)
        {
            int sum = ArraySum(a);
            int aver = sum / a.Length;
            return aver;
        }
        static int ArrayMax(int[] a)
        {
            int max = a[0];
            for(int i = 0; i < a.Length; i++)
            {
                if (max <= a[i])
                    max = a[i];
            }
            return max;
        }
        static int ArrayMin(int[] a)
        {
            int min = a[0];
            for(int i = 0; i <a.Length; i++)
            {
                if (min >= a[i])
                    min = a[i];
            }
            return min;
        }
    }
}
