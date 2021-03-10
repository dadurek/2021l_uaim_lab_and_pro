namespace ConsoleApp
{
    using System;
    using System.Diagnostics;
    using Repository;
    
    public class App
    {
        public static void Main(string[] args)
        {
            IPersonRepository personRepository = new PersonRepository();

            Debug.Assert(personRepository != null);

            foreach (var person in personRepository.Find(Sex.Female))
            {
                var personDescription = person.GetDescription();
                

                Console.WriteLine($"Person description = {personDescription}");
            }

            Console.ReadLine();
        }
    }
}