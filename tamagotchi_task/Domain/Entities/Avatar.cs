namespace tamagotchi_task.Domain.Entities
{
    public class Avatar : DomainEntity
    {
        //Скорее всего, эту таблицу имеет смысл убрать. Посмотрим по мере реализации.
        public Character Characters { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Fur> Furs { get; set; }
        public List<Accessories> Accessories { get; set; }
        public List<Wallpaper> Wallpapers { get; set; }

    }
}
