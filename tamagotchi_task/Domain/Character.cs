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

    }
}
