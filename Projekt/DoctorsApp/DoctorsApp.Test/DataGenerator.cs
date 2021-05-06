namespace DoctorsApp.Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Web.Application.Dtos;

    public class DataGenerator : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> DoctorsNullPatientsNull()
        {
            yield return new object[]
            {
                null,
                null
            };
        }
        
        public static IEnumerable<object[]> DoctorPatientSmallAmount()
        {
            yield return new object[]
            {
                new DoctorDto
                    {Id = 1, Name = "Marcin", Pesel = "123", Sex = "Male", Specializations = new List<SpecializationDto> {new(){Type = 1}, new(){Type = 2}}},
                new List<PatientDto>
                {
                    new()
                        {Name = "Maciek", Pesel = "123", Id = 1, Sex = "Male", Conditions = new List<ConditionDto>{new (){Type = 1}, new(){ Type = 2} }},
                    new()
                        {Name = "Zbigniew", Pesel = "123", Id = 2, Sex = "Male", Conditions = new List<ConditionDto>{new (){Type = 2}, new(){ Type = 3} }},
                    new()
                        {Name = "Witold", Pesel = "123", Id = 3, Sex = "Male", Conditions = new List<ConditionDto>{new (){Type = 3}, new(){ Type = 4} }}
                }
            };
        }
        
        public static IEnumerable<object[]> DoctorsSmallAmountPatientSmallAmount()
        {
            yield return new object[]
            {
                new List<DoctorDto>{
                    new (){Id = 1, Name = "Marcin", Pesel = "123", Sex = "Male", Specializations = new List<SpecializationDto> {new(){Type = 1}, new(){Type = 2}}},
                    new (){Id = 2, Name = "Zbigniew", Pesel = "123", Sex = "Male", Specializations = new List<SpecializationDto> {new(){Type = 3}, new(){Type = 4}}},
                    new (){Id = 3, Name = "Krzysztof", Pesel = "123", Sex = "Male", Specializations = new List<SpecializationDto> {new(){Type = 4}, new(){Type = 5}}}
                },
                new List<PatientDto>
                {
                    new()
                        {Name = "Maciek", Pesel = "123", Id = 1, Sex = "Male", Conditions = new List<ConditionDto>{new (){Type = 1}, new(){ Type = 2} }},
                    new()
                        {Name = "Zbigniew", Pesel = "123", Id = 2, Sex = "Male", Conditions = new List<ConditionDto>{new (){Type = 2}, new(){ Type = 3} }},
                    new()
                        {Name = "Witold", Pesel = "123", Id = 3, Sex = "Male", Conditions = new List<ConditionDto>{new (){Type = 6}, new(){ Type = 7} }}
                },
                2
            };
        }


        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}