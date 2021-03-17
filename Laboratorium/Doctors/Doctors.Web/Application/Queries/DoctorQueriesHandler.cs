namespace Doctors.Web.Application
{
    using System.Collections.Generic;
    using System.Linq;
    using Doctors.Domain.DoctorsAggregate;
    using Doctors.Web.Application.Mapper;   
    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorQueriesHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return doctorRepository.GetAll().Select(r=>r.Map());
        }

        public IEnumerable<DoctorDto> GetBySpecialization(int specialization)
        {
            return doctorRepository.GetBySpecialization(specialization)?.Select(ld=>ld.Map());
        }
    }
}
