using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace OptionsApi
{
    public class GetGreeksByTicker
    {
        private readonly ILogger _logger;
        private const string urlBase = "https://api.nasdaq.com/api/quote/";
        private static readonly HttpClient client = new HttpClient();

        public GetGreeksByTicker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetGreeksByTicker>();
        }

        [Function("GetGreeksByTicker")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,
            "get",
            Route = "GetGreeksByTicker/{ticker:alpha:required}/{expiration:regex(^\\d{{4}}-\\d{{2}}-\\d{{2}}):required}")] HttpRequestData req,
            string ticker,
            string expiration,
            ILogger log)
        {
            _logger.LogInformation($"request for Ticker: {ticker} | Expiration: {expiration}");
            var url = $"{urlBase}{ticker}/option-chain/greeks?assetclass=etf&date={expiration}";

            //var response = await client.GetAsync(url);

            //var greeksResponse = await client.GetFromJsonAsync<GreeksResponse>(url);
            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //   // Content = new StringContent(JsonSerializer.Serialize(greeksResponse), Encoding.UTF8, "application/json")
            //};

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;


        }
    }
}
