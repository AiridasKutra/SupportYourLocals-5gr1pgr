using Common;
using Common.Formatting;
using Common.Network;
using localhostUI;
using localhostUI.Backend;
using localhostUI.Classes;
using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Common.Network
{
    public delegate void TimeoutHandler(object source, TimeoutEventArgs e);

    public class TimeoutEventArgs : EventArgs
    {
        private string message;

        public TimeoutEventArgs(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return message;
        }
    }

    class ClientWrapper
    {
        private TCPClient client;
        private bool connected;
        private ulong vfid;

        public event TimeoutHandler OnTimeout;

        public int TIME_OUT_MS { get; set; } = 5000;
        
        public ClientWrapper()
        {
            client = new TCPClient();
            connected = false;
            vfid = 0;
        }

        public bool Connect(string ip, ushort port)
        {
            if (client.Connect(ip, port))
            {
                WaitForPacket();
                Packet result = client.GetPacket();
                if (Encoding.ASCII.GetString(result.Data) == "Connected.")
                {
                    connected = true;
                    return true;
                }
                else
                {
                    connected = false;
                    return false;
                }
            }
            else
            {
                connected = false;
                return false;
            }
        }

        public void Disconnect()
        {
            if (Connected())
            {
                client.Disconnect();
            }
        }

        public bool Connected()
        {
            connected = client.Connected();
            return connected;
        }

        public void WaitForPacket(int waitTimer = 10)
        {
            if (Connected())
            {
                DateTime startWait = DateTime.Now;
                while (client.PacketCount() == 0)
                {
                    Thread.Sleep(waitTimer);
                    if ((DateTime.Now - startWait).TotalMilliseconds > TIME_OUT_MS)
                    {
                        OnTimeout(this, new TimeoutEventArgs("timeout"));
                        return;
                    }
                }
            }
        }

        public void SetVfid(ulong vfid)
        {
            this.vfid = vfid;
        }

        public void SendVfid()
        {
            if (!client.Connected())
            {
                OnTimeout(this, new TimeoutEventArgs("disconnected"));
                return;
            }

            client.AddToSendQueue(new Packet
            {
                PacketId = (uint)PacketType.VFID,
                Data = BitConverter.GetBytes(vfid)
            });
        }

        public List<EventBrief> SelectEventsBrief(int id = -1)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_EVENTS_BRIEF,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket(1);

            Packet packet = client.GetPacket();
            string jsonStr = Encoding.ASCII.GetString(packet.Data);
            DataList events = DataList.FromList(Json.ToList(jsonStr));
            if (events == null) return new List<EventBrief>();

            List<EventBrief> eventList = new List<EventBrief>();
            foreach (var @event in events)
            {
                eventList.Add(new EventBrief((DataList)@event.item));
            }
            return eventList;
        }

        public List<EventFull> SelectEventsFull(int id = -1)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_EVENTS_FULL,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket(1);

            Packet packet = client.GetPacket();
            string jsonStr = Encoding.ASCII.GetString(packet.Data);
            DataList events = DataList.FromList(Json.ToList(jsonStr));
            if (events == null) return new List<EventFull>();

            List<EventFull> eventList = new List<EventFull>();
            foreach (var @event in events)
            {
                eventList.Add(new EventFull((DataList)@event.item));
            }
            return eventList;
        }

        public List<string> SelectSports()
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_SPORTS,
                Data = new byte[1] { 0 }
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket(1);

            Packet packet = client.GetPacket();
            try
            {
                List<string> sports = new List<string>();

                DataList data = DataList.FromList(Json.ToList(Encoding.ASCII.GetString(packet.Data)));
                foreach (var sport in data)
                {
                    sports.Add((string)sport.item);
                }

                return sports;
            }
            catch
            {
                return new List<string>();
            }
        }

        public void CreateEvent(EventFull @event)
        {
            SendVfid();

            string jsonStr = Json.FromList(DataList.ToList(@event.ToDataList()));

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.CREATE_EVENT,
                Data = Encoding.ASCII.GetBytes(jsonStr)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void DeleteEvent(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.DELETE_EVENT,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void EditEvent(EventFull @event)
        {
            SendVfid();

            string jsonStr = Json.FromList(DataList.ToList(@event.ToDataList()));

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_EVENT,
                Data = BitConverter.GetBytes(@event.Id)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_EVENT_DATA,
                Data = Encoding.ASCII.GetBytes(jsonStr)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.SendQueue();
        }

        public void SetEventVisible(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SET_EVENT_VISIBLE,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void SetEventInvisible(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SET_EVENT_INVISIBLE,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void CreateReport(Report report)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.CREATE_REPORT,
                Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(report.ToDataList())))
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public List<Report> SelectReports(int eventId)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_REPORTS_EVENT_ID,
                Data = BitConverter.GetBytes(eventId)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket();

            // Unpack DataList
            Packet packet = client.GetPacket();
            DataList data = DataList.FromList(Json.ToList(Encoding.ASCII.GetString(packet.Data)));
            List<Report> reports = new List<Report>();
            foreach (var report in data)
            {
                reports.Add(new Report((DataList)report.item));
            }

            return reports;
        }

        public void DeleteReports(int eventId)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.DELETE_REPORTS_EVENT_ID,
                Data = BitConverter.GetBytes(eventId)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void DeleteReport(int reportId)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.DELETE_REPORT,
                Data = BitConverter.GetBytes(reportId)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void SendMessage(Message message, int eventId)
        {
            SendVfid();

            string jsonStr = Json.FromList(DataList.ToList(message.ToDataList()));
            string idString = eventId.ToString();

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_DATA,
                Data = Encoding.ASCII.GetBytes(jsonStr)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_EVENT_ID,
                Data = Encoding.ASCII.GetBytes(idString)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.SendQueue();
        }

        public ulong Login(string email, string password, bool hashed = false)
        {
            SendVfid();

            string passwordHash = password;
            if (!hashed)
            {
                passwordHash = Validation.Hasher.Hash(password);
            }

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.LOGIN_EMAIL,
                Data = Encoding.ASCII.GetBytes(email)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.LOGIN_PASSWORD,
                Data = Encoding.ASCII.GetBytes(passwordHash)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.SendQueue();
            WaitForPacket();

            Packet packet = client.GetPacket();
            ulong vfid = BitConverter.ToUInt64(packet.Data);

            if (vfid == 0) return vfid;
            SetVfid(vfid);

            int id = GetAccountId(vfid);

            UserAccount acc = new UserAccount
            (
                id,
                SelectAccountUsername(id),
                email,
                SelectAccountPermissions(id)
            );
            Program.UserDataManager.UserAccount = acc;

            return vfid;
        }

        public void Logout()
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.LOGOUT,
                Data = new byte[0]
            };

            client.AddToSendQueue(pack);
            client.SendQueue();

            Program.UserDataManager.UserAccount = new UserAccount(-1, "", "", 0);

            vfid = 0;
        }

        public int GetAccountId(ulong vfid)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.GET_ACCOUNT_ID,
                Data = BitConverter.GetBytes(vfid)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket();

            Packet packet = client.GetPacket();
            return BitConverter.ToInt32(packet.Data);
        }

        public void SetAccountUsername(int id, string username)
        {
            SendVfid();

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.SET_ACCOUNT_USERNAME,
                Data = BitConverter.GetBytes(id)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.SET_ACCOUNT_USERNAME,
                Data = Encoding.ASCII.GetBytes(username)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.SendQueue();
        }

        public void SetAccountPassword(int id, string password)
        {
            SendVfid();

            string passwordHash = Validation.Hasher.Hash(password);

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.SET_ACCOUNT_PASSWORD,
                Data = BitConverter.GetBytes(id)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.SET_ACCOUNT_PASSWORD,
                Data = Encoding.ASCII.GetBytes(passwordHash)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.SendQueue();
        }

        public void MakeAccountAdministrator(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.MAKE_ADMINISTRATOR,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void MakeAccountModerator(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.MAKE_MODERATOR,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void MakeAccountUser(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.MAKE_USER,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void BanAccount(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.BAN_ACCOUNT,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void UnbanAccount(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.UNBAN_ACCOUNT,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void SilenceAccount(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SILENCE_ACCOUNT,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public void UnsilenceAccount(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.UNSILENCE_ACCOUNT,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
        }

        public string CreateAccount(string username, string email, string password)
        {
            SendVfid();

            string passwordHash = Validation.Hasher.Hash(password);

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.CREATE_ACCOUNT_USERNAME,
                Data = Encoding.ASCII.GetBytes(username)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.CREATE_ACCOUNT_EMAIL,
                Data = Encoding.ASCII.GetBytes(email)
            };

            Packet pack3 = new Packet
            {
                PacketId = (uint)PacketType.CREATE_ACCOUNT_PASSWORD,
                Data = Encoding.ASCII.GetBytes(passwordHash)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.AddToSendQueue(pack3);
            client.SendQueue();
            WaitForPacket(1);

            Packet result = client.GetPacket();
            return Encoding.ASCII.GetString(result.Data);
        }

        public void DeleteAccount(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.DELETE_ACCOUNT,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
        }

        public string SelectAccountUsername(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_ACCOUNT_USERNAME,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket();

            Packet packet = client.GetPacket();
            return Encoding.ASCII.GetString(packet.Data);
        }

        public string SelectAccountEmail(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_ACCOUNT_EMAIL,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket();

            Packet packet = client.GetPacket();
            return Encoding.ASCII.GetString(packet.Data);
        }

        public uint SelectAccountPermissions(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_ACCOUNT_PERMISSIONS,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket();

            Packet packet = client.GetPacket();
            return BitConverter.ToUInt32(packet.Data);
        }

        public List<UserAccount> SelectAccounts()
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_ACCOUNTS,
                Data = new byte[1]
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket(1);

            List<UserAccount> accounts = new List<UserAccount>();

            try
            {
                Packet packet = client.GetPacket();
                DataList data = DataList.FromList(Json.ToList(Encoding.ASCII.GetString(packet.Data)));
                foreach (var acc in data)
                {
                    DataList props = (DataList)acc.item;
                    accounts.Add(new UserAccount
                    (
                        (int)props.Get("id"),
                        (string)props.Get("username"),
                        (string)props.Get("email"),
                        (uint)props.Get("permissions")
                    ));
                }
                return accounts;
            }
            catch
            {
                return new List<UserAccount>();
            }
        }

        public List<Message> SelectEventComments(int id)
        {
            SendVfid();

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.SELECT_EVENT_COMMENTS,
                Data = BitConverter.GetBytes(id)
            };

            client.AddToSendQueue(pack);
            client.SendQueue();
            WaitForPacket(1);

            List<Message> comments = new List<Message>();

            try
            {
                Packet packet = client.GetPacket();
                DataList data = DataList.FromList(Json.ToList(Encoding.ASCII.GetString(packet.Data)));

                foreach (var item in data)
                {
                    Message comment = new Message((DataList)item.item);
                    comments.Add(comment);
                }

                return comments;
            }
            catch
            {
                return new List<Message>();
            }
        }

        public void SendComment(Message message, int eventId)
        {
            SendVfid();

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_DATA,
                Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(message.ToDataList())))
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.SEND_MESSAGE_EVENT_ID,
                Data = BitConverter.GetBytes(eventId)
            };

            client.AddToSendQueue(pack1);
            client.AddToSendQueue(pack2);
            client.SendQueue();
        }









        public DataList ExecuteCommand(string command)
        {
            if (command.Length > 512) return null;
            if (!client.Connected()) return null;

            Packet pack = new Packet
            {
                PacketId = (uint)PacketType.EXECUTE_COMMAND,
                Data = Encoding.ASCII.GetBytes(command)
            };

            client.Send(pack);
            while (client.PacketCount() < 1)
            {
                Thread.Sleep(1);
            }

            Packet packet = client.GetPacket();
            string jsonStr = Encoding.ASCII.GetString(packet.Data);
            return DataList.FromList(Json.ToList(jsonStr));
        }

        public bool AddEntry(DataList entry, string tableName)
        {
            if (!client.Connected()) return false;

            // Remove id attribute
            entry.Remove("id");

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(2u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.ADD_ENTRY_TABLENAME,
                Data = Encoding.ASCII.GetBytes(tableName)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.ADD_ENTRY_DATA,
                Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(entry)))
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);

            return true;
        }

        public bool ModifyEntry(DataList entry, string tableName, int id)
        {
            if (!client.Connected()) return false;

            // Remove id attribute
            entry.Remove("id");

            string rowName = id.ToString();

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(3u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_ENTRY_TABLENAME,
                Data = Encoding.ASCII.GetBytes(tableName)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_ENTRY_ROWNAME,
                Data = Encoding.ASCII.GetBytes(rowName)
            };

            Packet pack3 = new Packet
            {
                PacketId = (uint)PacketType.EDIT_ENTRY_DATA,
                Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(entry)))
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);
            client.Send(pack3);

            return true;
        }

        public bool RemoveEntry(string tableName, int id)
        {
            if (!client.Connected()) return false;

            string rowName = id.ToString();

            Packet packInfo = new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                Data = BitConverter.GetBytes(2u)
            };

            Packet pack1 = new Packet
            {
                PacketId = (uint)PacketType.REMOVE_ENTRY_TABLENAME,
                Data = Encoding.ASCII.GetBytes(tableName)
            };

            Packet pack2 = new Packet
            {
                PacketId = (uint)PacketType.REMOVE_ENTRY_ROWNAME,
                Data = Encoding.ASCII.GetBytes(rowName)
            };

            client.Send(packInfo);
            client.Send(pack1);
            client.Send(pack2);

            return true;
        }
    }
}
