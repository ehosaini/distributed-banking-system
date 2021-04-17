using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reporting_service.Services;

namespace reporting_service.Controllers
{
    [ApiController]
    [Route( "report" )]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ITransactionService _transactionService;

        public ReportController( ILogger<ReportController> logger, ITransactionService transactionService )
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route( "transaction" )]
        public IActionResult Get()
        {
            return new OkObjectResult( _transactionService.GetAllTransactions() );
        }

        [HttpGet]
        [Route( "transaction/tagged" )]
        public IActionResult Get( bool valid = true )
        {
            return new OkObjectResult( _transactionService.FilterTransactions( valid ) );
        }
    }
}
