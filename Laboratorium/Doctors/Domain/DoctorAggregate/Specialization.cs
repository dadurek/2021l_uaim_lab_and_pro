

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doctors.Domain.DoctorsAggregate
{
    using Doctors.Domain.SeedWork;
    public class Specialization
    {
        public int Number { get; set; }
        [Key]
        public int SpecId { get; set; }
        public List<Doctor> Doctors
        {
            get;
            set;
        } = new List<Doctor>();



    }
}