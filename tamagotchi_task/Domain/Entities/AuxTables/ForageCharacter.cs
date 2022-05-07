

namespace tamagotchi_task.Domain.Entities
{
    public class ForageCharacter
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Guid ForageId { get; set; }
        public int Amount { get; set; }
    }
}
