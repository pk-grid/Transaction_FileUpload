// Define the transaction service class

using System.Xml;

public class TransactionService
{
    // Method to parse transactions from a CSV file
    public List<Transaction> ParseTransactionsFromCsv(string fileContents)
    {
        // Initialize an empty list of transactions
        var transactions = new List<Transaction>();

        // Split the file contents into rows
        var rows = fileContents.Split('\n');

        // Iterate over the rows
        foreach (var row in rows)
        {
            // Split the row into columns
            var columns = row.Split(',');

            // Create a new transaction object
            var transaction = new Transaction
            {
                Id = columns[0].Trim(),
                Amount = decimal.Parse(columns[1].Trim()),
                CurrencyCode = columns[2].Trim(),
                TransactionDate = DateTime.Parse(columns[3].Trim()),
                Status = columns[4].Trim()
            };

            // Add the transaction to the list
            transactions.Add(transaction);
        }

        // Return the list of transactions
        return transactions;
    }

    // Method to parse transactions from an XML file
    public List<Transaction> ParseTransactionsFromXml(string fileContents)
    {
        // Initialize an empty list of transactions
        var transactions = new List<Transaction>();

        // Parse the XML file contents
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(fileContents);

        // Iterate over the transactions in the XML file
        foreach (XmlNode transactionNode in xmlDoc.SelectNodes("//Transaction"))
        {
            // Create a new transaction object
            var transaction = new Transaction
            {
                Id = transactionNode.Attributes["id"].Value,
                Amount = decimal.Parse(transactionNode.SelectSingleNode("Amount").InnerText),
                CurrencyCode = transactionNode.SelectSingleNode("CurrencyCode").InnerText,
                TransactionDate = DateTime.Parse(transactionNode.SelectSingleNode("TransactionDate").InnerText),
                Status = transactionNode.SelectSingleNode("Status").InnerText
            };

            // Add the transaction to the list
            transactions.Add(transaction);
        }

        // Return the list of transactions
        return transactions;
    }
}