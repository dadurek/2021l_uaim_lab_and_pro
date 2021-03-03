namespace Lib
{
    public class Patient : Person
    {
        public Patient(string firstName, string lastName, Sex sex, string Pesel) : base(firstName, lastName, sex)
        {
            this.Pesel = Pesel;
        }

        private string Pesel { get; }

        public override string GetDescription()
        {
            return $"Patient named {FirstName} {LastName}, which is {Sex}";
        }
    }
}