using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context= new OnlineShoppingDbContext(serviceProvider.GetRequiredService<DbContextOptions<OnlineShoppingDbContext>>()))
            {
                if(context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(
                    new Customer{Name="Oğuzhan",SurName="Çoruk",Phone=123456789,Adress="istanbul",Email="oguz@mail.com",Password="123"},
                    new Customer{Name="Kaan",SurName="Taşyaran",Phone=12345,Adress="istambul",Email="Kaan@mail.com",Password="1234"}
                );
                context.Products.AddRange(
                    new Product{Price=10.2,Genre="Yem"},
                    new Product{Price=2.5,Genre="İçecek"},
                    new Product{Price=5.7,Genre="Tatlı"}
                );
                context.Orders.AddRange(
                    new Order{Genre="yemek",Invoice=10.2}
                );
                context.SaveChanges();
            }
        }       
    }
}