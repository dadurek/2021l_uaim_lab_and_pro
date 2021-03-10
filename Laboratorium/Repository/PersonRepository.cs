namespace Repository
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] shapes =
        {
            new Patient("Ania", "Bodeńko", Sex.Female, "123123123"),
            new Doctor("Maciej", "Kowalski", Sex.Male, "321321321"),
            new Patient("Ania", "Kozacka", Sex.Female, "321321321"),
            new Doctor("Krzysztof", "Kowal", Sex.Male, "1234748123"),
            new Patient("Marcin", "Rafał", Sex.Male, "32464371"),
            new Doctor("Monika", "Bodeńko", Sex.Female, "12313526123")
        };

        public Person[] Find(Sex sex)
        {
            IList<Person> foundShapes = shapes.Where(s => s.Sex == sex).ToList();

            return foundShapes.ToArray();
        }
    }
}