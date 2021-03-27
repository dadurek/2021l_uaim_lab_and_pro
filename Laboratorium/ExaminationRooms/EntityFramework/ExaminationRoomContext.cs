namespace ExaminationRooms.Web.EntityFramework
{
    using Domain.ExaminationRoomAggregate;
    using Microsoft.EntityFrameworkCore;

    public class ExaminationRoomContext : DbContext
    {
        public DbSet<ExaminationRoom> ExaminationRooms { get; set; }

        public DbSet<Certification> Certifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExaminationRoom>().HasMany(xExaminationRoom => xExaminationRoom.Certifications);
            modelBuilder.Entity<ExaminationRoom>().ToTable("ExaminationRoom");
            modelBuilder.Entity<Certification>().ToTable("Certification");
        }


        protected ExaminationRoomContext()
        {
        }

        public ExaminationRoomContext(DbContextOptions options) : base(options)
        {
        }
    }
}