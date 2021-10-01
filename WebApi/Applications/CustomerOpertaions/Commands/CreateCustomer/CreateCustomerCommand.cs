using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {   
        public CreateCustomerModel Model {get;set;}
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer=_context.Customers.SingleOrDefault(x=>x.Email==Model.Email);
            if(customer is not null)
            throw new InvalidOperationException("KUllanıcı mevcut");
            customer=_mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();

        }

        public class CreateCustomerModel
        {
        public string Name{get;set;}
        public string SurName{get;set;}
        public int Phone{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public string Adress{get;set;}
        }
    }
}