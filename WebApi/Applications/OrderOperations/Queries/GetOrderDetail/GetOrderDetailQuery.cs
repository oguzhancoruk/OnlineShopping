using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace  WebApi.Applications.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery
    {
        
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
         public int OrderId{get;set;}
        public GetOrderDetailQuery(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public OrderDetailViewModel  Handle()
        {
          
          var orderlist=_context.Orders.Include(x=>x.Product).Where(a=>a.OrderId==OrderId).SingleOrDefault();
          if(orderlist is null)
            throw new InvalidOperationException("Kullanıcı Bulunamadı");
          
          return _mapper.Map<OrderDetailViewModel>(orderlist);
          
         
           
          

        }
    }
      public class OrderDetailViewModel
    {
      
        public string Genre{get;set;}
    
        public double Invoice{get;set;}


    }

}