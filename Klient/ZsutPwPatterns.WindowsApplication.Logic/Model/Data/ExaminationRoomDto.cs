namespace ZsutPw.Patterns.WindowsApplication.Logic.Model.Data
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    
    public class ExaminationRoomDto
    {
        [JsonPropertyName("Number")] public string Number { get; set; }

        [JsonPropertyName("Certifications")] public List<int> Certifications { get; set; }
    }
}