

namespace tamagotchi_task.Domain.Entities
{
    public class ForageCharacter
    {
        [Key]
        public Guid Id { get; set; }
        public int Amount { get; set; }

        public Guid CharacterId { get; set; }
        public Character Character { get; set; }

        public Guid ForageId { get; set; }
        public Forage Forage { get; set; }
    }
}
