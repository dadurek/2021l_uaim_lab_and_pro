namespace Model.Dto
{
    using System.Collections.Generic;

    public class DoctorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Pesel { get; set; }

        public List<SpecializationDto> Specializations { get; set; }
    }
}