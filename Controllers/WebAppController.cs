using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace myNamespace
{
    public static class WebAppTest
    {

        public static void Main(string[] args)
        {
            // included to keep errors away
        }
        [FunctionName("WebAppTest")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

        string htmlFilePath = "/workspaces/mvc2/Views/WebAppPage.html";
        string htmlContent = File.ReadAllText(htmlFilePath);

        return new ContentResult
        {
            Content = htmlContent,
            ContentType = "text/html",
            StatusCode = 200
        };

        var result = await SomeAsyncOperation();
        return new OkObjectResult($"Result: {result}");

        }
    private static async Task<string> SomeAsyncOperation()
    {
        // Perform your asynchronous logic here
        await Task.Delay(1000); // Example delay of 1 second

        return "Async operation completed";
    }
        
    }

    
}
