using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace tamagotchi_task.Domain
{
    //Всё перечисленное ниже может не сработать, если не установить специальные расширения
    //Этот класс - дар Microsoft и заодно главный элемент в EF Core
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Создание таблиц
       
        public DbSet<Chat> Chats { get; set; }     
        public DbSet<Message> Messages { get; set; }     
        public DbSet<Character> Characters { get; set; }
        public DbSet<Forage> Forages { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }
        public DbSet<ForageCharacter> ForageCharacters { get; set; }
        public DbSet<PotionCharacter> PotionCharacters { get; set; }
        public DbSet<ToyCharacter> ToyCharacters { get; set; }
        public DbSet<Potions> Potions { get; set; }
        public DbSet<Showcase> Showcases { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Toys> Toys { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<CharacterTask> CharacterTasks { get; set; }
       
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Chat>().HasData(new Chat
            {
                Id = new Guid("0FA0052E-B8FB-42F6-B8BA-BF205FDE5EFC"),
                Name = "Global Chat", //Нужна для удобного поиска при создании нового пользователя
                MyUsers = new List<MyUser>(),
                Messages = new List<Message>()
            });

            #region Хардкод сложностей
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = new Guid("2eb950a4-b039-47e8-b5b8-9bb596ba6ce5"),
                Name = "Low"
            });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = new Guid("a2b7f2b0-2f30-4d7c-a4b5-0c812c677f18"),
                Name = "Medium"
            });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = new Guid("f5b00802-6555-4fc5-af89-4532b09bc07a"),
                Name = "High"
            });
            #endregion

            #region Хардкод тэгов
            modelBuilder.Entity<Tags>().HasData(new Tags
            {
                Id = new Guid("c21d9094-7381-45da-96e7-41a8d434bb0f"),
                Name = "Sport"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags
            {
                Id = new Guid("6b6a0ac9-e83b-4856-8119-b44281df595f"),
                Name = "Study"
            });
            modelBuilder.Entity<Tags>().HasData(new Tags
            {
                Id = new Guid("dfe35ad9-f02f-4c68-96a4-29f5428d47e8"),
                Name = "Home Chores"
            });
            #endregion

            #region Промежуточные таблицы
            modelBuilder.Entity<ForageCharacter>().HasData(new ForageCharacter
            {
                Id = new Guid("597d8c8c-7295-4315-8e60-57286dc85683")
            });
            modelBuilder.Entity<PotionCharacter>().HasData(new PotionCharacter
            {
                Id = new Guid("357afc1a-e414-498e-84ed-60281751ae36")
            });
            modelBuilder.Entity<ToyCharacter>().HasData(new ToyCharacter
            {
                Id = new Guid("ce3ce8b7-e4a8-4231-b569-7dbf558a6033")
            });
            #endregion
        }
    }
}
