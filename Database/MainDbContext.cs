using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Database.TableClasses;

namespace Database
{
    class MainDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Sport> Sports { get; set; }

        private string connectionString = "";

        public MainDbContext(string server, string database, string username, string password)
        {
            connectionString = $"Server = {server}; Database = {database}; User Id = {username}; Password = {password}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer(@"Server = localhost\SQLEXPRESS; Database = testdb5; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // List<string> <=> string conversion for sports
            modelBuilder
                .Entity<Event>()
                .Property(e => e.Sports)
                .HasConversion(
                    v => string.Join(';', v),
                    v => new List<string>(v.Split(';', StringSplitOptions.None)));

            // List<string> <=> string conversion for links
            modelBuilder
                .Entity<Event>()
                .Property(e => e.Links)
                .HasConversion(
                    v => string.Join(';', v),
                    v => new List<string>(v.Split(';', StringSplitOptions.None)));

            // List<string> <=> string conversion for images
            modelBuilder
                .Entity<Event>()
                .Property(e => e.Images)
                .HasConversion(
                    v => string.Join(';', v),
                    v => new List<string>(v.Split(';', StringSplitOptions.None)));

            // AddressInfo <=> string conversion
            modelBuilder
                .Entity<Event>()
                .Property(e => e.Address)
                .HasConversion(
                    v => v.ToString(),
                    v => AddressInfo.FromString(v));
        }
    }
}
