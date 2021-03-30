namespace Doctors.Domain.DoctorsAggregate
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Specialization
    {
        [Key] public int SpecId { get; set; }

        public int Number { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}