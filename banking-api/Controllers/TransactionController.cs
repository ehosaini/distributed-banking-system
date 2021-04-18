using System;
using System.Threading.Tasks;
using banking_api.Services;
using core_library.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace banking_api.Controllers
{
    [ApiController]
    [Route( "transaction" )]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionBroadcaster _transactionBroadCastingService;

        public TransactionController( ILogger<TransactionController> logger, ITransactionBroadcaster transactionBroadcastingService )
        {
            _logger = logger;
            _transactionBroadCastingService = transactionBroadcastingService;
        }

        [HttpPost]
        public async Task<IActionResult> Post( TransactionDto transactionDto )
        {

            // Todo: make uri dynamically read from config
            var uri = new Uri( "https://localhost:44341/report/transaction" );

            var result = await _transactionBroadCastingService.BroadcastTransaction( transactionDto, uri );

            if( result.IsSuccessStatusCode )
            {
                return new OkResult();
            }

            // Todo: could be handled better
            return new ObjectResult( result );
        }
    }
}
