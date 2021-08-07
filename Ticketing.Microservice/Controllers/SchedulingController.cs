using MassTransit;
using MassTransit.Scheduling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMessageScheduler _messageScheduler;

        public SchedulingController(IBus bus, IMessageScheduler messageScheduler)
        {
            _bus = bus;
            _messageScheduler = messageScheduler;
        }

        [HttpPost]
        public async Task<IActionResult> SendScheduleMessage(string userName)
        {
            var schedule = new Schedule { UserName = userName, IntervalToSchedule = 120 };

            var uri = new Uri("rabbitmq://localhost/scheduling");
            await _messageScheduler.ScheduleSend(uri,
                DateTime.UtcNow + TimeSpan.FromSeconds(schedule.IntervalToSchedule),
                schedule);

            return Ok();
        }
    }
}