namespace ExaminationRooms.Infrastructure.EntityFramework
{
    using Domain.Model;
    using Microsoft.EntityFrameworkCore;

    public class ExaminationRoomContext : DbContext
    {
        public DbSet<ExaminationRoom> ExaminationRoom { get; set; }

        public DbSet<Certification> Certification { get; set; }


        public ExaminationRoomContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExaminationRoom>()
                .HasMany(c => c.Certifications)
                .WithMany(e => e.ExaminationRooms);
        }
    }
}