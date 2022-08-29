using System.Text.Json.Serialization;

namespace YahooOptions;
public class YahooResponse
{
    [JsonPropertyName("optionChain")]
    public OptionChain OptionChain { get; set; }
}
