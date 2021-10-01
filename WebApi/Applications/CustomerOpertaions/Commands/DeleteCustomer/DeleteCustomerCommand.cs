using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand

    {
        public  int CustomerId{get;set;}     
        private readonly IOnlineShoppingDbContext _context;
        public DeleteCustomerCommand(IOnlineShoppingDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer=_context.Customers.SingleOrDefault(x=>x.Id==CustomerId);
            if(customer is  null)
            throw new InvalidOperationException("Kullanıcı Bulunamadı");
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
}
    }