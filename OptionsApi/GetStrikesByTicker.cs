using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace OptionsApi
{
    public class GetStrikesByTicker
    {
        private readonly ILogger _logger;
        private const string urlBase = "https://query1.finance.yahoo.com/v7/finance/options/";
        private static readonly HttpClient client = new HttpClient();
        private const int numTicks = 25;

        public GetStrikesByTicker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetStrikesByTicker>();
        }

        [Function("GetStrikesByTicker")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "GetStrikesByTicker/{ticker:alpha:required}/{ticks:long?}")] HttpRequestData req,
            string ticker,
            long? ticks)
        {
            _logger.LogInformation($"request for Ticker: {ticker} | Ticks: {ticks}");

            if (!ticks.HasValue) ticks = 6;
            var url = $"{urlBase}/{ticker}";

            //var optionsResponse = await client.GetFromJsonAsync<YahooResponse>(url);
            //var options = new List<YahooResponse>();
            //options.Add(optionsResponse);
            //var expirations = optionsResponse.OptionChain.Result[0].ExpirationDates.Take((int)ticks.Value).ToList();
            //var strike = (int)Math.Round(optionsResponse.OptionChain.Result[0].Quote.RegularMarketPrice);

            //for (int i = 1; i < ticks; i++)
            //{
            //    optionsResponse = await client.GetFromJsonAsync<YahooResponse>($"{url}?date={expirations[i]}");
            //    options.Add(optionsResponse);
            //}

            //var csv = new StringBuilder();

            //for (int x = strike - numTicks; x <= strike + numTicks; x++)
            //{
            //    csv.AppendFormat("{0:0.00}", x);
            //    for (int y = 0; y < ticks; y++)
            //    {
            //        // refactor as dynamic for ticks
            //        var oi = options[y].OptionChain.Result[0].Options[0].Calls.Where(c => c.Strike == x).FirstOrDefault()?.OpenInterest ?? 0;
            //        csv.AppendFormat(",{0,0}", oi);
            //    }
            //    for (int y = 0; y < ticks; y++)
            //    {
            //        // refactor as dynamic for ticks
            //        var oi = -options[y].OptionChain.Result[0].Options[0].Puts.Where(p => p.Strike == x).FirstOrDefault()?.OpenInterest ?? 0;
            //        csv.AppendFormat(",{0,0}", oi);
            //    }
            //    csv.AppendLine();
            //}

            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new StringContent(csv.ToString(), Encoding.UTF8, "text/csv")
            //};

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
