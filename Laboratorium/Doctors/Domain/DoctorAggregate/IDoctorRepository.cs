namespace Doctors.Domain.DoctorsAggregate
{
    using System.Collections.Generic;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetBySpecialization(int specialization);
    }
}