using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Publisher.Model;
using System;
using System.Threading.Tasks;

namespace Publisher
{
    public static class Publisher
    {
        [FunctionName("Publisher")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Publisher/Start")] HttpRequest req,
            [ServiceBus("oa-func-test-topic", Connection = "ServiceBusConnectionString")] IAsyncCollector<PieceOfData> topicCollector,
            ILogger logger)
        {
            logger.LogInformation("Starting Service Bus test");

             int count = Int32.Parse(req.Query["count"]);

            for (int i = 0; i < count; i++)
            {
                await topicCollector.AddAsync(new PieceOfData {Id = Guid.NewGuid(), Name = i.ToString()});
            }

            logger.LogInformation("Service Bus test executed successfully");
        }
    }
}
