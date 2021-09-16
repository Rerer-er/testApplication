using MassTransit;
using Pact;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Microservices
{
    public class OrderMicroservice : IOrderMicroservice
    {
        //private readonly IPublishEndpoint _endpoint;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public OrderMicroservice()
        {
            //_endpoint = endpoint;
            _factory = new ConnectionFactory() { Uri = new Uri("amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl") };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }


        public void Publish(string message)
        {
            

            _channel.QueueDeclare("queue1", false, false, false, null);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("", "queue1", null, body);
        }
    }
}
