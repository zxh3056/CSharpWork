using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OrderPro.Tests
{
    [TestClass()]
    public class OrderSeviceTests
    {
        [TestMethod()]
        public void SearchByIDTest()//判断功能是否正确
        {
            OrderSevice orderSevice = new OrderSevice();
            List<OrderItem> items = new List<OrderItem>(new OrderItem[] {
                new OrderItem(1,5,"毛巾"),new OrderItem(2,3,"牙刷")
            });
            Order order_1 = new Order(1, "张三",items);
            Order order_2 = new Order(2, "李四",items);
            Order order_3 = new Order(3, "王五",items);
            orderSevice.orders.Add(order_1);
            orderSevice.orders.Add(order_2);
            orderSevice.orders.Add(order_3);
            List<Order> order = orderSevice.SearchByID(2).ToList();
            Order order0 = order[0];
            Assert.AreSame(order0, order_2);
        }
        [TestMethod()]
        public void SearchByIDTest_1()//判断查找不存在的情况

        {
            OrderSevice orderSevice = new OrderSevice();
            List<OrderItem> items = new List<OrderItem>(new OrderItem[] {
                new OrderItem(1,5,"毛巾"),new OrderItem(2,3,"牙刷")
            });
            Order order_1 = new Order(1, "张三",items);
            Order order_2 = new Order(2, "李四",items);
            Order order_3 = new Order(3, "王五",items);
            orderSevice.orders.Add(order_1);
            orderSevice.orders.Add(order_2);
            orderSevice.orders.Add(order_3);
            List<Order> order = (List<Order>)orderSevice.SearchByID(4);
            Assert.IsTrue(order.ToArray().Length == 0);
        }

        [TestMethod()]
        public void SearchAllTest()
        {
            OrderSevice orderSevice = new OrderSevice();
            List<OrderItem> items = new List<OrderItem>(new OrderItem[] {
                new OrderItem(1,5,"毛巾"),new OrderItem(2,3,"牙刷")
            });
            Order order_1 = new Order(1, "张三",items);
            Order order_2 = new Order(2, "李四",items);
            Order order_3 = new Order(3, "王五",items);
            orderSevice.orders.Add(order_2);
            orderSevice.orders.Add(order_1);
            orderSevice.orders.Add(order_3);
            List<Order> order = (List<Order>)orderSevice.SearchAll();
            Assert.AreEqual(order[0], order_1);
            Assert.AreEqual(order[1], order_2);
            Assert.AreEqual(order[2], order_3);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            OrderSevice order = new OrderSevice();
            OrderItem item = new OrderItem(1, 2, "牙刷");
            List<OrderItem> items = new List<OrderItem>(new OrderItem[] { item });
            Order myorder = new Order(1, "张三", items);
            order.AddOrder(myorder);
            Assert.AreEqual(order.orders[0], myorder);

        }
        [TestMethod]
        public void AddOrderTest_1()
        {

            OrderSevice order = new OrderSevice();
            OrderItem item = new OrderItem(1, 2, "牙刷");
            List<OrderItem> items = new List<OrderItem>(new OrderItem[] { item });
            Order myorder = new Order(1, "张三", items);
            order.AddOrder(myorder);
            order.AddOrder(myorder);
            Assert.IsTrue(order.orders.ToArray().Length==1);
        }

        //[TestMethod()]
        //public void AddItemTest()
        //{
        //    OrderSevice order = new OrderSevice();
        //    OrderItem item = new OrderItem(1, 2, "牙刷");
        //    List<OrderItem> items = new List<OrderItem>(new OrderItem[] { item });
        //    Order order1 = new Order(1, "张三", items);
        //    order.orders.Add(order1);
        //    order.AddItem(order.orders[0], 2, 5, "毛巾");
        //    OrderItem orderItem = new OrderItem(2, 5, "毛巾");
        //    Assert.AreEqual(order.orders[0].orderItemList[1], orderItem);
        //}

        //[TestMethod()]
        //public void DelOrderTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SortOdTest()
        //{
        //    Assert.Fail();
        //}
        //[TestMethod()]
        //public void ExportTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void InportTest()
        //{
        //    Assert.Fail();
        //}
    }
}