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
    [Serializable]
    public class Order //订单类//一共有多少订单，订单的总价是多少等等
    {
        public int moneySum;
        public int MoneySum
        {
            get { return moneySum; }
            set { }         
        }
        public List<OrderItem> Items => orderItemList;
        public string cusName { get; set; }
        public int OrderID { get; set; }//总订单ID
        public int num;
        public int Num {
            get { return num; }
            set{ }
        }
        public List<OrderItem> orderItemList = new List<OrderItem>();
        public Order(int id,string name,List<OrderItem> list)
        {
            OrderID = id;
            cusName = name;
            foreach (OrderItem orderItem in list)
            {
                orderItemList.Add(orderItem);
                Num++;
                MoneySum += orderItem.moneySolo;
            }
        }
        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderID == order.OrderID;
        }

        public override int GetHashCode()
        {
            return 1651275338 + OrderID.GetHashCode();
        }

        public override string ToString()
        {
            return "订单ID:"+OrderID.ToString()
                +"\t" +cusName 
                +"\t"+ "商品数目：" + num 
                +"\t"+ "总价：" + moneySum;
        }
    }


    public class OrderItem //订单明细类//用于作为具体某一个订单的抽象，通过实行具体的对象实现某一个订单
    {
        public string proName { get; set; }
        public int orderID { get; set; }
        public int moneySolo { get; set; }
        public OrderItem(int id,int money,string name)
        {
            proName = name;
            orderID = id;
            moneySolo = money;
        }
        public override string ToString()
        {
            return "商品名"+proName +"商品ID"+ orderID+"商品单价"+moneySolo;
        }
    }



    public class OrderSevice//订单服务类
    {
        public List<Order> orders = new List<Order>();
        public IEnumerable<Order> SearchByID(int n)//按照订单号查找订单
        {
            
                var myorder = from order in orders
                              where order.OrderID == n
                              select order;

            if (myorder.ToList().ToArray().Length == 0)
                Console.WriteLine("查找订单不存在");
            return myorder;
        }
        public IEnumerable<Order> SearchAll()//查找全部订单
        {
            var myorder = from order in orders
                          orderby order.MoneySum
                          select order;
            return myorder;
        }
        public void AddOrder(Order myOrder)//添加订单
        {
            bool flag = false;
            foreach (Order order in orders)
            {
                if (myOrder.Equals(order))
                    flag = true;
            }
            if(flag==false)
                orders.Add(myOrder);
        }
        public void AddItem(Order order,OrderItem orderItem)//添加订单明细
        {
            order.orderItemList.Add(orderItem);
            order.num++;

            order.moneySum += orderItem.moneySolo;
        }
        public void DelOrder(int id)//删除一个订单
        {
            var removeOd = from order in orders
                           where order.OrderID == id
                           select order;          
            this.orders.Remove(removeOd.First());
        }
        public IEnumerable<Order> SortOd()//排序
        {
            var myOrder = from order in orders
                          orderby order.OrderID
                          select order;
            return myOrder;
        }
        public void Export()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xml.Serialize(fs, orders);
            }
        }
        public List<Order> Inport()
        {
            List<Order> newOrders;
            XmlSerializer xml = new XmlSerializer(typeof(Order));
            using(FileStream fs=new FileStream("order.xml", FileMode.Open))
            {
                newOrders = (List<Order>)xml.Deserialize(fs);
            }
            return newOrders;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderSevice orderSevice = new OrderSevice();
            Order order_1 = new Order(1, "张三", new List<OrderItem>(new OrderItem[] {
                new OrderItem(1,5,"毛巾"),new OrderItem(2,3,"牙刷")
            }));
            Order order_2 = new Order(2, "李四", new List<OrderItem>(new OrderItem[] {
                new OrderItem(1,5,"毛巾"),new OrderItem(2,3,"牙刷")
            }));
            orderSevice.AddOrder(order_1);
            orderSevice.AddOrder(order_2);
            orderSevice.ToString();
            orderSevice.DelOrder(1);
            orderSevice.ToString();
        }
    }
}
