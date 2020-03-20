using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPro
{
    class Order //订单类//一共有多少订单，订单的总价是多少等等
    {
        public int moneySum;
        public string cusName;
        public int OrderID; //总订单ID
        public int num;//商品数目
        public List<OrderItem> orderItemList = new List<OrderItem>();
        public Order(int id,string name)
        {
            OrderID = id;
            cusName = name;
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
    class OrderItem //订单明细类//用于作为具体某一个订单的抽象，通过实行具体的对象实现某一个订单
    {
        public string proName;
        public int orderID;
        public int moneySolo;
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
    class OrderSevice//订单服务类
    {
        public List<Order> orders = new List<Order>();
        public IEnumerable<Order> SearchByID(int n)//按照订单号查找订单
        {
            var myorder = from order in orders
                          where order.OrderID == n
                          select order;
            return myorder;
        }
        public IEnumerable<Order> SearchAll()//查找全部订单
        {
            var myorder = from order in orders
                          orderby order.moneySum
                          select order;
            return myorder;
        }
        public void AddOrder(int orderid,string cum)//添加订单
        {
            Order myOrder = new Order(orderid, cum);
            try
            {
                orders.Add(myOrder);
            }catch (Exception){
                Console.WriteLine("订单添加失败");
            }
        }
        public void AddItem(Order order,int id,int money,string itemname)//添加订单明细
        {
            OrderItem myitem = new OrderItem(id, money, itemname);
            order.orderItemList.Add(myitem);
            order.num++;
            order.moneySum += myitem.moneySolo;
        }
        public void DelOrder(int id)//删除一个订单
        {
            var removeOd = from order in orders
                           where order.OrderID == id
                           select order;
            Order removeOD = removeOd.First<Order>();//由于id是具有唯一标识的主码，故第一个也是唯一一个
            this.orders.Remove(removeOD);
        }
        public IEnumerable<Order> SortOd()//排序
        {
            var myOrder = from order in orders
                          orderby order.OrderID
                          select order;
            return myOrder;
        }
        public Order GetOrder(int id,List<Order> OD)//获取其中一个订单
        {
            foreach(Order od in OD)
            {
                if (od.OrderID == id)
                    return od;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderSevice orderSevice = new OrderSevice();
            orderSevice.AddOrder(10, "张三");
            orderSevice.AddItem(orderSevice.GetOrder(10, orderSevice.orders), 1, 5, "牙刷");
            orderSevice.AddOrder(5, "李四");
            orderSevice.AddItem(orderSevice.GetOrder(5, orderSevice.orders), 2, 3, "毛巾");
            orderSevice.AddOrder(7, "王五");
            orderSevice.AddItem(orderSevice.GetOrder(7, orderSevice.orders), 3, 10, "拖把");
            List<Order> myorder=orderSevice.SearchAll().ToList();
            foreach(Order order in myorder)
            {
                Console.WriteLine(order.ToString());
            }
            myorder=orderSevice.SortOd().ToList();
            foreach(Order order in myorder)
            {
                Console.WriteLine(order.ToString());
            }
            orderSevice.DelOrder(10);
            foreach (Order order in orderSevice.orders)
            {
                Console.WriteLine(order.ToString());
            }

        }
    }
}
