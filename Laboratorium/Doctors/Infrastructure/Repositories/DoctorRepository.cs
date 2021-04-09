namespace Doctors.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.DoctorsAggregate;
    using EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorContext doctorContext;

        public DoctorRepository(DoctorContext doctorContext)
        {
            this.doctorContext = doctorContext;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return doctorContext.Doctors.Include(x => x.Specializations).ToList();
        }

        public IEnumerable<Doctor> GetBySpecialization(int certificationType)
        {
            return doctorContext.Doctors
                .Include(x => x.Specializations)
                .ToList()
                .Where(ld => ld.Specializations
                    .Any(s => s.Number == certificationType));
        }

        public void Add(string FirstName, string LastName, Sex Sex, List<Specialization> Specializations)
        {
            var doc = new Doctor
                {FirstName = FirstName, LastName = LastName, Sex = Sex, Specializations = Specializations};
            doctorContext.Doctors.Add(doc);
            doctorContext.SaveChanges();
        }
    }
}