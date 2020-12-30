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
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{eventid}")]
        public IEnumerable<Report> GetReports(int eventid)
        {
            HttpContext.Response.StatusCode = 200;
            return Program.Database.QSelectReports(item => item.EventId == eventid);
        }

        [HttpPost("{eventid}")]
        public void CreateReport(int eventid, Report report)
        {
            if (Program.Database.QSelectEvents(item => item.Id == eventid).Count > 0)
            {
                report.EventId = eventid;
                Program.Database.QCreateReport(report);
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 201;
                return;
            }
            HttpContext.Response.StatusCode = 404;
        }
    }
}
