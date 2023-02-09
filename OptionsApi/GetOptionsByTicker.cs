using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace OptionsApi
{
    public class GetOptionsByTicker
    {
        private readonly ILogger _logger; 
        private const string urlBase = "https://query1.finance.yahoo.com/v7/finance/options/";
        private static readonly HttpClient client = new HttpClient();

        public GetOptionsByTicker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetOptionsByTicker>();
        }

        [Function("GetOptionsByTicker")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "GetOptionsByTicker/{ticker:alpha:required}/{expiration:long?}")] HttpRequestData req,
            string ticker,
            long? expiration)
        {
            var url = $"{urlBase}{ticker}";
            if (expiration.HasValue) {
                url += $"?date={expiration}";
            }

            _logger.LogInformation($"request for Ticker: {ticker} | Expiration: {expiration}");

            //var optionsResponse = await client.GetFromJsonAsync<YahooResponse>(url);

            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new StringContent(JsonSerializer.Serialize(optionsResponse), Encoding.UTF8, "application/json")
            //};

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
