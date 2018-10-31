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
        string id, name, customer, money;
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
            orderlist.Add(a);
            addtest.Export(xmlSerializer, xmlFileName, addtest.orderlist);
            addend ae = new addend();
            ae.ShowDialog();
        }
    }
}
