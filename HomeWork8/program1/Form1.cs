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
using System.Xml.XPath;
using System.Xml.Xsl;
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
        private void button1_Click(object sender, EventArgs e)
        {
            addtest at = new addtest();
            at.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteorder de = new deleteorder();
            de.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changetest ct = new changetest();
            ct.ShowDialog();
        }
        string id, name, customer;
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (OrderDetail od in orderlist)
            {
                if (od.id == id) {
                    bindingSource1.DataSource = od;
                }
                else MessageBox.Show("不存在该订单！", "提示", MessageBoxButtons.OK);
            }
            foreach (OrderDetail od in orderlist)
            {
                if (od.name == name)
                {
                    bindingSource1.DataSource = od;
                }
                else MessageBox.Show("不存在该订单！", "提示", MessageBoxButtons.OK);
            }
            foreach (OrderDetail od in orderlist)
            {
                if (od.customer == customer)
                {
                    bindingSource1.DataSource = od;
                }
                else MessageBox.Show("不存在该订单！", "提示", MessageBoxButtons.OK);
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

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(@"order.xsl");
            trans.Transform(@"D:\C#Homework\Homework7\program1\orderlist.xml", @".\order.html");
            try { System.Diagnostics.Process.Start("order.html"); }
            catch { MessageBox.Show("文件不存在", "提示", MessageBoxButtons.OK); };
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
            bindingSource1.DataSource = orderlist;
        }
    }
}
