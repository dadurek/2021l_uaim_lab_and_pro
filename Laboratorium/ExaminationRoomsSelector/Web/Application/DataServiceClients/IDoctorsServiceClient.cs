namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IDoctorsServiceClient
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        
        void AddDoctor(DoctorDto doctorDto);
    }
}
