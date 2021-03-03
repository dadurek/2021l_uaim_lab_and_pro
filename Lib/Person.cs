namespace Lib
{
    using System.Diagnostics;

    public abstract class Person
    {
        #region Constructors

        protected Person(string firstName, string lastName, Sex sex)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
        }

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return $"Person named {FirstName} {LastName}, who is {Sex}";
        }

        #endregion

        #region Properties and Fields

        public Sex Sex { get; set; }

        protected string FirstName
        {
            get => _firstName;

            set
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(value));

                _firstName = value;
            }
        }

        private string _firstName;

        protected string LastName
        {
            get => _lastName;

            set
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(value));

                _lastName = value;
            }
        }

        private string _lastName;

        #endregion
    }
}