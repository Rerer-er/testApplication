using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;
using System.Text;
using Pact;
using Entities.RequestFeatures;
using AutoMapper;
using Entities.ModelsDto;
using Entities.Models;
using System.Text.Json;

namespace TestApplication.Controllers
{

    [Route("test")]
    [ApiController]  
    public class TestsController : ControllerBase
    {
        private readonly IAllModelsActions _modelsActions;
        private IOrderMicroservice _orderMicroservice;
        private IMapper _mapper;
        public TestsController(IOrderMicroservice orderMicroservice, IAllModelsActions modelsActions, IMapper mapper)
        {
            _orderMicroservice = orderMicroservice;
            _modelsActions = modelsActions;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(int id)
        {
            var kinds = await _modelsActions.Kind.GetKindAsync(id, false);
            var products = await _modelsActions.Product.GetAllProductsAsync(id,new ProductParameters { }, false);
            decimal price = products.Average(n => n.Price);
            

            var productsDto = _mapper.Map<IEnumerable<ReturnProductDto>>(products);
            Order order = new Order
            {
                KindId = kinds.KindId,
                Name = kinds.Name,
                AveragePrice = price,
            };
            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.method = "post";
            string json = JsonSerializer.Serialize<OrderDto>(orderDto);
            
            _orderMicroservice.Publish(json);

            return Ok($"");


        }
        [HttpDelete]
        public IActionResult DeleteOrder(string OrderId)
        {

            Order order = new Order
            {
                _id = OrderId,
            };
            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.method = "delete";
            string json = JsonSerializer.Serialize<OrderDto>(orderDto);

            _orderMicroservice.Publish(json);

            return Ok($"");
        }
        [HttpPut]
        public IActionResult UpdateOrder(string OrderId)
        {
            Order order = new Order
            {
                _id = OrderId,
            };
            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.method = "put";
            string json = JsonSerializer.Serialize<OrderDto>(orderDto);

            _orderMicroservice.Publish(json);

            return Ok($"");
        }
    }
}
