namespace ExaminationRooms.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Model;
    using EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public class ExaminationRoomsRepository : IExaminationRoomsRepository
    {
        private readonly ExaminationRoomContext examinationRoomContext;

        public ExaminationRoomsRepository(ExaminationRoomContext examinationRoomContext)
        {
            this.examinationRoomContext = examinationRoomContext;
        }

        public IEnumerable<ExaminationRoom> GetAll()
        {
            // using(var examinationRoomContext = new ExaminationRoomContext())
            return examinationRoomContext.ExaminationRoom.Include(x => x.Certifications).ToList();
        }

        public IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType)
        {
            return examinationRoomContext.ExaminationRoom
                .Include(x => x.Certifications)
                .ToList()
                .Where(ld => ld.Certifications.Any(s => s.Type == certificationType));
        }

        public void Add(string Number, List<Certification> Certifications)
        {
            var room = new ExaminationRoom {Number = Number, Certifications = Certifications};
            examinationRoomContext.ExaminationRoom.Add(room);
            examinationRoomContext.SaveChanges();
        }
    }
}