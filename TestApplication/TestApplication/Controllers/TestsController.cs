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
        [HttpGet]
        public IActionResult GetValues()
        {
            _orderMicroservice.Publish("123");




            //var factory = new ConnectionFactory() { Uri = new Uri( "amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl") };
            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
                    
            //        channel.QueueDeclare("queue1", false, false, false, null);
            //        var body = Encoding.UTF8.GetBytes("fdgdfg");
            //        channel.BasicPublish("", "queue1", null, body);
            //    }
            //}
            return Ok($"");
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
            string json = JsonSerializer.Serialize<Order>(order);

            _orderMicroservice.Publish(json);



            return Ok($"");
        }
    }
}
