using EF_task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_task.Data
{
    internal class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =. ; Database=ASP_EFTask ; Trusted_Connection=True; TrustServerCertificate=True");
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Order> Orders { get; set; }   
    }
}
