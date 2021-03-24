namespace Doctors.Domain.SeedWork
{
    public abstract class Entity
    {
        private int Id { get; }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}