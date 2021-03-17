namespace Doctors.Web.Application.Mapper
{
    using Doctors.Domain.DoctorsAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
                Specializations = doctor?.Specializations.Select(s => s.ToString())
            };
        }
    }
}
