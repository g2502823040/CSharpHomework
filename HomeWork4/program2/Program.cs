using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    public class Order
    {
        public void Start(OrderService a)
        {
            bool Y = true;
            while (Y)
            {
                Console.WriteLine("请输入：1.添加订单 2.删除订单 3.更改订单 4.查找订单 5.完成订单");
                string n = Console.ReadLine();
                switch (n)
                {
                    case "1": a.Add();break;
                    case "2": a.Delete(); break;
                    case "3": a.Change(); break;
                    case "4": a.Find(); break;
                    case "5": Y=false; break;
                    default:
                        Console.WriteLine("无效操作");
                        break;
                }
            }
        }
    }
    public class OrderDetails
    {
        public int id;
        public string name;
        public string customer;
    }
    public class OrderService
    {
        public List<OrderDetails> orderlist = new List<OrderDetails>();
        public void Add()
        {
            OrderDetails a = new OrderDetails();
            Console.WriteLine("请输入订单号码：");
            a.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入订单名字：");
            a.name = Console.ReadLine();
            Console.WriteLine("请输入客户名字：");
            a.customer = Console.ReadLine();
            orderlist.Add(a);
        }
        public void Delete()
        {
            try
            {
                Console.WriteLine("请输入删除订单的号码：");
                int b = Convert.ToInt32(Console.ReadLine());
                orderlist.RemoveAt(b - 1);
            }
            catch { Console.WriteLine("无效操作"); }
        }
        public void Change()
        {
            OrderDetails a = new OrderDetails();
            Console.WriteLine("请输入更改订单的号码：");
            a.id = Convert.ToInt32(Console.ReadLine());
            foreach(OrderDetails c in orderlist)
            {
                if (a.id == c.id)
                {
                    Console.WriteLine("请输入新订单名字：");
                    a.name = Console.ReadLine();
                    Console.WriteLine("请输入新顾客名字：");
                    a.customer = Console.ReadLine();
                }
            }
        }
        public void Find()
        {
            OrderDetails a = new OrderDetails();
            Console.WriteLine("请输入：1.按号码查找 2.按名字查找 3.按顾客查找");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1:
                    Console.WriteLine("请输入查找订单的号码：");
                    a.id = Convert.ToInt32(Console.ReadLine());
                    foreach(OrderDetails i in orderlist)
                    {
                        if (a.id == i.id)
                        {
                            Console.WriteLine("订单号码:" + i.id + "订单名称：" + i.name + "订单顾客：" + i.customer);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("请输入查找订单的名字：");
                    a.name = Console.ReadLine();
                    foreach (OrderDetails i in orderlist)
                    {
                        if (a.name == i.name)
                        {
                            Console.WriteLine("订单号码:" + i.id + "订单名称：" + i.name + "订单顾客：" + i.customer);
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("请输入查找订单的顾客：");
                    a.customer = Console.ReadLine();
                    foreach (OrderDetails i in orderlist)
                    {
                        if (a.customer == i.customer)
                        {
                            Console.WriteLine("订单号码:" + i.id + "订单名称：" + i.name + "订单顾客：" + i.customer);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("无效操作");
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            OrderService o = new OrderService();
            order.Start(o);
        }
    }
}
