using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OptionsApi;
public class EodOptions
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Option
    {
        [JsonPropertyName("contractName")]
        public string ContractName { get; set; }

        [JsonPropertyName("contractSize")]
        public string ContractSize { get; set; }

        [JsonPropertyName("contractPeriod")]
        public string ContractPeriod { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("inTheMoney")]
        public string InTheMoney { get; set; }

        [JsonPropertyName("lastTradeDateTime")]
        public string LastTradeDateTime { get; set; }

        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set; }

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
        public double? ChangePercent { get; set; }

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
        public string UpdatedAt { get; set; }

        [JsonPropertyName("daysBeforeExpiration")]
        public int? DaysBeforeExpiration { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("impliedVolatility")]
        public double? ImpliedVolatility { get; set; }

        [JsonPropertyName("putVolume")]
        public int? PutVolume { get; set; }

        [JsonPropertyName("callVolume")]
        public int? CallVolume { get; set; }

        [JsonPropertyName("putCallVolumeRatio")]
        public double? PutCallVolumeRatio { get; set; }

        [JsonPropertyName("putOpenInterest")]
        public int? PutOpenInterest { get; set; }

        [JsonPropertyName("callOpenInterest")]
        public int? CallOpenInterest { get; set; }

        [JsonPropertyName("putCallOpenInterestRatio")]
        public double? PutCallOpenInterestRatio { get; set; }

        [JsonPropertyName("optionsCount")]
        public int? OptionsCount { get; set; }

        [JsonPropertyName("options")]
        public Options Options { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("Call")]
        public List<Option> Calls { get; set; }

        [JsonPropertyName("Put")]
        public List<Option> Puts { get; set; }
    }

    //public class Put
    //{
    //    [JsonPropertyName("contractName")]
    //    public string ContractName { get; set; }

    //    [JsonPropertyName("contractSize")]
    //    public string ContractSize { get; set; }

    //    [JsonPropertyName("contractPeriod")]
    //    public string ContractPeriod { get; set; }

    //    [JsonPropertyName("currency")]
    //    public string Currency { get; set; }

    //    [JsonPropertyName("type")]
    //    public string Type { get; set; }

    //    [JsonPropertyName("inTheMoney")]
    //    public string InTheMoney { get; set; }

    //    [JsonPropertyName("lastTradeDateTime")]
    //    public string LastTradeDateTime { get; set; }

    //    [JsonPropertyName("expirationDate")]
    //    public string ExpirationDate { get; set; }

    //    [JsonPropertyName("strike")]
    //    public double? Strike { get; set; }

    //    [JsonPropertyName("lastPrice")]
    //    public double? LastPrice { get; set; }

    //    [JsonPropertyName("bid")]
    //    public double? Bid { get; set; }

    //    [JsonPropertyName("ask")]
    //    public double? Ask { get; set; }

    //    [JsonPropertyName("change")]
    //    public double? Change { get; set; }

    //    [JsonPropertyName("changePercent")]
    //    public double? ChangePercent { get; set; }

    //    [JsonPropertyName("volume")]
    //    public int? Volume { get; set; }

    //    [JsonPropertyName("openInterest")]
    //    public int? OpenInterest { get; set; }

    //    [JsonPropertyName("impliedVolatility")]
    //    public double? ImpliedVolatility { get; set; }

    //    [JsonPropertyName("delta")]
    //    public double? Delta { get; set; }

    //    [JsonPropertyName("gamma")]
    //    public double? Gamma { get; set; }

    //    [JsonPropertyName("theta")]
    //    public double? Theta { get; set; }

    //    [JsonPropertyName("vega")]
    //    public double? Vega { get; set; }

    //    [JsonPropertyName("rho")]
    //    public double? Rho { get; set; }

    //    [JsonPropertyName("theoretical")]
    //    public double? Theoretical { get; set; }

    //    [JsonPropertyName("intrinsicValue")]
    //    public double? IntrinsicValue { get; set; }

    //    [JsonPropertyName("timeValue")]
    //    public double? TimeValue { get; set; }

    //    [JsonPropertyName("updatedAt")]
    //    public string UpdatedAt { get; set; }

    //    [JsonPropertyName("daysBeforeExpiration")]
    //    public int? DaysBeforeExpiration { get; set; }
    //}

    public class EodOptionsResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("lastTradeDate")]
        public string LastTradeDate { get; set; }

        [JsonPropertyName("lastTradePrice")]
        public double? LastTradePrice { get; set; }

        [JsonPropertyName("data")]
        public List<Data> Data { get; set; }
    }


}
