namespace tamagotchi_task.Models.ViewModels
{
    public class RegisterModel //Собственно, модуль регистрации
    {
        [Required(ErrorMessage = "Username required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        public string ConfirmPassword { get; set; }
    }
}
