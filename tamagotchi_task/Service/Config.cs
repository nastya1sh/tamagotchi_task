namespace tamagotchi_task.Service
{
    public class Config //Вспомогательный класс, откуда мы берём информацию о сайте
    {
        //Эти свойства заполняются в appsettings.json
        public static string ConnectionString { get; set; }
        public static string SiteName { get; set;}
        //Можно что-то ещё добавить
    }
}
