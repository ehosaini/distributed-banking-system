using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace user_notification_service.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class UserNotificationController : ControllerBase
    {
        private readonly ILogger<UserNotificationController> _logger;

        public UserNotificationController( ILogger<UserNotificationController> logger )
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
