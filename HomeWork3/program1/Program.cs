using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Graph     //图形基类
    {
        public virtual void Init()
        {
            Console.WriteLine("创建图形。");
        }
        public virtual void Getarea()
        {
            double area = 0;
            Console.WriteLine(area);
        }
        class Triangle : Graph  //三角形类
        {
            public double bottom;//底
            public double high;//高
            public override void Init()
            {
                Console.WriteLine("创建三角形。");
                Console.WriteLine("请输入三角形的底：");
                bottom = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入三角形的高：");
                high = Convert.ToInt32(Console.ReadLine());
            }
            public override void Getarea()
            {
                Console.WriteLine("三角形面积为：");
                Console.WriteLine(bottom * high / 2);
            }
        }
        class Circle : Graph  //圆形类
        {
            public double PI = 3.14159;
            public double radius;//半径 
            public override void Init()
            {
                Console.WriteLine("创建圆形。");
                Console.WriteLine("请输入圆形的半径：");
                radius = Convert.ToInt32(Console.ReadLine());
            }
            public override void Getarea()
            {
                Console.WriteLine("圆形面积为：");
                Console.WriteLine(PI * radius * radius);
            }
        }
        class Square : Graph  //正方形形类
        {
            public double length;//边长
            public override void Init()
            {
                Console.WriteLine("创建正方形。");
                Console.WriteLine("请输入正方形的边长：");
                length = Convert.ToInt32(Console.ReadLine());
            }
            public override void Getarea()
            {
                Console.WriteLine("正方形面积为：");
                Console.WriteLine(length * length);
            }
        }
        class Rectangle : Graph //长方形类
        {
            public double length;//长
            public double width;//宽
            public override void Init()
            {
                Console.WriteLine("创建长方形。");
                Console.WriteLine("请输入长方形的长：");
                length = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入长方形的宽：");
                width = Convert.ToInt32(Console.ReadLine());
            }
            public override void Getarea()
            {
                Console.WriteLine("长方形面积为：");
                Console.WriteLine(length * width);
            }
        }
        public class GraphFactory //工厂类
        {
            public static Graph createGraph(int num)
            {
                Graph shape = null;
                switch (num)
                {
                    case 1:
                        Console.WriteLine("请求创建三角形。");
                        shape = new Triangle(); break;
                    case 2:
                        Console.WriteLine("请求创建圆形。");
                        shape = new Circle(); break;
                    case 3:
                        Console.WriteLine("请求创建正方形。");
                        shape = new Square(); break;
                    case 4:
                        Console.WriteLine("请求创建长方形。");
                        shape = new Rectangle(); break;
                }
                return shape;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你所要创建图形的序号：（1.三角形 2.圆形 3.正方形 4.长方形）");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            Graph shape;
            shape = GraphFactory.createGraph(n);
            shape.Init();
            shape.Getarea();
            Console.ReadKey();
        }
    }
}
