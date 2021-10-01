using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class OnlineShoppingDbContext:DbContext,IOnlineShoppingDbContext
    {
        public OnlineShoppingDbContext(DbContextOptions<OnlineShoppingDbContext> options):base(options)
        {}
        public DbSet<Customer>Customers{get;set;}
        public DbSet<Order>Orders{get;set;}
        public DbSet<Product>Products{get; set;}
         public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        
    }
}