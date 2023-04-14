using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsData;
public class OptionIngest
{
    public string ContractName { get; set; } = string.Empty;
    public DateTime QuoteDate { get; set; } = DateTime.MinValue;
    public DateTime ExpirationDate { get; set; } = DateTime.MinValue;
    public string ContractType { get; set; } = string.Empty;
    public double Strike { get; set; }
    public int DaysToExpiration => Math.Max(0, (ExpirationDate - QuoteDate).Days);
    public double LastPrice { get; set; } 
    public double Bid { get; set; }
    public double Ask { get; set; }
    public int Volume { get; set; }
    public int OpenInterest { get; set; }
    public float ImpliedVolatility { get; set; }
    public float Delta { get; set; }
    public float Gamma { get; set; }
    public float Theta { get; set;}
    public float Vega { get; set; }
    public double UnderlyingLast { get; set; }
    public OptionIngest(HistoricOption option)
    {
        ContractName = option.OptionAlias;
        QuoteDate = option.QuoteDate;
        ExpirationDate = option.ExpirationDate;
        ContractType = option.ContractType;
        Strike = option.Strike;
        LastPrice = option.LastPrice; 
        Bid = option.Bid; 
        Ask = option.Ask; 
        Volume = option.Volume;
        OpenInterest = option.OpenInterest; 
        ImpliedVolatility = option.ImpliedVolatility; 
        Delta = option.Delta; 
        Gamma = option.Gamma;
        Theta = option.Theta; 
        Vega = option.Vega; 
        UnderlyingLast = option.UnderlyingLast;
    }
}

