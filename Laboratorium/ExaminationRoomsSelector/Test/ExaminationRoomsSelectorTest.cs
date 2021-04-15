namespace ExaminationRoomsSelector.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using FluentAssertions;
    using Web.Application.Dtos;
    using Web.Web.Application;
    using Xunit;

    public class ExaminationRoomsSelectorTest
    {
        private readonly ExaminationRoomsSelector _selector = new();

        // Point 1.
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorNullRoomNull), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingIllegaPozwlArguments
            (List<DoctorDto> doctorsDto, List<ExaminationRoomDto> examinationRoomsDto)
        {
            Action action = () => _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            action.Should().ThrowExactly<ArgumentNullException>();
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorOneRoomNull), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullExaminationRooms
            (List<DoctorDto> doctorsDto, List<ExaminationRoomDto> examinationRoomsDto)
        {
            Action action = () => _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*examinationRoomsDto*");
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorNullRoomOne), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullDoctors(List<DoctorDto> doctorsDto,
            List<ExaminationRoomDto> examinationRoomsDto)
        {
            Action action = () => _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*doctorsDto*");
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorEmptyRoomEmpty), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingEmptyDoctorsAndEmptyRooms
            (List<DoctorDto> doctorsDto, List<ExaminationRoomDto> examinationRoomsDto)
        {
            var res = _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            res.Should().BeEmpty().And.HaveCount(0);
        }


        // Point 2.
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorOneRoomOne), MemberType = typeof(DataGenerator))]
        public void ShouldMatchDoctorWithExaminationRoomWhenPassingOneDoctorAndOneExaminationRoom
            (List<DoctorDto> doctorsDto, List<ExaminationRoomDto> examinationRoomsDto)
        {
            var res = _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            res.Should().NotBeEmpty().And.HaveCount(1);
        }


        // Point 3.
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorManyRoomsMany), MemberType = typeof(DataGenerator))]
        public void ShouldMatchAllDoctorsWithExaminationRoomsAndCountShouldEqualsTheSpecifiedNumber
            (List<DoctorDto> doctorsDto, List<ExaminationRoomDto> examinationRoomsDto, int count)
        {
            var res = _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            res.Should().NotBeEmpty().And.HaveCount(count);
        }


        // Point 4.
        // Data is 10k Doctors and 10k ExaminationRooms
        [Theory]
        [JsonFileData("Resources/data.json")]
        public void ShouldMatchManyDoctorsWithManyExaminationRoomsInRelevantTime(List<DoctorDto> doctorsDto,
            List<ExaminationRoomDto> examinationRoomsDto)
        {
            var sw = new Stopwatch();

            sw.Start();
            _selector.MatchDoctorsWithRooms(doctorsDto, examinationRoomsDto);
            sw.Stop();

            sw.Elapsed.Seconds.Should().BeLessThan(30); //less than 30s
        }
    }
}