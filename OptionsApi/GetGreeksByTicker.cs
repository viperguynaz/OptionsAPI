using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
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
            [HttpTrigger(AuthorizationLevel.Anonymous,
            "get",
            Route = "GetGreeksByTicker/{ticker:alpha:required}")] HttpRequestData req,
            string ticker,
            string expiration)
        {
            _logger.LogInformation($"request for Ticker: {ticker} | Expiration: {expiration}");
            var url = $"{urlBase}/options/{ticker}.US?api_token={apiKey}&fmt=json";

            var greeksResponse = await client.GetFromJsonAsync<EodOptionsResponse>(url);

            var csv = new StringBuilder();

            foreach (PropertyInfo prop in greeksResponse.Data[0]?.Options.Put[0].GetType().GetProperties())
            {
                csv.AppendFormat("{0}, ", prop.Name);
            }
            csv.Remove(csv.Length - 2, 2);
            csv.AppendLine();
            foreach(var datum in greeksResponse.Data)
            {
                foreach (var put in datum.Options.Put ?? new List<EodOptions.Put>())
                {
                    foreach (PropertyInfo prop in put.GetType().GetProperties())
                    {
                        var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        if (type == typeof(double?))
                        {
                            csv.AppendFormat("{0, 0.0}, ", prop.GetValue(put));
                        } else if (type == typeof(int?))
                        {
                            csv.AppendFormat("{0, 0}, ", prop.GetValue(put));
                        } else 
                        {
                            var x = prop.GetValue(put);
                            csv.AppendFormat("{0}, ", x);
                        }

                    }
                    csv.Remove(csv.Length - 2, 2);
                    csv.AppendLine();
                }
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/csv; charset=utf-8");
            response.WriteString(csv.ToString());
            return response;
        }
    }
}
