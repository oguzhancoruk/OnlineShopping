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
using WebApi.Applications.ProductOperations.Commands.CreateProduct;
using WebApi.Applications.ProductOperations.Commands.DeleteProduct;
using WebApi.Applications.ProductOperations.Commands.UpdateOrder;
using WebApi.Applications.ProductOperations.Queries.GetDetailProduct;
using WebApi.Applications.ProductOperations.Queries.GetProduct;
using WebApi.DBOperations;
using static WebApi.Applications.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace WebApi.Controllers
{   
   
    [ApiController]
    [Route("[controller]s")]
    public class ProductController:ControllerBase
    {
        private readonly IOnlineShoppingDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(IOnlineShoppingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            GetProductQuery query=new GetProductQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductDetailViewModel result;
            GetProductDetailQuery query=new GetProductDetailQuery(_context,_mapper);
            query.ProductId=id;
            GetProductDetailQueryValidator validator=new GetProductDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductModel newProduct)
        {
            CreateProductCommand command=  new CreateProductCommand(_context,_mapper);
            command.productModel=newProduct;
            CreateProductCommandValidator validator=new CreateProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,[FromBody]UpdateProductModel productModel )
        {
            UpdateProductCommand command=new UpdateProductCommand(_context);
            command.ProductId=id;
            command.updateProductModel=productModel;
            UpdateProductCommandValidator validator= new UpdateProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            DeleteProductCommand command= new DeleteProductCommand(_context);
            command.ProductId=id;
            DeleteProductCommandValidator validator= new DeleteProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}