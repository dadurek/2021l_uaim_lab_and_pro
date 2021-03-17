using System.Collections.Generic;

namespace Doctors.Web.Application
{
    public class DoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Specializations { get; set; }
    }
}
