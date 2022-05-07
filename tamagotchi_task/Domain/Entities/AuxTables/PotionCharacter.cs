

namespace tamagotchi_task.Domain.Entities
{
    public class PotionCharacter
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Guid PotionId { get; set; }
        public int Amount { get; set; }
    }
}
