namespace tamagotchi_task.Domain.Entities
{
    public class Character : DomainEntity
    {
        [Required(ErrorMessage = "Character must have a name!")]
        [Display(Name = "Character's name")]
        public override string Name { get; set; } //Перегружаем, так как есть ErrorMessage и Name

        public int Level { get; set; } = 0;
        public int Money { get; set; } = 0;
        public int HP { get; set; } = 6; //Пусть у животного будет пока 3 сердечка, а отнимается половина
        public int XP { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Intellect { get; set; } = 0;

        public string? AnimalImage { get; set; }
        public string ColorImage { get; set; } = "~/img/cat0.png";
        public string? AccessoryImage { get; set; }
        public string WallpaperImage { get; set; } = "~/img/circle.png";


        public MyUser MyUsers { get; set; } //Ссылка на пользователя

        public List<CharacterTask> CharacterTasks { get; set; } = new List<CharacterTask>();//Нужна для создания связи "Один ко многим"
        //public List<Avatar> Avatars { get; set; } = new List<Avatar>();
    }
}
