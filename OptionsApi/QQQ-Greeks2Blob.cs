using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using static OptionsApi.EodOptions;
using System.Net.Http.Json;
using OptionsData;
using System.Text.Json;

namespace OptionsApi
{
    public class Greeks2Blob
    {
        private readonly ILogger _logger;
        private const string urlBase = "https://eodhistoricaldata.com/api";
        private const string apiKey = "623b75cf0a9c85.30775135";
        private static readonly HttpClient client = new();

        public Greeks2Blob(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Greeks2Blob>();
        }

        [Function("QQQ-Greeks2Blob")]
        [BlobOutput("qqq-options-historic/qqq-greeks-{DateTime}.json", Connection = "options-storage")]
        public async Task<string> Run([TimerTrigger("0 0 5 * * 1-5")] TimerInfo myTimer)
        {
            _logger.LogInformation("C# Timer trigger function executed at: {now}", DateTime.Now);
            _logger.LogInformation("Next timer schedule at: {time}", myTimer.ScheduleStatus.Next);

            var url = $"{urlBase}/options/QQQ.US?api_token={apiKey}&fmt=json";
            var greeksResponse = await client.GetFromJsonAsync<EodOptionsResponse>(url);

            List<OptionIngest> optionList = new();
            for (int i = 0; i < greeksResponse.Data.Count; i++)
            {
                if (greeksResponse.Data[i].Options.Calls != null)
                    optionList.AddRange(greeksResponse.Data[i].Options.Calls.Where(o => o.DaysBeforeExpiration < 91 && DateTime.Parse(o.ExpirationDate).DayOfWeek == DayOfWeek.Friday).Select(o => new OptionIngest(o)));
                if (greeksResponse.Data[i].Options.Puts != null)
                    optionList.AddRange(greeksResponse.Data[i].Options.Puts.Where(o => o.DaysBeforeExpiration < 91 && DateTime.Parse(o.ExpirationDate).DayOfWeek == DayOfWeek.Friday).Select(o => new OptionIngest(o)));
            }

            return JsonSerializer.Serialize(optionList);
        }
    }
}
