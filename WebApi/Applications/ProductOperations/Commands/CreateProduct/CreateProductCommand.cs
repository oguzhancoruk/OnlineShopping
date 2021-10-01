using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommand
    {   
         public CreateProductModel productModel{get;set;}
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCommand(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
             var product=_context.Products.SingleOrDefault(x=>x.ProductId==productModel.ProductId);
            if(product is not null)
            throw new InvalidOperationException("Örün mevcut değil");
            product=_mapper.Map<Product>(productModel);
            _context.Products.Add(product);
            _context.SaveChanges();

        }

    }

    public class CreateProductModel
    {
        public int ProductId{get;set;}
        public double Price{get;set;}
        public string genre{get;set; }
    }
}