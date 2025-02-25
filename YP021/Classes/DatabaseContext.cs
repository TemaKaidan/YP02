using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YP021.Elements;
using YP021.Models;

namespace YP021.Classes
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<StudGroups> StudGroups { get; set; }


        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;port=3312;database=UP02;user=root;pwd=;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }    
}