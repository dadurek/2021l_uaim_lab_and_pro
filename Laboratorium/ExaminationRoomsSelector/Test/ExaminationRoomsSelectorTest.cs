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
        public void ShouldThrowArgumentNullExceptionWhenPassingNullArguments
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            Action action = () => _selector.MatchDoctorsWithRooms(doctorList, roomList);
            action.Should().ThrowExactly<ArgumentNullException>();
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorOneRoomNull), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullExaminationRooms
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            Action action = () => _selector.MatchDoctorsWithRooms(doctorList, roomList);
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*examinationRoomsDto*");
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorNullRoomOne), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullDoctors(List<DoctorDto> doctorList,
            List<ExaminationRoomDto> roomList)
        {
            Action action = () => _selector.MatchDoctorsWithRooms(doctorList, roomList);
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*doctorsDto*");
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorEmptyRoomEmpty), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingEmptyDoctorsAndEmptyRooms
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            var res = _selector.MatchDoctorsWithRooms(doctorList, roomList);
            res.Should().BeEmpty().And.HaveCount(0);
        }


        // Point 2.
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorOneRoomOne), MemberType = typeof(DataGenerator))]
        public void ShouldMatchDoctorWithExaminationRoomWhenPassingOneDoctorAndOneExaminationRoom
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            var res = _selector.MatchDoctorsWithRooms(doctorList, roomList);
            res.Should().NotBeEmpty().And.HaveCount(1);
        }


        // Point 3.
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorManyRoomsMany), MemberType = typeof(DataGenerator))]
        public void ShouldMatchAllDoctorsWithExaminationRoomsAndCountShouldEqualsTheSpecifiedNumber
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList, int count)
        {
            var res = _selector.MatchDoctorsWithRooms(doctorList, roomList);
            res.Should().NotBeEmpty().And.HaveCount(count);
        }


        // Point 4.
        // Data is 10k Doctors and 10k ExaminationRooms
        [Theory]
        [JsonFileData("Resources/data.json")]
        public void ShouldMatchManyDoctorsWithManyExaminationRoomsInShortTime(List<DoctorDto> doctorList,
            List<ExaminationRoomDto> roomList)
        {
            var sw = new Stopwatch();

            sw.Start();
            _selector.MatchDoctorsWithRooms(doctorList, roomList);
            sw.Stop();

            sw.Elapsed.Seconds.Should().BeLessThan(30); //less than 30s
        }
    }
}