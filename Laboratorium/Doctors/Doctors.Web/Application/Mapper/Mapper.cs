using System.Linq;
using Doctors.Domain.DoctorsAggregate;

namespace Doctors.Web.Application.Mapper
{
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
