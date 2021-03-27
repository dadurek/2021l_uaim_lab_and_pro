using Doctors.EntityFramework;

namespace Doctors.Web.Application
{
    using System.Collections.Generic;
    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll(DoctorContext doctorContext);
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}
