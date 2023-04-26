using OptionsApi;
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
    public OptionIngest(EodOptions.Option option)
    {
        ContractName = option.ContractName;
        QuoteDate = DateTime.Parse(option.UpdatedAt).Date;
        ExpirationDate = DateTime.Parse(option.ExpirationDate).Date;
        ContractType = option.Type.ToUpper();
        Strike = option.Strike ?? 0;
        LastPrice = option.LastPrice ?? 0;
        Bid = option.Bid ?? 0;
        Ask = option.Ask ?? 0;
        Volume = option.Volume ?? 0;
        OpenInterest = option.OpenInterest ?? 0;
        ImpliedVolatility = option.ImpliedVolatility ?? 0;
        Delta = option.Delta ?? 0;
        Gamma = option.Gamma ?? 0;
        Theta = option.Theta ?? 0;
        Vega = option.Vega ?? 0;
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
    }
}


