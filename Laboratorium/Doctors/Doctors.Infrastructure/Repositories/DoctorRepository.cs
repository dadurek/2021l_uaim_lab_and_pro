namespace Doctors.Infrastructure
{
    using Domain.DoctorsAggregate;
    using System.Collections.Generic;
    using System.Linq;
    
    public class DoctorRepository : IDoctorRepository
    {
        private readonly Doctor[] Doctors =
        {
           
            new Doctor(1,"Ewa", "Jakas", Sex.Female, "321321321",new List<int>{1,2}),
            new Doctor(2,"Kacper", "Krzysztosofski", Sex.Male, "1234748123",new List<int>{1,3}),
            new Doctor(3,"Agnieszka", "Bodeńko", Sex.Female, "12313526123",new List<int>{4,2,5}),
            new Doctor(4,"Monika", "Bodeńko", Sex.Female, "12313526123",new List<int>{4,2,7,4}),
            new Doctor(5,"Agnieszka", "Kowalska", Sex.Female, "12313526123",new List<int>{4,2,1}),
            new Doctor(6,"Rafał", "Bodeńko", Sex.Male, "12313526123",new List<int>{4,2,8,10}),
            new Doctor(7,"Agnieszka", "Kowal", Sex.Female, "12313526123",new List<int>{4,2,20}),
            new Doctor(8,"Mateusz", "Kowal", Sex.Male, "12313526123",new List<int>{4,2,21,20,17,15}),
            new Doctor(9,"Paweł", "Bodeńko", Sex.Male, "12313526123",new List<int>{4,2,12,3}),
            new Doctor(10,"Agnieszka", "John", Sex.Female, "12313526123",new List<int>{4,2,11,6}),
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