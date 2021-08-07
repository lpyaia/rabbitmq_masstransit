using MassTransit;
using Newtonsoft.Json;
using Shared.Models.Models;
using System;
using System.Threading.Tasks;

namespace TicketProcessor.Microservice.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        public async Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}