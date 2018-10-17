using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
        int n;
        int LineWidth;
        double leng;
        double x0;
        double y0;
        double th1;
        double th2;
        double per1=0.6;
        double per2=0.7;
        void drawCayleyTree(int n, double x0, double y0, double leng,  double th)
        {
            double temp1= double.Parse(textBox1.Text);
            double temp2 = double.Parse(textBox3.Text);
            double th1 = temp1 * Math.PI / 180;
            double th2 = temp2 * Math.PI / 180;
            if (0 == n) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1*leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2*leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            int LineWidth = int.Parse(textBox4.Text);
            if (checkBox1.Checked)
            {
                Pen pen = new Pen(Color.Red, LineWidth);
                graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if (checkBox2.Checked)
            {
                Pen pen = new Pen(Color.Yellow, LineWidth);
                graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
            }
            else if (checkBox3.Checked)
            {
                Pen pen = new Pen(Color.Blue, LineWidth);
                graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox5.Text);
            double x0 = double.Parse(textBox6.Text);
            double y0 = double.Parse(textBox7.Text);
            int leng = int.Parse(textBox2.Text);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(n, x0, y0, leng, -Math.PI / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
