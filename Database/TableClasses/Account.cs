using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.TableClasses
{
    class Account
    {
        [Key]
        public int Id { get; set; }

        public uint Permissions { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(64)]
        public string PasswordHash { get; set; }

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
