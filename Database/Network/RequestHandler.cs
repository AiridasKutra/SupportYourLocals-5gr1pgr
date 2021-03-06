﻿using Common;
using Common.Formatting;
using Common.Network;
using Database.TableClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace Database.Network
{
    class RequestHandler
    {
        private readonly Database database;
        private readonly TCPServer server;
        private Thread handler;
        private bool threadStop;

        private ChatMessageSender chatMessageSender;
        private ChatDataManager chatManager;

        private ulong vfid;

        public RequestHandler(Database database, TCPServer server)
        {
            this.database = database;
            this.server = server;

            this.chatMessageSender = new ChatMessageSender(server);
            this.chatManager = new ChatDataManager("Chatrooms");

            // Create missing rooms
            chatManager.Load();
            List<int> ids = chatManager.GetRoomIds();
            foreach (var @event in database.QSelectEvents(-1))
            {
                if (ids.IndexOf(@event.Id) == -1)
                {
                    chatManager.CreateRoom(@event.Id);
                }
            }
            chatManager.Save();
        }

        public void Start()
        {
            threadStop = false;
            handler = new Thread(new ThreadStart(HandlerThread));
            handler.Start();
        }

        public void Stop()
        {
            threadStop = true;
        }

        private void HandlerThread()
        {
            if (!server.Start())
            {
                Console.WriteLine("Server start failed");
                return;
            }

            while (true)
            {
                if (threadStop) return;

                while (server.PacketCount() > 0)
                {
                    Packet packet = server.GetPacket();
                    if (packet.PacketId == (uint)PacketType.VFID)
                    {
                        vfid = BitConverter.ToUInt64(packet.Data);
                        packet = server.GetPacket();
                    }

                    switch (packet.PacketId)
                    {
                        case (uint)PacketType.EXECUTE_COMMAND:
                        {
                            ExecuteCommand(packet);
                            break;
                        }
                        case (uint)PacketType.ADD_ENTRY_TABLENAME:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            AddEntry(packets);
                            break;
                        }
                        case (uint)PacketType.EDIT_ENTRY_TABLENAME:
                        {
                            Packet[] packets = new Packet[3];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            packets[2] = server.GetPacket();
                            EditEntry(packets);
                            break;
                        }
                        case (uint)PacketType.REMOVE_ENTRY_TABLENAME:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            RemoveEntry(packets);
                            break;
                        }




                        case (uint)PacketType.SEND_MESSAGE_DATA:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            SendMessage(packets);
                            break;
                        }
                        case (uint)PacketType.OPEN_CHAT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            OpenChat(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_EVENT_COMMENTS:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectEventComments(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_EVENTS_BRIEF:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectEventsBrief(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_EVENTS_FULL:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectEventsFull(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_SPORTS:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectSports(packets);
                            break;
                        }
                        case (uint)PacketType.CREATE_EVENT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            CreateEvent(packets);
                            break;
                        }
                        case (uint)PacketType.DELETE_EVENT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            DeleteEvent(packets);
                            break;
                        }
                        case (uint)PacketType.EDIT_EVENT:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            EditEvent(packets);
                            break;
                        }
                        case (uint)PacketType.SET_EVENT_VISIBLE:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SetEventVisible(packets);
                            break;
                        }
                        case (uint)PacketType.SET_EVENT_INVISIBLE:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SetEventInvisible(packets);
                            break;
                        }
                        case (uint)PacketType.CREATE_REPORT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            CreateReport(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_REPORTS_EVENT_ID:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectReports(packets);
                            break;
                        }
                        case (uint)PacketType.DELETE_REPORTS_EVENT_ID:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            DeleteReports(packets);
                            break;
                        }
                        case (uint)PacketType.DELETE_REPORT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            DeleteReport(packets);
                            break;
                        }
                        case (uint)PacketType.LOGIN_EMAIL:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            Login(packets);
                            break;
                        }
                        case (uint)PacketType.LOGOUT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            Logout(packets);
                            break;
                        }
                        case (uint)PacketType.GET_ACCOUNT_ID:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            GetAccountId(packets);
                            break;
                        }
                        case (uint)PacketType.SET_ACCOUNT_USERNAME:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            SetAccountUsername(packets);
                            break;
                        }
                        case (uint)PacketType.SET_ACCOUNT_PASSWORD:
                        {
                            Packet[] packets = new Packet[2];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            SetAccountPassword(packets);
                            break;
                        }
                        case (uint)PacketType.MAKE_ADMINISTRATOR:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            MakeAccountAdministrator(packets);
                            break;
                        }
                        case (uint)PacketType.MAKE_MODERATOR:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            MakeAccountModerator(packets);
                            break;
                        }
                        case (uint)PacketType.MAKE_USER:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            MakeAccountUser(packets);
                            break;
                        }
                        case (uint)PacketType.BAN_ACCOUNT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            BanAccount(packets);
                            break;
                        }
                        case (uint)PacketType.UNBAN_ACCOUNT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            UnbanAccount(packets);
                            break;
                        }
                        case (uint)PacketType.SILENCE_ACCOUNT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SilenceAccount(packets);
                            break;
                        }
                        case (uint)PacketType.UNSILENCE_ACCOUNT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            UnsilenceAccount(packets);
                            break;
                        }
                        case (uint)PacketType.CREATE_ACCOUNT_USERNAME:
                        {
                            Packet[] packets = new Packet[3];
                            packets[0] = packet;
                            packets[1] = server.GetPacket();
                            packets[2] = server.GetPacket();
                            CreateAccount(packets);
                            break;
                        }
                        case (uint)PacketType.DELETE_ACCOUNT:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            DeleteAccount(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_ACCOUNT_USERNAME:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectAccountUsername(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_ACCOUNT_EMAIL:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectAccountEmail(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_ACCOUNT_PERMISSIONS:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectAccountPermissions(packets);
                            break;
                        }
                        case (uint)PacketType.SELECT_ACCOUNTS:
                        {
                            Packet[] packets = new Packet[1];
                            packets[0] = packet;
                            SelectAccounts(packets);
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }

                    database.SaveChanges();
                }
                Thread.Sleep(10);
            }
        }

        private Account GetAccountFromId(uint senderId)
        {
            List<TCPServer.Client> users = server.GetClients();
            try
            {
                TCPServer.Client user = users.Where(item => item.id == senderId).Single();
                if (user.vfid == vfid)
                {
                    return database.QSelectAccounts(user.accountId).Single();
                }
                return null;
            }
            catch { return null; }
        }

        private void SelectEventsBrief(Packet[] packets)
        {
            try
            {
                int id = BitConverter.ToInt32(packets[0].Data);
                List<Event> events = database.QSelectEvents(id);

                // Create DataList
                DataList data = new DataList();
                foreach (var @event in events)
                {
                    data.Add(@event.ToBriefDataList());
                }

                string jsonStr = Json.FromList(DataList.ToList(data));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId
                });
            }
            catch
            {
                string jsonStr = Json.FromList(DataList.ToList(new DataList()));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId
                });
            }
        }

        private void SelectEventsFull(Packet[] packets)
        {
            try
            {
                int id = BitConverter.ToInt32(packets[0].Data);
                List<Event> events = database.QSelectEvents(id);

                // Create DataList
                DataList data = new DataList();
                foreach (var @event in events)
                {
                    data.Add(@event.ToFullDataList());
                }

                string jsonStr = Json.FromList(DataList.ToList(data));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId
                });
            }
            catch
            {
                string jsonStr = Json.FromList(DataList.ToList(new DataList()));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId
                });
            }
        }

        private void SelectSports(Packet[] packets)
        {
            try
            {
                DataList data = new DataList();
                foreach (var sport in database.context.Sports)
                {
                    data.Add(sport.Name);
                }

                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(data)))
                });
            }
            catch
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(new DataList())))
                });
            }
        }

        private void CreateEvent(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                {
                    string jsonStr = Encoding.ASCII.GetString(packets[0].Data);
                    DataList data = DataList.FromList(Json.ToList(jsonStr));

                    Event newEvent = new Event(data, true) { Author = acc.Id };
                    database.QCreateEvent(newEvent);
                    database.SaveChanges();
                    
                    chatManager.CreateRoom(newEvent.Id);
                    chatManager.Save();
                }
            }
            catch { }
            
        }

        private void DeleteEvent(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                int id = BitConverter.ToInt32(packets[0].Data);

                Event @event = database.context.Events.Where(item => item.Id == id).Single();
                if (@event.Author == acc.Id)
                {
                    if (acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                    {
                        database.QDeleteEvent(id);
                    }
                    return;
                }
                else
                {
                    if (acc.Can((uint)Permissions.DELETE_OTHER_EVENTS))
                    {
                        database.QDeleteEvent(id);
                    }
                    return;
                }
            }
            catch { return; }
        }

        private void EditEvent(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                int id = BitConverter.ToInt32(packets[0].Data);
                string jsonStr = Encoding.ASCII.GetString(packets[1].Data);
                DataList data = DataList.FromList(Json.ToList(jsonStr));
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                Event @event = database.context.Events.Where(item => item.Id == id).Single();
                if (@event.Author == acc.Id)
                {
                    if (acc.Can((uint)Permissions.MANAGE_SELF_EVENT))
                    {
                        database.QEditEvent(id, new Event(data, true));
                    }
                    return;
                }
                else
                {
                    if (acc.Can((uint)Permissions.EDIT_OTHER_EVENTS))
                    {
                        database.QEditEvent(id, new Event(data, true));
                    }
                    return;
                }
                    
            }
            catch { return; }
        }

        private void SetEventVisible(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                int id = BitConverter.ToInt32(packets[0].Data);
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();
                
                if (acc.Can((uint)Permissions.SET_EVENT_VISIBILITY))
                {
                    List<Event> events = database.QSelectEvents(id);
                    if (events.Count > 0)
                    {
                        events[0].Visible = true;
                        database.QEditEvent(id, events[0]);
                    }
                }
            }
            catch { return; }
        }

        private void SetEventInvisible(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                int id = BitConverter.ToInt32(packets[0].Data);
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.SET_EVENT_VISIBILITY))
                {
                    List<Event> events = database.QSelectEvents(id);
                    if (events.Count > 0)
                    {
                        events[0].Visible = false;
                        database.QEditEvent(id, events[0]);
                    }
                }
            }
            catch { return; }
        }

        private void CreateReport(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                string jsonStr = Encoding.ASCII.GetString(packets[0].Data);

                if (acc.Can((uint)Permissions.CREATE_REPORTS))
                {
                    Report report = new Report(DataList.FromList(Json.ToList(jsonStr)), true);
                    database.QCreateReport(report);
                }
            }
            catch { return; }
        }

        private void SelectReports(Packet[] packets)
        {
            try
            {
                if (vfid == 0) throw new Exception();

                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.ACCESS_REPORTS))
                {
                    int eventId = BitConverter.ToInt32(packets[0].Data);

                    List<Report> allreports = database.QSelectReports(-1);
                    List<Report> eventReports = allreports.Where(item => item.EventId == eventId).ToList();

                    // Add all reports to a DataList
                    DataList data = new DataList();
                    foreach (var report in eventReports)
                    {
                        data.Add(report.ToDataList());
                    }

                    // Send reports
                    string jsonStr = Json.FromList(DataList.ToList(data));
                    server.Send(new Packet
                    {
                        PacketId = (uint)PacketType.DATA,
                        SenderId = packets[0].SenderId,
                        Data = Encoding.ASCII.GetBytes(jsonStr)
                    });
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                string jsonStr = Json.FromList(DataList.ToList(new DataList()));
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes(jsonStr)
                });
            }
        }

        private void DeleteReports(Packet[] packets)
        {
            return;
            int eventId = BitConverter.ToInt32(packets[0].Data);

            var allReports = database.QSelectReports(-1);
            var eventReports = allReports.Where(item => item.EventId == eventId);

            database.context.Reports.RemoveRange(eventReports);
        }

        private void DeleteReport(Packet[] packets)
        {
            return;
            int id = BitConverter.ToInt32(packets[0].Data);

            database.QDeleteReport(id);
        }

        private void Login(Packet[] packets)
        {
            string email = Encoding.ASCII.GetString(packets[0].Data);
            string password = Encoding.ASCII.GetString(packets[1].Data);

            ulong vfid = 0;

            Account account = database.context.Accounts.Where(item => item.Email == email).FirstOrDefault();
            if (account != default(Account))
            {
                if (account.PasswordHash == password)
                {
                    vfid = server.GenerateVfid(packets[0].SenderId);
                }
            }

            // Send the verification id to user
            server.Send(new Packet()
            {
                PacketId = (uint)PacketType.DATA,
                SenderId = packets[0].SenderId,
                Data = BitConverter.GetBytes(vfid)
            });

            if (vfid != 0)
            {
                server.LinkAccount(packets[0].SenderId, account.Id);
            }
        }

        private void Logout(Packet[] packets)
        {
            server.UnlinkAccount(packets[0].SenderId);
        }

        private void GetAccountId(Packet[] packets)
        {
            if (this.vfid == 0)
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = BitConverter.GetBytes(-1)
                });
            }

            ulong vfid = BitConverter.ToUInt64(packets[0].Data);

            List<TCPServer.Client> clients = server.GetClients();
            foreach (var client in clients)
            {
                if (client.vfid == vfid)
                {
                    List<Account> accs = database.QSelectAccounts(-1).Where(item => item.Id == client.accountId).ToList();
                    if (accs.Count == 1)
                    {
                        Packet pack = new Packet
                        {
                            PacketId = (uint)PacketType.DATA,
                            SenderId = packets[0].SenderId,
                            Data = BitConverter.GetBytes(accs[0].Id)
                        };
                        server.Send(pack);
                    }
                    else
                    {
                        Packet pack = new Packet
                        {
                            PacketId = (uint)PacketType.DATA,
                            SenderId = packets[0].SenderId,
                            Data = BitConverter.GetBytes(-1)
                        };
                        server.Send(pack);
                    }
                    return;
                }
            }

            Packet packFail = new Packet
            {
                PacketId = (uint)PacketType.DATA,
                SenderId = packets[0].SenderId,
                Data = BitConverter.GetBytes(-1)
            };
            server.Send(packFail);
        }

        private void SetAccountUsername(Packet[] packets)
        {
            return;
            if (vfid == 0) return;
            int id = BitConverter.ToInt32(packets[0].Data);
            string username = Encoding.ASCII.GetString(packets[1].Data);

            List<Account> accounts = database.QSelectAccounts(id);
            if (accounts.Count > 0)
            {
                accounts[0].Username = username;
                database.QEditAccount(id, accounts[0]);
            }
        }

        private void SetAccountPassword(Packet[] packets)
        {
            if (vfid == 0) return;

            int id = BitConverter.ToInt32(packets[0].Data);
            string password = Encoding.ASCII.GetString(packets[1].Data);

            List<TCPServer.Client> clients = server.GetClients();
            foreach (var client in clients)
            {
                if (client.vfid == vfid)
                {
                    List<Account> accs = database.context.Accounts.Where(item => item.Id == client.accountId).ToList();
                    if (accs.Count == 1)
                    {
                        accs[0].PasswordHash = password;
                    }
                    return;
                }
            }

            //List<Account> accounts = database.QSelectAccounts(id);
            //if (accounts.Count > 0)
            //{
            //    accounts[0].PasswordHash = password;
            //    database.QEditAccount(id, accounts[0]);
            //}
        }

        private void MakeAccountAdministrator(Packet[] packets)
        {
            return;
            if (vfid == 0) return;
            Account acc = GetAccountFromId(packets[0].SenderId);
            if (acc.Permissions != (uint)AccountType.ADMINISTRATOR) return;
            int id = BitConverter.ToInt32(packets[0].Data);

            List<Account> accounts = database.QSelectAccounts(id);
            if (accounts.Count > 0)
            {
                accounts[0].Permissions = (uint)AccountType.ADMINISTRATOR;
                database.QEditAccount(id, accounts[0]);
            }
        }

        private void MakeAccountModerator(Packet[] packets)
        {
            return;
            if (vfid == 0) return;
            Account acc = GetAccountFromId(packets[0].SenderId);
            if (acc.Permissions != (uint)AccountType.ADMINISTRATOR) return;
            int id = BitConverter.ToInt32(packets[0].Data);

            List<Account> accounts = database.QSelectAccounts(id);
            if (accounts.Count > 0)
            {
                accounts[0].Permissions = (uint)AccountType.MODERATOR;
                database.QEditAccount(id, accounts[0]);
            }
        }

        private void MakeAccountUser(Packet[] packets)
        {
            return;
            if (vfid == 0) return;
            Account acc = GetAccountFromId(packets[0].SenderId);
            if (acc.Permissions != (uint)AccountType.ADMINISTRATOR) return;
            int id = BitConverter.ToInt32(packets[0].Data);

            List<Account> accounts = database.QSelectAccounts(id);
            if (accounts.Count > 0)
            {
                accounts[0].Permissions = (uint)AccountType.USER;
                database.QEditAccount(id, accounts[0]);
            }
        }

        private void BanAccount(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.BAN_ACCOUNTS))
                {
                    int id = BitConverter.ToInt32(packets[0].Data);

                    List<Account> accounts = database.QSelectAccounts(id);
                    if (accounts.Count > 0)
                    {
                        accounts[0].AddPermission(Permissions.BANNED);
                        database.QEditAccount(id, accounts[0]);
                    }
                }
            }
            catch { return; }
        }

        private void UnbanAccount(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.BAN_ACCOUNTS))
                {
                    int id = BitConverter.ToInt32(packets[0].Data);

                    List<Account> accounts = database.QSelectAccounts(id);
                    if (accounts.Count > 0)
                    {
                        accounts[0].RemovePermission(Permissions.BANNED);
                        database.QEditAccount(id, accounts[0]);
                    }
                }
            }
            catch { return; }
        }

        private void SilenceAccount(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.SILENCE_ACCOUNTS))
                {
                    int id = BitConverter.ToInt32(packets[0].Data);

                    List<Account> accounts = database.QSelectAccounts(id);
                    if (accounts.Count > 0)
                    {
                        accounts[0].RemovePermission(Permissions.SEND_CHAT_MESSAGES);
                        database.QEditAccount(id, accounts[0]);
                    }
                }
            }
            catch { return; }
            
        }

        private void UnsilenceAccount(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.SILENCE_ACCOUNTS))
                {
                    int id = BitConverter.ToInt32(packets[0].Data);

                    List<Account> accounts = database.QSelectAccounts(id);
                    if (accounts.Count > 0)
                    {
                        accounts[0].AddPermission(Permissions.SEND_CHAT_MESSAGES);
                        database.QEditAccount(id, accounts[0]);
                    }
                }
            }
            catch { return; }
            
        }

        private void CreateAccount(Packet[] packets)
        {
            string username = Encoding.ASCII.GetString(packets[0].Data);
            string email = Encoding.ASCII.GetString(packets[1].Data);
            string password = Encoding.ASCII.GetString(packets[2].Data);

            if (database.context.Accounts.Where(item => item.Email == email).Count() > 0)
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes("This email is already in use.")
                });
                return;
            }
            if (database.context.Accounts.Where(item => item.Username == username).Count() > 0)
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes("This username is already in use.")
                });
                return;
            }

            Account account = new Account()
            {
                Username = username,
                Email = email,
                PasswordHash = password,
                Permissions = (uint)AccountType.USER
            };

            database.QCreateAccount(account);
            
            server.Send(new Packet
            {
                PacketId = (uint)PacketType.DATA,
                SenderId = packets[0].SenderId,
                Data = Encoding.ASCII.GetBytes("OK")
            });
        }

        private void DeleteAccount(Packet[] packets)
        {
            if (vfid == 0) return;

            try
            {
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                int id = BitConverter.ToInt32(packets[0].Data);

                if (acc.Can((uint)Permissions.DELETE_ACCOUNTS))
                {
                    database.QDeleteAccount(id);
                }
                else if (acc.Id == id)
                {
                    database.QDeleteAccount(id);
                }
            }
            catch { return; }
        }

        private void SelectAccounts(Packet[] packets)
        {
            try
            {
                if (vfid == 0) throw new Exception();

                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Can((uint)Permissions.VIEW_ACCOUNTS))
                {
                    DataList data = new DataList();
                    foreach (var account in database.context.Accounts)
                    {
                        DataList accData = new DataList();
                        accData.Add(account.Id, "id");
                        accData.Add(account.Username, "username");
                        accData.Add(account.Email, "email");
                        accData.Add(account.Permissions, "permissions");
                        data.Add(accData);
                    }

                    server.Send(new Packet
                    {
                        PacketId = (uint)PacketType.DATA,
                        SenderId = packets[0].SenderId,
                        Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(data)))
                    });
                    return;
                }
            }
            catch { }

            server.Send(new Packet
            {
                PacketId = (uint)PacketType.DATA,
                SenderId = packets[0].SenderId,
                Data = Encoding.ASCII.GetBytes("[]")
            });
        }

        private void SelectAccountUsername(Packet[] packets)
        {
            int id = BitConverter.ToInt32(packets[0].Data);

            List<Account> accounts = database.QSelectAccounts(id);
            if (accounts.Count == 0)
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.TEXT,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes("<unknown>")
                });
                return;
            };

            server.Send(new Packet
            {
                PacketId = (uint)PacketType.TEXT,
                SenderId = packets[0].SenderId,
                Data = Encoding.ASCII.GetBytes(accounts[0].Username)
            });
        }

        private void SelectAccountEmail(Packet[] packets)
        {
            try
            {
                if (vfid == 0) throw new Exception();

                int id = BitConverter.ToInt32(packets[0].Data);
                Account acc = GetAccountFromId(packets[0].SenderId);
                if (acc == null) throw new Exception();

                if (acc.Id == id)
                {
                    List<Account> accounts = database.QSelectAccounts(id);
                    if (accounts.Count == 0) throw new Exception();

                    server.Send(new Packet
                    {
                        PacketId = (uint)PacketType.TEXT,
                        SenderId = packets[0].SenderId,
                        Data = Encoding.ASCII.GetBytes(accounts[0].Email)
                    });
                }
            }
            catch
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.TEXT,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes("Invalid id")
                });
            }
        }

        private void SelectAccountPermissions(Packet[] packets)
        {
            try
            {
                if (vfid == 0) throw new Exception();

                int id = BitConverter.ToInt32(packets[0].Data);

                List<Account> accounts = database.QSelectAccounts(id);
                if (accounts.Count == 0) throw new Exception();

                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packets[0].SenderId,
                    Data = BitConverter.GetBytes(accounts[0].Permissions)
                });
            }
            catch
            {
                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.TEXT,
                    SenderId = packets[0].SenderId,
                    Data = BitConverter.GetBytes(0u)
                });
            }
        }

        private void SelectEventComments(Packet[] packets)
        {
            try
            {
                int id = BitConverter.ToInt32(packets[0].Data);

                // Get messages
                List<Message> messages = chatManager.GetMessages(id);
                if (messages == null)
                {
                    throw new Exception();
                }

                // Send messages
                DataList data = new DataList();
                foreach (var msg in messages)
                {
                    data.Add(msg.ToDataList());
                }

                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.SEND_MESSAGE_DATA,
                    SenderId = packets[0].SenderId,
                    Data = Encoding.ASCII.GetBytes(Json.FromList(DataList.ToList(data)))
                });
            }
            catch
            {
                string jsonStr = Json.FromList(DataList.ToList(new DataList()));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.SEND_MESSAGE_DATA,
                    SenderId = packets[0].SenderId
                });
            }
        }


        // //////////////// //
        // GENERIC HANDLING //
        // //////////////// //
        private void ExecuteCommand(Packet packet)
        {
            string command = Encoding.ASCII.GetString(packet.Data);
            DataList result = database.Execute(command);
            if (result != null)
            {
                string jsonStr = Json.FromList(DataList.ToList(result));
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes(jsonStr),
                    PacketId = (uint)PacketType.DATA,
                    SenderId = packet.SenderId
                });
            }
            else
            {
                server.Send(new Packet
                {
                    Data = Encoding.ASCII.GetBytes("null"),
                    PacketId = (uint)PacketType.TEXT,
                    SenderId = packet.SenderId
                });
            }
        }

        private void AddEntry(Packet[] data)
        {
            string tableName = Encoding.ASCII.GetString(data[0].Data);
            string jsonStr = Encoding.ASCII.GetString(data[1].Data);
            DataList entry = DataList.FromList(Json.ToList(jsonStr));

            if (tableName == "events_full")
            {
                AddEvent(tableName, entry);
            }
        }

        private void EditEntry(Packet[] data)
        {
            string tableName = Encoding.ASCII.GetString(data[0].Data);
            string rowName = Encoding.ASCII.GetString(data[1].Data);
            string jsonStr = Encoding.ASCII.GetString(data[2].Data);
            DataList entry = DataList.FromList(Json.ToList(jsonStr));

            if (tableName == "events_full")
            {
                EditEvent(tableName, rowName, entry);
            }
        }

        private void RemoveEntry(Packet[] data)
        {
            string tableName = Encoding.ASCII.GetString(data[0].Data);
            string rowName = Encoding.ASCII.GetString(data[1].Data);

            if (tableName == "events_full")
            {
                RemoveEvent(tableName, rowName);
            }
        }

        private void SendMessage(Packet[] data)
        {
            try
            {
                Account acc = GetAccountFromId(data[0].SenderId);
                if (acc.Can((uint)Permissions.SEND_CHAT_MESSAGES))
                {
                    Message message = new Message(DataList.FromList(Json.ToList(Encoding.ASCII.GetString(data[0].Data))));
                    int eventId = BitConverter.ToInt32(data[1].Data);

                    if (message.Content.Length == 0) return;

                    message.SendTime = DateTime.Now;
                    message.Sender = acc.Id;

                    // Add message to memory
                    List<Message> messages = chatManager.GetMessages(eventId);
                    if (messages == null) return;
                    messages.Add(message);

                    // Save chat
                    chatManager.Save(true);
                }
            }
            catch { return; }
        }

        private void OpenChat(Packet[] data)
        {
            chatMessageSender.AddClient(data[0].SenderId);

            // Get messages
            int eventId;
            if (!int.TryParse(Encoding.ASCII.GetString(data[0].Data), out eventId))
            {
                return;
            }
            List<Message> messages = chatManager.GetMessages(eventId);
            if (messages == null)
            {
                return;
            }

            // Send message count (+1 for a confirmation packet)
            server.Send(new Packet
            {
                PacketId = (uint)PacketType.MULTIPLE_PACKETS,
                SenderId = data[0].SenderId,
                Data = BitConverter.GetBytes((uint)messages.Count + 1)
            });

            // Send confirmation packet
            server.Send(new Packet
            {
                PacketId = (uint)PacketType.NONE,
                SenderId = data[0].SenderId,
                Data = new byte[1]
            });

            // Send messages
            foreach (var msg in messages)
            {
                string jsonstr = Json.FromList(DataList.ToList(msg.ToDataList()));

                server.Send(new Packet
                {
                    PacketId = (uint)PacketType.SEND_MESSAGE_DATA,
                    SenderId = data[0].SenderId,
                    Data = Encoding.ASCII.GetBytes(jsonstr)
                });
            }
        }

        // ///////////////////// //
        // SPECIALIZED FUNCTIONS //
        // ///////////////////// //
        private void AddEvent(string tableName, DataList entry)
        {
            entry.Remove("id");

            // Create brief copy
            DataList brief = new DataList(entry);
            brief.Remove("address");
            brief.Remove("description");
            brief.Remove("links");

            database.AddEntry(brief, "events_brief");
            database.AddEntry(entry, "events_full");

            // Create chatroom
            DataList chatroom = new DataList();
            database.AddEntry(chatroom, "event_chatrooms");
        }

        private void EditEvent(string tableName, string rowName, DataList entry)
        {
            entry.Remove("id");

            // Create brief copy
            DataList brief = new DataList(entry);
            brief.Remove("address");
            brief.Remove("description");
            brief.Remove("links");

            database.EditEntry(brief, "events_brief", rowName);
            database.EditEntry(entry, "events_full", rowName);
        }

        private void RemoveEvent(string tableName, string rowName)
        {
            database.RemoveEntry("events_brief", rowName);
            database.RemoveEntry("events_full", rowName);

            // Delete chatroom
            database.RemoveEntry("event_chatrooms", rowName);
        }

        private void SendChatMessage(string message, string eventId)
        {
            if (message.Length == 0) return;

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd|HH:mm:ss");

            DataList messageData = new DataList();
            messageData.Add($"{message}", timestamp);

            // Add message to database
            database.AppendEntry(messageData, "event_chatrooms", eventId);

            // Echo incoming message to all connected users
            //chatMessageSender.EchoMessage($"{message}", eventId);
        }
    }
}
