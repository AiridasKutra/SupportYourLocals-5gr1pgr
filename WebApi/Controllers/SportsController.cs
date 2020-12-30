using Database.TableClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportsController : ControllerBase
    {
        private readonly ILogger<SportsController> _logger;

        public SportsController(ILogger<SportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Sport> GetSports()
        {
            HttpContext.Response.StatusCode = 200;
            return Program.Database.QSelectSports(item => true);
        }
    }
}
