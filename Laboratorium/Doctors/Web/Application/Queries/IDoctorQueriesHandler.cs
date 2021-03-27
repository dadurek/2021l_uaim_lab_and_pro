namespace Doctors.Web.Application
{
    using System.Collections.Generic;
    using EntityFramework;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll(DoctorContext doctorContext);
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}