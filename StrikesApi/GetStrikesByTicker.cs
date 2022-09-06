using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net;
using YahooOptions;

namespace StrikesApi
{
    public static class GetStrikesByTicker
    {
        private const string urlBaseYahoo = "https://query1.finance.yahoo.com/v7/finance/options/";
        private const string urlBaseViper = "https://viperoptions.azurewebsites.net/api/";
        private static readonly HttpClient client = new HttpClient();
        private static long expiration;
        private const int numTicks = 25;

        [FunctionName("GetStrikesByTicker")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{ticker:alpha:required}/{ticks:long?}")] HttpRequest req,
            string ticker,
            long? ticks,
            ILogger log)
        {
            log.LogInformation($"request for Ticker: {ticker} | Ticks: {ticks}");

            if (!ticks.HasValue) ticks = 6;
            var url = $"{urlBaseViper}/{ticker}";

            var optionsResponse = await client.GetFromJsonAsync<YahooResponse>(url);
            var options = new List<YahooResponse>();
            options.Add(optionsResponse);
            var expirations = optionsResponse.OptionChain.Result[0].ExpirationDates.Take((int)ticks.Value).ToList();
            var strike = (int)Math.Round(optionsResponse.OptionChain.Result[0].Quote.RegularMarketPrice);

            for (int i = 1; i < ticks; i++)
            {
                optionsResponse = await client.GetFromJsonAsync<YahooResponse>($"{url}/{expirations[i]}");
                options.Add(optionsResponse);
            }

            var csv = new StringBuilder();

            for (int x = strike - numTicks; x <= strike + numTicks; x++)
            {
                csv.AppendFormat("{0:0.00}", x);
                for (int y = 0; y < ticks; y++)
                {
                    // refactor as dynamic for ticks
                    var oi = options[y].OptionChain.Result[0].Options[0].Calls.Where(c => c.Strike == x).FirstOrDefault()?.OpenInterest ?? 0;
                    csv.AppendFormat(",{0,0}", oi);
                }
                for (int y = 0; y < ticks; y++)
                {
                    // refactor as dynamic for ticks
                    var oi = -options[y].OptionChain.Result[0].Options[0].Puts.Where(p => p.Strike == x).FirstOrDefault()?.OpenInterest ?? 0;
                    csv.AppendFormat(",{0,0}", oi);
                }
                csv.AppendLine();
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(csv.ToString(), Encoding.UTF8, "text/csv")
            };
        }
    }
}
