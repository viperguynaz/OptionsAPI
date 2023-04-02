using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using static OptionsApi.EodOptions;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;

namespace OptionsApi
{
    public class Greeks2Blob
    {
        private readonly ILogger _logger;
        private const string urlBase = "https://eodhistoricaldata.com/api";
        private const string apiKey = "623b75cf0a9c85.30775135";
        private static HttpClient client = new();

        public Greeks2Blob(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Greeks2Blob>();
        }

        [Function("Greeks2Blob")]
        [BlobOutput("options-data/greeks-{DateTime}.csv", Connection = "options-storage")]
        public async Task<string> Run([TimerTrigger("0 0 5 * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");

            var url = $"{urlBase}/options/QQQ.US?api_token={apiKey}&fmt=json";
            var greeksResponse = await client.GetFromJsonAsync<EodOptionsResponse>(url);

            var csv = new StringBuilder();
            foreach (PropertyInfo prop in greeksResponse.Data[0]?.Options.Put[0].GetType().GetProperties())
            {
                csv.AppendFormat("{0}, ", prop.Name);
            }
            csv.Remove(csv.Length - 2, 2);
            csv.AppendLine();
            foreach (var datum in greeksResponse.Data)
            {
                foreach (var put in datum.Options.Put ?? new List<EodOptions.Put>())
                {
                    foreach (PropertyInfo prop in put.GetType().GetProperties())
                    {
                        var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        if (type == typeof(double?))
                        {
                            csv.AppendFormat("{0, 0.0}, ", prop.GetValue(put));
                        }
                        else if (type == typeof(int?))
                        {
                            csv.AppendFormat("{0, 0}, ", prop.GetValue(put));
                        }
                        else
                        {
                            var x = prop.GetValue(put);
                            csv.AppendFormat("{0}, ", x);
                        }

                    }
                    csv.Remove(csv.Length - 2, 2);
                    csv.AppendLine();
                }
            }

            return csv.ToString();
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
