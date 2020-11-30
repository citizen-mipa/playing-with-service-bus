using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Publisher
{
    public static class Publisher
    {
        [FunctionName("Publisher")]
        [return: ServiceBus("myqueue", Connection = "ServiceBusConnection")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Publisher/Start")] HttpRequest req, ILogger logger)
        {
            logger.LogInformation("Starting Service Bus test");


            logger.LogInformation("Service Bus test executed successfully");

            return new OkObjectResult(null);
        }
    }
}
