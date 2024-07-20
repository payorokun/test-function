using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TestFunction
{
    public class TestFunctionBlobTrigger(ILogger<TestFunctionBlobTrigger> logger)
    {
        [Function(nameof(TestFunctionBlobTrigger))]
        public async Task Run([BlobTrigger("publisher-files/{name}", Connection = "TriggerFileStorage")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
