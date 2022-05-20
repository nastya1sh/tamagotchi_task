namespace tamagotchi_task.Domain.Entities
{
    public class Showcase
    {
        [Key]
        public Guid Id { get; set; }

        public string Item_Type{ get; set; }
        public string Item_Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string? AuxImg { get; set; } //Костыль-костыльчик для аксессуаров
        public int Level { get; set; } //Уровень, требуемый для покупки этого предмета

        public Guid? ToyId { get; set; }
        public Toys? Toy { get; set; }

        public Guid? PotionId { get; set; }
        public Potions? Potion { get; set; }

        public Guid? ForageId { get; set; }
        public Forage? Forage { get; set; }
    }
}
