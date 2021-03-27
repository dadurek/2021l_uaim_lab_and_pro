using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using Doctors.Domain.SeedWork;

namespace Doctors.Domain.DoctorsAggregate
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Sex Sex { get; set; }

        public List<Specialization> Specializations { get; set; } = new List<Specialization>();


    }
}