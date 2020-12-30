using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDatabase.Middleware
{
    public interface ICustomMiddleware
    {
        public Func<HttpContext, Func<Task>, Task> Get();
    }
}
