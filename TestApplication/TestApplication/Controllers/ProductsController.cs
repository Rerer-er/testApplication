using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pact;
using Entities.Models;
using Entities.ModelsDto;
using ActionDB;
using AutoMapper;


namespace TestApplication.Controllers
{
    //[Route("api/companies/{companyId}/employees")]
    [Route("api/kinds/{KindId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        public ProductsController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper)
        {
            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetProducts(int kindId)
        {

            var products = _modelsActions.Product.GetAllProducts(kindId);
            var productsDto = _mapper.Map<IEnumerable<ReturnProductDto>>(products);
            return Ok(productsDto);
        }
        [HttpGet("{id}", Name = " ProductById")]
        public IActionResult GetProduct(int kindId, int id)
        {
            var product = _modelsActions.Product.GetProduct(kindId, id);
            if (product == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var productDto = _mapper.Map<ReturnProductDto>(product);
                return Ok(productDto);
            }
        }

        [HttpPost]
        public IActionResult AddProduct(int kindId, [FromBody]CreateProductDto productDto)
        {
            if(productDto == null)
            {
                _logger.LogError("ProductDto object sent from client is null.");
                return BadRequest("ProductnDto object is null");
            }
            var product = _mapper.Map<Product>(productDto);
            product.ShipperId = 1;
            _modelsActions.Product.CreateProduct(kindId, product);
            _modelsActions.Save();

            var ReturnProduct = _mapper.Map<ReturnProductDto>(product);
            return Ok(ReturnProduct);
        }

    }
}
