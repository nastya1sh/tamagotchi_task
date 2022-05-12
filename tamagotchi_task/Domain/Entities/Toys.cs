namespace tamagotchi_task.Domain.Entities
{
    public class Toys : DomainEntity
    {
        public int Buff_Strength { get; set; }
        public int Buff_Intellect { get; set; }

        //public ToyCharacter ToyCharacters { get; set; }
        public List<Showcase> Showcases { get; set; }
    }
}