using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.ProductOperations.Commands.DeleteProduct
{
    public class DeleteProductCommand

    {
        public  int ProductId{get;set;}     
        private readonly IOnlineShoppingDbContext _context;
        public DeleteProductCommand(IOnlineShoppingDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var product=_context.Products.SingleOrDefault(x=>x.ProductId==ProductId);
            if( product is  null)
            throw new InvalidOperationException("Ürün Bulunamadı");
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
}
    }