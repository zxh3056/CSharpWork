using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPro_1
{
    public partial class Form1 : Form
    {
        static char FuHao = '0';
        static int Num_1 = 0;
        static int Num_2 = 0;
        static int answer = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "+";
            Form1.FuHao = '+';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "-";
            Form1.FuHao = '-';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "*";
            Form1.FuHao = '*';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "/";
            Form1.FuHao = '/';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Num_1 = Int32.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                errorProvider3.SetError(textBox1, "请输入合法字符");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Num_2 = Int32.Parse(textBox3.Text);
            }
            catch (FormatException)
            {
                errorProvider4.SetError(textBox3, "请输入合法字符");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (FuHao)
            {
                case '+':
                    answer = Num_2 + Num_1;
                    label2.Text = answer.ToString();
                    break;
                case '-':
                    answer = Num_1 - Num_2;
                    label2.Text = answer.ToString();
                    break;
                case '*':
                    answer = Num_1 * Num_2;
                    label2.Text = answer.ToString();
                    break;
                case '/':
                    try
                    {
                        answer = Num_1 / Num_2;
                        label2.Text = answer.ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        errorProvider1.SetError(textBox3,"除数不能为0");
                    }
                    break;
                default:
                    errorProvider2.SetError(label3, "请选择操作符");
                    break;

            }
        }
    }
}
