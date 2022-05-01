
namespace tamagotchi_task.Domain.Entities
{
    public class Animal : DomainEntity
    {
        [Required(ErrorMessage = "Выберите животное!")]
        [Display(Name = "Животное")]
        public string Image { get; set; }
        public Avatar Avatar { get; set; }
    }
}