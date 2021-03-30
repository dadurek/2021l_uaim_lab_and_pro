namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System.Collections.Generic;

    public class ExaminationRoomDto
    {
        public ExaminationRoomDto(string number, IEnumerable<int> certifications)
        {
            Number = number;
            Certifications = certifications;
        }

        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }
    }
}