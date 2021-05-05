namespace ExaminationRoomsSelectorApp.Web.Application.Dtos
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class DoctorsRooms
    {
        [JsonPropertyName("DoctorDtos")] public List<DoctorDto> DoctorDtos { get; set; }

        [JsonPropertyName("ExaminationRoomDtos")]
        public List<ExaminationRoomDto> ExaminationRoomDtos { get; set; }
    }
}