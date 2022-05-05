namespace tamagotchi_task.Domain.Entities
{
    public class Character : DomainEntity
    {
        [Required(ErrorMessage = "Character must have a name!")]
        [Display(Name = "Character's name")]
        public override string Name { get; set; } //Перегружаем, так как есть ErrorMessage и Name

        public int Level { get; set; }
        public int Money { get; set; }
        public int HP { get; set; } //Пусть у животного будет пока 3 сердечка, а отнимается половина
        public int XP { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }

        public MyUser MyUsers { get; set; } //Ссылка на пользователя
        public ToyCharacter ToyCharacters { get; set; } //Ссылка на таблицу ToyCharacter
        public PotionCharacter PotionCharacters { get; set; } //И т.д.
        public ForageCharacter ForageCharacters { get; set; }
        public List<CharacterTask> CharacterTasks { get; set; } = new List<CharacterTask>();//Нужна для создания связи "Один ко многим"
        public List<Avatar> Avatars { get; set; } = new List<Avatar>();
    }
}
