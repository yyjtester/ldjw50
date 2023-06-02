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

        int result = await Task.Run(PerformCPUIntensiveTask);

        // Display the result
        Console.WriteLine("CPU-bound task completed. Result: " + result);

        // Other code to execute after the CPU-bound task completes
        Console.WriteLine("Main thread is continuing to execute.");

        // Wait for user input to exit the program
        Console.ReadLine();

        }
        
        public static int PerformCPUIntensiveTask()
    {
        // Simulate a CPU-bound task by performing a large calculation
        int result = 0;
        for (int i = 0; i < 100000000; i++)
        {
            result += i;
        }

        return result;
    }
    }

    
}
