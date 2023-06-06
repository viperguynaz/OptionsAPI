
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptionsData;

[Table("SPY_Historic")]
public class EquityQuote
{
    [Key]
    [Name("Date")]
    public DateTime QuoteDate { get; set; }
    public double Open { get ; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }

    [NotMapped]
    [Name("Adj Close")]
    public double AdjustedClose { get; set; }
}

