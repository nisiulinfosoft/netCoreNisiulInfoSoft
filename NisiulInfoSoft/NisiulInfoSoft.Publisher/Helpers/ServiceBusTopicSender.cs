using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.Publisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NisiulInfoSoft.Publisher.Helpers
{
    public class ServiceBusTopicSender
    {
        private readonly TopicClient _topicClient;
        private readonly IConfiguration _configuration;
        //private const string TOPIC_PATH = "enviapedido";
        private readonly ILogger _logger;
        private readonly ParametroConfig _config;

        public ServiceBusTopicSender(
            IConfiguration configuration,
            ILogger<ServiceBusTopicSender> logger,
            IOptions<ParametroConfig> config)
        {
            _configuration = configuration;
            _logger = logger;
            _config = config.Value;
            _topicClient = new TopicClient(
                _config.BusUrl, _config.BusTopic);
            //_topicClient = new TopicClient(
            //    "Endpoint=sb://busgalaxymasp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=6TbmpDVgjfUEfPLpMkcoXjMlUqd0e+hjCtOVxyv4IuI=",
            //    TOPIC_PATH);

        }

        public async Task SendMessage(Pedido payload)
        {
            string data = JsonConvert.SerializeObject(payload);
            Message message = new Message(Encoding.UTF8.GetBytes(data));
            //message.UserProperties.Add("totalVenta", payload.PrecioUnitario * payload.Cantidad);

            try
            {
                await _topicClient.SendAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
