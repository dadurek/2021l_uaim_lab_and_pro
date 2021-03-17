namespace ExaminationRooms.Web.Application
{
    using System.Collections.Generic;
    
    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<string> Certifications { get; set; }
    }
}
