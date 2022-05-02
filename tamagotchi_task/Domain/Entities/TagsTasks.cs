namespace tamagotchi_task.Domain.Entities
{
    public class TagsTasks : DomainEntity
    {
        public List<CharacterTask> CharacterTasks { get; set; } = new List<CharacterTask>();
        public List<Tags> Tags { get; set; } = new List<Tags>();
    }
}
