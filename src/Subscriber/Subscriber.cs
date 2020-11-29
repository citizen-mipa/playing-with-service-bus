using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Subscriber
{
    public static class Subscriber
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("mytopic", "mysubscription", Connection = "connectionstring")]string mySbMsg, ILogger logger)
        {
            logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
