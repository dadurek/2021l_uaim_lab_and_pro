namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System;
    using System.Collections.Generic;

    public class Certification
    {
        public int Id { get; set; }
        public DateTime GrantedAt { get; set; }
        public int Type { get; set; }

        public List<ExaminationRoom> ExaminationRooms { get; set; }
    }
}