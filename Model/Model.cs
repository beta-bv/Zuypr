using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        private SqlConnectionStringBuilder _builder;

        public DatabaseContext() {
            _builder = new()
            {
                // TODO: security for this shit
                // NOTE: "localhost" werkt dus niet.. ffs
                DataSource = @"127.0.0.1", 
                UserID = "sa",
                Password = "Betaverse01!",
                InitialCatalog = "zuypr",
                TrustServerCertificate = true,
            };
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_builder.ConnectionString);
    }
}
