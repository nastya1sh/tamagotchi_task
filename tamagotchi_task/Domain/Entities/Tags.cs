namespace tamagotchi_task.Domain.Entities
{
    public class Tags : DomainEntity
    {
        public string Tag { get; set; }

        public TagsTasks TagsTasks { get; set; } //Ссылка на таблицу TagsTask
    }
}
