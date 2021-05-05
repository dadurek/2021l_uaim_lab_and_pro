namespace ExaminationRooms.Application.Dtos
{
    using System.Collections.Generic;

    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }
    }
}