using System.ComponentModel.DataAnnotations;

namespace tamagotchi_task.Domain
{
    public abstract class DomainEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
