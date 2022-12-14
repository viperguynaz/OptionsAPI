using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Json;
using OptionsApi;

namespace OptionsApi
{
    public static class GetOptionsByTicker
    {
        private const string urlBase = "https://query1.finance.yahoo.com/v7/finance/options/";
        private static readonly HttpClient client = new HttpClient();

        [FunctionName("GetOptionsByTicker")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetOptionsByTicker/{ticker:alpha:required}/{expiration:long?}")] HttpRequest req,
            string ticker,
            long? expiration,
            ILogger log)
        {
            var url = $"{urlBase}{ticker}";
            if (expiration.HasValue) {
                url += $"?date={expiration}";
            }

            log.LogInformation($"request for Ticker: {ticker} | Expiration: {expiration}");

            var optionsResponse = await client.GetFromJsonAsync<YahooResponse>(url);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(optionsResponse), Encoding.UTF8, "application/json")
            };

        }
    }
}
