using CsvHelper;
using System.Globalization;
using OptionsData;
using CsvHelper.Configuration;
using Azure.Identity;
using Azure.Storage.Blobs;
using System.IO.Compression;

Console.WriteLine("Processing Historic Option Data...");

string symbol = "SPY";
string directoryPath = "C:\\Options-Historic\\SPY";

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    MissingFieldFound = null
};

for (int year = 2005; year < 2024; year++)
{
    string inputFileName = $"{symbol}_{year}.csv";
    string outputFileName = $"{symbol}-{year}-ingest.csv";
    Console.WriteLine($"processing SPY {year}...");
    using (var reader = new StreamReader($"{directoryPath}\\{inputFileName}"))
    using (var csv = new CsvReader(reader, config))
    {
        csv.Read();
        csv.ReadHeader();
        using var writer = new StreamWriter($"{directoryPath}\\{outputFileName}");
        using var csvout = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvout.WriteHeader<OptionIngest>();
        csvout.NextRecord();

        while (csv.Read())
        {
            var record = csv.GetRecord<HistoricOption>();
            if (record != null)
            {
                csvout.WriteRecord(new OptionIngest(record));
                csvout.NextRecord();
            }
        }

        csvout.Flush();
    }

    using FileStream fs = new FileStream($"{directoryPath}\\{symbol}-{year}-ingest.zip", FileMode.Create);
    using ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create);
    arch.CreateEntryFromFile($"{directoryPath}\\{outputFileName}", outputFileName);
}



