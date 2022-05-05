namespace tamagotchi_task.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
