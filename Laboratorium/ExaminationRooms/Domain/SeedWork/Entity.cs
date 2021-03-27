namespace ExaminationRooms.Domain.SeedWork
{
    public abstract class Entity
    {
        private int ID { get; }

        protected Entity(int id) 
        {
            ID = id;
        }
    }
}
