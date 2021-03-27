namespace Doctors.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.DoctorsAggregate;

    public class DoctorRepository : IDoctorRepository
    {
        private readonly Doctor[] Doctors =
        {
        };

        public IEnumerable<Doctor> GetAll()
        {
            return Doctors;
        }

        public IEnumerable<Doctor> GetBySpecialization(int certificationType)
        {
            return Doctors.Where(ld => ld.Specializations.Any(s => s.Number == certificationType));
        }
    }
}