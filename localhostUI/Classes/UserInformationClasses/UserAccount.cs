using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace localhostUI.Classes
{
    enum Permissions : uint
    {
        MANAGE_SELF_EVENT       = 0x00000001,
        EDIT_OTHER_EVENTS       = 0x00000002,
        DELETE_OTHER_EVENTS     = 0x00000004,
        SET_EVENT_VISIBILITY    = 0x00000008,
        SEND_CHAT_MESSAGES      = 0x00000010,
        CREATE_REPORTS          = 0x00000020,
        ACCESS_REPORTS          = 0x00000040,
        SILENCE_ACCOUNTS        = 0x00000080,
        BAN_ACCOUNTS            = 0x00000100,
        VIEW_ACCOUNTS           = 0x00000200,
        DELETE_ACCOUNTS         = 0x00000400,
        DELETE_COMMENTS         = 0x00000800,
        BANNED                  = 0x10000000
    }

    enum AccountType : uint
    {
        GUEST = 0,

        USER = Permissions.MANAGE_SELF_EVENT |
               Permissions.SEND_CHAT_MESSAGES |
               Permissions.CREATE_REPORTS,

        MODERATOR = Permissions.MANAGE_SELF_EVENT |
                    Permissions.EDIT_OTHER_EVENTS |
                    Permissions.SET_EVENT_VISIBILITY |
                    Permissions.SEND_CHAT_MESSAGES |
                    Permissions.CREATE_REPORTS |
                    Permissions.ACCESS_REPORTS |
                    Permissions.SILENCE_ACCOUNTS,

        ADMINISTRATOR = Permissions.MANAGE_SELF_EVENT |
                        Permissions.EDIT_OTHER_EVENTS |
                        Permissions.DELETE_ACCOUNTS |
                        Permissions.SET_EVENT_VISIBILITY |
                        Permissions.SEND_CHAT_MESSAGES |
                        Permissions.CREATE_REPORTS |
                        Permissions.ACCESS_REPORTS |
                        Permissions.SILENCE_ACCOUNTS |
                        Permissions.BAN_ACCOUNTS |
                        Permissions.DELETE_ACCOUNTS |
                        Permissions.SET_EVENT_VISIBILITY,
    }

    class UserAccount
    {
        public int Id { get; private set; }
        public uint Permissions { private get; set; }
        public string Username { get; private set; }
        public string Email { get; private set; }

        public UserAccount(int id, string username, string email, uint permissions)
        {
            Id = id;
            Username = username;
            Email = email;
            Permissions = permissions;
        }

        public bool Can(uint permissions)
        {
            return (permissions & ~Permissions) == 0;
        }

        public void AddPermission(Permissions permission)
        {
            Permissions |= (uint)permission;
        }

        public void RemovePermission(Permissions permission)
        {
            Permissions &= ~(uint)permission;
        }
    }
}
