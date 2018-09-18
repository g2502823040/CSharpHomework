using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("2~100以内的素数：" );
            int[] a = new int[101];
            int i, j;
            for (i = 1; i <=100; i++) {
                a[i] = i;
            }
          for(j=2;j<=100;j++)
                for (i = j+1; i <=100; i++)
                {
                    if (a[i] % j == 0)   
                        a[i] = 0;
                }
            for (i = 2; i <=100; i++){
                if (a[i] != 0)
                {
                    Console.Write(" " + a[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
