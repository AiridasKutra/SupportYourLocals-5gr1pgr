﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Text;
using WebApi.Classes;

namespace WebApi
{
    static class RequestSender
    {
        private static ulong _vfid = 0;

        private static HttpClient ConnectHttpClient()
        {
            HttpClientHandler _handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true
            };

            HttpClient client = new HttpClient(_handler);
            //client.BaseAddress = new Uri("http://10.0.2.2:54000");
            client.BaseAddress = new Uri("http://193.219.91.103:7099/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("VFIDAuth", _vfid.ToString());

            return client;
        }

        public static Account ThisAccount()
        {
            int id = GetLoggedInAccountId();
            if (id == -1)
            {
                return new Account();
            }
            else {
                return new Account
                {
                    Id = id,
                    Permissions = GetAccountPermissions(id),
                    Username = GetAccountUsername(id)
                };
            }
        }

        public static List<Event> GetBriefEvents()
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync("/events/brief").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Event>>().Result.ToList();
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return new List<Event>();
                }
            }
        }

        public static Event GetFullEvent(int eventId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync($"/events/full/{eventId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Event>().Result;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
        }

        public static void CreateEvent(Event @event)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PostAsJsonAsync("/events", @event).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void EditEvent(Event @event)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PutAsJsonAsync($"/events/{@event.Id}", @event).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void DeleteEvent(int eventId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.DeleteAsync($"/events/{eventId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void SetEventVisibility(int eventId, bool visible)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PutAsync($"/events/visibility/{eventId}/{(visible ? 1 : 0)}", null).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static List<Sport> GetSports()
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync("/sports").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Sport>>().Result.ToList();
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return new List<Sport>();
                }
            }
        }

        public static List<Report> GetReports(int eventId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync($"/reports/{eventId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Report>>().Result.ToList();
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return new List<Report>();
                }
            }
        }

        public static void CreateReport(Report report, int eventId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PostAsJsonAsync($"/reports/{eventId}", report).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static ulong Login(string email, string password, bool hashed = true)
        {
            using (var client = ConnectHttpClient())
            {
                if (!hashed)
                {
                    password = Hasher.Hash(password);
                }

                var response = client.GetAsync($"/login/{email}/{password}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsByteArrayAsync().Result;
                    ulong vfid = BitConverter.ToUInt64(data);
                    _vfid = vfid;
                    return vfid;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return 0;
                }
            }
        }

        public static void Logout()
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync("/logout").Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static int GetLoggedInAccountId()
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync("/accounts/id").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<int>().Result;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return -1;
                }
            }
        }

        public static bool SetLoggedInAccountPassword(string password, bool hashed = true)
        {
            using (var client = ConnectHttpClient())
            {
                if (!hashed)
                {
                    password = Hasher.Hash(password);
                }

                var response = client.PutAsJsonAsync("/accounts/password", password).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return false;
                }
            }
        }

        public static void BanAccount(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PutAsync($"/accounts/ban/{accountId}", null).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void UnbanAccount(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PutAsync($"/accounts/unban/{accountId}", null).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void SilenceAccount(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PutAsync($"/accounts/silence/{accountId}", null).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void UnsilenceAccount(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.PutAsync($"/accounts/unsilence/{accountId}", null).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static List<Account> GetAccounts()
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync("/accounts").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Account>>().Result.ToList();
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return new List<Account>();
                }
            }
        }

        public static string CreateAccount(string email, string username, string password, bool hashed = true)
        {
            var emailRes = Validator.ValidateEmail(email);
            var usernameRes = Validator.ValidateUsername(username);
            var passwordRes = Validator.ValidatePassword(password);
            if (!emailRes.isValid) return emailRes.message;
            if (!usernameRes.isValid) return usernameRes.message;
            if (!passwordRes.isValid) return passwordRes.message;

            if (!hashed)
            {
                password = Hasher.Hash(password);
            }

            Account acc = new Account
            {
                Username = username,
                Email = email,
                PasswordHash = password
            };

            using (var client = ConnectHttpClient())
            {
                var response = client.PostAsJsonAsync("/accounts", acc).Result;
                if (response.IsSuccessStatusCode)
                {
                    return ";";
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    List<string> usernameErrorMsgs = new List<string>();
                    List<string> emailErrorMsgs = new List<string>();
                    try { usernameErrorMsgs = response.Headers.GetValues("MessageUsername").ToList(); } catch { }
                    try { emailErrorMsgs = response.Headers.GetValues("MessageEmail").ToList(); } catch { }

                    string errorMsg = "";
                    if (usernameErrorMsgs.Count > 0)
                    {
                        errorMsg += usernameErrorMsgs[0];
                    }
                    errorMsg += ";";
                    if (emailErrorMsgs.Count > 0)
                    {
                        errorMsg += emailErrorMsgs[0];
                    }
                    if (errorMsg == ";")
                    {
                        return "Unable to create an account.";
                    }
                    return errorMsg;
                }
            }
        }

        public static void DeleteAccount(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.DeleteAsync($"/accounts/{accountId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static string GetAccountUsername(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync($"/accounts/username/{accountId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<string>().Result;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return "";
                }
            }
        }

        public static uint GetAccountPermissions(int accountId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync($"/accounts/permissions/{accountId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<uint>().Result;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return 0u;
                }
            }
        }

        public static List<Message> GetComments(int eventId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.GetAsync($"/comments/{eventId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Message>>().Result.ToList();
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return new List<Message>();
                }
            }
        }

        public static void CreateComment(int eventId, string content)
        {
            Message msg = new Message
            {
                Content = content
            };

            using (var client = ConnectHttpClient())
            {
                var response = client.PostAsJsonAsync($"/comments/{eventId}", msg).Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static void DeleteComment(int eventId, int commentId)
        {
            using (var client = ConnectHttpClient())
            {
                var response = client.DeleteAsync($"/comments/{eventId}/{commentId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}
