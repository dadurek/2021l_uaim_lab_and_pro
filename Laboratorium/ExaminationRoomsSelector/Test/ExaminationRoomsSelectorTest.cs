namespace ExaminationRoomsSelector.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using FluentAssertions;
    using Web.Application.Dtos;
    using Web.Application.Queries;
    using Xunit;

    public class ExaminationRoomsSelectorTest
    {
        
        [Theory]
        [MemberData(nameof(DataGenerator.DoctorOneRoomNull), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullExaminationRoomsIEnumerable
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            Action action = () => ExaminationRoomsSelectorQueryHandler.MatchDoctorsWithRooms(doctorList, roomList);
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*examinationRoomsDto*");
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorNullRoomOne), MemberType = typeof(DataGenerator))]
        public void ShouldThrowArgumentNullExceptionWhenPassingNullDoctorsIEnumerable(List<DoctorDto> doctorList,
            List<ExaminationRoomDto> roomList)
        {
            Action action = () => ExaminationRoomsSelectorQueryHandler.MatchDoctorsWithRooms(doctorList, roomList);
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*doctorsDto*");
        }


        [Theory]
        [MemberData(nameof(DataGenerator.DoctorOneRoomOne), MemberType = typeof(DataGenerator))]
        public void ShouldMatchDoctorWithExaminationRoomWhenPassingOneDoctorAndOneExaminationRoom
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            var res = ExaminationRoomsSelectorQueryHandler.MatchDoctorsWithRooms(doctorList, roomList);
            res.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Theory]
        [MemberData(nameof(DataGenerator.DoctorManyRoomsMany), MemberType = typeof(DataGenerator))]
        public void ShouldMatchAllDoctorsWithExaminationRoomsAndCountShouldEqualsTheSpecifiedNumber
            (List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList, int count)
        {
            var res = ExaminationRoomsSelectorQueryHandler.MatchDoctorsWithRooms(doctorList, roomList);
            res.Should().NotBeEmpty().And.HaveCount(count);
        }

        // Data is 10k Doctors and 10k ExaminationRooms
        [Theory]
        [JsonFileData("Resources/data.json")]
        public void BIGONE(List<DoctorDto> doctorList, List<ExaminationRoomDto> roomList)
        {
            var sw = new Stopwatch();
            
            sw.Start();
            ExaminationRoomsSelectorQueryHandler.MatchDoctorsWithRooms(doctorList, roomList);
            sw.Stop();
            
            sw.Elapsed.Seconds.Should().BeLessThan(20); //less than one minute 
        }
    }
}