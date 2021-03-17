namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Specializations { get; set; }
    }
}