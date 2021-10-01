using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IOnlineShoppingDbContext
    {
        DbSet<Customer>Customers{get;set;}
        DbSet<Order>Orders{get;set;}
        DbSet<Product>Products{get;set;}
        

        int SaveChanges();
    }
}