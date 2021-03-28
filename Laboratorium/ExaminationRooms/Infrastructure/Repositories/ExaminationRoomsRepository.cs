namespace ExaminationRooms.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.ExaminationRoomAggregate;
    using Microsoft.EntityFrameworkCore;
    using Web.EntityFramework;

    public class ExaminationRoomsRepository : IExaminationRoomsRepository
    {

        private readonly ExaminationRoomContext examinationRoomContext;

        public ExaminationRoomsRepository(ExaminationRoomContext examinationRoomContext)
        {
            this.examinationRoomContext = examinationRoomContext;
        }

        public IEnumerable<ExaminationRoom> GetAll()
        {
            // examinationRoomContext.Database.EnsureCreated();
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