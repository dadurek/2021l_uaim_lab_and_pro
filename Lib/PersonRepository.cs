namespace Lib
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] shapes =
        {
            new Patient("Paweł", "Bodeńko", Sex.Female, "123123123"),
            new Doctor("Maciej", "Kowalski", Sex.Male, "321321321"),
            new Patient("Marcin", "Rafał", Sex.Female, "321321321"),
            new Doctor("Monika", "Bodeńko", Sex.Male, "123123123")
        };

        public Person[] Find(Sex sex)
        {
            IList<Person> foundShapes = shapes.Where(s => s.Sex == sex).ToList();

            return foundShapes.ToArray();
        }
    }
}