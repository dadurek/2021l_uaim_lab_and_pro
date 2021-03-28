namespace Doctors.Domain.DoctorsAggregate
{
    using System.Collections.Generic;
    using EntityFramework;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetBySpecialization(int specialization);
        void Add(string FirstName, string LastName, Sex Sex, List<Specialization> Specializations);
    }
}