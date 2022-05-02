
namespace tamagotchi_task.Domain.Entities
{
    public class Animal : DomainEntity
    {
        [Required(ErrorMessage = "Сhoose the animal!")]
        [Display(Name = "Animal")]
        public string Image { get; set; }
        public Avatar Avatar { get; set; }
    }
}