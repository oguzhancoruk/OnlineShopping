using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace  WebApi.Applications.ProductOperations.Queries.GetProduct
{
    public class GetProductDetailQuery
    {
        
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public int ProductId{get;set;}
        public GetProductDetailQuery(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ProductDetailViewModel  Handle()
        {
          
          var productlist=_context.Products.Where(a=>a.ProductId==ProductId).SingleOrDefault();
          
        return _mapper.Map<ProductDetailViewModel>(productlist);
          
         
           
        

        }
    }
      public class ProductDetailViewModel
    {
      
      
        public double Price{get;set;}
        public string genre{get;set; }


    }

}