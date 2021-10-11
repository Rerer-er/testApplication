using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ActionFilters;

namespace TestApplication.Controllers
{
    //[Route("api/companies/{companyId}/employees")]
    [Route("kinds/{kindId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        private readonly ICurrencyConverter _currencyConverter;

        public ProductsController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper, ICurrencyConverter currencyConverter)
        {

            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;
            _currencyConverter = currencyConverter;

        }

        ///<summary>
        ///Gets the list of all products.
        ///</summary>

        [HttpGet]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> GetProducts(int kindId, [FromQuery] ProductParameters productParameters)
        {
            productParameters.MinPrice = _currencyConverter.ConvertToCurrentForFiltr(productParameters.MinPrice, productParameters.Currency);
            productParameters.MaxPrice = _currencyConverter.ConvertToCurrentForFiltr(productParameters.MaxPrice, productParameters.Currency);

            var products = await _modelsActions.Product.GetAllProductsAsync(kindId, productParameters, false);

            foreach (var product in products)
            {
                _currencyConverter.ConvertToCurrent(product, productParameters.Currency);
            }

            var productsDto = _mapper.Map<IEnumerable<ReturnProductDto>>(products);
            ReturnProductAndCountDto retProducts = new ReturnProductAndCountDto();

            retProducts.ProductsDto = productsDto;
            retProducts.CountPage = products.MetaData.TotalPages;
            retProducts.CurrentPage = products.MetaData.CurrentPage;

            return Ok(retProducts);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        [HttpGet("{id}", Name = " ProductById")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> GetProduct(int kindId, int id, string currency = "rub")
        {
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
            _modelsActions.Product.CreateProduct(kindId, product);
            await _modelsActions.SaveAsync();

            var returnProduct = _mapper.Map<ReturnProductDto>(product);
            return Ok(returnProduct);
        }

        /// <summary>
        /// Updating a product
        /// </summary>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> UpdateProduct(int kindId, int id, [FromBody] UpdateProductDto productDto)
        {
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, true);
            _mapper.Map(productDto, product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Deleting a product
        /// </summary>
        [HttpDelete("{id}")]
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

            var product = await _modelsActions.Product.GetProductAsync(kindId, id, true);

            var productToPatch = _mapper.Map<UpdateProductDto>(product);
            patchDoc.ApplyTo(productToPatch);
            _mapper.Map(productToPatch, product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
    }
}
