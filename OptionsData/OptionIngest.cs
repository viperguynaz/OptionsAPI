using OptionsApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public OptionIngest(EodOptions.Option option, double underlyingPrice = 0.0)
    {
        ContractName = option.ContractName;
        QuoteDate = DateTime.Parse(option.UpdatedAt).Date;
        ExpirationDate = DateTime.Parse(option.ExpirationDate).Date;
        ContractType = option.Type.ToUpper();
        Strike = option.Strike.HasValue ? option.Strike.Value : 0.0;
        LastPrice = option.LastPrice.HasValue ? option.LastPrice.Value : 0;
        Bid = option.Bid.HasValue ? option.Bid.Value : 0;
        Ask = option.Ask.HasValue ? option.Ask.Value : 0;
        Volume = option.Volume.HasValue ? option.Volume.Value : 0;
        OpenInterest = option.OpenInterest.HasValue ? option.OpenInterest.Value : 0;
        ImpliedVolatility = option.ImpliedVolatility.HasValue ? option.ImpliedVolatility.Value : 0;
        Delta = option.Delta.HasValue ? option.Delta.Value : 0;
        Gamma = option.Gamma.HasValue ? option.Gamma.Value : 0;
        Theta = option.Theta.HasValue ? option.Theta.Value : 0;
        Vega = option.Vega.HasValue ? option.Vega.Value : 0;
        UnderlyingLast = underlyingPrice;
    }
    public OptionIngest(HistoricOption option)
    {
        ContractName = option.OptionAlias;
        QuoteDate = option.QuoteDate;
        ExpirationDate = option.ExpirationDate;
        ContractType = option.ContractType.ToUpper();
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


