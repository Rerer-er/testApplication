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

namespace TestApplication.Controllers
{

    [Route("test")]
    [ApiController]  
    public class TestsController : ControllerBase
    {
        private string allMessage;
        private IConnection _connection;
        private IModel _channel;
        private ManualResetEvent _resetEvent = new ManualResetEvent(false);
        static readonly string _url = "amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl";

        //[HttpGet(Name = "GetKinds"), Authorize]
        [HttpGet]
        public IActionResult GetValues()
        {
            // CloudAMQP URL in format amqp://user:pass@hostName:port/vhost
            var url = _url;
            // create a connection and open a channel, dispose them when done
            var factory = new ConnectionFactory
            {
                Uri = new Uri(url)
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // ensure that the queue exists before we access it
            var queueName = "queue1";
            bool durable = false;
            bool exclusive = false;
            bool autoDelete = true;

            _channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

            var consumer = new EventingBasicConsumer(_channel);



            // add the message receive event
            consumer.Received += (model, deliveryEventArgs) =>
            {
                var body = deliveryEventArgs.Body.ToArray();
                // convert the message back from byte[] to a string
                var message = Encoding.UTF8.GetString(body);
                allMessage = $"** Received message: by Consumer thread **";
                // ack the message, ie. confirm that we have processed it
                // otherwise it will be requeued a bit later
                _channel.BasicAck(deliveryEventArgs.DeliveryTag, false);
            };

            // start consuming
            _ = _channel.BasicConsume(consumer, queueName);
            // Wait for the reset event and clean up when it triggers
            _resetEvent.WaitOne();
            _channel?.Close();
            _channel = null;
            _connection?.Close();
            _connection = null;

            return Ok($"You message: {allMessage}");
        }
    }
}
