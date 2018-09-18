using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n请输入该数组元素个数：");
            string A = Console.ReadLine();
            int i = int.Parse(A);
            int[] a=new int [i];
            Console.Write("\n请依次输入该数组元素：");
            for (int j = 0; j < i; j++)
            {
                string B = Console.ReadLine();
                a[j]= int.Parse(B);
            }
            int x = 0;
            while(x< i-1)
            {
                if (a[x] > a[x + 1])
                {
                    int b = a[x];
                    a[x] = a[x + 1];
                    a[x + 1] = b;
                }
                x++;
            }
            int Max = a[x];
            Console.Write("\n最大值："+Max);
            int y = 0;
            while (y < i - 1)
            {
                if (a[y] < a[y + 1])
                {
                    int b = a[y];
                    a[y] = a[y + 1];
                    a[y+ 1] = b;
                }
                y++;
            }
            int Min = a[y];
             Console.Write("\n最大值："+Max);
            int N = 0;
            for(int j = 0; j < i; j++)
            {
                N += a[j];
            }
            Console.Write("\n总和：" + N);
            Console.Write("\n平均值：" + N/i);
            Console.ReadKey();
        }
    }
}
