using System;
using System.Collections.Generic;
using ExaminationRoomsSelector.Web.Application.Dtos;

namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Threading.Tasks;

    public interface IExaminationRoomsSelectorHandler
    {
        Task<List<DoctorRoomDto>> GetExaminationRoomsSelectionAsync();
        
        void Add(DoctorDto doctorDto);
    }
}
