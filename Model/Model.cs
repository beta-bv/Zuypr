using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> Users { get; set; }

        private string _connectionString;

        public DatabaseContext() {
            DotEnv.Load("./database.env");

            string server = DotEnv.Get("DB_HOST");
            string username = DotEnv.Get("DB_USERNAME");
            string password = DotEnv.Get("DB_PASSWORD");
            string database = DotEnv.Get("DB_CATALOG");

            _connectionString = $"server={server};initial catalog={database};user id={username};password={password};";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);
    }
}
