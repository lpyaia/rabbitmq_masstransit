using MassTransit;
using Newtonsoft.Json;
using Shared.Models.Models;
using System;
using System.Threading.Tasks;

namespace TicketProcessor.Microservice.Consumers
{
    public class RecurringConsumer : IConsumer<Recurring>
    {
        public async Task Consume(ConsumeContext<Recurring> context)
        {
            var data = context.Message;
            Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}