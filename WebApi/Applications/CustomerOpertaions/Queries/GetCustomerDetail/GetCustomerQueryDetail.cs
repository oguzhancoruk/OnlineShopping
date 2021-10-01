using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {   
         private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public int CustomerId{get;set;}
        public GetCustomerDetailQuery(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDetailViewModel  Handle()
        {
            var customerlist=_context.Customers.Include(x=>x.Order).Where(a=>a.Id==CustomerId).SingleOrDefault();
             if(customerlist is null)
            throw new InvalidOperationException("Kullanıcı Bulunamadı");
          
            return  _mapper.Map<CustomerDetailViewModel>(customerlist);
          
          

        }
    }

     public class CustomerDetailViewModel
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