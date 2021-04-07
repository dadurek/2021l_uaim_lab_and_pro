namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ExaminationRoomDto
    {
        [JsonPropertyName("Number")]
        public string Number { get; set; }

        [JsonPropertyName("Certifications")]
        public IEnumerable<int> Certifications { get; set; }
    }
}