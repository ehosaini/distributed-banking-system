using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace reporting_service.Controllers
{
    [ApiController]
    [Route( "report" )]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController( ILogger<ReportController> logger )
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("suspicious-transaction")]
        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
