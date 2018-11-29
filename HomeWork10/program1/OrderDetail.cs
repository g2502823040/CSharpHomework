using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class OrderDetail
    {
        public String id { get; set; }
        public String name { get; set; }
        public String customer { get; set; }
        public String money { get; set; }
        public long phonenumber { get; set; }
        public long ordernumber { get; set; }
        public override string ToString()
        {
            return "订单号码为:" + id + "\t订单名字：" + name + "\t顾客姓名：" + customer + "\t订单金额：" + money;
        }
    }
}
