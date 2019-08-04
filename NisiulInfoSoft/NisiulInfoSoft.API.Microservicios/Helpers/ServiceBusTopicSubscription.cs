﻿using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NisiulInfoSoft.API.Microservicios.Helpers
{
    public interface IServiceBusTopicSubscription
    {
        Task PrepareFiltersAndHandleMessages();
        Task CloseSubscriptionClientAsync();
    }

    public interface IProcessData
    {
        void Process(Pedido myPayload);
    }

    public class ServiceBusTopicSubscription : IServiceBusTopicSubscription
    {
        private readonly IProcessData _processData;
        private readonly IConfiguration _configuration;
        private readonly SubscriptionClient _subscriptionClient;
        private const string TOPIC_PATH = "enviapedido";
        private const string SUBSCRIPTION_NAME = "enviosql";
        private readonly ILogger _logger;

        public ServiceBusTopicSubscription(IProcessData processData,
            IConfiguration configuration,
            ILogger<ServiceBusTopicSubscription> logger)
        {
            _processData = processData;
            _configuration = configuration;
            _logger = logger;

            _subscriptionClient = new SubscriptionClient(
                //_configuration.GetConnectionString("ServiceBusConnectionString"),
                "Endpoint=sb://busgalaxylema.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=nMmVHcnIqrHgD6e1P/RPGHtMyGBtPKysZkbNMqz3JMY=",
                TOPIC_PATH,
                SUBSCRIPTION_NAME);
        }

        public async Task PrepareFiltersAndHandleMessages()
        {
            //await RemoveDefaultFilters();
            //await AddFilters();

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
            };

            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task RemoveDefaultFilters()
        {
            try
            {
                var rules = await _subscriptionClient.GetRulesAsync();
                foreach (var rule in rules)
                {
                    if (rule.Name == RuleDescription.DefaultRuleName)
                    {
                        await _subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }
        }

        private async Task AddFilters()
        {
            try
            {
                var rules = await _subscriptionClient.GetRulesAsync();

                if (rules.Any(r => r.Name == "GoalsGreaterThanSeven"))
                {
                    await _subscriptionClient.RemoveRuleAsync("GoalsGreaterThanSeven");
                }

                var filter = new SqlFilter("totalVenta > 1000");
                await _subscriptionClient.AddRuleAsync("GoalsGreaterThanSeven", filter);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
            }
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var myPayload = JsonConvert.DeserializeObject<Pedido>(Encoding.UTF8.GetString(message.Body));
            //await _processData.Process(myPayload);
            _processData.Process(myPayload);
            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.LogError(exceptionReceivedEventArgs.Exception, "Message handler encountered an exception");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            _logger.LogDebug($"- Endpoint: {context.Endpoint}");
            _logger.LogDebug($"- Entity Path: {context.EntityPath}");
            _logger.LogDebug($"- Executing Action: {context.Action}");

            return Task.CompletedTask;
        }

        public async Task CloseSubscriptionClientAsync()
        {
            await _subscriptionClient.CloseAsync();
        }
    }
}
