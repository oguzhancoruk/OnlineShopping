using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {   
         public UpdateOrderModel updateorderModel{get;set;}
        public int OrderId{get;set;}
        private readonly IOnlineShoppingDbContext _context;
        public UpdateOrderCommand(IOnlineShoppingDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {   
             var order=_context.Orders.SingleOrDefault(x=>x.OrderId==OrderId);
            if(order is null)
                throw new InvalidOperationException("Sipariş Bulunamadı");

            order.Genre = updateorderModel.Genre == default? order.Genre: updateorderModel.Genre;
       
            _context.SaveChanges();
        }

    }
    public class UpdateOrderModel
    {
         public string Genre{get;set;}
    }
}