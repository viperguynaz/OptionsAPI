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
    public string Type { get; set; } = string.Empty;
    
    [Name("expiration")]
    public DateTime Expiration { get; set; }
    
    [Name("quotedate")]
    public DateTime QuoteDate { get; set; }
    
    [Name("strike")]
    public double Strike { get; set; }
    
    [Name("last")]
    public double Last { get; set; }
    
    [Name("bid")]
    public double Bid { get; set; }
    
    [Name("ask")]
    public double Ask { get; set; }
    
    [Name("volume")]
    public int Volume { get; set; }
    
    [Name("openinterest")]
    public int Openinterest { get; set; }
    
    [Name("impliedvol")]
    public double Impliedvol { get; set; }
    
    [Name("delta")]
    public double Delta { get; set; }
    
    [Name("gamma")]
    public double Gamma { get; set; }
    
    [Name("theta")]
    public double Theta { get; set; }
    
    [Name("vega")]
    public double Vega { get; set; }
    
    [Name("optionalias")]
    public string OptionAlias { get; set; } = string.Empty;
    
    [Name("IVBid")]
    public double IVBid { get; set; }
    
    [Name("IVAsk")]
    public double IVAsk { get; set; }

    public int DaysToExpiration => Math.Max(0, (Expiration - QuoteDate).Days);
}



