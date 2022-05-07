

namespace tamagotchi_task.Domain.Entities
{
    public class ToyCharacter
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Guid ToyId { get; set; }
        public int Amount { get; set; }
    }
}
