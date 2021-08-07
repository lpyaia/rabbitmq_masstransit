using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Models;
using System;
using System.Threading.Tasks;
using Ticketing.Microservice.Configurations;

namespace Ticketing.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurringMessageController : ControllerBase
    {
        private readonly IBus _bus;

        public RecurringMessageController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> RecurringMessage()
        {
            var message = new Recurring { SendedAt = DateTime.Now };
            var uri = new Uri("rabbitmq://localhost/quartz-scheduler");
            var endpoint = await _bus.GetSendEndpoint(uri);

            await endpoint.ScheduleRecurringSend(
                new Uri("rabbitmq://localhost/recurring"),
                new PollExternalSystemSchedule(),
                message);

            return Ok();
        }
    }
}