namespace ExaminationRooms.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Dtos;
    using Infrastructure.Repositories;
    using Mapper;

    public class ExaminationRoomQueriesHandler : IExaminationRoomQueriesHandler
    {
        private readonly IExaminationRoomsRepository examinationRoomsRepository;

        public ExaminationRoomQueriesHandler(IExaminationRoomsRepository examinationRoomsRepository)
        {
            this.examinationRoomsRepository = examinationRoomsRepository;
        }

        public IEnumerable<ExaminationRoomDto> GetAll()
        {
            return examinationRoomsRepository.GetAll().Select(r => r.Map());
        }

        public IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType)
        {
            return examinationRoomsRepository.GetByCertificationType(certificationType)?.Select(ld => ld.Map());
        }

        public void AddRoom(ExaminationRoomDto examinationRoomDto)
        {
            var room = examinationRoomDto.UnMap();
            examinationRoomsRepository.Add(room.Number, room.Certifications);
        }
    }
}