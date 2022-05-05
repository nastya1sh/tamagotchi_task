namespace tamagotchi_task.Domain.Entities.AuxTables
{
    public class PotionAmount
    {
        public Guid Id { get; set; }
        public Guid PotionId { get; set; }
        public Guid CharacterId { get; set; }
        public int Amount { get; set; }

        //public Potions Potion { get; set; }
        //public Character Character { get; set; }
    }
}
