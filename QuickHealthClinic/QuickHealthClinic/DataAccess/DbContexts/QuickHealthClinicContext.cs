using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickLifeCoachingClinic.DataAccess.Entities;
using System.Diagnostics;

namespace QuickLifeCoachingClinic.DataAccess.DbContexts
{
    public class QuickHealthClinicContext : IdentityDbContext<Mentor>
    {
        public QuickHealthClinicContext(DbContextOptions<QuickHealthClinicContext> options) : base(options)
        {
        }
        public DbSet<Mentor> Mentors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
