using System.Text.Json.Serialization;

namespace OptionsApi;
public class Option
{
    [JsonPropertyName("expirationDate")]
    public int ExpirationDate { get; set; }

    [JsonIgnore]
    [JsonPropertyName("hasMiniOptions")]
    public bool HasMiniOptions { get; set; }

    [JsonPropertyName("calls")]
    public List<Call> Calls { get; set; }

    [JsonPropertyName("puts")]
    public List<Put> Puts { get; set; }
}
