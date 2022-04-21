using System.ComponentModel.DataAnnotations;

namespace tamagotchi_task.Domain
{
    public class Character: DomainEntity
    {
        [Required(ErrorMessage = "У персонажа должно быть имя!")]
        [Display(Name = "Имя персонажа")]
        public string Nickname { get; set; }

        public int Level { get; set; } = 0;

        //Возможно, сделаем как-то иначе
        //public string Rank { get; set; } = "Noob";
        public int HP { get; set; } = 6; //Пусть у животного будет пока 3 сердечка, а отнимается половина
        public int XP { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Intellect { get; set; } = 0;
    }
}
