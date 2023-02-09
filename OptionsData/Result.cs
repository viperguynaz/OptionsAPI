using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OptionsApi;
public class Result
{
    [JsonPropertyName("underlyingSymbol")]
    public string UnderlyingSymbol { get; set; }

    [JsonPropertyName("expirationDates")]
    public List<int> ExpirationDates { get; set; }

    [JsonPropertyName("strikes")]
    public List<double> Strikes { get; set; }

    [JsonPropertyName("hasMiniOptions")]
    public bool HasMiniOptions { get; set; }

    [JsonPropertyName("quote")]
    public Quote Quote { get; set; }

    [JsonPropertyName("options")]
    public List<Option> Options { get; set; }
}
