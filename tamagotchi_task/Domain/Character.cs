using System.ComponentModel.DataAnnotations;

namespace tamagotchi_task.Domain
{
    public class Character
    {
        [Required]
        public string Nickname { get; set; }

        public int Level { get; set; } = 0;

        //Возможно, сделаем как-то иначе
        //public string Rank { get; set; } = "Noob";
        public int HP { get; set; } = 6;
        public int XP { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Intellect { get; set; } = 0;
    }
}
