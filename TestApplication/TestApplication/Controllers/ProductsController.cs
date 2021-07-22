using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pact;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ActionFilters;

namespace TestApplication.Controllers
{
    //[Route("api/companies/{companyId}/employees")]
    [Route("api/kinds/{kindId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        private readonly ICurrencyConverter _currencyConverter;

        //private IMemoryCache _memoryCache;

        public ProductsController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper, ICurrencyConverter currencyConverter)
        {

            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;
            _currencyConverter = currencyConverter;

        }

        // <summary>
        /// Gets the list of all products
        /// <summary>
        [HttpGet]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> GetProducts(int kindId, [FromQuery] ProductParameters productParameters)
        {
            _currencyConverter.UpdateCurrency();
            productParameters.MinPrice = _currencyConverter.ConvertToCurrentForFiltr(productParameters.MinPrice, productParameters.Currency);
            productParameters.MaxPrice = _currencyConverter.ConvertToCurrentForFiltr(productParameters.MaxPrice, productParameters.Currency);

            var products = await _modelsActions.Product.GetAllProductsAsync(kindId, productParameters, false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));

            foreach (var product in products)
            {
                _currencyConverter.ConvertToCurrent(product, productParameters.Currency);
            }

            var productsDto = _mapper.Map<IEnumerable<ReturnProductDto>>(products);
            return Ok(productsDto);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        [HttpGet("{id}", Name = " ProductById")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> GetProduct(int kindId, int id, string currency = "rub")
        {
            _currencyConverter.UpdateCurrency();
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, false);
            
            _currencyConverter.ConvertToCurrent(product, currency);
            var productDto = _mapper.Map<ReturnProductDto>(product);
            return Ok(productDto);
        }

        /// <summary>
        /// Creating a product
        /// </summary>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> CreateProduct(int kindId, [FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError("ProductDto object sent from client is null.");
                return BadRequest("Invalid data");
            }
            var product = _mapper.Map<Product>(productDto);
            product.ShipperId = 1;
            _modelsActions.Product.CreateProduct(kindId, product);
            await _modelsActions.SaveAsync();

            var ReturnProduct = _mapper.Map<ReturnProductDto>(product);
            return Ok(ReturnProduct);
        }

        /// <summary>
        /// Deleting a product
        /// </summary>
        [HttpDelete("{id}", Name = " ProductById")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> DeleteProduct(int kindId, int id)
        {
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, false);
            
            _modelsActions.Product.DeleteProduct(product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Updating a product
        /// </summary>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> UpdateProduct(int kindId, int id, [FromBody] UpdateProductDto productDto)
        {
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, true);
            _mapper.Map(productDto, product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Updating a product
        /// </summary>
        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> PatchProduct(int kindId, int id,
            [FromBody] JsonPatchDocument<UpdateProductDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            var kind = await _modelsActions.Kind.GetKindAsync(kindId, false);
            
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, true);
            
            var productToPatch = _mapper.Map<UpdateProductDto>(product);
            patchDoc.ApplyTo(productToPatch);
            _mapper.Map(productToPatch, product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

    }
}
