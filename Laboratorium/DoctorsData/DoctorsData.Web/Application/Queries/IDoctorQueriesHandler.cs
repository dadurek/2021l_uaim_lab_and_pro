namespace DoctorsData.Web.Application.Queries
{
    using System.Collections.Generic;
    using Dtos;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
        void Add(DoctorDto doctorDto);
    }
}