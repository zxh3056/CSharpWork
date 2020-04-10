using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderPro;
using System.Threading;

namespace OrderWindow
{
    
    public partial class MainForm : Form
    {
        public OrderSevice orderSevice = new OrderSevice();
       
        public string ID_1 { get; set; }
        public string CumName { get; set; }
        public MainForm()
        {          
            
            InitializeComponent();
            this.IsMdiContainer = true;
            textBox1.DataBindings.Add("Text", this, "ID_1");
            textBox2.DataBindings.Add("Text", this, "CumName");
            bindingSource1.DataSource = orderSevice.orders;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Details")
            {
                ItemShow itemShow = new ItemShow();
                itemShow.MdiParent = this;
                itemShow.Items = orderSevice.orders[e.RowIndex].Items;
                //itemShow.TopLevel = true;
                itemShow.Show();              
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID_1 == null || ID_1 == "")
            {
                orderBindingSource1.DataSource = orderSevice.orders;
            }
            else
            {
                orderBindingSource1.DataSource =
                    orderSevice.orders.Where(s => s.OrderID == Int32.Parse(ID_1));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ID_1 == null || ID_1 == "")
            {
                orderBindingSource1.DataSource = orderSevice.orders;
            }
            else
            {
                orderSevice.DelOrder(Int32.Parse(ID_1));

                bindingSource1.ResetBindings(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderSevice.AddOrder(new Order(Int32.Parse(ID_1), CumName, 
                new List<OrderItem>(new OrderItem[] { })));
            bindingSource1.ResetBindings(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem(this);
            addItem.MdiParent = this;
            addItem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource1.ResetBindings(false);
        }
    }
}
