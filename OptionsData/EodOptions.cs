using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OptionsApi;
public class EodOptions
{
    public class Option
    {
        [JsonPropertyName("contractName")]
        public string ContractName { get; set; }

        [JsonPropertyName("contractSize")]
        public string ContractSize { get; set; }

        [JsonPropertyName("contractPeriod")]
        public string ContractPeriod { get; set; } = string.Empty;

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("inTheMoney")]
        public string InTheMoney { get; set; } = string.Empty;

        [JsonPropertyName("lastTradeDateTime")]
        public string LastTradeDateTime { get; set; } = string.Empty;

        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set; } = string.Empty;

        [JsonPropertyName("strike")]
        public double? Strike { get; set; }

        [JsonPropertyName("lastPrice")]
        public double? LastPrice { get; set; }

        [JsonPropertyName("bid")]
        public double? Bid { get; set; }

        [JsonPropertyName("ask")]
        public double? Ask { get; set; }

        [JsonPropertyName("change")]
        public double? Change { get; set; }

        [JsonPropertyName("changePercent")]
        public float? ChangePercent { get; set; }

        [JsonPropertyName("volume")]
        public int? Volume { get; set; }

        [JsonPropertyName("openInterest")]
        public int? OpenInterest { get; set; }

        [JsonPropertyName("impliedVolatility")]
        public float? ImpliedVolatility { get; set; }

        [JsonPropertyName("delta")]
        public float? Delta { get; set; }

        [JsonPropertyName("gamma")]
        public float? Gamma { get; set; }

        [JsonPropertyName("theta")]
        public float? Theta { get; set; }

        [JsonPropertyName("vega")]
        public float? Vega { get; set; }

        [JsonPropertyName("rho")]
        public float? Rho { get; set; }

        [JsonPropertyName("theoretical")]
        public float? Theoretical { get; set; }

        [JsonPropertyName("intrinsicValue")]
        public double? IntrinsicValue { get; set; }

        [JsonPropertyName("timeValue")]
        public double? TimeValue { get; set; }

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; } = string.Empty;

        [JsonPropertyName("daysBeforeExpiration")]
        public int? DaysBeforeExpiration { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set; } = string.Empty;

        [JsonPropertyName("impliedVolatility")]
        public float? ImpliedVolatility { get; set; }

        [JsonPropertyName("putVolume")]
        public int? PutVolume { get; set; }

        [JsonPropertyName("callVolume")]
        public int? CallVolume { get; set; }

        [JsonPropertyName("putCallVolumeRatio")]
        public float? PutCallVolumeRatio { get; set; }

        [JsonPropertyName("putOpenInterest")]
        public int? PutOpenInterest { get; set; }

        [JsonPropertyName("callOpenInterest")]
        public int? CallOpenInterest { get; set; }

        [JsonPropertyName("putCallOpenInterestRatio")]
        public float? PutCallOpenInterestRatio { get; set; }

        [JsonPropertyName("optionsCount")]
        public int? OptionsCount { get; set; }

        [JsonPropertyName("options")]
        public Options Options { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("Call")] 
        public List<Option> Calls { get; set; } = new List<Option>();

        [JsonPropertyName("Put")]
        public List<Option> Puts { get; set; }
    }

    public class EodOptionsResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; } = string.Empty;

        [JsonPropertyName("lastTradeDate")]
        public string LastTradeDate { get; set; } = string.Empty;

        [JsonPropertyName("lastTradePrice")]
        public double? LastTradePrice { get; set; }

        [JsonPropertyName("data")]
        public List<Data> Data { get; set; } = new List<Data>();
    }
}
