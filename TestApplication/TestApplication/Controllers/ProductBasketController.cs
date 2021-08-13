using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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

        private readonly IAuthenticationManager _authManager;

        private readonly UserManager<User> _userManager;


        public ProductBasketController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper, 
               ICurrencyConverter currencyConverter, IAuthenticationManager authManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;
            _currencyConverter = currencyConverter;
            _authManager = authManager;
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
        public async Task<IActionResult> CreateProduct(int productId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var productsBasket = new ProductBasket()
            {
                ProductId = productId,
                UserId = user.Id,
            };
            _modelsActions.Basket.CreateProductBasket(productsBasket);
            await _modelsActions.SaveAsync();
            return Ok(user);
        }
    }
}
