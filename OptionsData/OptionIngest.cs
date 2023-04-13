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
    public float Strike { get; set; }
    public int DaysToExpiration => Math.Max(0, (ExpirationDate - QuoteDate).Days);
    public float LastPrice { get; set; } 
    public float Bid { get; set; }
    public float Ask { get; set; }
    public int Volume { get; set; }
    public int OpenInterest { get; set; }
    public float ImpliedVolatility { get; set; }
    public float Delta { get; set; }
    public float Gamma { get; set; }
    public float Theta { get; set;}
    public float Vega { get; set; }
    public float UnderlyingLast { get; set; }
}