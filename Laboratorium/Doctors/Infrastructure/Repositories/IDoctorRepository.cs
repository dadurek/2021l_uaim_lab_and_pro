namespace Doctors.Domain.DoctorsAggregate
{
    using System.Collections.Generic;
    using EntityFramework;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll(DoctorContext doctorContext);
        IEnumerable<Doctor> GetBySpecialization(DoctorContext doctorContext, int specialization);
    }
}