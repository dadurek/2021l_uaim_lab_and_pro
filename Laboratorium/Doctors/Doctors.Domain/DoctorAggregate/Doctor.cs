using System.Collections.Generic;

namespace Doctors.Domain.DoctorsAggregate
{
    public class Doctor : Person
    {
        public Doctor(int id,string firstName, string lastName, Sex sex, List<int> specializations) : base(id,firstName, lastName, sex)
        {
            this.Specializations = specializations;
        }

        public List<int> Specializations { get;  }

        public override string GetDescription()
        {
            return $"Doctor named {FirstName} {LastName}, who is {Sex}";
        }
    }
}