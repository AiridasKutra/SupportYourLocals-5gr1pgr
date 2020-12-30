using Database.TableClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseInterface
    {
        private MainDbContext _context;
        private ChatDataManager _chatDataManager;

        public DatabaseInterface(MainDbContext context)
        {
            _context = context;
            _chatDataManager = new ChatDataManager("Chatrooms");
            _chatDataManager.Load();

            // Create missing comment rooms
            foreach (var @event in _context.Events)
            {
                if (_chatDataManager.GetMessages(@event.Id) == null)
                {
                    _chatDataManager.CreateRoom(@event.Id);
                }
            }
            _chatDataManager.Save(false);
        }

        // Event CRUD
        public List<Event> QSelectEvents(Func<Event, bool> func)
        {
            return _context.Events.Where(func).ToList();
        }

        public void QCreateEvent(Event @event)
        {
            @event.Id = default;
            _context.Events.Add(@event);
        }

        public void QDeleteEvent(Func<Event, bool> func)
        {
            _context.Events.RemoveRange(_context.Events.Where(func));
        }

        public void QEditEvent(int id, Event @event)
        {
            var ev = _context.Events.FirstOrDefault(item => item.Id == id);
            @event.Id = ev.Id;
            @event.Author = ev.Author;
            ev = @event;
        }

        // Account CRUD
        public List<Account> QSelectAccounts(Func<Account, bool> func)
        {
            return _context.Accounts.Where(func).ToList();
        }

        public void QCreateAccount(Account account)
        {
            account.Id = default;
            _context.Accounts.Add(account);
        }

        public void QDeleteAccount(Func<Account, bool> func)
        {
            _context.Accounts.RemoveRange(_context.Accounts.Where(func));
        }

        public void QEditAccount(int id, Account account)
        {
            var ev = _context.Accounts.FirstOrDefault(item => item.Id == id);
            account.Id = ev.Id;
            ev = account;
        }

        // Report CRUD
        public List<Report> QSelectReports(Func<Report, bool> func)
        {
            return _context.Reports.Where(func).ToList();
        }

        public void QCreateReport(Report report)
        {
            report.Id = default;
            _context.Reports.Add(report);
        }

        public void QDeleteReport(Func<Report, bool> func)
        {
            _context.Reports.RemoveRange(_context.Reports.Where(func));
        }

        public void QEditReport(int id, Report report)
        {
            var ev = _context.Reports.FirstOrDefault(item => item.Id == id);
            report.Id = ev.Id;
            ev = report;
        }

        // Sport CRUD
        public List<Sport> QSelectSports(Func<Sport, bool> func)
        {
            return _context.Sports.Where(func).ToList();
        }

        public void QCreateSport(Sport sport)
        {
            sport.Id = default;
            _context.Sports.Add(sport);
        }

        public void QDeleteSport(Func<Sport, bool> func)
        {
            _context.Sports.RemoveRange(_context.Sports.Where(func));
        }

        public void QEditSport(int id, Sport sport)
        {
            var ev = _context.Sports.FirstOrDefault(item => item.Id == id);
            sport.Id = ev.Id;
            ev = sport;
        }

        // Comment CRD
        public List<Message> QSelectComments(Func<Message, bool> func, int roomId)
        {
            var room = _chatDataManager.GetMessages(roomId);
            if (room != null)
            {
                return room.Where(func).ToList();
            }
            else
            {
                return null;
            }
        }

        public void QCreateComment(Message message, int roomId)
        {
            var room = _chatDataManager.GetMessages(roomId);
            if (room != null)
            {
                message.Id = room.Last().Id + 1;
                room.Add(message);
            }
            _chatDataManager.Save(true);
        }

        public void QDeleteComment(Predicate<Message> func, int roomId)
        {
            var room = _chatDataManager.GetMessages(roomId);
            if (room != null)
            {
                room.RemoveAll(func);
            }
            _chatDataManager.Save();
        }

        // Comment room C
        public bool QCreateCommentRoom(int roomId)
        {
            return _chatDataManager.CreateRoom(roomId);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
