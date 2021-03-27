using System.ComponentModel.DataAnnotations;

namespace Doctors.Domain.SeedWork
{
    public abstract class Entity
    {
        [Key]
        private int Id { get; }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}