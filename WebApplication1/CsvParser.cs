using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using FileUpload.Models;

namespace FileUpload.Utils
{
    public class CsvParser
    {
        public static List<Transaction> Parse(IFormFile file)
        {
            var transactions = new List<Transaction>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = false,
                    TrimOptions = TrimOptions.Trim,
                    IgnoreBlankLines = true,
                    MissingFieldFound = null
                };
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var transaction = new Transaction
                        {
                            Id = csv.GetField(0),
                            Amount = decimal.Parse(csv.GetField(1)),
                            CurrencyCode = csv.GetField(2),
                            TransactionDate = DateTime.Parse(csv.GetField(3)),
                            Status = csv.GetField(4)
                        };
                        transactions.Add(transaction);
                    }
                }
            }
            return transactions;
        }
    }
}