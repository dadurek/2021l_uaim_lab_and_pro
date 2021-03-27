namespace Doctors.Web.Application
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.DoctorsAggregate;
    using EntityFramework;
    using Mapper;

    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorQueriesHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorDto> GetAll(DoctorContext doctorContext)
        {
            doctorContext.Database.EnsureCreated();
            var doc = new Doctor
                {FirstName = "xd", LastName = "xd", Sex = Sex.Female};
            doc.Specializations = new List<Specialization> {new Specialization {Number = 1}};
            var doc2 = new Doctor
                {FirstName = "xdd", LastName = "xd", Sex = Sex.Male};
            doc2.Specializations = new List<Specialization> {new Specialization {Number = 2}};
            doctorContext.doctors.Add(doc);
            doctorContext.doctors.Add(doc2);
            doctorContext.SaveChanges();
            return doctorRepository.GetAll().Select(r => r.Map());
        }

        public IEnumerable<DoctorDto> GetBySpecialization(int specialization)
        {
            return doctorRepository.GetBySpecialization(specialization)?.Select(ld => ld.Map());
        }
    }
}