// Define the transaction class
public class Transaction
{
    // Properties for the transaction
    public string Id { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Status { get; set; }

    // Constructor to initialize the transaction
    public Transaction(string id, decimal amount, string currencyCode, DateTime transactionDate, string status)
    {
        Id = id;
        Amount = amount;
        CurrencyCode = currencyCode;
        TransactionDate = transactionDate;
        Status = status;
    }

    public Transaction()
    {
    }
}