using CsvHelper;
using System.Globalization;
using OptionsData;
using CsvHelper.Configuration;
using static ParseHistoricOptions.Startup;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Processing Historic Option Data...");

string symbol = "SPY";
string directoryPath = $"C:\\Options-Historic\\{symbol}";

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    MissingFieldFound = null
};

var ndx = 0;
var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=optiongreeks;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
    .Options;
using var context = new ApplicationDbContext(dbContextOptions);
for (int year = 2018; year < 2024; year++)
{
    Console.WriteLine($"processing {symbol} year {year}...");
    string inputFileName = $"{symbol}_{year}.csv";

    using var reader = new StreamReader($"{directoryPath}\\{inputFileName}");
    using var csv = new CsvReader(reader, config);
    csv.Read();
    csv.ReadHeader();

    while (csv.Read())
    {
        var record = csv.GetRecord<HistoricOption>();
        if (record != null && record.ContractType.ToLower() == "put")
        {
            var option = new OptionIngest(record);
            context.Add(option);
            ndx++;
            if (ndx % 10000 == 0)
            {
                context.SaveChanges();
                Console.WriteLine($"... {ndx} saved");
            }
        }
    }
    context.SaveChanges();
}

Console.WriteLine($"DONE processing {symbol}!");



