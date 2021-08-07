using MassTransit.Scheduling;

namespace Ticketing.Microservice.Configurations
{
    public class PollExternalSystemSchedule : DefaultRecurringSchedule
    {
        public PollExternalSystemSchedule()
        {
            CronExpression = "0 0/1 * 1/1 * ? *"; // this means every minute
        }
    }

    public class PollExternalSystem { }
}