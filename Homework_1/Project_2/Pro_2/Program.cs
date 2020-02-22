using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                char Fuhao = '0';
                bool flag_1 = true;
                bool flag_2 = true;
                bool flag_3 = true;
                string Num = "";
                int Num_1 = 0;
                int Num_2 = 0;
                while (flag_1)
                {
                    Console.WriteLine("请输入第一个数字");
                    Num = Console.ReadLine();
                    try {
                        Num_1 = Int32.Parse(Num);
                        flag_1 = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("请输入一个数字");
                    }

                }
                while (flag_2)
                {
                    Console.WriteLine("请输入第二个数字");
                    Num = Console.ReadLine();
                    try {
                        Num_2 = Int32.Parse(Num);
                        flag_2 = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("请输入一个数字");
                    }
                }
                while (flag_3)
                {
                    Console.WriteLine("请输入运算符");
                    Num = Console.ReadLine();
                    try {
                        Fuhao = Char.Parse(Num);
                        flag_3 = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("请输入一个运算符");
                    }
                }
                switch (Fuhao)
                {
                    case '+':
                        Console.WriteLine(Num_1 + "+" + Num_2 + "=" + (Num_1 + Num_2));
                        break;
                    case '-':
                        Console.WriteLine(Num_1 + "-" + Num_2 + "=" + (Num_1 - Num_2));
                        break;
                    case '*':
                        Console.WriteLine(Num_1 + "*" + Num_2 + "=" + (Num_1 * Num_2));
                        break;
                    case '/':
                        try {
                            Console.WriteLine(Num_1 + "/" + Num_2 + "=" + (Num_1 / Num_2));
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("除数不能为0");
                        }
                        break;
                    default:
                        Console.WriteLine("请输入正确运算符");
                        break;
                }
            }
        }
    }
}
