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
    public partial class changetest : Form
    {
        public List<OrderDetail> orderlist = new List<OrderDetail>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetail>));
        public changetest()
        {
            InitializeComponent();
        }
        string newid, newname, newcustomer, newmoney;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { newid = this.textBox1.Text; }
            catch { };
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { newname = this.textBox1.Text; }
            catch { };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { newcustomer = this.textBox1.Text; }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n = textBox5.Text;
            foreach (OrderDetail s in orderlist)
            {
                if (s.id == n)
                {
                    label5.Text=s.name;
                    label6.Text = s.customer;
                    label11.Text = s.money;
                }
                else
                {
                    label5.Text = "无该订单信息！";
                    label6.Text = "无该订单信息！";
                    label11.Text = "无该订单信息！";
                }
            };
            using (FileStream fs = new FileStream(@"D:\C#Homework\Homework7\program1\orderlist.xml", FileMode.Open))
            {
                orderlist = (List<OrderDetail>)xs.Deserialize(fs);
            }
            foreach (OrderDetail s in orderlist)
            {
                if (s.id==n)
                {
                    s.id = newid;
                    s.name = newname;
                    s.customer = newcustomer;
                    s.money = newmoney;
                }
            };
            using (FileStream fs = new FileStream(@"D:\C#Homework\Homework7\program1\orderlist.xml", FileMode.Create))
            {
                xs.Serialize(fs, orderlist);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { newmoney = this.textBox1.Text; }
            catch { };
        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
