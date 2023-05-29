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
        {}
        [FunctionName("WebAppTest")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

        // string responseMessage = "<html><body><h1>Hello World</html></body></h1>";

        string htmlFilePath = "/workspaces/mvc2/Views/WebAppPage.html";
        string htmlContent = File.ReadAllText(htmlFilePath);

        return new ContentResult
        {
            Content = htmlContent,
            ContentType = "text/html",
            StatusCode = 200
        };

        }
    }
}
