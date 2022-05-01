namespace tamagotchi_task.Domain.Entities
{
    public class ToyCharacter : DomainEntity
    { 
        public int Amount { get; set; }
        public List<Character> Character { get; set; } = new List<Character>();
        public List<Toys> Toys { get; set; } = new List<Toys>();
    }
}
