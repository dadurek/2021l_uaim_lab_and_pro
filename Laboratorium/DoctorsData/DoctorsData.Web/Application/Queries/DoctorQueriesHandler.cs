namespace DoctorsData.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Dtos;
    using Infrastructure.Repositories;
    using Mapper;

    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorQueriesHandler(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return doctorRepository.GetAll().Select(r => r.Map());
        }

        public IEnumerable<DoctorDto> GetBySpecialization(int specialization)
        {
            return doctorRepository.GetBySpecialization(specialization)?.Select(ld => ld.Map());
        }

        public void Add(DoctorDto doctorDto)
        {
            var doctor = doctorDto.UnMap();
            doctorRepository.Add(doctor.FirstName, doctor.LastName, doctor.Sex, doctor.Specializations);
        }
    }
}