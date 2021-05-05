namespace DoctorsData.Infrastructure.EntityFramework
{
    using Domain.Model;
    using Microsoft.EntityFrameworkCore;

    public class DoctorContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public DoctorContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .Property(e => e.Sex)
                .HasConversion<string>();
            modelBuilder.Entity<Doctor>()
                .HasMany(s => s.Specializations)
                .WithMany(c => c.Doctors);
        }
    }
}