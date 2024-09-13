using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using FileUpload.Services;

namespace FileUpload.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                _transactionService.UploadCsv(file);
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                _transactionService.UploadXml(file);
            }
            else
            {
                return BadRequest("Unknown format");
            }
            return Ok("File uploaded successfully");
        }

        [HttpGet]
        public IActionResult GetTransactions(string currency, string dateRange, string status)
        {
            var transactions = _transactionService.GetTransactions(currency, dateRange, status);
            return Ok(transactions);
        }
    }
}