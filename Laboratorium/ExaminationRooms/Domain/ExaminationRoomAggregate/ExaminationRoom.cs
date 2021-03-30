namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System.Collections.Generic;

    public class ExaminationRoom
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Certification> Certifications { get; set; }
    }
}