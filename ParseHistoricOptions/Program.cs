using CsvHelper;
using System.Globalization;
using OptionsData;
using CsvHelper.Configuration;

Console.WriteLine("Processing Historic Option Data...");

var directoryPath = "D:\\Documents\\OptionsData\\QQQ-History";
var fileName = "QQQ_schema.csv";

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    MissingFieldFound = null
};

using (var reader = new StreamReader($"{directoryPath}\\{fileName}"))
using (var csv = new CsvReader(reader, config))
{
    csv.Read();
    csv.ReadHeader();
    while (csv.Read())
    {
        var record = csv.GetRecord<HistoricOption>();
        Console.WriteLine($"ContractName: {record!.OptionAlias} | Expiration: {record.Expiration.ToShortDateString()} | QuoteDate {record.QuoteDate.ToShortDateString()} | DTE {record.DaysToExpiration}");
    }
}

//Console.WriteLine("Press enter to quit");
//Console.ReadLine();

