namespace ExaminationRooms.Web.Application
{
    using System.Collections.Generic;
    using System.Linq;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application.Mapper;
    
    public class ExaminationRoomQueriesHandler : IExaminationRoomQueriesHandler
    {
        private readonly IExaminationRoomsRepository examinationRoomsRepository;

        public ExaminationRoomQueriesHandler(IExaminationRoomsRepository examinationRoomsRepository)
        {
            this.examinationRoomsRepository = examinationRoomsRepository;
        }

        public IEnumerable<ExaminationRoomDto> GetAll()
        {
            return examinationRoomsRepository.GetAll().Select(r=>r.Map());
        }

        public IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType)
        {
            return examinationRoomsRepository.GetByCertificationType(certificationType)?.Select(ld=>ld.Map());
        }
    }
}
