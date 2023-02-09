using System.Text.Json.Serialization;

namespace OptionsApi;

public class GreeksData
{
    [JsonPropertyName("pageTitle")]
    public string PageTitle { get; set; }

    [JsonPropertyName("table")]
    public GreeksTable Table { get; set; }

    [JsonPropertyName("filters")]
    public List<Filter> Filters { get; set; }
}

public class Filter
{
    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Headers
{
    [JsonPropertyName("cDelta")]
    public string CallDelta { get; set; }

    [JsonPropertyName("cGamma")]
    public string CallGamma { get; set; }

    [JsonPropertyName("cRho")]
    public string CallRho { get; set; }

    [JsonPropertyName("cTheta")]
    public string CallTheta { get; set; }

    [JsonPropertyName("cVega")]
    public string CallVega { get; set; }

    [JsonPropertyName("cIV")]
    public string CallIV { get; set; }

    [JsonPropertyName("Strike")]
    public string Strike { get; set; }

    [JsonPropertyName("pDelta")]
    public string PutDelta { get; set; }

    [JsonPropertyName("pGamma")]
    public string PutGamma { get; set; }

    [JsonPropertyName("pRho")]
    public string PutRho { get; set; }

    [JsonPropertyName("pTheta")]
    public string PutTheta { get; set; }

    [JsonPropertyName("pVega")]
    public string PutVega { get; set; }

    [JsonPropertyName("pIV")]
    public string PutIV { get; set; }
}

public class GreeksResponse
{
    [JsonPropertyName("data")]
    public GreeksData Data { get; set; }

    [JsonPropertyName("message")]
    public object Message { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }
}

public class Greeks
{
    [JsonPropertyName("cDelta")]
    public double? CallDelta { get; set; }

    [JsonPropertyName("cGamma")]
    public double? CallGamma { get; set; }

    [JsonPropertyName("cRho")]
    public double? CallRho { get; set; }

    [JsonPropertyName("cTheta")]
    public double? CallTheta { get; set; }

    [JsonPropertyName("cVega")]
    public double? CallVega { get; set; }

    [JsonPropertyName("cIV")]
    public double? CallIV { get; set; }

    [JsonPropertyName("strike")]
    public double? Strike { get; set; }

    [JsonPropertyName("pDelta")]
    public double? PutDelta { get; set; }

    [JsonPropertyName("pGamma")]
    public double? PutGamma { get; set; }

    [JsonPropertyName("pRho")]
    public double? PutRho { get; set; }

    [JsonPropertyName("pTheta")]
    public double? PutTheta { get; set; }

    [JsonPropertyName("pVega")]
    public double? PutVega { get; set; }

    [JsonPropertyName("pIV")]
    public double? PutIV { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Status
{
    [JsonPropertyName("rCode")]
    public int? RCode { get; set; }

    [JsonPropertyName("bCodeMessage")]
    public object BCodeMessage { get; set; }

    [JsonPropertyName("developerMessage")]
    public object DeveloperMessage { get; set; }
}

public class GreeksTable
{
    [JsonPropertyName("headers")]
    public Headers Headers { get; set; }

    [JsonPropertyName("rows")]
    public List<Greeks> Rows { get; set; }
}




