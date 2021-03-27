namespace Doctors.Domain.SeedWork
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity
    {
        [Key] private int Id { get; }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}