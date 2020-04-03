using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree1
{
    public partial class Form1 : Form
    {
        public Graphics graphics;
        public Pen color = Pens.Black;
        public int depth = 10;//递归深度
        double th1 = 30 * Math.PI / 180;//长度1
        double th2 = 20 * Math.PI / 180;//长度2
        double per1 = 0.6;//角度1
        double per2 = 0.7;//角度2
        public double height = 100;
        public Form1()
        {
            
            InitializeComponent();
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(4);
            comboBox2.Items.Add(5);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(7);
            comboBox2.Items.Add(8);
            comboBox2.Items.Add(9);
            comboBox2.Items.Add(10);
            comboBox2.Items.Add(11);
            comboBox2.Items.Add(12);
            comboBox2.Items.Add(13);
            comboBox2.Items.Add(14);
            comboBox1.Items.Add("蓝色");
            comboBox1.Items.Add("粉色");
            comboBox1.Items.Add("黑色");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (graphics == null)
                graphics = this.panel1.CreateGraphics();
            drawCayleyTree(depth, 200, 310, height, -Math.PI / 2);

        }
      
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                 color,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    color = Pens.Blue;
                    break;
                case 1:
                    color = Pens.Pink;
                    break;
                case 2:
                    color = Pens.Black;
                    break;
                default:
                    color = Pens.Black;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            depth = comboBox2.SelectedIndex;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            th1 = Double.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            th2 = Double.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            per1 = Double.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            per2 = Double.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            height = Double.Parse(textBox5.Text);
        }
    }
}
