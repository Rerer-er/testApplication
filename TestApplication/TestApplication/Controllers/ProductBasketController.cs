using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBasketController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        private readonly ICurrencyConverter _currencyConverter;

        public ProductBasketController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper, ICurrencyConverter currencyConverter)
        {

            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;
            _currencyConverter = currencyConverter;

        }
        [HttpGet]
        //[ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> GetProduct(string userId)
        {
            var productsBasket = await _modelsActions.Basket.GetsProductsBasketAsync(userId, false);

            return Ok(productsBasket);
        }

        /// <summary>
        /// Creating a product
        /// </summary>
        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //[ServiceFilter(typeof(ValidateProductExistsAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> CreateProduct(string userId, int productId)
        {
            var productsBasket = new ProductBasket()
            {
                ProductId = productId,
                UserId = userId,
            };
            _modelsActions.Basket.CreateProductBasket(productsBasket);
            await _modelsActions.SaveAsync();
            return Ok(productsBasket);
        }
    }
}
