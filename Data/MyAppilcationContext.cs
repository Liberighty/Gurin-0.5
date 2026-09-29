using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Gurin_0._5.Data
{
    public class MyAppilcationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=dekanat.db");
            }    
        }
    }
}