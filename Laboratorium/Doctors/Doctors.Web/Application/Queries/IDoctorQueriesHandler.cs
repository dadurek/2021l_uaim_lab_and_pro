namespace Doctors.Web.Application
{
    using Doctors.Domain.DoctorsAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorQueriesHandler
    {
        IEnumerable<DoctorDto> GetAll();
        IEnumerable<DoctorDto> GetBySpecialization(int specialization);
    }
}
