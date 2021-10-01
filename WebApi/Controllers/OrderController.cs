using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.CustomerOperations.Commands.CreateCustomer;
using WebApi.Applications.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Applications.CustomerOperations.Commands.UpdateCustomer;
using WebApi.Applications.CustomerOperations.Queries.GetCustomer;
using WebApi.Applications.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.Applications.OrderOperations.Commands.CreateOrder;
using WebApi.Applications.OrderOperations.Commands.DeleteOrder;
using WebApi.Applications.OrderOperations.Commands.UpdateOrder;
using WebApi.Applications.OrderOperations.Queries.GetOrder;
using WebApi.Applications.OrderOperations.Queries.GetOrderDetail;
using WebApi.DBOperations;
using static WebApi.Applications.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace WebApi.Controllers
{   
   
    [ApiController]
    [Route("[controller]s")]
    public class OrderController:ControllerBase
    {
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            GetOrderQuery query=new GetOrderQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            OrderDetailViewModel result;
            GetOrderDetailQuery query=new GetOrderDetailQuery(_context,_mapper);
            query.OrderId=id;
            GetOrderDetailQueryValidator validator=new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand command=  new CreateOrderCommand(_context,_mapper);
            command.orderModel=newOrder;
            CreateOrderCommandValidator validator=new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id,[FromBody]UpdateOrderModel orderModel )
        {
            UpdateOrderCommand command=new UpdateOrderCommand(_context);
            command.OrderId=id;
            command.updateorderModel=orderModel;
            UpdateOrderCommandValidator validator= new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command= new DeleteOrderCommand(_context);
            command.OrderId=id;
            DeleteOrderCommandValidator validator= new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}