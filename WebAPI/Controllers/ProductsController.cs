using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled
        //naming convention
        //IoC Container -- invercion of control (program.cs)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        //public List<Product> Get()
        public IActionResult Get()
        {
            //return "Merhaba";
            //return new List<Product>
            //{
            //    new Product{ ProductID = 1, ProductName="Elma"},
            //    new Product{ ProductID = 2, ProductName="Armut"}
            //};

            //Dependency chain
            //IProductService productService = new ProductManager(new EfProductDal());

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            //return result.Data;
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
