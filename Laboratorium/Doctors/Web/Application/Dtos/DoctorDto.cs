﻿namespace Doctors.Web.Application
{
    using System.Collections.Generic;

    public class DoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public IEnumerable<int> Specializations { get; set; }
    }
}

