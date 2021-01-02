using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Classes
{
    public class Account
    {
        public int Id { get; set; }

        public uint Permissions { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Account()
        {
            Id = -1;
            Permissions = 0u;
            Username = "";
            Email = "";
            PasswordHash = "";
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
