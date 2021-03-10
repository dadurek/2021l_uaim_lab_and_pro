namespace Repository
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] shapes =
        {
            new Patient("Weronika", "Koks", Sex.Female, "123123123"),
            new Doctor("Marcin", "Kowalski", Sex.Male, "321321321"),
            new Patient("Wiktor", "Kozacli", Sex.Male, "321321321"),
            new Doctor("Bartłomiej", "Krzysztosofski", Sex.Male, "1234748123"),
            new Patient("Kacper", "Rafał", Sex.Male, "32464371"),
            new Doctor("Izabela", "Bodeńko", Sex.Female, "12313526123")
        };

        public Person[] Find(Sex sex)
        {
            IList<Person> foundShapes = shapes.Where(s => s.Sex == sex).ToList();

            return foundShapes.ToArray();
        }
    }
}