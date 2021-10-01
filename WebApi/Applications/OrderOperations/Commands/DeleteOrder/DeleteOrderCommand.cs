using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand

    {
        public  int OrderId{get;set;}     
        private readonly IOnlineShoppingDbContext _context;
        public DeleteOrderCommand(IOnlineShoppingDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var order=_context.Orders.SingleOrDefault(x=>x.OrderId==OrderId);
            if(order is  null)
            throw new InvalidOperationException("Sipariş Bulunamadı");
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
}
    }