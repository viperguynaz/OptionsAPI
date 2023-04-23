using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OptionsData;
public class NasdaqGreeks
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("status")]
    public Status Status { get; set; }
}

public class Data
{
    [JsonPropertyName("pageTitle")]
    public string? PageTitle { get; set; }

    [JsonPropertyName("table")]
    public Table Table { get; set; }

    [JsonPropertyName("filters")]
    public List<Filter> Filters { get; set; }
}

public class Filter
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}

public class Headers
{
    [JsonPropertyName("cDelta")]
    public string CDelta { get; set; }

    [JsonPropertyName("cGamma")]
    public string CGamma { get; set; }

    [JsonPropertyName("cRho")]
    public string CRho { get; set; }

    [JsonPropertyName("cTheta")]
    public string CTheta { get; set; }

    [JsonPropertyName("cVega")]
    public string CVega { get; set; }

    [JsonPropertyName("cIV")]
    public string CIV { get; set; }

    [JsonPropertyName("Strike")]
    public string Strike { get; set; }

    [JsonPropertyName("pDelta")]
    public string PDelta { get; set; }

    [JsonPropertyName("pGamma")]
    public string PGamma { get; set; }

    [JsonPropertyName("pRho")]
    public string PRho { get; set; }

    [JsonPropertyName("pTheta")]
    public string PTheta { get; set; }

    [JsonPropertyName("pVega")]
    public string PVega { get; set; }

    [JsonPropertyName("pIV")]
    public string PIV { get; set; }
}

public class Row
{
    [JsonPropertyName("cDelta")]
    public double CDelta { get; set; }

    [JsonPropertyName("cGamma")]
    public double CGamma { get; set; }

    [JsonPropertyName("cRho")]
    public double CRho { get; set; }

    [JsonPropertyName("cTheta")]
    public double CTheta { get; set; }

    [JsonPropertyName("cVega")]
    public double CVega { get; set; }

    [JsonPropertyName("cIV")]
    public double CIV { get; set; }

    [JsonPropertyName("strike")]
    public double Strike { get; set; }

    [JsonPropertyName("pDelta")]
    public double PDelta { get; set; }

    [JsonPropertyName("pGamma")]
    public double PGamma { get; set; }

    [JsonPropertyName("pRho")]
    public double PRho { get; set; }

    [JsonPropertyName("pTheta")]
    public double PTheta { get; set; }

    [JsonPropertyName("pVega")]
    public double PVega { get; set; }

    [JsonPropertyName("pIV")]
    public double PIV { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Status
{
    [JsonPropertyName("rCode")]
    public int RCode { get; set; }

    [JsonPropertyName("bCodeMessage")]
    public string? BCodeMessage { get; set; }

    [JsonPropertyName("developerMessage")]
    public string? DeveloperMessage { get; set; }
}

public class Table
{
    [JsonPropertyName("asOf")]
    public string? AsOf { get; set; }

    [JsonPropertyName("headers")]
    public Headers Headers { get; set; }

    [JsonPropertyName("rows")]
    public List<Row> Rows { get; set; }
}


