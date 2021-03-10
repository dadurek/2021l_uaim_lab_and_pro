namespace Repository
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] shapes =
        {
            new Patient("Izabela", "Koks", Sex.Female, "123123123"),
            new Doctor("Ewa", "Jakas", Sex.Female, "321321321"),
            new Patient("Martin", "Kozacli", Sex.Male, "321321321"),
            new Doctor("Kacper", "Krzysztosofski", Sex.Male, "1234748123"),
            new Patient("Wojtek", "Rafał", Sex.Male, "32464371"),
            new Doctor("Agnieszka", "Bodeńko", Sex.Female, "12313526123")
        };

        public Person[] Find(Sex sex)
        {
            IList<Person> foundShapes = shapes.Where(s => s.Sex == sex).ToList();

            return foundShapes.ToArray();
        }
    }
}