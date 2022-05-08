

namespace tamagotchi_task.Domain.Entities
{
    public class ToyCharacter
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Guid ToyId { get; set; }
        public int Amount { get; set; }

        public Character Character { get; set; }
        public Toys Toy { get; set; }
    }
}
