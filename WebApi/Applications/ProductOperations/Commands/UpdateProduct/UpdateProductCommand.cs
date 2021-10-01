using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.ProductOperations.Commands.UpdateOrder
{
    public class UpdateProductCommand
    {   
         public int ProductId{get;set;}
        public UpdateProductModel updateProductModel{get;set;}
        private readonly IOnlineShoppingDbContext _context;
        public UpdateProductCommand(IOnlineShoppingDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product =_context.Products.SingleOrDefault(x=>x.ProductId==ProductId);
             if(product is null)
                throw new InvalidOperationException("Ürün Bulunamadı");

            product.Price = updateProductModel.Price == default? product.Price: updateProductModel.Price;
            product.Genre=updateProductModel.Genre==default? product.Genre:updateProductModel.Genre;
       
            _context.SaveChanges();


        }
    }
    public class UpdateProductModel
    {
        public double Price{get;set;}
        public string Genre{get;set; }


        
    }
}