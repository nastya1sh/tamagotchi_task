namespace tamagotchi_task.Domain
{
    public class Character: DomainEntity
    {
        [Required(ErrorMessage = "Character must have a name!")]
        [Display(Name = "Character's name")]
        public override string Name { get; set; } //Перегружаем, так как есть ErrorMessage и Name

        public int Level { get; set; } = 0;

        public string Rank { get; set; } = "Noob"; //Возможно, сделаем как-то иначе
        public int HP { get; set; } = 6; //Пусть у животного будет пока 3 сердечка, а отнимается половина
        public int XP { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Intellect { get; set; } = 0;

        public List<CharacterTask> CharacterTasks { get; set; } = new List<CharacterTask>(); //Нужна для создания связи "Один ко многим"
        public MyUser MyUsers { get; set; } //Ссылка на пользователя
        public ToyCharacter ToyCharacters { get; set; } //Ссылка на таблицу  ToyCharacter
        public PotionCharacter PotionCharacters { get; set; } //И т.д.
        public ForageCharacter ForageCharacters { get; set; }
        public List<Avatar> Avatars { get; set; } = new List<Avatar>();
    }
}
