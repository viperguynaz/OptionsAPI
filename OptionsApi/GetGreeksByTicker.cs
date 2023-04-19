using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using CsvHelper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using OptionsData;
using static OptionsApi.EodOptions;

namespace OptionsApi
{
    public class GetGreeksByTicker
    {
        private readonly ILogger _logger;
        private const string urlBase = "https://eodhistoricaldata.com/api";
        private const string apiKey = "623b75cf0a9c85.30775135";
        private static HttpClient client = new();

        public GetGreeksByTicker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetGreeksByTicker>();
        }

        [Function("GetGreeksByTicker")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",
            Route = "GetGreeksByTicker/{ticker:alpha:required}")] HttpRequestData req,
            string ticker, DateTime? from = null, DateTime? to = null)
        {
            _logger.LogInformation("request for Ticker: {ticker}", ticker);
            var url = $"{urlBase}/options/{ticker}.US?api_token={apiKey}&fmt=json";
            if (from.HasValue && to.HasValue)
            {
                url += $"&from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}";
            }

            var greeksResponse = await client.GetFromJsonAsync<EodOptionsResponse>(url);

            List<OptionIngest> optionList = new();
            for (int i = 0; i < greeksResponse.Data.Count; i++)
            {
                if (greeksResponse.Data[i].Options.Calls != null) 
                    optionList.AddRange(greeksResponse.Data[i].Options.Calls.Select(o => new OptionIngest(o)));
                if (greeksResponse.Data[i].Options.Puts != null)
                    optionList.AddRange(greeksResponse.Data[i].Options.Puts.Select(o => new OptionIngest(o)));
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteString(JsonSerializer.Serialize(optionList));
            return response;
        }
    }
}
