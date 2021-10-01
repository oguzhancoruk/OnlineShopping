using AutoMapper;
using WebApi.Applications.CustomerOperations.Queries.GetCustomer;
using WebApi.Applications.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.Applications.OrderOperations.Commands.CreateOrder;
using WebApi.Applications.OrderOperations.Queries.GetOrder;
using WebApi.Applications.OrderOperations.Queries.GetOrderDetail;
using WebApi.Applications.ProductOperations.Commands.CreateProduct;
using WebApi.Applications.ProductOperations.Queries.GetProduct;
using WebApi.Entities;
using static WebApi.Applications.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace WebApi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
        
            CreateMap<Customer,CustomerDetailViewModel>().ForMember(dest=>dest.Invoice,opt=>opt.MapFrom(src=>src.Order.Product.Price));
            CreateMap<Customer,CustomerViewModel>().ForMember(dest=>dest.Invoice,opt=>opt.MapFrom(src=>src.Order.Product.Price));
            CreateMap<CreateCustomerModel,Customer>();

            CreateMap<Order,OrderDetailViewModel>();
            CreateMap<Order,OrderViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Product.Genre)).ForMember(dest=>dest.Invoice,opt=>opt.MapFrom(src=>src.Product.Price ) );
            CreateMap<CreateOrderModel,Order>();

            CreateMap<Product,ProductDetailViewModel>();
            CreateMap<Product,ProductViewModel>();
            CreateMap<CreateProductModel,Product>();
            
              
        }

    }
}