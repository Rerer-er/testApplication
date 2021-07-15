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
using Microsoft.AspNetCore.JsonPatch;
using Entities.RequestFeatures;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using Entities.Сurrency;

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

        private readonly ICurrencyConverter _currencyConverter;

        //private IMemoryCache _memoryCache;

        public ProductsController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper, ICurrencyConverter currencyConverter) { 

            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;
            _currencyConverter = currencyConverter;

        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(int kindId, [FromQuery] ProductParameters productParameters)
        {
            _currencyConverter.UpdateCurrency();
            productParameters.MinPrice = _currencyConverter.ConvertToCurrentForFiltr(productParameters.MinPrice, productParameters.Currency);
            productParameters.MaxPrice = _currencyConverter.ConvertToCurrentForFiltr(productParameters.MaxPrice, productParameters.Currency);
            
            var products = await _modelsActions.Product.GetAllProductsAsync(kindId, productParameters, false);
            
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
            
            foreach(var product in products)
            {
                _currencyConverter.ConvertToCurrent(product, productParameters.Currency);
            }

            var productsDto = _mapper.Map<IEnumerable<ReturnProductDto>>(products);
            return Ok(productsDto);
        }
        [HttpGet("{id}", Name = " ProductById")]
        public async Task<IActionResult> GetProduct(int kindId,int id, string currency)
        {

            _currencyConverter.UpdateCurrency();
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, false);
            _currencyConverter.ConvertToCurrent(product, currency);
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
        public async Task<IActionResult> CreateProduct(int kindId, [FromBody]CreateProductDto productDto)
        {
            if(productDto == null)
            {
                _logger.LogError("ProductDto object sent from client is null.");
                return BadRequest("ProductnDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var product = _mapper.Map<Product>(productDto);
            product.ShipperId = 1;
            _modelsActions.Product.CreateProduct(kindId, product);
            await _modelsActions.SaveAsync();

            var ReturnProduct = _mapper.Map<ReturnProductDto>(product);
            return Ok(ReturnProduct);
        }
        [HttpDelete("{id}", Name = " ProductById")]
        public async Task<IActionResult> DeleteProduct(int kindId, int id)
        {
            var kind = await _modelsActions.Kind.GetKindAsync(kindId, false);
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var product = await _modelsActions.Product.GetProductAsync(kindId, id, false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _modelsActions.Product.DeleteProduct(product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int kindId, int id, [FromBody] UpdateProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError("UpdateProductDto object sent from client is null.");
                return BadRequest("UpdateProductDto object is null");
            }
            var kind = await _modelsActions.Kind.GetKindAsync(kindId, false); ;
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var product = await _modelsActions.Product.GetProductAsync(kindId, id, true);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(productDto, product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(int kindId, int id,
            [FromBody] JsonPatchDocument<UpdateProductDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            var kind = await _modelsActions.Kind.GetKindAsync(kindId, false);
            if (kind == null)
            {
                _logger.LogInfo($"Company with id: {kindId} doesn't exist in the database.");
                return NotFound();
            }
            var product = await  _modelsActions.Product.GetProductAsync(kindId, id, true);
            if (product == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var productToPatch = _mapper.Map<UpdateProductDto>(product);
            patchDoc.ApplyTo(productToPatch);
            _mapper.Map(productToPatch, product);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

    }
}
