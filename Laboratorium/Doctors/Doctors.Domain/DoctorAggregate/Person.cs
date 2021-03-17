using System.Diagnostics;
using Doctors.Domain.SeedWork;

namespace Doctors.Domain.DoctorsAggregate
{
    public abstract class Person : Entity
    {
        #region Constructors

        protected Person(int id,string firstName, string lastName, Sex sex) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
        }

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return $"Person named {LastName} {FirstName}, who is {Sex}";
        }

        #endregion

        #region Properties and Fields

        public Sex Sex { get; set; }

        public string FirstName
        {
            get => firstName;

            set
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(value));

                firstName = value;
            }
        }

        private string firstName;

        public string LastName
        {
            get => lastName;

            set
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(value));

                lastName = value;
            }
        }

        private string lastName;

        #endregion
    }
}