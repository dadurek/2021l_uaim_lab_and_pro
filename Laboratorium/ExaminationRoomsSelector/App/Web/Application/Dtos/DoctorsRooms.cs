namespace ExaminationRoomsSelector.Test
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Web.Application.Dtos;

    public class Root
    {
        [JsonPropertyName("DoctorDtos")] public List<DoctorDto> DoctorDtos { get; set; }

        [JsonPropertyName("ExaminationRoomDtos")]
        public List<ExaminationRoomDto> ExaminationRoomDtos { get; set; }
    }
}