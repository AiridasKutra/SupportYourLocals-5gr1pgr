using System;
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
        private static HttpClientHandler _handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true
        };

        private static HttpClient ConnectHttpClient()
        {

            HttpClient client = new HttpClient(_handler);
            //client.BaseAddress = new Uri("https://localhost:44357");
            client.BaseAddress = new Uri("http://193.219.91.103:7099/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("VFIDAuth", _vfid.ToString());

            return client;
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

        public static void SetLoggedInAccountPassword(string password, bool hashed = true)
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
                    return;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
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

        public static string CreateAccount(string username, string email, string password, bool hashed = true)
        {
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
                    return "";
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    List<string> errorMsgs = response.Headers.GetValues("Message").ToList();
                    if (errorMsgs.Count > 0)
                    {
                        return errorMsgs[0];
                    }
                    else
                    {
                        return "Unable to create an account.";
                    }
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

        public static ulong GetAccountPermissions(int accountId)
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
