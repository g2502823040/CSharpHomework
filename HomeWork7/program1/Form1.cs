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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<OrderDetail> orderlist = new List<OrderDetail>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetail>));
        public void Showlist(List<OrderDetail> orderlist)
        {
            string t = "";
            foreach (OrderDetail od in orderlist)
            {

                t = t + od.ToString() + "\n";

            }
            label7.Text = t;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addtest at = new addtest();
            at.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            using (FileStream fs = new FileStream(@"D:\C#Homework\Homework7\program1\orderlist.xml", FileMode.Open))
            {
                orderlist = (List<OrderDetail>)xs.Deserialize(fs);

            }
            int b;
            try {
                b = Convert.ToInt32(textBox1.Text); orderlist.RemoveAt(b - 1);
                deletesuccess ds = new deletesuccess();
                ds.ShowDialog();
            }
            catch
            {
                deletefail df = new deletefail();
                df.ShowDialog();
            }
            using (FileStream fs = new FileStream(@"D:\C#Homework\Homework7\program1\orderlist.xml", FileMode.Create))
            {
                xs.Serialize(fs, orderlist);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changetest ct = new changetest();
            ct.ShowDialog();
        }
        string id, name, customer;
        private void button4_Click(object sender, EventArgs e)
        {
            string t = "";
            foreach (OrderDetail od in orderlist)
            {
                if (od.id == id) {
                    t = t + od.ToString() + "\n";
                }
                else { t = "不存在该订单！"; }
                label7.Text = t;
            }
            foreach (OrderDetail od in orderlist)
            {
                if (od.name == name)
                {
                    t = t + od.ToString() + "\n";
                }
                else { t = "不存在该订单！"; }
                label7.Text = t;
            }
            foreach (OrderDetail od in orderlist)
            {
                if (od.customer == customer)
                {
                    t = t + od.ToString() + "\n";
                }
                else { t = "不存在该订单！"; }
                label7.Text = t;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { id = this.textBox3.Text; }
            catch { };
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { name = this.textBox4.Text; }
            catch { };
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try { customer = this.textBox5.Text; }
            catch { };
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(@"D:\C#Homework\Homework7\program1\orderlist.xml", FileMode.Open))
            {
                orderlist = (List<OrderDetail>)xs.Deserialize(fs);

            }
            Showlist(orderlist);
        }
    }
}
