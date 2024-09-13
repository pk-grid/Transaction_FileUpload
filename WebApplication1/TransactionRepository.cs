using System.Collections.Generic;
using System.Linq;
using FileUpload.DbContexts;
using FileUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Repositories
{
    public class TransactionRepository
    {
        private readonly TransactionDbContext _transactionDbContext;

        public TransactionRepository(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }

        public void SaveTransactions(List<Transaction> transactions)
        {
            _transactionDbContext.Transactions.AddRange(transactions);
            _transactionDbContext.SaveChanges();
        }

        public List<Transaction> GetTransactions(string currency, string dateRange, string status)
        {
            var query = _transactionDbContext.Transactions.AsQueryable();
            if (!string.IsNullOrEmpty(currency))
            {
                query = query.Where(t => t.CurrencyCode == currency);
            }
            if (!string.IsNullOrEmpty(dateRange))
            {
                var dates = dateRange.Split(',');
                query = query.Where(t => t.TransactionDate >= DateTime.Parse(dates[0]) && t.TransactionDate <= DateTime.Parse(dates[1]));
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(t => t.Status == status);
            }
            return query.ToList();
        }
    }
}