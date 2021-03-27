namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System;
    using ExaminationRooms.Domain.SeedWork;
    public class Certification : Entity
    {
        
        public DateTime GrantedAt { get; private set; }
        public int Type {get; private set;}

        public Certification(int id, DateTime grantedAt, int type) : base(id)
        {
            GrantedAt = grantedAt;
            Type = type;
        }
    }
}
