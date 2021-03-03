using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banking_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IList<Transaction> _transactions ;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
            _transactions = new List<Transaction>
            {
                new Transaction
                {
                    UserId = 1,
                    Amount = 10,
                    TransactionLocation = "USA"
                },
                new Transaction
                {
                    UserId = 2,
                    Amount = 12,
                    TransactionLocation = "CANADA"
                },
                new Transaction
                {
                    UserId = 2,
                    Amount = 12,
                    TransactionLocation = "Mexico"
                }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            return _transactions.ToArray();
        }

        [HttpPost]
        public IActionResult Post(Transaction transaction)
        {
           _transactions.Add(transaction);

            return new OkObjectResult(transaction);
        }
    }

    public class Transaction
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string TransactionLocation { get; set; }
    }
}
