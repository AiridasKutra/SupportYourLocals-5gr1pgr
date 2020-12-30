using Database.TableClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ILogger<CommentsController> logger)
        {
            _logger = logger;
        }

        private Account GetAccountFromHeader()
        {
            HttpContext.Request.Headers.TryGetValue("AccountId", out StringValues stringValues);
            if (stringValues.Count == 1)
            {
                int accId = -1;
                int.TryParse(stringValues[0], out accId);

                if (accId != -1)
                {
                    return Program.Database.QSelectAccounts(item => item.Id == accId).FirstOrDefault();
                }
            }
            return null;
        }

        [HttpGet("{eventid}")]
        public IEnumerable<Message> GetComments(int eventid)
        {
            HttpContext.Response.StatusCode = 200;
            return Program.Database.QSelectComments(item => true, eventid);
        }

        [HttpPost("{eventid}")]
        public void CreateComment(int eventid, Message message)
        {
            HttpContext.Response.StatusCode = 400;

            Account acc = GetAccountFromHeader();
            if (acc != null)
            {
                if (message.Content.Length == 0) return;

                message.SendTime = DateTime.Now;
                message.Sender = acc.Id;

                // Add comment
                if (Program.Database.QSelectComments(item => false, eventid) == null)
                {
                    Program.Database.QCreateCommentRoom(eventid);
                }
                Program.Database.QCreateComment(message, eventid);

                HttpContext.Response.StatusCode = 201;
            }
        }

        [HttpDelete("{eventid}/{commentid}")]
        public void DeleteComment(int eventid, int commentid)
        {
            Program.Database.QDeleteComment(item => item.Id == commentid, eventid);

            HttpContext.Response.StatusCode = 200;
        }
    }
}
