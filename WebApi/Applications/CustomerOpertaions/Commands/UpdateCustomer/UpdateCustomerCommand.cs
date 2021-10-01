using System;
using System.Linq;
using WebApi.DBOperations;

namespace  WebApi.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        public UpdateCustomerModel updateCustomerModel{get;set;}
        public int CustomerId{get;set;}
        private readonly IOnlineShoppingDbContext _context;
        public UpdateCustomerCommand(IOnlineShoppingDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var customer=_context.Customers.SingleOrDefault(x=>x.Id==CustomerId);
            if(customer is null)
                throw new InvalidOperationException("Kullanıcı Bulunamadı");

            customer.Adress = updateCustomerModel.Adress == default? customer.Adress: updateCustomerModel.Adress;
            customer.Phone = updateCustomerModel.Phone == default? customer.Phone: updateCustomerModel.Phone;
            _context.SaveChanges();

        }
        }
        public class UpdateCustomerModel
    {
        public string Adress{get;set;}
        public int Phone{get;set;}

    }


    }

    