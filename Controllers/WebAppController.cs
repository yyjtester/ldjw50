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

        // Start the asynchronous operation
        Task<int> task = PerformAsyncOperation();

        // Other code to execute while the asynchronous operation is in progress
        Console.WriteLine("Other work on the main thread.");

        // Await the completion of the asynchronous operation
        int result = await task;

        // Display the result
        Console.WriteLine("Async operation completed. Result: " + result);

        Console.WriteLine("Main thread finished.");

        }
        
    public static async Task<int> PerformAsyncOperation()
    {
        // Simulate some asynchronous work
        await Task.Delay(2000); // Delay for 2 seconds

        // Return a result
        return 42;
    }
    }

    
}
