using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OptionsApi
{
    public static class GetGreeksByTicker
    {
        private const string urlBase = "https://api.nasdaq.com/api/quote/";
        private static readonly HttpClient client = new HttpClient();

        [FunctionName("GetGreeksByTicker")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,
            "GET",
            Route = "GetGreeksByTicker/{ticker:alpha:required}/{expiration:regex(^\\d{{4}}-\\d{{2}}-\\d{{2}}):required}")] HttpRequest req,
            string ticker,
            string expiration,
            ILogger log)
        {
            log.LogInformation($"request for Ticker: {ticker} | Expiration: {expiration}");
            var url = $"{urlBase}{ticker}/option-chain/greeks?assetclass=etf&date={expiration}";

            var greeksResponse = await client.GetFromJsonAsync<GreeksResponse>(url);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(greeksResponse), Encoding.UTF8, "application/json")
            };

        }
    }
}
