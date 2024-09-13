using Microsoft.EntityFrameworkCore;
using FileUpload.Models;

namespace FileUpload.DbContexts
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}