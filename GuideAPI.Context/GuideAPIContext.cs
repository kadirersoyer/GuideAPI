using GuideAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Context
{
    public class GuideAPIContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonInformation> PersonInformation { get; set; }

        public DbSet<Report> Report { get; set; }
        public GuideAPIContext(DbContextOptions<GuideAPIContext> dbContextOptions) : base(dbContextOptions)
        {

        }


        public override int SaveChanges()
        {
            var now = DateTime.Now;
            foreach (var entityEntry in ChangeTracker.Entries()) // Iterate all made changes
            {
                if (entityEntry.Entity is Person person)
                {
                    if (entityEntry.State == EntityState.Added) // If you want to update TenantId when Order is added
                    { 
                        person.CreatedDate = now;
                        person.UpdatedDate = now;
                    }
                    else if (entityEntry.State == EntityState.Modified) // If you want to update TenantId when Order is modified
                    {
                        person.UpdatedDate = now;
                    }
                }

                if (entityEntry.Entity is PersonInformation PersonInformation)
                {
                    if (entityEntry.State == EntityState.Added) // If you want to update TenantId when Order is added
                    {
                        PersonInformation.CreatedDate = now;
                        PersonInformation.UpdatedDate = now;
                    }
                    else if (entityEntry.State == EntityState.Modified) // If you want to update TenantId when Order is modified
                    {
                        PersonInformation.UpdatedDate = now;
                    }
                }


            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Person Builder
            modelBuilder.Entity<Person>(person =>
            {
                person.HasKey(p => p.Uuid);
                person.Property(m => m.Company).HasMaxLength(100);
                person.Property(m => m.Name).HasMaxLength(200);
                person.Property(m => m.Surname).HasMaxLength(100);
            });
            // Personal Informations Buidler
            modelBuilder.Entity<PersonInformation>(PersonInformation =>
            {
                PersonInformation.HasKey(p => p.Uuid);
                PersonInformation.Property(p => p.Content).IsRequired(false).HasMaxLength(500);
                PersonInformation.HasOne(m => m.Person).WithMany(p => p.Informations).HasForeignKey(f => f.PersonId);
            });


            // Report Buidler
            modelBuilder.Entity<Report>(PersonInformation =>
            {
                PersonInformation.HasKey(p => p.Uuid);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
