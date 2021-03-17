using System.Collections.Generic;

namespace Doctors.Web.Application
{
    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}
