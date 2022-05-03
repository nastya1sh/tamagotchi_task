using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tamagotchi_task.Domain
{
    //Всё перечисленное ниже может не сработать, если не установить специальные расширения
    //Этот класс - дар Microsoft и заодно главный элемент в EF Core
    public partial class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Forage> Forages { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }
        public DbSet<ForageCharacter> ForageCharacters { get; set; }
        public DbSet<PotionCharacter> PotionCharacters { get; set; }
        public DbSet<Potions> Potions { get; set; }
        public DbSet<Showcase> Showcases { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagsTasks> TagsTasks { get; set; }
        public DbSet<ToyCharacter> ToyCharacters{ get; set; }
        public DbSet<Toys> Toys { get; set; }
       


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
        }
    }
}
