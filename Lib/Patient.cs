namespace Lib
{
    public class Patient : Person
    {
        public Patient(string firstName, string lastName, Sex sex, string pesel) : base(firstName, lastName, sex)
        {
            this.pesel = pesel;
        }

        private string pesel { get; }

        public override string GetDescription()
        {
            return $"Patient named {FirstName} {LastName}, who is {Sex}";
        }
    }
}