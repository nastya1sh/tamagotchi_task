namespace tamagotchi_task.Domain.Entities
{
    public class Tags
    { public string Tag { get; set; }
        public TagsTasks TagsTasks { get; set; } //Ссылка на таблицу TagsTask
    }
}
