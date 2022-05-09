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
        public DbSet<Toys> Toys { get; set; }
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

            #region Дефолтные значения Character
            modelBuilder.Entity<Character>().Property(b => b.Intellect).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.Strength).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.Money).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.XP).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.Level).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.HP).HasDefaultValue(6);
            modelBuilder.Entity<Character>().Property(b => b.AnimalImage).HasDefaultValue("/img/catAnimal.png");
            modelBuilder.Entity<Character>().Property(b => b.ColorImage).HasDefaultValue("/img/cat0.png");
            modelBuilder.Entity<Character>().Property(b => b.WallpaperImage).HasDefaultValue("/img/circle.png");
            #endregion
            #region Дефолтные значения AuxTables
            modelBuilder.Entity<ForageCharacter>().Property(b => b.Amount).HasDefaultValue(0);
            modelBuilder.Entity<PotionCharacter>().Property(b => b.Amount).HasDefaultValue(0);
            modelBuilder.Entity<ToyCharacter>().Property(b => b.Amount).HasDefaultValue(0);
            #endregion
        }
    }
}
