using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n请输入一个数：");
            string s = Console.ReadLine();
            int a = int.Parse(s);
            Console.Write("\n该数的素数因子：");
            int i = 2;
            while (i <= a) 
            {
                while(a % i == 0)
                {
                    Console.Write("\n" + i);
                    a /= i;
                }
                i++;
            }
            Console.ReadKey();
        }
    }
}
