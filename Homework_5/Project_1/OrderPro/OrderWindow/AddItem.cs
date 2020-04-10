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

namespace OrderWindow
{
    public partial class AddItem : Form
    {
        public string ItemName { get; set; } 
        public string ItemID { get; set; } 
        public string ItemMoney { get; set; }
        public string OrderID { get; set; }
        public MainForm mainForm;
        public AddItem()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", this, "ItemName");
            textBox2.DataBindings.Add("Text", this, "ItemID");
            textBox3.DataBindings.Add("Text", this, "ItemMoney");
            textBox4.DataBindings.Add("Text", this, "OrderID");
        }
        public AddItem(MainForm main):this()
        {
            mainForm = main;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Order order = mainForm.orderSevice.orders.
                Where(s => s.OrderID == Int32.Parse(OrderID)).First();
            mainForm.orderSevice.AddItem(order,
                new OrderItem(Int32.Parse(ItemID), Int32.Parse(ItemMoney), ItemName));      
        }
    }
}
