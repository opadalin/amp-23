using System;
using System.Net;
using System.Text;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Functions;

public class GetDataFunction
{
    private readonly ILogger _logger;

    public GetDataFunction(ILoggerFactory loggerFactory)
    {
        ArgumentNullException.ThrowIfNull(loggerFactory);

        _logger = loggerFactory.CreateLogger<GetDataFunction>();
    }

    [Function(nameof(GetDataFunction))]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/{category:alpha}/{id:int?}")]
        HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!", Encoding.UTF8);

        return response;
    }
}