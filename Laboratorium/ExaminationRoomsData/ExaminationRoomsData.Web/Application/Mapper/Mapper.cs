namespace ExaminationRooms.Application.Mapper
{
    using System.Linq;
    using Domain.Model;
    using Dtos;

    public static class Mapper
    {
        public static ExaminationRoomDto Map(this ExaminationRoom examinationRoom)
        {
            if (examinationRoom == null)
                return null;

            return new ExaminationRoomDto
            {
                Number = examinationRoom.Number,
                Certifications = examinationRoom?.Certifications.Select(s => s.Type)
            };
        }

        public static ExaminationRoom UnMap(this ExaminationRoomDto examinationRoomDto)
        {
            if (examinationRoomDto == null)
                return null;

            return new ExaminationRoom
            {
                Number = examinationRoomDto.Number,
                Certifications = examinationRoomDto?.Certifications.Select(s => new Certification {Type = s}).ToList()
            };
        }
    }
}