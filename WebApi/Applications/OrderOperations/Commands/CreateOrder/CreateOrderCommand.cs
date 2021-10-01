using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel orderModel{get;set;}
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderCommand(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        { 
            var order=_context.Orders.SingleOrDefault(x=>x.OrderId==orderModel.OrderId);
            if(order is not null)
            throw new InvalidOperationException("Sipariş mevcut");
            order=_mapper.Map<Order>(orderModel);
            _context.Orders.Add(order);
            _context.SaveChanges();

        }
    }

    public class CreateOrderModel
    {   
         public int OrderId{get;set;}
        public string Genre{get;set;}
        public int CustomerId{get;set;}
        public double Invoice{get;set;}

    }
}