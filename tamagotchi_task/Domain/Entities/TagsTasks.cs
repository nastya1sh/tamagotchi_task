namespace tamagotchi_task.Domain.Entities
{
    public class TagsTasks : DomainEntity
    {
        public List<CharacterTask> CharacterTasks { get; set; }
        public List<Tags> Tags { get; set; }
    }
}
