﻿using Microsoft.EntityFrameworkCore;
using QuickHealthClinic.DataAccess.Entities;
using System.Diagnostics;

namespace QuickHealthClinic.DataAccess.DbContexts
{
    public class QuickHealthClinicContext : DbContext
    {
        public QuickHealthClinicContext(DbContextOptions<QuickHealthClinicContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
