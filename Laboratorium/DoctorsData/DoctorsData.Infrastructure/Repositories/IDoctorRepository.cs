namespace DoctorsData.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using Domain.Model;

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetBySpecialization(int specialization);
        void Add(string FirstName, string LastName, Sex Sex, List<Specialization> Specializations);
    }
}