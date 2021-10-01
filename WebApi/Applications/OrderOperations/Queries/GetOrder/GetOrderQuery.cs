using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace  WebApi.Applications.OrderOperations.Queries.GetOrder
{
    public class GetOrderQuery
    {
        
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderQuery(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<OrderViewModel>  Handle()
        {
          
          var orderlist=_context.Orders.Include(x=>x.Product).OrderBy(x=>x.OrderId);
          
          List<OrderViewModel> vn= _mapper.Map<List<OrderViewModel>>(orderlist);
          
         
           
          return vn;

        }
    }
      public class OrderViewModel
    {
      
        public string  Genre{get;set;}
    
        public double Invoice{get;set;}


    }

}