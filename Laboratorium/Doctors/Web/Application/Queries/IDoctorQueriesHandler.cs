namespace Doctors.Web.Application
{
    using System.Collections.Generic;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
        void Add(DoctorDto doctorDto);
    }
}