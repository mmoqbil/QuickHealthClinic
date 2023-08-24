using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickHealthClinic.DataAccess.Entities;
using System.Diagnostics;

namespace QuickHealthClinic.DataAccess.DbContexts
{
    public class QuickHealthClinicContext : IdentityDbContext<Mentor>
    {
        public QuickHealthClinicContext(DbContextOptions<QuickHealthClinicContext> options) : base(options)
        {
        }
        public DbSet<Mentor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
