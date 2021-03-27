
using Doctors.Domain.DoctorsAggregate;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Doctors.EntityFramework
{
    public class DoctorContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Doctor> doctors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Specialization> specializations { get; set; }

        public DoctorContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .Property(e => e.Sex)
                .HasConversion<string>();
            modelBuilder.Entity<Doctor>()    
                .HasMany<Specialization>(s => s.Specializations)
                .WithMany(c => c.Doctors);
        }
    }
}