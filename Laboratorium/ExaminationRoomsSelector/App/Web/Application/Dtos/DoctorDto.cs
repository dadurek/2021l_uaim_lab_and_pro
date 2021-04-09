namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class DoctorDto
    {
        [JsonPropertyName("FirstName")] public string FirstName { get; set; }

        [JsonPropertyName("LastName")] public string LastName { get; set; }

        [JsonPropertyName("Sex")] public string Sex { get; set; }

        [JsonPropertyName("Specializations")] public List<int> Specializations { get; set; }
    }
}