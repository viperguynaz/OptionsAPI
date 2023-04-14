using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsData;
public class HistoricOption
{
    [Name("underlying")]
    public string Underlying { get; set; } = string.Empty;

    [Name("underlying_last")]
    public double UnderlyingLast { get; set; }
    
    [Name("exchange")]
    public string Exchange { get; set; } = string.Empty;

    [Name("optionroot")]
    public string OptionRoot { get; set; } = string.Empty;
    
    [Name("optionext")]
    public string OptionExt { get; set; } = string.Empty;
    
    [Name("type")]
    public string ContractType { get; set; } = string.Empty;
    
    [Name("expiration")]
    public DateTime ExpirationDate { get; set; }
    
    [Name("quotedate")]
    public DateTime QuoteDate { get; set; }
    
    [Name("strike")]
    public double Strike { get; set; }
    
    [Name("last")]
    public double LastPrice { get; set; }
    
    [Name("bid")]
    public double Bid { get; set; }
    
    [Name("ask")]
    public double Ask { get; set; }
    
    [Name("volume")]
    public int Volume { get; set; }
    
    [Name("openinterest")]
    public int OpenInterest { get; set; }
    
    [Name("impliedvol")]
    public float ImpliedVolatility { get; set; }
    
    [Name("delta")]
    public float Delta { get; set; }
    
    [Name("gamma")]
    public float Gamma { get; set; }
    
    [Name("theta")]
    public float Theta { get; set; }
    
    [Name("vega")]
    public float Vega { get; set; }
    
    [Name("optionalias")]
    public string OptionAlias { get; set; } = string.Empty;
    
    [Name("IVBid")]
    public float IVBid { get; set; }
    
    [Name("IVAsk")]
    public float IVAsk { get; set; }

    public int DaysToExpiration => Math.Max(0, (ExpirationDate - QuoteDate).Days);
}



