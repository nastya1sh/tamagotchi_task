namespace tamagotchi_task.Domain
{
    public class MyUser: DomainEntity
    {
        [Required(ErrorMessage = "Login required!")]
        [Display(Name = "Login")]
        public override string Name { get; set; } //Перегружаем, так как есть ErrorMessage и Name

        [Required(ErrorMessage = "Password required!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        //Ссылка на персонажей
        //Не забываем, что в один момент времени у пользователя м.б. только одна зверушка
        public List<Character> Characters { get; set; }
        public Chat Chats { get; set; }
    }
}