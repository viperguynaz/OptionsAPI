using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
