namespace tamagotchi_task.Models.ViewModels
{
    public class RegisterModel //Собственно, модуль регистрации
    {
        [Required(ErrorMessage = "Не указан логин!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }
    }
}
