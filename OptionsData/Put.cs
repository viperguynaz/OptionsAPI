using System.Text.Json.Serialization;

namespace OptionsApi;
public class Put
{
    [JsonPropertyName("contractSymbol")]
    public string ContractSymbol { get; set; } = string.Empty;

    [JsonPropertyName("strike")]
    public double Strike { get; set; }

    [JsonIgnore]
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("lastPrice")]
    public double LastPrice { get; set; }

    [JsonIgnore]
    [JsonPropertyName("change")]
    public double Change { get; set; }

    [JsonIgnore]
    [JsonPropertyName("percentChange")]
    public double PercentChange { get; set; }

    [JsonPropertyName("openInterest")]
    public int OpenInterest { get; set; }

    [JsonIgnore]
    [JsonPropertyName("bid")]
    public double Bid { get; set; }

    [JsonIgnore]
    [JsonPropertyName("ask")]
    public double Ask { get; set; }

    [JsonIgnore]
    [JsonPropertyName("contractSize")]
    public string ContractSize { get; set; } = string.Empty;

    [JsonPropertyName("expiration")]
    public int Expiration { get; set; }

    [JsonIgnore]
    [JsonPropertyName("lastTradeDate")]
    public int LastTradeDate { get; set; }

    [JsonPropertyName("impliedVolatility")]
    public double ImpliedVolatility { get; set; }

    [JsonIgnore]
    [JsonPropertyName("inTheMoney")]
    public bool InTheMoney { get; set; }

    [JsonPropertyName("volume")]
    public int Volume { get; set; }
}

