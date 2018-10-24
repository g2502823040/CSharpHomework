using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;

namespace program2
{
    [TestClass]
    public class UnitTest1
    {

        OrderDetails order1 = new OrderDetails("1", "一级翅膀", "诩丶");
        OrderDetails order2 = new OrderDetails("2", "二级翅膀", "诩丶");
        OrderDetails order3 = new OrderDetails("3", "三级翅膀", "诩丶");
        [TestMethod]
        public void Addtest()
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            orders.Add(order1);
            Assert.IsNotNull(orders);
        }
        [TestMethod]
        public void Deletetest()
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            orders.Add(order1);
            orders.Remove(order1);
            Assert.IsNull(orders);
        }
        [TestMethod]
        public void Changetest()
        {
            OrderService os = new OrderService();
            string newname = "二级翅膀";
            string newcustomer = "言羽丶";
            os.Change(order1, newname, newcustomer);
            Assert.AreEqual(order1.name, newname);
            Assert.AreEqual(order1.customer, newcustomer);
        }
        [TestMethod]
        public void findbyidtest()
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            orders.Add(order1);
            bool flag = false;
            foreach (OrderDetails anorder in orders)
            {
                var ods = from od in orders where od.name == order1.name select od;
                if (ods != null)
                {
                    flag = true;
                }
            }
            Assert.IsTrue(flag);
        }
    }
}
