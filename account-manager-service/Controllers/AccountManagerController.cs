using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace account_manager_service.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class AccountManagerController : ControllerBase
    {
        private readonly ILogger<AccountManagerController> _logger;

        public AccountManagerController( ILogger<AccountManagerController> logger )
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
