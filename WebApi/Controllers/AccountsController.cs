using Database;
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
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger)
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

        [HttpGet("id")]
        public int GetAccountId()
        {
            Account acc = GetAccountFromHeader();
            if (acc != null)
            {
                HttpContext.Response.StatusCode = 200;
                return acc.Id;
            }
            HttpContext.Response.StatusCode = 400;
            return -1;
        }

        [HttpPut("password")]
        public void SetAccountPassword([FromBody]string passwordHash)
        {
            Account acc = GetAccountFromHeader();
            if (acc != null && passwordHash != null)
            {
                acc.PasswordHash = passwordHash;
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 201;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpPut("ban/{id}")]
        public void BanAccount(int id)
        {
            List<Account> accounts = Program.Database.QSelectAccounts(item => item.Id == id);
            if (accounts.Count > 0)
            {
                accounts[0].AddPermission(Permissions.BANNED);
                Program.Database.QEditAccount(id, accounts[0]);
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 200;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpPut("unban/{id}")]
        public void UnbanAccount(int id)
        {
            List<Account> accounts = Program.Database.QSelectAccounts(item => item.Id == id);
            if (accounts.Count > 0)
            {
                accounts[0].RemovePermission(Permissions.BANNED);
                Program.Database.QEditAccount(id, accounts[0]);
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 200;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpPut("silence/{id}")]
        public void SilenceAccount(int id)
        {
            List<Account> accounts = Program.Database.QSelectAccounts(item => item.Id == id);
            if (accounts.Count > 0)
            {
                accounts[0].AddPermission(Permissions.SEND_CHAT_MESSAGES);
                Program.Database.QEditAccount(id, accounts[0]);
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 200;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpPut("unsilence/{id}")]
        public void UnsilenceAccount(int id)
        {
            List<Account> accounts = Program.Database.QSelectAccounts(item => item.Id == id);
            if (accounts.Count > 0)
            {
                accounts[0].RemovePermission(Permissions.SEND_CHAT_MESSAGES);
                Program.Database.QEditAccount(id, accounts[0]);
                Program.Database.SaveChanges();
                HttpContext.Response.StatusCode = 200;
                return;
            }
            HttpContext.Response.StatusCode = 400;
        }

        [HttpGet("username/{id}")]
        public string GetAccountUsername(int id)
        {
            List<Account> accounts = Program.Database.QSelectAccounts(item => item.Id == id);
            if (accounts.Count > 0)
            {
                HttpContext.Response.StatusCode = 200;
                return accounts[0].Username;
            }
            HttpContext.Response.StatusCode = 400;
            return "";
        }

        [HttpGet("permissions/{id}")]
        public uint GetAccountPermissions(int id)
        {
            List<Account> accounts = Program.Database.QSelectAccounts(item => item.Id == id);
            if (accounts.Count > 0)
            {
                HttpContext.Response.StatusCode = 200;
                return accounts[0].Permissions;
            }
            HttpContext.Response.StatusCode = 400;
            return 0u;
        }

        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            HttpContext.Response.StatusCode = 200;
            return Program.Database.QSelectAccounts(item => true);
        }

        [HttpPost]
        public void CreateAccount(Account acc)
        {
            if (Program.Database.QSelectAccounts(item => item.Username == acc.Username).Count > 0)
            {
                HttpContext.Response.StatusCode = 400;
                HttpContext.Response.Headers.Add("Message", new StringValues("This username is already in use."));
                return;
            }
            if (Program.Database.QSelectAccounts(item => item.Email == acc.Email).Count > 0)
            {
                HttpContext.Response.StatusCode = 400;
                HttpContext.Response.Headers.Add("Message", new StringValues("This email is already in use."));
                return;
            }

            acc.Permissions = (uint)AccountType.USER;

            Program.Database.QCreateAccount(acc);
            Program.Database.SaveChanges();
            HttpContext.Response.StatusCode = 201;
        }

        [HttpDelete("{id}")]
        public void DeleteAccount(int id)
        {
            Program.Database.QDeleteAccount(item => item.Id == id);
            Program.Database.SaveChanges();
            HttpContext.Response.StatusCode = 200;
        }
    }
}
