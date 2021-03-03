namespace Lib
{
    public class Doctor : Person
    {
        public Doctor(string firstName, string lastName, Sex sex, string licenseNumber) : base(firstName, lastName, sex)
        {
            LicenseNumber = licenseNumber;
        }

        private string LicenseNumber { get; }

        public override string GetDescription()
        {
            return $"Doctor named {FirstName} {LastName}, who is {Sex}";
        }
    }
}