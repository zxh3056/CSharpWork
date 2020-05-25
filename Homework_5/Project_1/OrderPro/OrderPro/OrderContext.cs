using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OrderPro
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("OrderBase")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }

    }
}
