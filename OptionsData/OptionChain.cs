using System.Text.Json.Serialization;

namespace OptionsApi;
public class OptionChain
{
    [JsonPropertyName("result")]
    public List<Result> Result { get; set; }

    [JsonPropertyName("error")]
    public object Error { get; set; }
}
