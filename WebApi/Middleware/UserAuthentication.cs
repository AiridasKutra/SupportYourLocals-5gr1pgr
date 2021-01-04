using Database;
using Database.TableClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDatabase.Middleware
{
    public static class LoggedUsers
    {
        public class Session
        {
            public ulong vfid; // User verification ID
            public int accid; // User account ID
        }

        private static List<Session> _sessions = new List<Session>();

        private static Random ulongGen = new Random(DateTime.Now.Ticks.GetHashCode());

        private static ulong RandomUlong()
        {
            byte[] bytes = new byte[8];
            ulongGen.NextBytes(bytes);
            return BitConverter.ToUInt64(bytes);
        }

        /// <summary>
        /// Finds the index of a session for the given vfid using binary search. Returns -1 if session is not found
        /// </summary>
        /// <param name="vfid"></param>
        /// <returns></returns>
        private static int FindSession(ulong vfid, bool precise = true)
        {
            int left = 0;
            int right = _sessions.Count - 1;
            int head = 0;

            while (left <= right)
            {
                head = (left + right) / 2;
                ulong value = _sessions[head].vfid;

                if (value < vfid)
                    left = head + 1;
                else if (value > vfid)
                    right = head - 1;
                else
                    return head;
            }

            return precise == true ? -1 : head;
        }

        /// <summary>
        /// Inserts a new session using binary search, so that the list is still sorted by Session.vfid
        /// </summary>
        /// <param name="vfid"></param>
        private static void InsertSession(Session newSession)
        {
            int index = 0;
            foreach (var session in _sessions)
            {
                if (session.vfid > newSession.vfid)
                {
                    break;
                }
                index++;
            }
            _sessions.Insert(index, newSession);
            //int closestIndex = FindSession(newSession.vfid, false);
            //Session closestSession;

            //if (closestIndex > 0)
            //{
            //    closestSession = _sessions[closestIndex];
            //    if (closestSession.vfid < newSession.vfid)
            //    {
            //        do
            //        {
            //            closestIndex++;
            //            if (closestIndex >= _sessions.Count)
            //            {
            //                break;
            //            }
            //            closestSession = _sessions[closestIndex];
            //        } while (closestSession.vfid < newSession.vfid);
            //        _sessions.Insert(closestIndex, newSession);
            //    }
            //    else
            //    {
            //        do
            //        {
            //            closestIndex--;
            //            if (closestIndex < 0)
            //            {
            //                break;
            //            }
            //            closestSession = _sessions[closestIndex];
            //        } while (closestSession.vfid > newSession.vfid);
            //        _sessions.Insert(closestIndex + 1, newSession);
            //    }
            //}
            //else
            //{
            //    _sessions.Add(newSession);
            //}
        }

        public static ulong GenerateUser(int accountId)
        {
            // Generate unused vfid
            ulong vfid = RandomUlong();
            int index = FindSession(vfid);
            while (vfid == 0 || index >= 0)
            {
                // Try again
                vfid = RandomUlong();
                index = FindSession(vfid);
            }

            InsertSession(new Session { vfid = vfid, accid = accountId });
            return vfid;
        }

        public static bool EndSession(ulong vfid)
        {
            int index = FindSession(vfid);
            if (index != -1)
            {
                _sessions.RemoveAt(index);
                return true;
            }
            return false;
        }

        public static Session GetSession(ulong vfid)
        {
            if (vfid == 0) return null;

            int index = FindSession(vfid);
            if (index == -1)
            {
                return null;
            }
            else
            {
                return new Session
                {
                    vfid = _sessions[index].vfid,
                    accid = _sessions[index].accid,
                };
            }
        }

        public static Session GetSessionSlow(ulong vfid)
        {
            if (vfid == 0) return null;
            return _sessions.Find(item => item.vfid == vfid);
        }
    }

    public class UserAuthentication : ICustomMiddleware
    {
        public Func<HttpContext, Func<Task>, Task> Get()
        {
            return async (context, next) =>
            {
                // Remove account id header
                context.Request.Headers.Remove("AccountId");

                // Get authentication header
                context.Request.Headers.TryGetValue("VFIDAuth", out StringValues authenticationValues);

                // Extract vfid value
                ulong vfid = 0;
                if (authenticationValues.Count == 1)
                {
                    bool valid = ulong.TryParse(authenticationValues.ToArray()[0], out vfid);
                    if (!valid)
                    {
                        vfid = 0;
                    }
                }

                Console.Write($"[{vfid}] ");

                // Check against logged in users
                LoggedUsers.Session session = LoggedUsers.GetSession(vfid);
                if (session == null)
                {
                    Console.Write($"Session not found.");
                    context.Request.Headers.Add("AccountId", "-1");

                    session = LoggedUsers.GetSessionSlow(vfid);
                    if (session != null && vfid != 0)
                    {
                        Console.Write(" Found on repeat search.");
                    }
                }
                else
                {
                    // Get account id
                    Account acc = Program.Database.QSelectAccounts(item => item.Id == session.accid).FirstOrDefault();
                    if (acc != null)
                    {
                        Console.Write($"Session linked to account '{acc.Username}'");
                        context.Request.Headers.Add("AccountId", acc.Id.ToString());
                    }
                    else
                    {
                        Console.Write($"Session linked to non-existent account");
                        context.Request.Headers.Add("AccountId", "-1");
                    }
                }
                Console.WriteLine();

                await next.Invoke();
            };
        }
    }

    public class AccountManaging : ICustomMiddleware
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

                // Login
                if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/login")))
                {
                    if (context.Request.Method == "GET")
                    {
                        ulong vfid = 0;
                        string[] parameters = context.Request.Path.Value.Split('/').TakeLast(2).ToArray();
                        if (parameters.Length == 2)
                        {
                            string email = parameters[0];
                            string passwordHash = parameters[1];

                            Account loginAcc = Program.Database.QSelectAccounts(item => item.Email == email).FirstOrDefault();
                            if (loginAcc != null)
                            {
                                if (!loginAcc.Can((uint)Permissions.BANNED))
                                {
                                    if (loginAcc.PasswordHash == passwordHash)
                                    {
                                        vfid = LoggedUsers.GenerateUser(loginAcc.Id);
                                    }
                                }
                            }
                        }

                        context.Response.StatusCode = 200;
                        await context.Response.Body.WriteAsync(BitConverter.GetBytes(vfid), 0, 8);
                        return;
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                        return;
                    }
                }
                // Logout
                else if (context.Request.Path.StartsWithSegments(PathString.FromUriComponent("/logout")))
                {
                    if (context.Request.Method == "GET")
                    {
                        // Get authentication header
                        StringValues authenticationValues;
                        context.Request.Headers.TryGetValue("VFIDAuth", out authenticationValues);

                        // Extract vfid value
                        ulong vfid = 0;
                        if (authenticationValues.Count == 1)
                        {
                            bool valid = ulong.TryParse(authenticationValues.ToArray()[0], out vfid);
                            if (!valid)
                            {
                                vfid = 0;
                            }
                        }

                        // Logout
                        if (vfid != 0)
                        {
                            LoggedUsers.EndSession(vfid);
                        }

                        context.Response.StatusCode = 200;
                        return;
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                        return;
                    }
                }

                await next.Invoke();
            };
        }
    }
}
