namespace Doctors.Web.Application.Mapper
{
    using System;
    using System.Linq;
    using Domain.DoctorsAggregate;

    public static class Mapper
    {
        public static DoctorDto Map(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorDto
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Sex = doctor.Sex.ToString(),
                Specializations = doctor?.Specializations.Select(s => s.Number)
            };
        }

        public static Doctor UnMap(this DoctorDto doctorDto)
        {
            if (doctorDto == null)
                return null;

            return new Doctor
            {
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                Sex = (Sex) Enum.Parse(typeof(Sex), doctorDto.Sex),
                Specializations = doctorDto?.Specializations.Select(s => new Specialization {Number = s}).ToList()
            };
        }
    }
}