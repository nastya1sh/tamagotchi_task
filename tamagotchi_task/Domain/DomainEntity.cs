namespace tamagotchi_task.Domain
{
    public abstract class DomainEntity
    {
        [Required]
        [Key] //Id по стандарту является ключом, но я на всякий случай это пока оставлю
        public Guid Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
    }
}
