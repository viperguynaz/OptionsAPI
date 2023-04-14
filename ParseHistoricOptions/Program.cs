using CsvHelper;
using System.Globalization;
using OptionsData;
using CsvHelper.Configuration;
using Azure.Identity;
using Azure.Storage.Blobs;

Console.WriteLine("Processing Historic Option Data...");

string directoryPath = "D:\\Documents\\OptionsData\\QQQ-History";
string fileName = "QQQ_2018.csv";
Uri containerUri = new Uri("https://viperoptions.blob.core.windows.net/options-historic");

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    MissingFieldFound = null
};


// Create a BlobContainerClient that will authenticate through Active Directory
// Get a reference to a container: containerName -- then create container if it doesn't' exist
BlobContainerClient container = new BlobContainerClient(containerUri, new DefaultAzureCredential());
container.CreateIfNotExists();

using (var reader = new StreamReader($"{directoryPath}\\{fileName}"))
using (var csv = new CsvReader(reader, config))
{
    csv.Read();
    csv.ReadHeader();
    List<OptionIngest> optionList = new();
    int blockCount = 1;
    while (csv.Read())
    {
        int ndx = 0;
        optionList.Clear();
        while (ndx < 1000)
        {
            var record = csv.GetRecord<HistoricOption>();
            if (record != null)
            {
                optionList.Add(new OptionIngest(record));
                //Console.WriteLine($"ContractName: {record!.OptionAlias} | Expiration: {record.ExpirationDate.ToShortDateString()} | QuoteDate {record.QuoteDate.ToShortDateString()} | DTE {record.DaysToExpiration}");
                ndx++;
            }
        }

        // write list to blob
        string blobName = $"QQQ-2018-{blockCount}.csv";
        Console.WriteLine($"Writing bloBlock {blockCount} ...");

        // Get a reference to a blob: blobName in container: containerName
        BlobClient blob = container.GetBlobClient($"QQQ-2018-{blockCount}.csv");

        using var writer = new StreamWriter(new MemoryStream());
        using var csvout = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvout.WriteRecords(optionList);
        writer.Flush();
        writer.BaseStream.Seek(0, SeekOrigin.Begin);
        await blob.UploadAsync(writer.BaseStream, true);
        Console.WriteLine($"Block {blockCount} saved.");
        blockCount++;
    }
}



