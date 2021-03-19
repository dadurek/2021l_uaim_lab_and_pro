using System.Collections.Generic;
using System.Linq;
using Doctors.Domain.DoctorsAggregate;

namespace Doctors.Infrastructure
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly Doctor[] Doctors =
        {
           
            new Doctor(1,"Ewa", "Jakas", Sex.Female, new List<int>{1,3,5,6}),
            new Doctor(2,"Kacper", "Krzysztosofski", Sex.Male, new List<int>{1,3}),
            new Doctor(3,"Agnieszka", "Bodeńko", Sex.Female, new List<int>{4,2,5}),
            new Doctor(4,"Monika", "Bodeńko", Sex.Female,new List<int>{4,2,7,4}),
            new Doctor(5,"Agnieszka", "Kowalska", Sex.Female, new List<int>{4,2,1}),
            new Doctor(6,"Rafał", "Bodeńko", Sex.Male, new List<int>{4,2,8,10}),
            new Doctor(7,"Agnieszka", "Kowal", Sex.Female, new List<int>{4,2,20}),
            new Doctor(8,"Mateusz", "Kowal", Sex.Male, new List<int>{4,2,21,20,17,15}),
            new Doctor(9,"Paweł", "Bodeńko", Sex.Male, new List<int>{4,2,12,3}),
            new Doctor(10,"Ewelina", "Adawa", Sex.Female, new List<int>{4,2,11,6}),
            new Doctor(11,"Paulina", "Readas", Sex.Female, new List<int>{1,6,8,12}),
            new Doctor(12,"Joanna", "Smieszkowa", Sex.Female, new List<int>{5,3,7,10}),
            new Doctor(13,"Andrzej", "Niski", Sex.Male, new List<int>{3,11,12}),
            new Doctor(14,"Wladimir", "Wysoki", Sex.Male, new List<int>{7,8,9}),
            new Doctor(15,"Mikolaj", "Ktosowski", Sex.Male, new List<int>{3,7,10})
        };

        public IEnumerable<Doctor> GetAll ()
        {
            return Doctors;
        }

        public IEnumerable<Doctor> GetBySpecialization(int certificationType) 
        {
            return Doctors.Where(ld => ld.Specializations.Any(s => s == certificationType));
        }
    }
}