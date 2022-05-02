namespace tamagotchi_task.Domain.Entities
{
    public class ToyCharacter : DomainEntity
    { 
        public int Amount { get; set; }

        public List<Character> Characters { get; set; }
        public List<Toys> Toys { get; set; }
    }
}
