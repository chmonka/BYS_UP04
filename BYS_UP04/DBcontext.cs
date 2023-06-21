using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS_UP04
{
    public class DBcontext : DbContext
    {
        public string path = Path.GetFullPath(@"..\..\..\");
        public DbSet<Enrollee> Enrollees { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlite("Data Source = " + path + "StudentDB.db");
        }
    }
}
