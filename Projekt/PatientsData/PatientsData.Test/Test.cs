namespace PatientsData.Test
{
    using System.Collections.Generic;
    using Domain.Models;
    using ExaminationRoomsSelectorApp.Test.Utils;
    using FluentAssertions;
    using Infrastructure.Repositories;
    using Xunit;

    public class Test
    {
        private readonly PatientRepository _repository = new();
        
        [Fact]
        public void ShouldGetSpecifiedNumberOfPatients()
        {
            var res = _repository.GetAll();
            res.Should().NotBeEmpty().And.HaveCount(10);
        }
        
        
        [Theory]
        [MemberData(nameof(DataGenerator.ExactlyOnePatientFromDatabase), MemberType = typeof(DataGenerator))]
        public void ShouldReturnExactlyOnePatientById(Patient patient)
        {
            var res = _repository.GetById(patient.Id);
            res.Should().NotBeNull().And.BeOfType<Patient>().And.Should().Equals(patient);
        }
        
        
        [Theory]
        [MemberData(nameof(DataGenerator.ExactlyOnePatientFromDatabase), MemberType = typeof(DataGenerator))]
        public void ShouldReturnExactlyOnePatientByPesel(Patient patient)
        {
            var res = _repository.GetByPesel(patient.Pesel);
            res.Should().NotBeNull().And.BeOfType<Patient>().And.Should().Equals(patient);
        }
    }
}