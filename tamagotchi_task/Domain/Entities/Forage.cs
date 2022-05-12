namespace tamagotchi_task.Domain.Entities
{
    public class Forage : DomainEntity //корм
    {
        public int Buff_HP { get; set; }

        //public ForageCharacter ForageCharacters { get; set; }
        public List<Showcase> Showcases { get; set; }
    }
}
