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
            //var factory = new ConnectionFactory() { Uri = new Uri("amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl") };
            //using (var connection = _factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {

            _channel.QueueDeclare("queue1", false, false, false, null);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("", "queue1", null, body);
            //    }
            //}
            //await _endpoint.Publish<string>(message);
        }





        //private readonly string _url = "amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl";
        //private readonly string queueName = "queue1";
        //IModel channel;
        //public OrderMicroservice()
        //{
        //    var factory = new ConnectionFactory
        //    {
        //        Uri = new Uri(_url)
        //    };

        //    using var connection = factory.CreateConnection();
        //    channel = connection.CreateModel();

        //    bool durable = false;
        //    bool exclusive = false;
        //    bool autoDelete = false;
        //    channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);
        //}
        //public async Task PublishOrder()
        //{
        //    var message = "fddfgdfgdfgsfsd" + "    #";
        //    // the data put on the queue must be a byte array
        //    var data = Encoding.UTF8.GetBytes(message);
        //    // publish to the "default exchange", with the queue name as the routing key
        //    var exchangeName = "";
        //    var routingKey = queueName;
        //    //Console.WriteLine(message);

        //    channel.BasicPublish(exchangeName, routingKey, null, data);
        //}

    }
}
