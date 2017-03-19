using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MySQL.Data.Entity.Extensions;

namespace ZwartOpWit.Models
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Stitch> Stitches { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stitch>().HasKey(m => m.Id);
            builder.Entity<Machine>().HasKey(m => m.Id);
            builder.Entity<Department>().HasKey(m => m.Id);
            builder.Entity<User>().HasKey(m => m.Id);
            builder.Entity<Fold>().HasKey(m => m.Id);
        }
    }
}
