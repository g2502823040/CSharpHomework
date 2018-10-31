using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class OrderDetail
    {
        public String id;
        public String name;
        public String customer;
        public String money;
        public override string ToString()
        {
            return "订单号码为:" + id + "\t订单名字：" + name + "\t顾客姓名：" + customer + "\t订单金额：" + money;
        }
    }
}
