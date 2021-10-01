using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.CustomerOperations.Queries.GetCustomer
{
    public class GetCustomerQuery
    {
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerQuery(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CustomerViewModel> Handle()
        {
            var customerlist=_context.Customers.Include(x=>x.Order).OrderBy(x=>x.Id);
          
          List<CustomerViewModel> vn= _mapper.Map<List<CustomerViewModel>>(customerlist);
          
         
           
          return vn;

        }
    }
    public class CustomerViewModel
    {
       
        public string Name{get;set;}
        public string SurName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public int Phone{get;set;}
        public string Adress{get;set;} 
        public double Invoice{get;set;}
    }
    
}