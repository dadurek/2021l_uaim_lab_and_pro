namespace Repository
{
    public class Doctor : Person
    {
        public Doctor(string firstName, string lastName, Sex sex, string licenseNumber) : base(firstName, lastName, sex)
        {
            this.licenseNumber = licenseNumber;
        }

        private string licenseNumber { get; }

        public override string GetDescription()
        {
            return $"Doctor named {FirstName} {LastName}, who is {Sex}";
        }
    }
}