using IRIExcelWEBAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIExcelWEBAPI.Infra
{
    public class CountryContext:DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ServerName;Trusted_Connection=Yes;Integrated Security=true;Connection Timeout=30");
        }
    }
}
