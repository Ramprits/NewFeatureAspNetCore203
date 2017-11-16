using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewFeatureApplication.Models;

namespace NewFeatureApplication.Infrastructure {
    public class NewApplicationDbContext : DbContext {
        public NewApplicationDbContext (DbContextOptions<NewApplicationDbContext> options) : base (options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
                modelBuilder.Entity (entityType.Name).Property<DateTime> ("LastModified");
                modelBuilder.Entity (entityType.Name).Ignore ("IsDirty");
            }
        }
        public override int SaveChanges () {
            foreach (var entry in ChangeTracker.Entries ()
                    .Where (e => e.State == EntityState.Added || e.State == EntityState.Modified)) {
                entry.Property ("LastModified").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges ();
        }
    }
}