using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace  WebApi.Applications.ProductOperations.Queries.GetProduct
{
    public class GetProductQuery
    {
        
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public GetProductQuery(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductViewModel>  Handle()
        {
          
          var productlist=_context.Products.OrderBy(x=>x.ProductId);
          
          List<ProductViewModel> vn= _mapper.Map<List<ProductViewModel>>(productlist);
          
         
           
          return vn;

        }
    }
      public class ProductViewModel
    {
      
      
        public double Price{get;set;}
        public string genre{get;set; }


    }

}