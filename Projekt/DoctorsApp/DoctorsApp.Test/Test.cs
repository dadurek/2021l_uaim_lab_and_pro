namespace DoctorsApp.Test
{
    using System;
    using Xunit;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using FluentAssertions;
    using Web.Application.Dtos;
    using Web.Logic.Selector;
    using Xunit;
    public class Test
    {
        
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorsNullPatientsNull), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingIllegalArguments(DoctorDto doctorDto,
            IEnumerable<PatientDto> patientDto)
        {
            Action action = () => PatientSelector.GetPatientsThatDoctorCanTreat(doctorDto, patientDto);
            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(DataGenerator.DoctorPatientSmallAmount), MemberType = typeof(DataGenerator))]
        public void ShouldMatchDoctorToPatientsThatCanTreat(DoctorDto doctorDto,
            IEnumerable<PatientDto> patientDto)
        {
            var res = PatientSelector.GetPatientsThatDoctorCanTreat(doctorDto, patientDto);
            res.Should().NotBeEmpty().And.HaveCount(2);
            res.Should().Contain(patientDto.ElementAt(0));
            res.Should().Contain(patientDto.ElementAt(1));
        }
        
        
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorsNullPatientsNull), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingIllegalArgumentsMany(IEnumerable<DoctorDto> doctorDto,
            IEnumerable<PatientDto> patientDto)
        {
            Action action = () => PatientSelector.GetBestPatientDoctorMatches(doctorDto, patientDto);
            action.Should().ThrowExactly<ArgumentNullException>();
        }
        
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorsSmallAmountPatientSmallAmount), MemberType = typeof(DataGenerator))]
        public void ShouldMatchExactNumberOfPerson(IEnumerable<DoctorDto> doctorDto,
            IEnumerable<PatientDto> patientDto, int count)
        {
            var res = PatientSelector.GetBestPatientDoctorMatches(doctorDto, patientDto);
            res.Should().NotBeEmpty().And.HaveCount(count); ;
        }
    }
}