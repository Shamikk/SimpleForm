using Microsoft.EntityFrameworkCore;
using SimpleForm.BLL;
using SimpleForm.DAL.Configurations;
using System;

namespace SimpleForm.DAL
{
    public class SimpleFormDbContext : DbContext
    {
        protected SimpleFormDbContext(DbContextOptions<SimpleFormDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FormDbConfiguration());
            modelBuilder.ApplyConfiguration(new UserDbConfiguration());
            modelBuilder.ApplyConfiguration(new LogDbConfiguration());
        }
    }
}
