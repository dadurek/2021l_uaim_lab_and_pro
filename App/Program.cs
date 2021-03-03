namespace App
{
    using System;
    using System.Diagnostics;
    using Lib;
    
    public class App
    {
        public static void Main(string[] args)
        {
            IPersonRepository personRepository = new PersonRepository();

            Debug.Assert(personRepository != null);

            foreach (var shape in personRepository.Find(Sex.Male))
            {
                var shapeDescription = shape.GetDescription();

                Console.WriteLine($"Person description = {shapeDescription}");
            }

            Console.ReadLine();
        }
    }
}