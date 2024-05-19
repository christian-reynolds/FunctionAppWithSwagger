using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

public static class MyFunction
{
    [FunctionName("MyFunction")]
    [OpenApiOperation(operationId: "Run", tags: new[] { "MyFunction" })]
    [OpenApiRequestBody("application/json", typeof(RequestModel))]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseModel), Description = "The OK response")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<RequestModel>(requestBody);

        return new OkObjectResult(new ResponseModel { Message = "Hello, " + data.Name });
    }
}

public class RequestModel
{
    public string Name { get; set; }
}

public class ResponseModel
{
    public string Message { get; set; }
}
