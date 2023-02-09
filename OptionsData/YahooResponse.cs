using System.Text.Json.Serialization;

namespace OptionsApi;
public class YahooResponse
{
    [JsonPropertyName("optionChain")]
    public OptionChain OptionChain { get; set; }
}
