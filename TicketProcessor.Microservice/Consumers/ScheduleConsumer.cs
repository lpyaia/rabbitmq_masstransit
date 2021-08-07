using MassTransit;
using Newtonsoft.Json;
using Shared.Models.Models;
using System;
using System.Threading.Tasks;

namespace TicketProcessor.Microservice.Consumers
{
    public class ScheduleConsumer : IConsumer<Schedule>
    {
        public async Task Consume(ConsumeContext<Schedule> context)
        {
            var data = context.Message;
            Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}