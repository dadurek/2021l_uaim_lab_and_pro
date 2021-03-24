using System.Collections.Generic;

namespace Doctors.Domain.DoctorsAggregate
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetBySpecialization(int specialization);
    }
}