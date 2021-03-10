namespace Repository
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
            return $"Person named {LastName} {FirstName}, who is {Sex}";
        }

        #endregion

        #region Properties and Fields

        public Sex Sex { get; set; }

        protected string FirstName
        {
            get => firstName;

            set
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(value));

                firstName = value;
            }
        }

        private string firstName;

        protected string LastName
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