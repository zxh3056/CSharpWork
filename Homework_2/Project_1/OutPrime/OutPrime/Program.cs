using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int Num_1;
                string Num = "";
                Console.WriteLine("请输入一个数");
                Num = Console.ReadLine();
                try
                {
                    Num_1 = Int32.Parse(Num);
                }
                catch (FormatException)
                {
                    Console.WriteLine("请不要输入非法字符！");
                    continue;
                }
                for(int num = 2; num <= Num_1; num++)
                {
                    if (Num_1 % num != 0)
                        continue;
                    if (Prime(num))
                    {
                        Console.WriteLine(num);
                    }

                }
            }
        }
       static bool Prime(int n)
        {
          
            int m=0;
            for(int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                {
                    m = i;
                    break;
                }
            }
            if (m == n)
                return true;
            return false;
        }
    }
}
