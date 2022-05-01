namespace tamagotchi_task.Domain.Entities
{
    public class Toys
    {
        public string Image { get; set; }
        public int Buff_Strength { get; set; }
        public int Buff_Intellect { get; set; }
        public ToyCharacter ToyCharacter { get; set; }
        public Showcase Showcase { get; set; }
    }
}
