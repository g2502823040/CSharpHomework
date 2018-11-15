using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
namespace program1
{
    public partial class addtest : Form
    {
        static public List<OrderDetail> orderlist = new List<OrderDetail>();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<OrderDetail>));
        string xmlFileName = @"D:\C#Homework\Homework7\program1\orderlist.xml";
        string id, name, customer, money,phonenumber,ordernumber;
        public addtest()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { id = this.textBox1.Text; }
            catch { };
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { name = this.textBox2.Text; }
            catch { };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { customer = this.textBox3.Text; }
            catch { };
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { money = this.textBox4.Text; }
            catch { };
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ordernumber = this.textBox6.Text;
            }
            catch { };
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                phonenumber = this.textBox5.Text;
            }
            catch { };
        }

        static public void Import(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            orderlist = xmlSerializer.Deserialize(fileStream) as List<OrderDetail>;
            fileStream.Close();
        }

        static public void Export(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, obj);
            fileStream.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetail a = new OrderDetail();
            a.id = id;
            a.name = name;
            a.customer = customer;
            a.money = money;
            a.phonenumber = Convert.ToInt64(phonenumber);
            a.ordernumber = Convert.ToInt64(ordernumber);
            bool repeatordernumber = false;
            if (a.phonenumber < 10000000000 || a.phonenumber > 19000000000)
            {
                MessageBox.Show("无效的电话号码", "提示", MessageBoxButtons.OK);
                orderlist.Remove(a);
            }
            try
            {
                string year = ordernumber.Substring(0, 4);
                string month = ordernumber.Substring(4, 2);
                string day = ordernumber.Substring(6, 2);
                if (a.ordernumber > 20000000000 && a.ordernumber < 20190000000)
                {
                    if (!(Convert.ToInt32(year) > 2000 && Convert.ToInt32(year) < 2019 && Convert.ToInt32(month) < 13
                      && Convert.ToInt32(month) > 0 && Convert.ToInt32(day) < 32
                      && Convert.ToInt32(day) > 0))
                    {
                        MessageBox.Show("请按照 年月日+三位流水号输入订单号", "提示", MessageBoxButtons.OK);
                        orderlist.Remove(a);
                    }
                    else { }
                }
                else
                {
                    MessageBox.Show("请按照 年月日+三位流水号输入订单号", "提示", MessageBoxButtons.OK);
                    orderlist.Remove(a);
                }
            }
            catch
            {
                MessageBox.Show("请按照 年月日+三位流水号输入订单号", "提示", MessageBoxButtons.OK);
                orderlist.Remove(a);
            }
            foreach (OrderDetail s in orderlist)
            {
                if (a.ordernumber == s.ordernumber)
                {
                    MessageBox.Show("重复账单号", "提示", MessageBoxButtons.OK);
                    repeatordernumber = true;
                }
            }
            orderlist.Add(a);
            if (repeatordernumber)
            {
                orderlist.Remove(a);
            }
            addtest.Export(xmlSerializer, xmlFileName, addtest.orderlist);
        }
    }
}
