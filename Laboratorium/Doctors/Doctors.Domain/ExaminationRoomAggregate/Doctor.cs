using System.Collections.Generic;

namespace Doctors.Domain.DoctorsAggregate
{
    public class Doctor : Person
    {
        public Doctor(int id,string firstName, string lastName, Sex sex, string licenseNumber, List<int> specializations) : base(id,firstName, lastName, sex)
        {
            this.licenseNumber = licenseNumber;
            this.Specializations = specializations;
        }

        private string licenseNumber { get; }

        public List<int> Specializations { get; }

        public override string GetDescription()
        {
            return $"Doctor named {FirstName} {LastName}, who is {Sex}";
        }
    }
}