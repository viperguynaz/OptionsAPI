using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace OptionsApi
{
    public class GetGreeksByTicker
    {
        private readonly ILogger _logger;
        private const string urlBase = "https://api.nasdaq.com/api/quote/";
        private static HttpClient client;

        public GetGreeksByTicker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetGreeksByTicker>();
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            };

            client = new HttpClient(socketsHandler);
        }

        [Function("GetGreeksByTicker")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,
            "get",
            Route = "GetGreeksByTicker/{ticker:alpha:required}/{expiration:regex(^\\d{{4}}-\\d{{2}}-\\d{{2}}):required}")] HttpRequestData req,
            string ticker,
            string expiration)
        {
            _logger.LogInformation($"request for Ticker: {ticker} | Expiration: {expiration}");
            var url = $"{urlBase}{ticker}/option-chain/greeks?assetclass=etf&date={expiration}";


            //var greeksResponse = await client.GetFromJsonAsync<GreeksResponse>(url);

            using HttpResponseMessage greeksResponse = await client.GetAsync(url);
            greeksResponse.EnsureSuccessStatusCode();
            string responseBody = await greeksResponse.Content.ReadAsStringAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteString(JsonSerializer.Serialize(greeksResponse));

            return response;


        }
    }
}
