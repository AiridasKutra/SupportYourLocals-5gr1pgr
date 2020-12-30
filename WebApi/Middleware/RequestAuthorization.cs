using Database;
using Database.TableClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDatabase.Middleware
{
    public class RequestAuthorization : ICustomMiddleware
    {
        public Func<HttpContext, Func<Task>, Task> Get()
        {
            return async (context, next) =>
            {
                // Get account from request
                StringValues accountIdValue;
                context.Request.Headers.TryGetValue("AccountId", out accountIdValue);

                Account acc = new Account();
                if (accountIdValue.Count == 1)
                {
                    int accountId = -1;
                    bool valid = int.TryParse(accountIdValue.ToArray()[0], out accountId);
                    if (!valid)
                    {
                        accountId = -1;
                    }
                    acc = Program.Database.QSelectAccounts(item => item.Id == accountId).FirstOrDefault();
                    if (acc == null)
                    {
                        acc = new Account();
                    }
                }

                // Check authorization
                bool authorized = false;

                // Select full event
                if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/events/full")))
                {
                    authorized = true;
                }
                // Select brief events
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/events/brief")))
                {
                    authorized = true;
                }
                // Set event visibility
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/events/visibility/")))
                {
                    if (acc.Can((uint)Permissions.SET_EVENT_VISIBILITY))
                    {
                        authorized = true;
                    }
                }
                // Manage events
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/events")))
                {
                    // Get event id
                    int eventId = -1;
                    int.TryParse(context.Request.Path.Value.Split('/').Last(), out eventId);

                    // Create event
                    if (context.Request.Method == "POST")
                    {
                        if (acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                        {
                            authorized = true;
                        }
                    }
                    // Edit event
                    else if (context.Request.Method == "PUT")
                    {
                        Event @event = Program.Database.QSelectEvents(item => item.Id == eventId).FirstOrDefault();
                        if (@event != null)
                        {
                            if (@event.Author == acc.Id)
                            {
                                if (acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                                {
                                    authorized = true;
                                }
                            }
                            else
                            {
                                if (acc.Can((uint)Permissions.EDIT_OTHER_EVENTS))
                                {
                                    authorized = true;
                                }
                            }
                        }
                    }
                    // Delete event
                    else if (context.Request.Method == "DELETE")
                    {
                        Event @event = Program.Database.QSelectEvents(item => item.Id == eventId).FirstOrDefault();
                        if (@event != null)
                        {
                            if (@event.Author == acc.Id)
                            {
                                if (acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                                {
                                    authorized = true;
                                }
                            }
                            else
                            {
                                if (acc.Can((uint)Permissions.DELETE_OTHER_EVENTS))
                                {
                                    authorized = true;
                                }
                            }
                        }
                    }
                }
                // Select sports
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/sports")))
                {
                    authorized = true;
                }
                // Manage reports
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/reports")))
                {
                    // Create reports
                    if (context.Request.Method == "POST")
                    {
                        if (acc.Can((uint)Permissions.CREATE_REPORTS))
                        {
                            authorized = true;
                        }
                    }
                    // Select reports
                    else if (context.Request.Method == "GET")
                    {
                        if (acc.Can((uint)Permissions.ACCESS_REPORTS))
                        {
                            authorized = true;
                        }
                    }
                }
                // Select account id
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/id")))
                {
                    authorized = true;
                }
                // Set account password
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/password")))
                {
                    authorized = true;
                }
                // Ban account
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/ban")))
                {
                    if (context.Request.Method == "PUT")
                    {
                        if (acc.Can((uint)Permissions.BAN_ACCOUNTS))
                        {
                            authorized = true;
                        }
                    }
                }
                // Unban account
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/unban")))
                {
                    if (context.Request.Method == "PUT")
                    {
                        if (acc.Can((uint)Permissions.BAN_ACCOUNTS))
                        {
                            authorized = true;
                        }
                    }
                }
                // Silence account
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/silence")))
                {
                    if (context.Request.Method == "PUT")
                    {
                        if (acc.Can((uint)Permissions.SILENCE_ACCOUNTS))
                        {
                            authorized = true;
                        }
                    }
                }
                // Unsilence account
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/unsilence")))
                {
                    if (context.Request.Method == "PUT")
                    {
                        if (acc.Can((uint)Permissions.SILENCE_ACCOUNTS))
                        {
                            authorized = true;
                        }
                    }
                }
                // Select account username
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/username")))
                {
                    authorized = true;
                }
                // Select account permissions
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts/permissions")))
                {
                    authorized = true;
                }
                // Accounts
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/accounts")))
                {
                    // Select accounts
                    if (context.Request.Method == "GET")
                    {
                        if (acc.Can((uint)Permissions.VIEW_ACCOUNTS))
                        {
                            authorized = true;
                        }
                    }
                    // Create account
                    else if (context.Request.Method == "POST")
                    {
                        authorized = true;
                    }
                    // Delete accounts
                    else if (context.Request.Method == "DELETE")
                    {
                        // Get account id
                        int accountId = -1;
                        int.TryParse(context.Request.Path.Value.Split('/').Last(), out accountId);

                        if (acc.Id == accountId)
                        {
                            authorized = true;
                        }
                        else
                        {
                            if (acc.Can((uint)Permissions.DELETE_ACCOUNTS))
                            {
                                authorized = true;
                            }
                        }
                    }
                }
                // Comments
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/comments")))
                {
                    // Select comments
                    if (context.Request.Method == "GET")
                    {
                        authorized = true;
                    }
                    // Create comment
                    if (context.Request.Method == "POST")
                    {
                        if (acc.Can((uint)Permissions.SEND_CHAT_MESSAGES))
                        {
                            authorized = true;
                        }
                    }
                    // Delete comment
                    if (context.Request.Method == "DELETE")
                    {
                        if (acc.Can((uint)Permissions.DELETE_COMMENTS))
                        {
                            authorized = true;
                        }
                    }
                }



                if (!authorized)
                {
                    context.Response.StatusCode = 401;
                }
                else
                {
                    await next.Invoke();
                }
            };
        }
    }
}
