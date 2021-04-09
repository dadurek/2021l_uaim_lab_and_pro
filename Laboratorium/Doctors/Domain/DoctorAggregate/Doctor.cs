namespace Doctors.Domain.DoctorsAggregate
{
    using System.Collections.Generic;

    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Sex Sex { get; set; }

        public List<Specialization> Specializations { get; set; }
    }
}