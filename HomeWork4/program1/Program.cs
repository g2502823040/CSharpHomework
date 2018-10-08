using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class alarm
    {
        public int Ch = 0;//现在小时
        public int Cm = 0;//现在分钟
        public int Cs = 0;//现在秒
        public int Sh = 0;//设定小时
        public int Sm = 0;//设定分钟
        public int Ss = 0;//设定秒
        public int h = 0;//相差小时
        public int m = 0;//相差分钟
        public int s = 0;//相差秒
        public void Settime()
        {
            Console.WriteLine("请输入设定小时");
            int H = Convert.ToInt32(Console.ReadLine());
            Sh = H;
            Console.WriteLine("请输入设定分钟");
            int M = Convert.ToInt32(Console.ReadLine());
            Sm = M;
            Console.WriteLine("请输入设定秒");
            int S = Convert.ToInt32(Console.ReadLine());
            Ss = S;
        }
        public void Gettime()
        {
            Ch = Convert.ToInt32(DateTime.Now.Hour.ToString());
            Cm = Convert.ToInt32(DateTime.Now.Minute.ToString());
            Cs = Convert.ToInt32(DateTime.Now.Second.ToString());
            if (Sm - Cm <= 0)
            {
                h = Sh - Ch - 1;
                if (Ss - Cs < 0)
                {
                    m = 60 + Sm - Cm - 1;
                    s = 60 + Ss - Cs;
                }
                else
                {
                    m = 60 + Sm - Cm;
                    s = Ss - Cs;
                }
            }
            else
            {
                h = Sh - Ch;
                if (Ss - Cs < 0)
                {
                    m = Sm - Cm - 1;
                    s = 60 + Ss - Cs;
                }
                else
                {
                    m = Sm - Cm;
                    s = Ss - Cs;
                }
            }
            Console.WriteLine("剩余时间：" + h + ":" + m + ":" + s);
        }
        public void Starttime()
        {
            while (Ch != Sh || Cm != Sm || Cs != Ss)
            {
                Gettime();
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("时间到了！");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            alarm alarm = new alarm();
            alarm.Settime();
            alarm.Gettime();
            alarm.Starttime();
            Console.ReadKey();
        }
    }
}
