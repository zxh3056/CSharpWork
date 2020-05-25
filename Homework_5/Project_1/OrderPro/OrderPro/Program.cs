using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace OrderPro
{
    
    class Program
    {
        static void Main(string[] args)
        {
           using(var context=new OrderContext())
            {
                var order = new Order(0, "张三", new List<OrderItem>(new OrderItem[] { }));
                order.Items.Add(new OrderItem(1, 15, "牙刷"));
                order.Items.Add(new OrderItem(2, 5, "袜子"));
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
