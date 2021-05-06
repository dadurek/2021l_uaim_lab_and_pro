namespace ExaminationRoomsSelectorApp.Test.Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using PatientsData.Domain.Models;

    public class DataGenerator : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> ExactlyOnePatientFromDatabase()
        {
            yield return new object[]
            {
                new Patient
                {
                    Id = 1, Name = "Tekla Goc", Sex = Sex.Female, Pesel = "48084055957", Conditions = new List<Condition>(){new (){Type = 15, DiagnosisDate = new DateTime(1989,8,5)}}
                }
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