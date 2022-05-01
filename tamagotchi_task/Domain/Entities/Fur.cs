namespace tamagotchi_task.Domain.Entities
{
    public class Fur: DomainEntity
    {
        [Required(ErrorMessage = "Выберите шерсть персонажу!")]
        [Display(Name = "Шерсть")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Выберите тип шерсти!")]
        [Display(Name = "Тип шерсти")]
        public string Type { get; set; }
        public Avatar Avatar { get; set; }
    }
}
