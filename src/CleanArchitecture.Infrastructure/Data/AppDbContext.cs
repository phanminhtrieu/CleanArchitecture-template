using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Entities.BookAggregate;
using CleanArchitecture.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

        // Identity
        public DbSet<ApplicationUser> ApplicatioUsers { get; set; }
        public DbSet<ApplicationRole> ApplicatoinRoles { get; set; }

        // System
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Book
            builder.ApplyConfiguration(new BookConfiguration());

            builder.Seed();
        }
    }
}
