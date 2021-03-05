using System.Collections.Generic;
using System.Linq;
using banking_api.Models;
using banking_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banking_api.Controllers
{
    [ApiController]
    [Route( "transaction" )]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController( ILogger<TransactionController> logger, ITransactionService transactionService )
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<IList<Transaction>> Get( bool validTransactions = true )
        {
            return _transactionService.GetAllTransactions().ToList();
        }

        [HttpPost]
        public IActionResult Post( Transaction transaction )
        {
            _transactionService.AddTransaction( transaction );

            return new OkObjectResult( transaction );
        }

        [HttpGet]
        [Route("filtered")]
        public ActionResult<IList<Transaction>> FilteredTransactions(bool validTransactions = true)
        {
            return new OkObjectResult( _transactionService.GetValidOrSuspicious( validTransactions ).ToList() );
        }
    }
}
