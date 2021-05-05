namespace ExaminationRooms.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using Domain.Model;

    public interface IExaminationRoomsRepository
    {
        IEnumerable<ExaminationRoom> GetAll();
        IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType);
        void Add(string Number, List<Certification> Certifications);
    }
}