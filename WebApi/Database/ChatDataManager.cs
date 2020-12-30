using Database.TableClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Database
{
    class Chatroom
    {
        public int id;
        public List<Message> messages;

        public Chatroom()
        {
            messages = new List<Message>();
        }
    }

    class ChatDataManager
    {
        private List<Chatroom> chatrooms;
        private string directory;
        private DateTime lastSave;
        private int autosaveTimer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="autosaveTimer">In seconds</param>
        public ChatDataManager(string directory, int autosaveTimer = 30)
        {
            this.directory = directory;
            chatrooms = new List<Chatroom>();
            lastSave = DateTime.Now;
        }

        public List<Message> GetMessages(int roomId)
        {
            foreach (var room in chatrooms)
            {
                if (room.id == roomId)
                {
                    return room.messages;
                }
            }
            return null;
        }

        public List<int> GetRoomIds()
        {
            return chatrooms.Select(room => room.id).ToList();
        }

        public bool CreateRoom(int roomId)
        {
            // Check if id exists
            foreach (var room in chatrooms)
            {
                if (room.id == roomId)
                {
                    return false;
                }
            }

            { // <-- Error without these brackets
                Chatroom room = new Chatroom();
                room.id = roomId;
                chatrooms.Add(room);
                Save();
                return true;
            }
        }

        public bool Load()
        {
            try
            {
                string curDir = Path.Combine(Directory.GetCurrentDirectory(), directory);
                if (!Directory.Exists(curDir))
                {
                    Directory.CreateDirectory(curDir);
                }

                foreach (var file in Directory.EnumerateFiles(curDir))
                {
                    try
                    {
                        string filename = Path.GetFileNameWithoutExtension(file);
                        int id = int.Parse(filename);

                        string jsonstr = File.ReadAllText(filename);
                        List<Message> messages = JsonSerializer.Deserialize<IEnumerable<Message>>(jsonstr).ToList();

                        Chatroom room = new Chatroom();
                        room.id = id;
                        room.messages = messages;
                    }
                    catch { continue; }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(bool autosave = false)
        {
            if (autosave)
            {
                if ((DateTime.Now - lastSave).TotalSeconds < autosaveTimer)
                {
                    return false;
                }
            }

            try
            {
                string curDir = Path.Combine(Directory.GetCurrentDirectory(), directory);
                if (!Directory.Exists(curDir))
                {
                    Directory.CreateDirectory(curDir);
                }

                foreach (var room in chatrooms)
                {
                    try
                    {
                        string filename = $"{room.id}.json";
                        string finalPath = Path.Combine(curDir, filename);

                        string jsonstr = JsonSerializer.Serialize(room.messages.Select(item => item));
                        File.WriteAllText(finalPath, jsonstr);
                    }
                    catch { continue; }
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                lastSave = DateTime.Now;
            }
        }
    }
}
