// Define the transaction controller class

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    // Method to upload transactions
    [HttpPost]
    [Route("upload")]
    public IActionResult UploadTransactions(IFormFile file)
    {
        // Check if the file is null or empty
        if (file == null || file.Length == 0)
        {
            // Return a bad request response
            return BadRequest("No file was uploaded.");
        }

        // Check if the file is a CSV or XML file
        if (file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ||
            file.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
        {
            // Read the file contents
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var fileContents = reader.ReadToEnd();

                // Parse the file contents
                var transactionService = new TransactionService();
                var transactions = file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ?
                    transactionService.ParseTransactionsFromCsv(fileContents) :
                    transactionService.ParseTransactionsFromXml(fileContents);

                // Return the transactions
                return Ok(transactions);
            }
        }
        else
        {
            // Return a bad request response
            return BadRequest("Unsupported file format.");
        }
    }

    // Method to get transactions by currency
    [HttpGet]
    [Route("by-currency/{currencyCode}")]
    public IActionResult GetTransactionsByCurrency(string currencyCode)
    {
        // Create a list of transactions
        var transactions = new List<Transaction>
        {
            new Transaction("1", 100, "USD", DateTime.Now, "A"),
            new Transaction("2", 200, "EUR", DateTime.Now, "R"),
            new Transaction("3", 300, "USD", DateTime.Now, "D")
        };

        // Filter the transactions by currency
        var filteredTransactions = transactions.Where(t => t.CurrencyCode == currencyCode).ToList();

        // Return the filtered transactions
        return Ok(filteredTransactions);
    }

    // Method to get transactions by date range
    [HttpGet]
    [Route("by-date-range/{startDate}/{endDate}")]
    public IActionResult GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
    {
        // Create a list of transactions
        var transactions = new List<Transaction>
        {
            new Transaction("1", 100, "USD", DateTime.Now, "A"),
            new Transaction("2", 200, "EUR", DateTime.Now, "R"),
            new Transaction("3", 300, "USD", DateTime.Now, "D")
        };

        // Filter the transactions by date range
        var filteredTransactions = transactions.Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate).ToList();

        // Return the filtered transactions
        return Ok(filteredTransactions);
    }

    // Method to get transactions by status
    [HttpGet]
    [Route("by-status/{status}")]
    public IActionResult GetTransactionsByStatus(TransactionStatus status)
    {
        // Create a list of transactions
        var transactions = new List<Transaction>
        {
            new Transaction("1", 100, "USD", DateTime.Now, "A"),
            new Transaction("2", 200, "EUR", DateTime.Now, "R"),
            new Transaction("3", 300, "USD", DateTime.Now, "D")
        };

        // Filter the transactions by status
        var filteredTransactions = transactions.Where(t => t.Status == status.ToString()).ToList();

        // Return the filtered transactions
        return Ok(filteredTransactions);
    }
}