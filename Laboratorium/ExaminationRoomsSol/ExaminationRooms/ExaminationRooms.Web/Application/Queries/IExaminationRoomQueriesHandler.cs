namespace ExaminationRooms.Web.Application
{
    using System.Collections.Generic;
    
    public interface IExaminationRoomQueriesHandler
    {
        IEnumerable<ExaminationRoomDto> GetAll();
        IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType);
    }
}
