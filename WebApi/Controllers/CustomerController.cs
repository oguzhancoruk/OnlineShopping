using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.CustomerOperations.Commands.CreateCustomer;
using WebApi.Applications.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Applications.CustomerOperations.Commands.UpdateCustomer;
using WebApi.Applications.CustomerOperations.Queries.GetCustomer;
using WebApi.Applications.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.DBOperations;
using static WebApi.Applications.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace WebApi.Controllers
{   
   
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController:ControllerBase
    {
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public CustomerController(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            GetCustomerQuery query=new GetCustomerQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CustomerDetailViewModel result;
            GetCustomerDetailQuery query=new GetCustomerDetailQuery(_context,_mapper);
            query.CustomerId=id;
            GetCustomerDetailQueryValidator validator=new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command=  new CreateCustomerCommand(_context,_mapper);
            command.Model=newCustomer;
            CreateCustomerCommandValidator validator=new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id,[FromBody]UpdateCustomerModel customerNodel )
        {
            UpdateCustomerCommand command=new UpdateCustomerCommand(_context);
            command.CustomerId=id;
            command.updateCustomerModel=customerNodel;
            UpdateCustomerCommandValidator validator= new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command= new DeleteCustomerCommand(_context);
            command.CustomerId=id;
            DeleteCustomerCommandValidator validator= new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}