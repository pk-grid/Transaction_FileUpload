using System.Collections.Generic;
using System.Linq;
using FileUpload.Models;
using FileUpload.Repositories;
using FileUpload.Schemas;
using FileUpload.Utils;

namespace FileUpload.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void UploadCsv(IFormFile file)
        {
            var transactions = CsvParser.Parse(file);
            _transactionRepository.SaveTransactions(transactions);
        }

        public void UploadXml(IFormFile file)
        {
            var transactions = XmlParser.Parse(file);
            _transactionRepository.SaveTransactions(transactions);
        }

        public List<TransactionSchema> GetTransactions(string currency, string dateRange, string status)
        {
            var transactions = _transactionRepository.GetTransactions(currency, dateRange, status);
            return transactions.Select(t => new TransactionSchema
            {
                Id = t.Id,
                Payment = $"{t.Amount} {t.CurrencyCode}",
                Status = t.Status
            }).ToList();
        }
    }
}