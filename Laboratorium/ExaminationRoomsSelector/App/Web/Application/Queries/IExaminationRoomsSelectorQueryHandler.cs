namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;

    public interface IExaminationRoomsSelectorHandler
    {
        Task<List<DoctorRoomDto>> GetExaminationRoomsSelectionAsync();

        void AddDoctor(DoctorDto doctorDto);

        void AddRoom(ExaminationRoomDto examinationRoomDto);
    }
}