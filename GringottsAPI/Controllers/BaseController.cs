using Gringotts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GringottsAPI.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly IConfiguration _configuration;
        protected readonly IGringottsDataContext _gringottsDataContext;

        public BaseController(ILogger<BaseController> logger, IConfiguration configuration, IGringottsDataContext gringottsDataContext)
        {
            _logger = logger;
            _configuration = configuration;
            _gringottsDataContext = gringottsDataContext;
        }
    }
}
