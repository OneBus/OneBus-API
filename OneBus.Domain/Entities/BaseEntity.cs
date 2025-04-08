using OneBus.Domain.Extensions;

namespace OneBus.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow.ToBrazilianDateTime();
        }

        public ulong Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public void Disable() 
        {
            DeletedAt = DateTime.UtcNow.ToBrazilianDateTime();
        }
        
        public void Enable()
        {
            DeletedAt = null;
        }
    }
}
