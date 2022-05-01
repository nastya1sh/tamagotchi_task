namespace tamagotchi_task.Domain.Entities
{
    public class Accessories : DomainEntity
    {
        [Required]
        [Display(Name = "Аксесуар")]
        public string Image { get; set; }
        public Avatar Avatar { get; set; }
    }
}
