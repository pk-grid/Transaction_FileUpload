using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FileUpload.Models;

namespace FileUpload.Utils
{
    public class XmlParser
    {
        public static List<Transaction> Parse(IFormFile file)
        {
            var transactions = new List<Transaction>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var xml = XDocument.Load(reader);
                var transactionsXml = xml.Descendants("Transaction");
                foreach (var transactionXml in transactionsXml)
                {
                    var transaction = new Transaction
                    {
                        Id = transactionXml.Attribute("id").Value,
                        Amount = decimal.Parse(transactionXml.Element("Amount").Value),
                        CurrencyCode = transactionXml.Element("CurrencyCode").Value,
                        TransactionDate = DateTime.Parse(transactionXml.Element("TransactionDate").Value),
                        Status = transactionXml.Element("Status").Value
                    };
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }
    }
}