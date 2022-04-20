using System.ComponentModel.DataAnnotations;

namespace tamagotchi_task.Domain
{
    public class User: DomainEntity
    {
        [Required]
        public string Login { get; set; } //Зачем нужны поля, когда есть свойства?

        [Required]
        public string Password { get; set; }
    }
}
