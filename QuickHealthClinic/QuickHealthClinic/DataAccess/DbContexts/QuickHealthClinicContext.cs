using Microsoft.EntityFrameworkCore;
using QuickHealthClinic.DataAccess.Entities;

namespace QuickHealthClinic.DataAccess.DbContexts
{
    public class QuickHealthClinicContext : DbContext
    {
        public QuickHealthClinicContext(DbContextOptions<QuickHealthClinicContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
