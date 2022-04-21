using System.ComponentModel.DataAnnotations;

namespace tamagotchi_task.Domain
{
    public class User: DomainEntity
    {
        [Required(ErrorMessage = "Введите логин!")]
        [Display(Name = "Логин")]
        public string Login { get; set; } //Зачем нужны поля, когда есть свойства?

        [Required(ErrorMessage = "Придумайте пароль!")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}