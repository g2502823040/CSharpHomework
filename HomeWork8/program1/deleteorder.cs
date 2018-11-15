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
    public partial class deleteorder : Form
    {
        List<OrderDetail> orderlist = new List<OrderDetail>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetail>));
        public deleteorder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(@"D:\C#Homework\Homework7\program1\orderlist.xml", FileMode.Open))
            {
                orderlist = (List<OrderDetail>)xs.Deserialize(fs);

            }
            int b;
            try
            {
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
    }
}
