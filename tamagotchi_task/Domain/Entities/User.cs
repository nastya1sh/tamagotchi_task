using System.ComponentModel.DataAnnotations;

namespace tamagotchi_task.Domain
{
    public class User: DomainEntity
    {
        [Required(ErrorMessage = "Введите логин!")]
        [Display(Name = "Логин")]
        public override string Name { get; set; } //Перегружаем, так как есть ErrorMessage и Name

        [Required(ErrorMessage = "Придумайте пароль!")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        //Ссылка на персонажей
        //Не забываем, что в один момент времени у пользователя м.б. только одна зверушка
        public List<Character> Characters { get; set; }
    }
}