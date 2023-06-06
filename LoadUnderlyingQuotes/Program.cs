using CsvHelper;
using System.Globalization;
using OptionsData;
using CsvHelper.Configuration;
using static LoadUnderlyingQuotes.Startup;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Processing Historic Quote Data...");

string symbol = "SPY";
string directoryPath = "C:\\Options-Historic\\SPY";
string inputFileName = $"{symbol}-daily.csv";

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    MissingFieldFound = null
};

var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=optiongreeks;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
    .Options;

Console.WriteLine($"processing {symbol}...");

using (var context = new ApplicationDbContext(dbContextOptions))
using (var reader = new StreamReader($"{directoryPath}\\{inputFileName}"))
using (var csv = new CsvReader(reader, config))
{
    csv.Read();
    csv.ReadHeader();

    while (csv.Read())
    {
        var record = csv.GetRecord<EquityQuote>();
        if (record != null)
        {
            context.Add<EquityQuote>(record);
            context.SaveChanges();
        }
    }
}

Console.WriteLine($"DONE processing {symbol}!");



