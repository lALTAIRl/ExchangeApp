using System;
using System.Collections.Generic;
using System.Text;
using Exchange_App.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exchange_App.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Exchange> Exchanges { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
