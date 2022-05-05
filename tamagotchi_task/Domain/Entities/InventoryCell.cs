namespace tamagotchi_task.Domain.Entities
{
    public class InventoryCell : DomainEntity
    {
        public string Item_Type { get; set; }
        public string Item_Name { get; set; }
        public int Amount { get; set; }

        public Character Character { get; set; }
        public List<Toys> Toys { get; set; } = new List<Toys>();
        public List<Potions> Potions { get; set; } = new List<Potions>();
        public List<Forage> Forages { get; set; } = new List<Forage>();
    }
}
